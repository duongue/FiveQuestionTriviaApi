using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEngineService
    {
        Task<Question> GetQuestion(int levelId, int categoryId, ICollection<int> askedQuestionIds);
        Task<bool> CheckAnswer(int questionId, string answer);
        Task<Encouragement> GetEncouragement(bool correctAnswer);
        Task<IEnumerable<Question>> GetANumberOfRandomQuestions(int numQuest);
        Task<IEnumerable<Question>> GetANumberOfQuestions(int levelId, int categoryId, int numQuest);
    }
}
