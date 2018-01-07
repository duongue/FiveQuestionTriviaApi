using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDataService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category categoryToAdd);
        Task UpdateCategoryAsync(Category categoryToUpdate);
        Task DeleteCategoryAsync(Category categoryToDelete);

        Task<IEnumerable<Level>> GetAllLevelsAsync();
        Task<Level> GetLevelByIdAsync(int id);
        Task AddLevelAsync(Level levelToAdd);
        Task UpdateLevelAsync(Level levelToUpdate);
        Task DeleteLevelAsync(Level levelToDelete);

        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionsByIdAsync(int id);
        Task AddQuestionAsync(Question questionToAdd);
        Task UpdateQuestionAsync(Question questionToUpdate);
        Task DeleteQuestionAsync(Question questionToDelete);

        Task<IEnumerable<Encouragement>> GetAllEncouragementAsync();
        Task<Encouragement> GetEncourgementByIdAsync(int id);
        Task AddEncouragementAsync(Encouragement encouragementToAdd);
        Task UpdateEncouragementAsync(Encouragement encouragementToUpdate);
        Task DeleteEncouragementAsync(Encouragement encouragementToDelete);
    }
}
