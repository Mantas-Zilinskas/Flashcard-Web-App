using FlashcardWebApp.Utilities;

namespace FlashcardWebApp.Models
{
    public class StudySet
    {
        public int Id { get; set; } 
        public StudySetColor Color { get; set; }
        public string StudySetName { get; set; }
        public DateTime DateCreated { get; set; } 
        public List<Flashcard> Flashcards { get; set; }
        public bool IsDuplicate { get; set; }
        public StudySet(string studySetName)
        {
            StudySetName = studySetName;
        }
    }
}
