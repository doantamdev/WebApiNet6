using AutoMapper;
using MyWebAppApi6.Data;
using MyWebAppApi6.Models;

namespace MyWebAppApi6.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Loai,LoaiModel>().ReverseMap();
        }
    }
}
