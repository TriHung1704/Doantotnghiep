using CooperateApplication.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class MajorsModel
    {
        public int Id { get; set; }
        public string MajorsName { get; set; }
    }
    public static class MajorsModelEmm
    {
        public static MajorsModel ToModel(this Majors majors)
        {
            MajorsModel majorsModel = new MajorsModel();
            majorsModel.Id = majors.Id;
            majorsModel.MajorsName = majors.Name;
            return majorsModel;
        }
        public static List<MajorsModel> ToListModel(this List<Majors> postModels)
        {
            return postModels.Select(x => x.ToModel()).ToList();
        }
    }
}
