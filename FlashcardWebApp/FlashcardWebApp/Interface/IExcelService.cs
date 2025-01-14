﻿using FlashcardWebApp.Models;

namespace FlashcardWebApp.Interface
{
    public interface IExcelService
    {

        public void CreateFile(string filePath);
        public void Fill(string filePath, IEnumerable<Flashcard> flashcards);
        List<FlashcardDTO> GetExcelData(string filePath, string setName);
    }
}
