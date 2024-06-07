using FlashcardWebApp.Models;
using FlashcardWebApp.Utilities;

namespace FlashcardWebAppTests
{
    [TestClass]
    public class AllColorsUsedExceptionTests
    {
        [TestMethod]
        public void Constructor_ShouldSetStudySetColorToWhite()
        {
            // Arrange
            string exceptionMessage = "All colors used.";
            var studySet = new StudySet("Mathematics");

            // Act
            try
            {
                throw new AllColorsUsedException(exceptionMessage, studySet);
            }
            catch (AllColorsUsedException ex)
            {
                // Assert
                Assert.AreEqual(exceptionMessage, ex.Message);
                Assert.AreEqual(StudySetColor.White, studySet.Color);
            }
        }
    }
}