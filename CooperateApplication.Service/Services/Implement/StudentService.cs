using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Google.Protobuf.Collections;
using IronXL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace CooperateApplication.Service.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public readonly IRepository<User> _userRepository;
        public readonly IRepository<Student> _studentRepository;
        public readonly IRepository<PostStudent> _recruitmentStudent;
        public readonly IRepository<SenimarStudent> _senimarStudent;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StudentService(IRepository<Student> studentRepository,
            IHttpContextAccessor httpContextAccessor,
            IRepository<User> userRepository,
            IRepository<PostStudent> recruitmentStudent,
            IRepository<SenimarStudent> senimarStudent) : base(studentRepository, httpContextAccessor)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _recruitmentStudent = recruitmentStudent;
            _senimarStudent = senimarStudent;
        }

        public async Task<string> CvStudent()
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x => x.UserId == user.Id);
                return student.FileCV;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<StudentModelReponse> GetStudentAsync(int page)
        {
            try
            {
                var student = await _studentRepository.GetAll(x => x.User, x => x.Class);

                int limit = 100;
                int total = student.Count();
                int start = (int)(page - 1) * limit;
                var studentsPagination = student.Skip(start).Take(limit);

                var studentModelReponse = new StudentModelReponse();
                studentModelReponse.StudentModels = new List<StudentModel>();

                foreach (var st in studentsPagination)
                {
                    var studentModel = new StudentModel
                    {
                        Id = st.UserId,
                        UserName = st.User.UserName,
                        FullName = st.User.FullName,
                        ClassName = st.Class.Name,
                        IsDeleted = st.User.IsDeleted,
                    };
                    studentModelReponse.StudentModels.Add(studentModel);
                }
                studentModelReponse.Total = NumberPage(total, limit);
                return studentModelReponse;
            }
            catch
            {
                throw new NotImplementedException();
            }
           
        }

        public async Task<bool> LockStudent(bool isLock, int userId)
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

        public async Task<bool> UploadCvStudent(string file)
        {
            try
            {
                var user =  GetUserCurent();
                if (user == null) { return false; }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x=>x.UserId == user.Id);
                student.FileCV = file;
                await _studentRepository.Update(student);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        
        public async Task<bool> RecruitmentCV(int id)
        {
            try
            {
                var user =  GetUserCurent();
                if (user == null) { return false; }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x=>x.UserId == user.Id);

                var hasrecruitmentCV = (await _recruitmentStudent.GetQueryable()).Any(x => x.PostId == id && x.StudentId == student.Id);
                if (hasrecruitmentCV)
                {
                    return false;
                }
                var recruitmentCV = new PostStudent
                {
                    StudentId = student.Id,
                    PostId = id
                };
                await _recruitmentStudent.Insert(recruitmentCV);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        
        public async Task<PostStudentModels> GetPostStudentAsync(int page)
        {
            try
            {
                var user =  GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x=>x.UserId == user.Id);

                var recruitmentCV = (await _recruitmentStudent.GetAll(x=>x.Post,y=>y.Student)).Where(x => x.StudentId == student.Id);
                int limit = 10;
                int total = recruitmentCV.Count();
                int start = (int)(page - 1) * limit;
                var postsPagination = recruitmentCV.Skip(start).Take(limit);

                var postStudents = new PostStudentModels();
                postStudents.PostList = new List<PostStudentModel>();
                foreach (var item in recruitmentCV)
                {
                    postStudents.PostList.Add(new()
                    {
                        Id = item.PostId,
                        Title = item.Post.Title,
                        Description = item.Post.Description,
                        Image = item.Post.Image,
                        ExpireTime = item.Post.ExpireTime,
                        IsAccept = item.IsAccept,
                        Type = (Enum.Enum.PostTypeName)item.Post.Type
                    });
                }
                postStudents.Total = NumberPage(total, limit);
                return postStudents;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> CancelCV(int id)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { return false; }
                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x => x.UserId == user.Id);
                if (student == null) { return false; }

                var recruitmentCV = (await _recruitmentStudent.GetQueryable()).FirstOrDefault(x => x.PostId == id && x.StudentId == student.Id);
                if (recruitmentCV != null)
                {
                    await _recruitmentStudent.Delete(recruitmentCV.Id);
                }
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> SenimarAttend(int id)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { return false; }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x => x.UserId == user.Id);

                var hasSenimarStudent = (await _senimarStudent.GetQueryable()).Any(x => x.PostId == id && x.StudentId == student.Id);
                if (hasSenimarStudent)
                {
                    return false;
                }
                var senimarStudent = new SenimarStudent
                {
                    StudentId = student.Id,
                    PostId = id
                };
                await _senimarStudent.Insert(senimarStudent);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> CancelSenimarAttend(int id)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { return false; }
                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x => x.UserId == user.Id);
                if (student == null) { return false; }

                var senimarStudent = (await _senimarStudent.GetQueryable()).FirstOrDefault(x => x.PostId == id && x.StudentId == student.Id);
                if (senimarStudent != null)
                {
                    await _senimarStudent.Delete(senimarStudent.Id);
                }
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<SenimarStudentModels> GetSenimarAttendAsync(int page)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var student = (await _studentRepository.GetQueryable()).FirstOrDefault(x => x.UserId == user.Id);

                var senimarStudent = (await _senimarStudent.GetAll(x => x.Post, y => y.Student)).Where(x => x.StudentId == student.Id);
                int limit = 10;
                int total = senimarStudent.Count();
                int start = (int)(page - 1) * limit;
                var postsPagination = senimarStudent.Skip(start).Take(limit);

                var senimarStudents = new SenimarStudentModels();
                senimarStudents.PostList = new List<SenimarStudentModel>();
                foreach (var item in senimarStudent)
                {
                    senimarStudents.PostList.Add(new()
                    {
                        Id = item.PostId,
                        Title = item.Post.Title,
                        Description = item.Post.Description,
                        Image = item.Post.Image,
                        ExpireTime = item.Post.ExpireTime,
                        IsExpire = DateTime.Now > item.Post.ExpireTime,
                        Type = (Enum.Enum.PostTypeName)item.Post.Type
                    });
                }
                senimarStudents.Total = NumberPage(total, limit);
                return senimarStudents;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
