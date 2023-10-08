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
        private readonly IProgramService _sut;
        private readonly Mock<IProgramRepository> _programRepository = new Mock<IProgramRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public ProgramTest()
        {
            _sut = new ProgramService(_programRepository.Object, _mapper.Object);  
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

            var programId = await _sut.AddProgram(program);

            Assert.NotNull(programId);

        }
    }
}