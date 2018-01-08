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
    public class DataService : BaseService, IDataService
    {
        public DataService(IUnitOfWork unit) : base(unit)
        {
        }

        public Task AddCategoryAsync(Category categoryToAdd)
        {
            return Task.Run(() => 
            {
                Unit.Categories.Add(categoryToAdd);
                Unit.Save();
            });
        }

        public Task AddEncouragementAsync(Encouragement encouragementToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Add(encouragementToAdd);
                Unit.Save();
            });
        }

        public Task AddLevelAsync(Level levelToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Add(levelToAdd);
                Unit.Save();
            });
        }

        public Task AddQuestionAsync(Question questionToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Add(questionToAdd);
                Unit.Save();
            });
        }

        public Task DeleteCategoryAsync(Category categoryToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Categories.Delete(categoryToDelete);
                Unit.SaveAsync();
            });
        }

        public Task DeleteEncouragementAsync(Encouragement encouragementToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Delete(encouragementToDelete);
                Unit.SaveAsync();
            });
        }

        public Task DeleteLevelAsync(Level levelToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Delete(levelToDelete);
                Unit.SaveAsync();
            });
        }

        public Task DeleteQuestionAsync(Question questionToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Delete(questionToDelete);
                Unit.SaveAsync();
            });
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return Unit.Categories.GetAsync();
        }

        public Task<IEnumerable<Encouragement>> GetAllEncouragementAsync()
        {
            return Unit.Encouragements.GetAsync();
        }

        public Task<IEnumerable<Level>> GetAllLevelsAsync()
        {
            return Unit.Levels.GetAsync();
        }

        public Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return Unit.Questions.GetAsync(includeProperties:"Category,Level");
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return Unit.Categories.GetByIdAsync(id);
        }

        public Task<Encouragement> GetEncourgementByIdAsync(int id)
        {
            return Unit.Encouragements.GetByIdAsync(id);
        }

        public Task<Level> GetLevelByIdAsync(int id)
        {
            return Unit.Levels.GetByIdAsync(id);
        }

        public Task<Question> GetQuestionsByIdAsync(int id)
        {
            var list = Unit.Questions.GetAsync(t => t.QuestionId == id, includeProperties: "Category,Level");
            return Task.FromResult(list.Result.FirstOrDefault());
        }

        public Task UpdateCategoryAsync(Category categoryToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Categories.Update(categoryToUpdate.CategoryId, categoryToUpdate);
                Unit.SaveAsync();
            });
        }

        public Task UpdateEncouragementAsync(Encouragement encouragementToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Update(encouragementToUpdate.Id, encouragementToUpdate);
                Unit.SaveAsync();
            });
        }

        public Task UpdateLevelAsync(Level levelToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Update(levelToUpdate.LevelId, levelToUpdate);
                Unit.SaveAsync();
            });
        }

        public Task UpdateQuestionAsync(Question questionToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Update(questionToUpdate.QuestionId, questionToUpdate);
                Unit.SaveAsync();
            });
        }
    }
}
