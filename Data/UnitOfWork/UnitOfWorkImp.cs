using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.UnitOfWork
{
    public class UnitOfWorkImp : IUnitOfWork
    {
        private readonly FiveQuestionEntities _context;

        private RepositoryImp<Category> categories;
        private RepositoryImp<Level> levels;
        private RepositoryImp<Question> questions;
        private RepositoryImp<Encouragement> encouragements;

        private bool disposed = false;

        public IRepository<Category> Categories
        {
            get
            {
                this.categories = this.categories ?? new RepositoryImp<Category>(_context);
                return this.categories;
            }
        }
        public IRepository<Level> Levels
        {
            get
            {
                this.levels = this.levels ?? new RepositoryImp<Level>(_context);
                return this.levels;
            }
        }
        public IRepository<Question> Questions
        {
            get
            {
                this.questions = this.questions ?? new RepositoryImp<Question>(_context);
                return this.questions;
            }
        }
        public IRepository<Encouragement> Encouragements
        {
            get
            {
                this.encouragements = this.encouragements ?? new RepositoryImp<Encouragement>(_context);
                return this.encouragements;
            }
        }

        public UnitOfWorkImp(FiveQuestionEntities context)
        {
            _context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public int Save()
        {
            return this._context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}
