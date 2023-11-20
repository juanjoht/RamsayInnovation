using MediatR;
using StudentApp.Api.DB.Repository.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Command
{
    public class GetCommand : IRequest<StudentsResponse>
    {
    }
}
