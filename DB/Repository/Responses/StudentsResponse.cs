using StudentApp.Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Api.DB.Repository.Responses
{
    public class StudentsResponse
    {
        public List<Student> Students { get; set; }
        public StudentsResponse(List<Student> students)
        {
            Students = students;
        }
    }
}
