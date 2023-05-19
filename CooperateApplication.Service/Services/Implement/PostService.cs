using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using static CooperateApplication.Service.Enum.Enum;
using EnterpriseFacility = CooperateApplication.Repositories.Entities.EnterpriseFacility;
using EnterpriseField = CooperateApplication.Repositories.Entities.EnterpriseField;

namespace CooperateApplication.Service.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        public readonly IRepository<Post> _repository;
        public readonly IRepository<Enterprise> _repositoryEnterprise;
        public readonly IRepository<EnterpriseFacility> _repositoryEnterpriseFacility;
        public readonly IRepository<EnterpriseField> _repositoryEnterpriseField;

        public readonly IRepository<PostMajors> _repositoryPostMajors;
        public readonly IRepository<Majors> _repositoryMajors;
        public readonly IRepository<PostStudent> _recruitmentStudent;
        public readonly IRepository<SenimarStudent> _senimarStudent;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IEnterpriseEmployeeService _enterpriseEmployeeService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PostService(IRepository<Post> repository,
            IRepository<PostMajors> repositoryPostMajors,
            IRepository<Majors> repositoryMajors,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IEnterpriseEmployeeService enterpriseEmployeeService,
            IHostingEnvironment hostingEnvironment,
            IRepository<Enterprise> repositoryEnterprise,
            IRepository<EnterpriseFacility> repositoryEnterpriseFacility,
            IRepository<EnterpriseField> repositoryEnterpriseField,
            IRepository<PostStudent> recruitmentStudent,
            IRepository<SenimarStudent> senimarStudent) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _repositoryPostMajors = repositoryPostMajors;
            _repositoryMajors = repositoryMajors;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _enterpriseEmployeeService = enterpriseEmployeeService;
            _hostingEnvironment = hostingEnvironment;
            _repositoryEnterprise = repositoryEnterprise;
            _repositoryEnterpriseFacility = repositoryEnterpriseFacility;
            _repositoryEnterpriseField = repositoryEnterpriseField;
            _recruitmentStudent = recruitmentStudent;
            _senimarStudent = senimarStudent;
        }

        public async Task<PostModels> PostOfEmployeeAsync(PostTypeName type, int page, int limit)
        {
            var userIdCurrent = GetUserCurent().Id;

            var posts = (await _repository.GetAll(x => x.Enterprise, y => y.User)).Where(x=>x.UserId == userIdCurrent && (int)x.Type == (int)type);

            var postModels = new PostModels();
            postModels.PostList = new List<PostModel>();
            foreach (var post in posts)
            {
                var queryPostMajors = (await _repositoryPostMajors.GetAll(pm => pm.Majors)).Where(x => x.PostId == post.Id).Select(x => x.Majors).ToList();
                var postModel = post.ToModel(queryPostMajors.ToListModel());

                var recruitmentCVNotSeen = (await _recruitmentStudent.GetQueryable()).Where(x => x.PostId == post.Id && x.Status == false);
                postModel.NumberNotification = recruitmentCVNotSeen.Count();

                postModels.PostList.Add(postModel);
            }
            int total = postModels.PostList.Count();
            int start = (page - 1) * limit;

            postModels.PostList = postModels.PostList.AsEnumerable().Skip(start).Take(limit).ToList();
            postModels.Total = NumberPage(total, limit);
            return postModels;
        }

        public async Task<PostModels> PostsAsync(PostSearchRequest postSearchRequest)
        {

            HashSet<int> majorsIds = postSearchRequest.MajorsIds?.Split(',')?.Select(Int32.Parse)?.ToHashSet();

            var posts = (await _repository.GetAll(x=>x.Enterprise, y=>y.User)).Where(x=>(int)x.Type == (int)postSearchRequest.Type && x.Status == true);

            if (!string.IsNullOrEmpty(postSearchRequest.Title))
            {
                posts = posts.Where(x => x.Title.ToLower().Contains(postSearchRequest.Title.ToLower()));
            }
            if (!string.IsNullOrEmpty(postSearchRequest.EnterpriseName))
            {
                posts = posts.Where(x => x.Enterprise.Name.ToLower().Contains(postSearchRequest.EnterpriseName.ToLower()));
            }
            var postModels = new PostModels();
            postModels.PostList = new List<PostModel>();
            foreach (var post in posts)
            {
                var queryPostMajors = (await _repositoryPostMajors.GetAll(pm => pm.Majors)).Where(x => x.PostId == post.Id).Select(x => x.Majors).ToList();
                if (majorsIds == null || queryPostMajors.Select(x=>x.Id).Intersect(majorsIds).Any())
                {
                    var postModel = post.ToModel(queryPostMajors.ToListModel());
                    postModels.PostList.Add(postModel);
                }
            }
            int total = postModels.PostList.Count();
            int start = (int)(postSearchRequest.Page - 1) * postSearchRequest.Limit;

            postModels.PostList = postModels.PostList.AsEnumerable().Skip(start).Take(postSearchRequest.Limit).ToList();
            postModels.Total = NumberPage(total, postSearchRequest.Limit);
            return postModels;
        }

        public async Task<PostModel> PostsAsync(int id)
        {
            var post = (await _repository.GetById(id, x => x.User, x => x.Enterprise));
            post.Image = post.Image;
            var queryPostMajors = (await _repositoryPostMajors.GetAll(pm => pm.Majors)).Where(x => x.PostId == post.Id).Select(x => x.Majors).ToList();
            var postModel = post.ToModel(queryPostMajors.ToListModel());
            postModel.MajorsIds = queryPostMajors.Select(x => x.Id).ToList();

            var enterpriseField = (await _repositoryEnterpriseField.GetQueryable()).Where(x=>x.EnterpriseId == post.EnterpriseId).ToList();
            var enterpriseFacility = (await _repositoryEnterpriseFacility.GetQueryable()).Where(x=>x.EnterpriseId == post.EnterpriseId).ToList();
            var listField = new List<Model.EnterpriseField>();
            enterpriseField.ForEach(x => listField.Add(new Model.EnterpriseField() { Id = x.Id, Name = x.Name }));
            var listFacility = new List<Model.EnterpriseFacility>();
            enterpriseFacility.ForEach(x => listFacility.Add(new Model.EnterpriseFacility() { Id = x.Id, DetailAddress = x.DetailAddress }));

            var enterprise = post.Enterprise;
            postModel.Enterprise = new EnterpriseModel() { 
                Id = enterprise.Id,
                ImageByte = !string.IsNullOrEmpty(enterprise.ImageLogo) ? File.ReadAllBytes(Path.Combine(_hostingEnvironment.WebRootPath, enterprise.ImageLogo)) : null,
                Name = enterprise.Name,
                Description = enterprise.Description,
                Email = enterprise.Email,
                Phone = enterprise.Phone,
                Website = enterprise.Website,
                ImageLogo = enterprise.ImageLogo,
            };

            postModel.EnterpriseFacilities = listFacility;
            postModel.EnterpriseFields = listField;

            var userCurrent = GetUserCurent();
            if (userCurrent != null)
            {
                var isSeen = (int)post.Type == 3 ? (await _senimarStudent.GetAll(x => x.Student.User)).Any(x => x.PostId == id && x.Student.User.Id == userCurrent.Id) : (await _recruitmentStudent.GetAll(x => x.Student.User)).Any(x => x.PostId == id && x.Student.User.Id == userCurrent.Id);
                postModel.IsSeen = isSeen;
            }
            
            return postModel;
        }

        public async Task<bool> RegisterPostsAsync(PostRequest postModel)
        {
            try
            {
                var userCurrent = GetUserCurent();

                var user = await _userService.GetById(userCurrent.Id);
                if (user == null)
                {
                    return false;
                }

                var ent = postModel.ToEntities();
                ent.UserId = userCurrent.Id;
                ent.EnterpriseId = userCurrent.EnterpriseId;

                var post = await _repository.Insert(ent);
                foreach (var item in postModel.MajorsIds)
                {
                    var postMajors = new PostMajors() { PostId = post.Id, MajorsId = item};
                    await _repositoryPostMajors.Insert(postMajors);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdatePostsAsync(PostRequest postModel)
        {
            try
            {
                var userCurrent = GetUserCurent();

                var user = await _userService.GetById(userCurrent.Id);
                if (user == null)
                {
                    return false;
                }

                var ent = postModel.ToEntities();
                ent.UserId = userCurrent.Id;
                ent.EnterpriseId = userCurrent.EnterpriseId;
                var post = await _repository.Update(ent);

                var majorsByPost = (await _repositoryPostMajors.GetQueryable()).Where(x => x.PostId == post.Id).ToList();
                //Remove majors not include list current
                foreach (var major in majorsByPost)
                {
                    if (!postModel.MajorsIds.Contains(major.MajorsId))
                    {
                        await _repositoryPostMajors.Delete(major.Id, true);
                    }
                }
                //Insert new majors(if any)
                foreach (var item in postModel.MajorsIds)
                {

                    var isExit = (await _repositoryPostMajors.GetQueryable()).Where(x => x.MajorsId == item && x.PostId == post.Id).Any();

                    if (!isExit)
                    {
                        var postMajors = new PostMajors() { PostId = post.Id, MajorsId = item };
                        await _repositoryPostMajors.Insert(postMajors);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PostStudentModels> GetPostStudentAsync(int postId, int page)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var recruitmentCV = (await _recruitmentStudent.GetAll(x => x.Post, y => y.Student, z => z.Student.User)).Where(x => x.PostId == postId);
                int limit = 20;
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
                        //Title = item.Post.Title,
                        //Description = item.Post.Description,
                        Image = item.Post.Image,
                        ExpireTime = item.Post.ExpireTime,
                        IsAccept = item.IsAccept,
                        StudentId = item.StudentId,
                        StudentName = item.Student.User.FullName,
                        StudentCode = item.Student.User.UserName,
                        FileCV = item.Student.FileCV,
                        Type = (Enum.Enum.PostTypeName)item.Post.Type
                    });
                }
                postStudents.Total = NumberPage(total, limit);
                postStudents.PostTitle = (await _repository.GetById(postId)).Title;
                return postStudents;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> AcceptedCVAsync(int postId, int studentId, bool isAccepted)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var recruitmentCV = (await _recruitmentStudent.GetQueryable()).FirstOrDefault(x => x.PostId == postId && x.StudentId == studentId);
                if (recruitmentCV == null)
                {
                    return false;
                }
                recruitmentCV.IsAccept = isAccepted;
                recruitmentCV.Status = true;
                await _recruitmentStudent.Update(recruitmentCV);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<SenimarStudentModels> GetSenimarStudentAsync(int postId, int page)
        {
            try
            {
                var user = GetUserCurent();
                if (user == null) { throw new NotImplementedException(); }

                var recruitmentCV = (await _senimarStudent.GetAll(x => x.Post, y => y.Student, z => z.Student.User)).Where(x => x.PostId == postId);
                int limit = 20;
                int total = recruitmentCV.Count();
                int start = (int)(page - 1) * limit;
                var postsPagination = recruitmentCV.Skip(start).Take(limit);

                var senimarStudents = new SenimarStudentModels();
                senimarStudents.PostList = new List<SenimarStudentModel>();
                foreach (var item in recruitmentCV)
                {
                    senimarStudents.PostList.Add(new()
                    {
                        Id = item.PostId,
                        //Title = item.Post.Title,
                        //Description = item.Post.Description,
                        Image = item.Post.Image,
                        ExpireTime = item.Post.ExpireTime,
                        StudentId = item.StudentId,
                        StudentName = item.Student.User.FullName,
                        StudentCode = item.Student.User.UserName,
                        Type = (Enum.Enum.PostTypeName)item.Post.Type
                    });
                }
                senimarStudents.Total = NumberPage(total, limit);
                senimarStudents.PostTitle = (await _repository.GetById(postId)).Title;
                return senimarStudents;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<PostModels> GetAllPostsAsync(int typeNumber, int page, int limit)
        {

            var posts = (await _repository.GetAll(x => x.Enterprise, y => y.User)).Where(x => (int)x.Type == typeNumber);

            var postModels = new PostModels();
            postModels.PostList = new List<PostModel>();
            int total = posts.Count();
            int start = (int)(page - 1) * limit;

            var postsPagination = posts.Skip(start).Take(limit);

            foreach (var post in postsPagination)
            {
                postModels.PostList.Add(new()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ExpireTime = post.ExpireTime,
                    CreateAt = post.CreateAt,
                    EnterpriseName = post.Enterprise.Name,
                    Status = post.Status,
                    Type = (PostTypeName)post.Type
                });
            }

            postModels.Total = NumberPage(total, limit);
            return postModels;
        }

        public async Task<bool> ConfirmPostAsync(int id, bool isConfirm)
        {
            try
            {
                var userCurrent = GetUserCurent();

                var user = await _userService.GetById(userCurrent.Id);
                if (user == null)
                {
                    return false;
                }

                var post = await _repository.GetById(id);
                post.Status = isConfirm;
                await Update(post);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
