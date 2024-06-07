using Moq;
using FlashcardWebApp.Controllers;
using FlashcardWebApp.Interface;
using FlashcardWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardWebAppTests
{
    [TestClass]
    public class FlashcardsControllerTests
    {
        private Mock<IFlashcardService> _mockFlashcardService;
        private Mock<IStudySetService> _mockStudySetService;
        private FlashcardsController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _mockFlashcardService = new Mock<IFlashcardService>();
            _mockStudySetService = new Mock<IStudySetService>();
            _controller = new FlashcardsController(_mockFlashcardService.Object, _mockStudySetService.Object);
        }

        [TestMethod]
        public async Task RandomizedAndSystemCheck_ReturnsViewWithFlashcards()
        {
            var setName = "TestSet";
            var time = 5;
            var flashcards = new List<Flashcard>
            {
                new Flashcard("1", "What is 2+2?", "4", setName),
                new Flashcard("2", "What is the capital of France?", "Paris", setName)
            };

            var flashcardDTOs = new List<FlashcardDTO>
            {
                new FlashcardDTO("1", "What is 2+2?", "4", setName),
                new FlashcardDTO("2", "What is the capital of France?", "Paris", setName)
            };

            _mockFlashcardService.Setup(s => s.GetAllFlashcardsBySetName(setName)).ReturnsAsync(flashcards);
            _mockFlashcardService.Setup(s => s.FlashcardsToDTOs(flashcards)).Returns(flashcardDTOs);

            var result = await _controller.RandomizedAndSystemCheck(setName, time) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<FlashcardDTO>));
            var model = result.Model as List<FlashcardDTO>;
            Assert.AreEqual(flashcardDTOs.Count, model.Count);
            for (int i = 0; i < flashcardDTOs.Count; i++)
            {
                Assert.AreEqual(flashcardDTOs[i].Id, model[i].Id);
                Assert.AreEqual(flashcardDTOs[i].Question, model[i].Question);
                Assert.AreEqual(flashcardDTOs[i].Answer, model[i].Answer);
                Assert.AreEqual(flashcardDTOs[i].SetName, model[i].SetName);
            }
        }

        [TestMethod]
        public async Task CountDown_ReturnsDecrementedTime()
        {
            int initialTime = 10;

            var result = await _controller.CountDown(initialTime) as OkObjectResult;

            // to check that the result is not null and is of type OkObjectResult
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var returnedTime = result.Value;
            Assert.AreEqual(initialTime - 1, returnedTime);
        }

        [TestMethod]
        public void AddFlashcard_ReturnsViewWithNewStudySetModel()
        {
            var studySetName = "Physics";

            var result = _controller.AddFlashcard(studySetName) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(StudySet));
            var model = result.Model as StudySet;
            Assert.AreEqual(studySetName, model.StudySetName);
        }
    }
}
