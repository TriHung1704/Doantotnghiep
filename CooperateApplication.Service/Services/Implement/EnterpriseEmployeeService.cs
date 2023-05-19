using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;
using static CooperateApplication.Repositories.Enums.CooperateEnums;
using static CooperateApplication.Service.Enum.Enum;
using EnterpriseFacility = CooperateApplication.Repositories.Entities.EnterpriseFacility;
using EnterpriseField = CooperateApplication.Repositories.Entities.EnterpriseField;

namespace CooperateApplication.Service.Services
{
    public class EnterpriseEmployeeService : BaseService<EnterpriseEmployee>, IEnterpriseEmployeeService
    {
        public readonly IRepository<EnterpriseEmployee> _repository;
        public readonly IRepository<EnterpriseFacility> _facility;
        public readonly IRepository<EnterpriseField> _field;
        public readonly IRepository<Enterprise> _enterprise;
        public readonly IRepository<User> _userRepository;
        public readonly IRepository<UserRole> _userRoleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EnterpriseEmployeeService(IRepository<EnterpriseEmployee> repository
            , IHttpContextAccessor httpContextAccessor
            , IRepository<User> userRepository,
            IRepository<UserRole> userRoleRepository,
            IRepository<Enterprise> enterprise,
            IRepository<EnterpriseFacility> facility,
            IRepository<EnterpriseField> field) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _enterprise = enterprise;
            _facility = facility;
            _field = field;
        }

        public async Task<bool> CreateEmployee(UserRequest userRequest)
        {
            try
            {
                var user = userRequest.ToEntity();
                user.UserType = UserTypeName.Employee;
                user.Password = BCrypt.Net.BCrypt.HashPassword("1234");
                var users = await _userRepository.GetAll();
                if (users.Any(x=>x.UserName == user.UserName))

                {
                    return false;
                }
                var userResponse = await _userRepository.Insert(user);

                var userRole = new UserRole() { UserId = userResponse.Id, RoleId = (int)userRequest.EmployeeType };
                await _userRoleRepository.Insert(userRole);

                var employeeEnterprise = new EnterpriseEmployee() { UserId = userResponse.Id, EnterpriseId = GetUserCurent().EnterpriseId };
                await _repository.Insert(employeeEnterprise);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return true;
        }

        public async Task<bool> CreateEnterprise(EnterpriseModel enterpriseModel)
        {
            try
            {
                var users = await _userRepository.GetAll();
                if (users.Any(x => x.UserName == enterpriseModel.UserName))
                {
                    return false;
                }

                var enterprise = await _enterprise.Insert(new()
                {
                    Name = enterpriseModel.Name,
                    Email = enterpriseModel.Email,
                    Phone = enterpriseModel.Phone,
                    CorporateTaxCode = enterpriseModel.CorporateTaxCode,
                    Description = enterpriseModel.Description,
                    Website = enterpriseModel.Website,
                    Director = enterpriseModel.Director,
                    ImageLogo = enterpriseModel.ImageLogo,
                    Status = true
                });
                foreach (var item in enterpriseModel.FieldCompanyList)
                {
                    await _field.Insert(new()
                    {
                        Name = item.Name,
                        EnterpriseId = enterprise.Id
                    });
                }

                foreach (var item in enterpriseModel.AddressCompanyList)
                {
                    await _facility.Insert(new()
                    {
                        DetailAddress = item.DetailAddress,
                        EnterpriseId = enterprise.Id
                    });
                }
                var userResponse = await _userRepository.Insert(new()
                {
                    UserName = enterpriseModel.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    UserType = UserTypeName.Employee,
                    Email = enterpriseModel.Email,
                    Phone = enterpriseModel.Phone,
                    Avatar = enterpriseModel.ImageLogo,
                    FullName = enterprise.Name
                });

                var userRole = new UserRole() { UserId = userResponse.Id, RoleId = (int)EmployeeType.EmployeeAdmin };
                await _userRoleRepository.Insert(userRole);

                var employeeEnterprise = new EnterpriseEmployee() { UserId = userResponse.Id, EnterpriseId = enterprise.Id };
                await _repository.Insert(employeeEnterprise);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return true;
        }

        public async Task<List<UserModel>> GetEmployeeAsync()
        {
            try
            {
                var userCurent = GetUserCurent();
                var employeeEnterprises = (await _repository.GetQueryable()).Where(x => x.EnterpriseId == userCurent.EnterpriseId).ToList();
                var users = new List<UserModel>();
                foreach (var userId in employeeEnterprises.Select(x=>x.UserId))
                {
                    var user = await _userRepository.GetById(userId);
                    users.Add(user.ToModel());
                }
                return users;
            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<EnterpriseEmployee> GetEmployeeByUserId(int userId)
        {
            var enterpriseEmployees = await _repository.GetQueryable();
            var entE = enterpriseEmployees.Where(x => x.UserId == userId).FirstOrDefault();
            return entE;
        }

        public async Task<EnterpriseModel> GetEnterprisesAsync(int id)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var enterprise = (await _enterprise.GetById(id));

                var enterpriseModel = new EnterpriseModel();
                var userEmployee = (await _repository.GetQueryable()).FirstOrDefault(x => x.EnterpriseId == enterprise.Id);
                var facility = (await _facility.GetQueryable()).Where(x=>x.EnterpriseId == enterprise.Id);
                var field = (await _field.GetQueryable()).Where(x => x.EnterpriseId == enterprise.Id);
                enterpriseModel = (new()
                {
                    Id = enterprise.Id,
                    Name = enterprise.Name,
                    Description = enterprise.Description,
                    Email = enterprise.Email,
                    Phone = enterprise.Phone,
                    Website = enterprise.Website,
                    ImageLogo = enterprise.ImageLogo,
                    Status = enterprise.Status,
                    UserName = (await _userRepository.GetById(userEmployee.UserId)).UserName,
                    UserId = userEmployee.UserId, 
                    Director = enterprise.Director,
                    CorporateTaxCode = enterprise.CorporateTaxCode,
                    AddressCompanyList = facility.Select(x=> new Model.EnterpriseFacility { Id = x.Id, DetailAddress = x.DetailAddress}).ToList(),
                    FieldCompanyList = field.Select(x=> new Model.EnterpriseField { Id = x.Id, Name = x.Name}).ToList(),
                });
                return enterpriseModel;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<EnterpriseModels> GetListEnterprisesAsync(int page)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var enterprises = (await _enterprise.GetQueryable(includeDeleted: true)).ToList();
                int limit = 20;
                int total = enterprises.Count();
                int start = (int)(page - 1) * limit;
                var enterprisesPagination = enterprises.Skip(start).Take(limit);

                var enterpriseModels = new EnterpriseModels();
                enterpriseModels.EnterpriseList = new List<EnterpriseModel>();
                foreach (var enterprise in enterprises)
                {
                    var userEmployee = (await _repository.GetQueryable()).Where(x => x.EnterpriseId == enterprise.Id);
                    var userAdminId = 0;
                    foreach(var item in userEmployee)
                    {
                        var userRole = (await _userRoleRepository.GetQueryable()).FirstOrDefault(x => x.UserId == item.UserId);
                        if (userRole.RoleId == (int)EmployeeType.EmployeeAdmin)
                        {
                            userAdminId = userRole.UserId;
                        }
                    };
                    
                    enterpriseModels.EnterpriseList.Add(new()
                    {
                        Id = enterprise.Id,
                        Name = enterprise.Name,
                        Description = enterprise.Description,
                        Email = enterprise.Email,
                        Phone = enterprise.Phone,
                        Website = enterprise.Website,
                        ImageLogo = enterprise.ImageLogo,
                        Status = enterprise.Status,
                        UserName = (await _userRepository.GetById(userAdminId))?.UserName,
                        UserId = userAdminId
                    });
                }
                enterpriseModels.Total = NumberPage(total, limit);
                return enterpriseModels;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> LockEmployee(bool isLock, int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null) { return false; }
                user.IsDeleted = isLock;
                await _userRepository.Update(user);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> LockEnterprise(bool isLock, int enterpriseId)
        {
            var user = GetUserCurent();
            if (user == null) { throw new NotImplementedException(); }
            try
            {
                var enterprise = await _enterprise.GetById(enterpriseId);
                if (enterprise == null) { return false; }
                enterprise.Status = isLock;
                await _enterprise.Update(enterprise);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> UpdateEnterprise(EnterpriseModel enterpriseModel)
        {
            try
            {
                
                var users = enterpriseModel.UserId == 0 ? await _userRepository.GetAll() : (await _userRepository.GetQueryable()).Where(x=>x.Id != enterpriseModel.UserId).ToList();
                if (users.Any(x => x.UserName == enterpriseModel.UserName))
                {
                    return false;
                }

                var enterprise = await _enterprise.Update(new()
                {
                    Id = enterpriseModel.Id,
                    Name = enterpriseModel.Name,
                    Email = enterpriseModel.Email,
                    Phone = enterpriseModel.Phone,
                    CorporateTaxCode = enterpriseModel.CorporateTaxCode,
                    Description = enterpriseModel.Description,
                    Website = enterpriseModel.Website,
                    Director = enterpriseModel.Director,
                    ImageLogo = enterpriseModel.ImageLogo,
                    Status = true,
                });
                //Delete current
                var currentFields = (await _field.GetQueryable()).Where(x => x.EnterpriseId == enterprise.Id);
                foreach(var item in currentFields)
                {
                    await _field.Delete(item.Id);
                }
                var currentFacilitys = (await _facility.GetQueryable()).Where(x => x.EnterpriseId == enterprise.Id);
                foreach(var item in currentFacilitys)
                {
                    await _facility.Delete(item.Id);
                }
                //Insert new data
                foreach (var item in enterpriseModel.FieldCompanyList)
                {
                    await _field.Insert(new()
                    {
                        Name = item.Name,
                        EnterpriseId = enterprise.Id
                    });
                }

                foreach (var item in enterpriseModel.AddressCompanyList)
                {
                    await _facility.Insert(new()
                    {
                        DetailAddress = item.DetailAddress,
                        EnterpriseId = enterprise.Id
                    });
                }

                var userResponse = await _userRepository.Update(new()
                {
                    Id = enterpriseModel.UserId,
                    UserName = enterpriseModel.UserName,
                    Password = (await _userRepository.GetById(enterpriseModel.UserId)).Password,
                    UserType = UserTypeName.Employee,
                    Email = enterpriseModel.Email,
                    Phone = enterpriseModel.Phone,
                    Avatar = enterpriseModel.ImageLogo,
                    FullName = enterprise.Name
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
            return true;
        }

    }
}
