using Autofac;
using Data.Repository;
using Data.UnitOfWork;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkImp>().As<IUnitOfWork>();

            builder.RegisterType<RepositoryImp<Category>>().As <IRepository<Category>>();
            builder.RegisterType<RepositoryImp<Level>>().As<IRepository<Level>>();
            builder.RegisterType<RepositoryImp<Question>>().As<IRepository<Question>>();
            builder.RegisterType<RepositoryImp<Encouragement>>().As<IRepository<Encouragement>>();

            builder.RegisterType<FiveQuestionEntities>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
