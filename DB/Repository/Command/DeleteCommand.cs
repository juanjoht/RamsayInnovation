using MediatR;
using StudentApp.Api.DB.Models;
using StudentApp.Api.DB.Repository.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Command
{
    public class DeleteCommand : IRequest<Response>
    {
        public long StudentId { get; set; }
        public DeleteCommand(long id)
        {
            StudentId = id;
        }
    }
}
