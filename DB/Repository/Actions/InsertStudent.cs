using AutoMapper;
using MediatR;
using StudentApp.Api.DB.Data;
using StudentApp.Api.DB.Models;
using StudentApp.Api.DB.Repository.Command;
using StudentApp.Api.DB.Repository.Responses;
using StudentApp.Api.Models.Request;
using StudentApp.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Actions
{
    public class InsertStudent
    {
        //handler
        public class Handler : IRequestHandler<InsertCommand, Response>
        {
            private readonly IDataRepository _dataRepo;
            private readonly IMapper _mapper;
            public Handler(IDataRepository dataRepo, IMapper mapper)
            {
                _dataRepo = dataRepo;
                _mapper = mapper;
            }
            public async Task<Response> Handle(InsertCommand request, CancellationToken cancellationToken)
            {

                _dataRepo.Add(request.Student);
                var studentResult = _mapper.Map<StudentResponse>(request.Student);
                if (await _dataRepo.Save())
                {
                    return new Response(studentResult);
                }
                return new Response(studentResult, "An error has occurred");
            }
        }
    }
}
