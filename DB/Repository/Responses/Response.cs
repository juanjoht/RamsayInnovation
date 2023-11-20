using StudentApp.Api.DB.Models;
using StudentApp.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Responses
{
    public class Response
    {
        public StudentResponse Student { get; set; }
        public string Error { get; set; }
        public Response(StudentResponse student, string error = null)
        {
            Student = student;
            Error = error;
        }
    }
}
