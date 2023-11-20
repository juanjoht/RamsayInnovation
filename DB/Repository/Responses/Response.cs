using StudentApp.Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Responses
{
    public class Response
    {
        public Student Student { get; set; }
        public string Error { get; set; }
        public Response(Student student, string error = null)
        {
            Student = student;
            Error = error;
        }
    }
}
