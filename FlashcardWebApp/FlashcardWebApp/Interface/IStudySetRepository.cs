using FlashcardWebApp.Models;

namespace FlashcardWebApp.Interface
{
    public interface IStudySetRepository
    {
        Task<List<StudySet>> GetAll();
        Task<StudySet> GetByName(string studySetName);
        Task Add(StudySet studySet);
    }
}
