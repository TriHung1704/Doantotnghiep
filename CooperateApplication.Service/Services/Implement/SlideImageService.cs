using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public class SlideImageService : BaseService<SlideImage>, ISlideImageService
    {
        public readonly IRepository<SlideImage> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SlideImageService(IRepository<SlideImage> repository, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> EnableSlide(int id)
        {
            var query = (await _repository.GetQueryable());
            var slideEnabled = query.Where(x => x.IsEnable == true);
            foreach (var slide in slideEnabled)
            {
                slide.IsEnable = false;
                await _repository.Update(slide);
            }

            var slideCurrent = query.Where(x => x.Id == id).FirstOrDefault();
            slideCurrent.IsEnable = true;
            await _repository.Update(slideCurrent);
            return true;
        }

        public async Task<List<SlideImageModel>> GetSlideFile()
        {
            var slideFile = await _repository.GetAll();
            var slideFileList = new List<SlideImageModel>();
            slideFile.ForEach(x => slideFileList.Add(new SlideImageModel() { Id = x.Id, Image= x.Image, IsEnable = x.IsEnable}));
            return slideFileList;
        }
    }
}
