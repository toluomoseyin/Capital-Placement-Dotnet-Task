using Domain.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]

        public async Task<IActionResult> AddQuestion(QuestionDTO question)
        {
           var  questionId =  await _questionService.AddQuestionAsync(question);

            return Ok(new {QuestionId = questionId});
        }



        [HttpGet("ApplicationForm/{programId}")]

        public async Task<IActionResult> ApplicationFormQuestions(string programId)
        {
          var question =  await _questionService.GetQuestionByProgramIdAsync(programId);

          return Ok(question);
        }

        [HttpDelete("questionId")]

        public async Task<IActionResult> DeleteQuestion(string questionId)
        {
            await _questionService.DeleteAsync(questionId);

            return Ok();
        }


    }
}
