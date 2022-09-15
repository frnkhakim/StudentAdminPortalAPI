using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.DomainModels;
using StudentAdminPortalAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [ApiController]

    public class StudentsController : Controller


    {
        private readonly IStudentRepository studentReposistory;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentReposistory, IMapper mapper)
        {
            this.studentReposistory = studentReposistory;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentReposistory.GetStudentsAsync();


            return Ok(mapper.Map<List<Student>>(students));

        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch Student Details
            var student = await studentReposistory.GetStudentAsync(studentId);
            //Return Student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut ]
        [Route("[controller]/{studentId:guid}")]

        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await studentReposistory.Exists(studentId))
            {
                //update details
                var updatedStudent = await studentReposistory.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
          
                return NotFound();
            
        }


        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await studentReposistory.Exists(studentId))
            {
                //Delete student
                var student = await studentReposistory.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            }

            return NotFound();
        }




    }
}
