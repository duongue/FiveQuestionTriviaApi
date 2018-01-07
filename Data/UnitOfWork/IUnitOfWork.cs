using Data.Repository;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Level> Levels { get; }
        IRepository<Question> Questions { get; }
        IRepository<Encouragement> Encouragements { get; }

        int Save();

        Task<int> SaveAsync();
    }
}
