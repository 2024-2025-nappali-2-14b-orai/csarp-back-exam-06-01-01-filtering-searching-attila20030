using Kreata.Backend.Controllers.Base;
using Kreata.Backend.Repos;
using Kreta.Shared.Assemblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{//változtatva
    public partial class StudentController : BaseController<Student, StudentDto>
    {
        private IStudentRepo _studentRepo;
        public StudentController(StudentAssembler? assambler, IStudentRepo? repo) : base(assambler, repo)
        {
            _studentRepo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("getstudentbyfullname")]
        public async Task<IActionResult> GetStudentByFullName([FromQuery] FullNameQueryDto fullNameDto)
        {
            return Ok(await _studentRepo.GetByNameAsync(fullNameDto.FirstName, fullNameDto.LastName));
        }

        /*
        [HttpGet("NumberOfStudent")]//
        public async Task<IActionResult> GetNumberOfStudentsAsync()
        {
            return Ok(await _studentRepo.GetNumberOfStudentAsync());
        }        
        
        [HttpGet("NumberOfWoman")]
        public async Task<IActionResult> GetNumberOfWomanAsync()
        {
            return Ok(await _studentRepo.GetNumberOfWomanAsync());
        }        
        
        
        [HttpGet("NumberOfMan")]
        public async Task<IActionResult> GetNumberOfManAsync()
        {
            return Ok(await _studentRepo.GetNumberOfManAsync());
        }        
        
        [HttpGet("BornInTwentyTwentyOne")]// A diákok száma akik 2021-ben születtek
        public async Task<IActionResult> GetNumberOfStudentByBirthdayAsync()
        {
            return Ok(await _studentRepo.GetNumberOfStudentByBirthdayAsync());
        }        
        
        [HttpGet("GetNumberOfStudentBornInAprilAsync")]// A diákok száma akik áprilisban születtek
        public async Task<IActionResult> GetNumberOfStudentBornInAprilAsync()
        {
            return Ok(await _studentRepo.GetNumberOfStudentBornInAprilAsync());
        }
        */

        // A paraméterben kapott évszám évben született diákok száma
        [HttpGet("NumberOfStudentByYear/{year}")]
        public async Task<IActionResult> GetNumberOfStudentByYearAsync(int year)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYearAsync(year));
        }

    }

}
