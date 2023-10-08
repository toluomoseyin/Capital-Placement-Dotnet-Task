using Domain.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStageService _stageService;

        public StageController(IStageService stageService)
        {
            _stageService = stageService;
        }

        [HttpPost]

        public async Task<IActionResult> AddStage(StageDTO stage)
        {
           var id =  await _stageService.AddAsync(stage);

            return Ok(new {StegeId = id});
        }



        [HttpGet("{programId}")]

        public async Task<IActionResult> GetStageByProgramId(string programId)
        {
            var question = await _stageService.GetByProgramIdAsync(programId);

            return Ok(question);
        }


        [HttpGet("stageId")]

        public async Task<IActionResult> DeleteQuestion(string stageId)
        {
          var stage =  await _stageService.GetAsync(stageId);

            return Ok(stage);
        }

    }
}
