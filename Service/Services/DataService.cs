using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data.UnitOfWork;

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
            });
        }

        public Task AddEncouragementAsync(Encouragement encouragementToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Add(encouragementToAdd);
            });
        }

        public Task AddLevelAsync(Level levelToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Add(levelToAdd);
            });
        }

        public Task AddQuestionAsync(Question questionToAdd)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Add(questionToAdd);
            });
        }

        public Task DeleteCategoryAsync(Category categoryToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Categories.Delete(categoryToDelete);
            });
        }

        public Task DeleteEncouragementAsync(Encouragement encouragementToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Delete(encouragementToDelete);
            });
        }

        public Task DeleteLevelAsync(Level levelToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Delete(levelToDelete);
            });
        }

        public Task DeleteQuestionAsync(Question questionToDelete)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Delete(questionToDelete);
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
            return Unit.Questions.GetAsync();
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
            return Unit.Questions.GetByIdAsync(id);
        }

        public Task UpdateCategoryAsync(Category categoryToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Categories.Update(categoryToUpdate);
            });
        }

        public Task UpdateEncouragementAsync(Encouragement encouragementToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Encouragements.Update(encouragementToUpdate);
            });
        }

        public Task UpdateLevelAsync(Level levelToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Levels.Update(levelToUpdate);
            });
        }

        public Task UpdateQuestionAsync(Question questionToUpdate)
        {
            return Task.Run(() =>
            {
                Unit.Questions.Update(questionToUpdate);
            });
        }
    }
}
