using Domain.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]

        public async Task<IActionResult> AddProgram(ProgramDTO program)
        {
          var programId = await _programService.AddProgram(program);

           return Ok(new {ProgramId = programId});
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProgram(string id)
        {
           var program = await _programService.GetProgram(id);
            return Ok(program);
        }
    }
}
