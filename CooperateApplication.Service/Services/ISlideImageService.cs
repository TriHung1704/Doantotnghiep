using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;

namespace CooperateApplication.Service.Services
{
    public interface ISlideImageService : IBaseService<SlideImage>
    {
        Task<List<SlideImageModel>> GetSlideFile();
        Task<bool> EnableSlide(int id);
    }
}
