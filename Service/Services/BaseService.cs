using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork Unit;

        public BaseService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }
    }
}
