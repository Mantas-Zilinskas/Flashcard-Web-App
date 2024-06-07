using FlashcardWebApp.Models;

namespace FlashcardWebApp.Utilities
{
    public class AllColorsUsedException : Exception
    {
        public AllColorsUsedException(string message, StudySet studySet) : base(message)
        {
            studySet.Color = StudySetColor.White;
        }
    }
}
