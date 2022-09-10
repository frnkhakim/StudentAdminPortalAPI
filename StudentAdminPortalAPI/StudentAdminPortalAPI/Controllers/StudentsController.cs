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
    }
}
