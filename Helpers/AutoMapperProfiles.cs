using AutoMapper;
using StudentApp.Api.DB.Models;
using StudentApp.Api.Models.Request;

namespace PolizaSeguro.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Domain to Dto
            CreateMap<Student, StudentRequest>();

            // Dto to Domain
            CreateMap<StudentRequest, Student>();        
        }
    }
}