using CooperateApplication.Repositories.Context;
using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using IronXL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CooperateApplication.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public readonly IRepository<User> _repository;
        public readonly IRepository<ClassStudent> _classStudent;
        public readonly IRepository<Student> _student;
        public readonly IRepository<UserRole> _userRolerepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UserService(IRepository<User> repository, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment, IRepository<ClassStudent> classStudent = null, IRepository<Student> student = null, IRepository<UserRole> userRolerepository = null) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _classStudent = classStudent;
            _student = student;
            _userRolerepository = userRolerepository;
        }

        public async Task<bool> CreateUser(string fileUrl)
        {
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, fileUrl);
                WorkBook workBook = WorkBook.Load(path);
                WorkSheet workSheet = workBook.GetWorkSheet("Sheet1");
                //Iterate through all the cells
                var users = new List<User>();
                for (var i = 2; i <= 100000; i++)
                {
                    //Get the range from A-F
                    var range = workSheet[$"A{i}:F{i}"].ToList();
                    if (string.IsNullOrEmpty(range[0]?.Value.ToString()))
                    {
                        break;
                    }
                    
                    var user = new User
                    {
                        UserName = range[0]?.Value.ToString(),
                        Phone = range[1].Value?.ToString(),
                        FullName = range[2].Value?.ToString(),
                        Gender = (range[3].Value.ToString() == "Name" ? true : false),
                        ProvinceAddress = range[4].Value?.ToString(),
                        Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                        UserType = Repositories.Enums.CooperateEnums.UserTypeName.Student
                    };
                    var hasStudent = (await GetQueryable()).Any(x => x.UserName == user.UserName);
                    
                    if (!hasStudent)
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<CooperationDbContext>();
                        optionsBuilder.UseMySQL("server=localhost; port=3306; database=CooperationDb; user=root; password=1234");

                        using (var context = new CooperationDbContext(optionsBuilder.Options))
                        {
                            using (var dbContextTransaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    //Insert User
                                    //var userResult = await Insert(user);
                                    context.Users.Add(user);
                                    await context.SaveChangesAsync();

                                    //insert Student
                                    var className = range[5].Value?.ToString();
                                    var classId = (await _classStudent.GetQueryable()).Where(x => x.Name == className).FirstOrDefault().Id;
                                    var classUser = new Student
                                    {
                                        UserId = user.Id,
                                        ClassId = classId,
                                        CreateAt = DateTime.Now,
                                    };
                                    //await _student.Insert(classUser);
                                    context.Students.Add(classUser);
                                    await context.SaveChangesAsync();

                                    //insert user role
                                    var userRole = new UserRole
                                    {
                                        RoleId = 5,//Role Student ID
                                        UserId = user.Id
                                    };
                                    //await _userRolerepository.Insert(userRole);
                                    context.UserRoles.Add(userRole);
                                    await context.SaveChangesAsync();

                                    dbContextTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    dbContextTransaction.Rollback();
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
