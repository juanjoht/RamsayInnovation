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
    public class DeleteStudent
    {
        public class Handler : IRequestHandler<DeleteCommand, Response>
        {
            private readonly IDataRepository _dataRepo;
            private readonly IMapper _mapper;

            public Handler(IDataRepository dataRepo, IMapper mapper)
            {
                _dataRepo = dataRepo;
                _mapper = mapper;
            }
           

            public async Task<Response> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var studentExist = await _dataRepo.GetById(request.StudentId);
                if (studentExist == null)
                {
                    return new Response(null, "No student exists");
                }
                else
                {
                    _dataRepo.Delete(studentExist);
                }
                if (await _dataRepo.Save())
                {
                    var student = _mapper.Map<StudentResponse>(studentExist);
                    return new Response(student);
                }
                return new Response(null, "An error has occurred");
            }
        }
    }
}
