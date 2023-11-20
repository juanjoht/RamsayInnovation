using MediatR;
using StudentApp.Api.DB.Data;
using StudentApp.Api.DB.Repository.Command;
using StudentApp.Api.DB.Repository.Responses;
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

            public Handler(IDataRepository dataRepo)
            {
                _dataRepo = dataRepo;
            }
            public async Task<Response> Handle(GetByIdCommand request, CancellationToken cancellationToken)
            {
                var student = await _dataRepo.GetById(request.StudentId);
                return new Response(student);
            }
        }
    }
}
