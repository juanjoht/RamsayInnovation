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
    public class GetStudentsById
    {
        public class Handler : IRequestHandler<GetByIdCommand, Response>
        {
            private readonly IDataRepository _dataRepo;
            private readonly IMapper _mapper;

            public Handler(IDataRepository dataRepo, IMapper mapper)
            {
                _dataRepo = dataRepo;
                _mapper = mapper;
            }
            public async Task<Response> Handle(GetByIdCommand request, CancellationToken cancellationToken)
            {
                var student = await _dataRepo.GetById(request.StudentId);
                var studentResult = _mapper.Map<StudentResponse>(student);
                return new Response(studentResult);
            }
        }
    }
}
