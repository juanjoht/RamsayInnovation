using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Api.DB;
using StudentApp.Api.DB.Repository;
using StudentApp.Api.DB.Models;
using StudentApp.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Api.DB.Repository.Command;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace StudentApp.Api.Controllers
{    
    [ApiController]
    [Route("api/students/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;



        public StudentController(MainDbContext studentContext, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _mediator.Send(new GetCommand());
            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var student = await _mediator.Send(new GetByIdCommand(id));
            if (student.Student == null)
            {
                return NotFound();
            }
            return Ok(student.Student);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] StudentRequest studentRequest)
        {
            var student = _mapper.Map<Student>(studentRequest);
            var response = await _mediator.Send(new InsertCommand(student));
            if (!string.IsNullOrEmpty(response.Error))
            {
                return BadRequest($"{response.Error} {student.FirstName}");
            }
            var studenInserted = response.Student;
            return Ok(new { studenInserted });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            var response = await _mediator.Send(new UpdateCommand(student));
            if (!string.IsNullOrEmpty(response.Error))
            {
                return BadRequest($"{response.Error} {student.FirstName}");
            }
            var studenUpdated = response.Student;
            return Ok(new { studenUpdated });
        }

        [HttpDelete("{id}",Name = "student")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _mediator.Send(new DeleteCommand(id));
            if (!string.IsNullOrEmpty(response.Error))
            {
                return BadRequest($"{response.Error} {id}");
            }
            var studentDeleted = response.Student;
            return Ok(new { studentDeleted });

        }

    }
}
