using MediatR;
using StudentApp.Api.DB.Data;
using StudentApp.Api.DB.Models;
using StudentApp.Api.DB.Repository.Command;
using StudentApp.Api.DB.Repository.Responses;
using StudentApp.Api.Models.Request;
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
            public Handler(IDataRepository dataRepo)
            {
                _dataRepo = dataRepo;
            }
            public async Task<Response> Handle(InsertCommand request, CancellationToken cancellationToken)
            {

                _dataRepo.Add(request.Student);
                if (await _dataRepo.Save())
                {
                    return new Response(request.Student);
                }
                return new Response(request.Student, "An error has occurred");
            }
        }
    }
}
