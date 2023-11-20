using AutoMapper;
using StudentApp.Api.DB.Models;
using StudentApp.Api.Models.Request;
using StudentApp.Api.Models.Response;

namespace PolizaSeguro.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Domain to Dto
            CreateMap<Student, StudentRequest>();
            CreateMap<Student, StudentResponse>();

            // Dto to Domain
            CreateMap<StudentRequest, Student>();
            CreateMap<StudentResponse,Student>();
        }
    }
}