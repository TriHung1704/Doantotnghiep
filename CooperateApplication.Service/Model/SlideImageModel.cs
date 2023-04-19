using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class SlideImageModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsEnable { get; set; }  
    }
    public static class SlideImageModelEmm
    {
        public static SlideImage ToEntities(this SlideImageModel slideImageModel)
        {
            SlideImage slideImage = new SlideImage();
            slideImage.Id = slideImageModel.Id;
            slideImage.Image = slideImageModel.Image;
            slideImage.IsEnable = slideImageModel.IsEnable;
            return slideImage;
        }
    }
}
