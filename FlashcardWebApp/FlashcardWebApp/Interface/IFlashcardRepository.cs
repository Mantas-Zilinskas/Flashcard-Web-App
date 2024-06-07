using FlashcardWebApp.Models;

namespace FlashcardWebApp.Interface
{
    public interface IFlashcardRepository
    {
        Task<List<Flashcard>> GetAllBySetName(string setName);
        Task Add(Flashcard flashcard);
    }
}
