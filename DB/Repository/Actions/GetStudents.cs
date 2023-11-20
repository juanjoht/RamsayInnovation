using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetStudents
    {       
        public class Handler : IRequestHandler<GetCommand,StudentsResponse>
        {
            private readonly IDataRepository _dataRepo;

            public Handler(IDataRepository dataRepo)
            {
                _dataRepo = dataRepo;
            }

            public async Task<StudentsResponse> Handle(GetCommand request, CancellationToken cancellationToken)
            {
                var students = await _dataRepo.GetStudents();
                return new StudentsResponse(students.ToList());
            }
        }
    }
}
