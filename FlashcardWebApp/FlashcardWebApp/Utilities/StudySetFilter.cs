using FlashcardWebApp.Models;

namespace FlashcardWebApp.Utilities
{
    public delegate bool StudySetDateFilter(StudySet studySet);
    public delegate IOrderedEnumerable<StudySet> StudySetOrderFilter(IEnumerable<StudySet> studySets);

}
