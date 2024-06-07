using FlashcardWebApp.Models;

namespace FlashcardWebApp.Interface
{
    public interface IFlashcardService
    {
        Task<List<Flashcard>> GetAllFlashcardsBySetName(string setName);
        Task Add(string question, string answer, string setName);
        List<FlashcardDTO> FlashcardsToDTOs(List<Flashcard> flashcards);
    }
}
