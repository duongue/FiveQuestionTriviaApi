using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data.UnitOfWork;
using System.Linq;

namespace Service.Services
{
    public class EngineService : BaseService, IEngineService
    {
        private readonly IDataService _dataService;

        public EngineService(IUnitOfWork unit, IDataService dataService) : base(unit)
        {
            _dataService = dataService;
        }

        public Task<bool> CheckAnswer(int questionId, string answer)
        {
            var question = _dataService.GetQuestionsByIdAsync(questionId).Result;
            var answerKey = question.Answer.ToLower();
            return Task.FromResult(answer.Contains(answerKey));
        }

        public Task<IEnumerable<Question>> GetANumberOfQuestions(int levelId, int categoryId, int numQuest)
        {
            List<int> addedQuestionIds = new List<int>();
            List<Question> rtn = new List<Question>();
            while (addedQuestionIds.Count < numQuest)
            {
                var randomQuestion = GetQuestion(levelId, categoryId, addedQuestionIds).Result;
                rtn.Add(randomQuestion);
                addedQuestionIds.Add(randomQuestion.QuestionId);
            }
            return Task.FromResult(rtn.AsEnumerable());
        }

        public Task<IEnumerable<Question>> GetANumberOfRandomQuestions(int numQuest)
        {
            List<int> addedQuestionIds = new List<int>();
            List<Question> rtn = new List<Question>();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int numLevels = _dataService.GetAllLevelsAsync().Result.Count();
            int numCategories = _dataService.GetAllCategoriesAsync().Result.Count();
            while (addedQuestionIds.Count < numQuest)
            {
                random = new Random(Guid.NewGuid().GetHashCode());
                int ranLvl = random.Next(1, numLevels);
                int ranCat = random.Next(1, numCategories);
                var randomQuestion = GetQuestion(ranLvl, ranCat, addedQuestionIds).Result;
                rtn.Add(randomQuestion);
                addedQuestionIds.Add(randomQuestion.QuestionId);
            }
            return Task.FromResult(rtn.AsEnumerable());
        }

        public Task<Encouragement> GetEncouragement(bool correctAnswer)
        {
            var encouragement = Unit.Encouragements.GetAsync(e => e.SaysOnCorrectAnswer == correctAnswer).Result.ToList();
            if (encouragement.Count > 1)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int randomNumber = random.Next(0, encouragement.Count);
                return Task.FromResult(encouragement[randomNumber]);
            }
            else
            {
                return Task.FromResult(encouragement[0]);
            }
        }

        public Task<Question> GetQuestion(int levelId, int categoryId, ICollection<int> askedQuestionIds)
        {
            var question = Unit.Questions.GetAsync(q => q.LevelId == levelId && q.CategoryId == categoryId & askedQuestionIds.Contains(q.QuestionId) == false).Result.ToList();
            if (question.Count > 1)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int randomNumber = random.Next(0, question.Count);
                return Task.FromResult(question[randomNumber]);
            }
            else
            {
                return Task.FromResult(question[0]);
            }
        }
    }
}
