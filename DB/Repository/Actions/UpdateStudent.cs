using AutoMapper;
using MediatR;
using StudentApp.Api.DB.Data;
using StudentApp.Api.DB.Repository.Command;
using StudentApp.Api.DB.Repository.Responses;
using StudentApp.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Actions
{
    public class UpdateStudent
    {
        public class Handler : IRequestHandler<UpdateCommand, Response>
        {
            private readonly IDataRepository _dataRepo;
            private readonly IMapper _mapper;

            public Handler(IDataRepository dataRepo, IMapper mapper)
            {
                _dataRepo = dataRepo;
                _mapper = mapper;
            }
            public async Task<Response> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<StudentResponse>(request.Student);
                var studentExist = await _dataRepo.GetById(request.Student.Id);
                if (studentExist == null)
                {
                    return new Response(student, "No student exists");
                }
                else
                {
                    studentExist.FirstName = request.Student.FirstName;
                    studentExist.LastName = request.Student.LastName;
                    studentExist.Username = request.Student.Username;
                    studentExist.Age = request.Student.Age;
                    studentExist.Career = request.Student.Career;
                    student = _mapper.Map<StudentResponse>(studentExist);
                }
                if (await _dataRepo.Save())
                {
                    return new Response(student);
                }
                return new Response(student, "An error has occurred");
            }
        }
    }
}
