using application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Services;
using Moq;

namespace Tests
{
    public class ProgramTest
    {
        private readonly IProgramService _programService;
        private readonly IQuestionService _questionService;
        private readonly Mock<IProgramRepository> _programRepository = new Mock<IProgramRepository>();
        private readonly Mock<IQuestionRepository> _questionRepository = new Mock<IQuestionRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public ProgramTest()
        {
            _programService = new ProgramService(_programRepository.Object, _mapper.Object);
            _questionService = new QuestionService(_questionRepository.Object, _mapper.Object);
        }


        [Fact]

        public async Task AddProgram_ShouldReturnProgramId_WhenProgramAddedSuccessfully()
        {

            var program = new ProgramDTO
            {
                ProgramSummary = "summary",
                RequiredSkills = new List<string> { "C#", "sql server" },
                ProgramBenefits = new List<string> { "Free Food","Laptop"}
            };

            var newProgram = new Program
            {
                ProgramSummary = "summary",
                RequiredSkills = "C#, sql server" ,
                ProgramBenefits =  "Free Food,Laptop" 
            };

            _mapper.Setup(x=>x.Map<Program>(program)).Returns(newProgram);

            _programRepository.Setup(x => x.AddAsync(newProgram)).Returns(Task.CompletedTask);

            var programId = await _programService.AddProgram(program);

            Assert.NotNull(programId);

        }



        [Fact]

        public async Task AddQuestion_ShouldReturnQuestionId_WhenQuestionAddedSuccessfully()
        {

            var question = new QuestionDTO
            {
                ProgramId = "sdsdfsd",
                QuestionType = Domain.Enum.QuestionType.YesNo
            };

            var newQuestion = new Question
            {
                ProgramId = "sdsdfsd",
                QuestionType = Domain.Enum.QuestionType.YesNo
            };

            _mapper.Setup(x => x.Map<Question>(question)).Returns(newQuestion);

            _questionRepository.Setup(x => x.AddAsync(newQuestion)).Returns(Task.CompletedTask);

            var programId = await _questionService.AddQuestionAsync(question);

            Assert.NotNull(programId);

        }
    }
}