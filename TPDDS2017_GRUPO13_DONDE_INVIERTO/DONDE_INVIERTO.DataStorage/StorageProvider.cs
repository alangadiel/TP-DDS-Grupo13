using NHibernate;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace DONDE_INVIERTO.DataStorage
{
    public sealed class StorageProvider<T> where T : Model.Model
    {
        private static ISessionFactory _sessionFactory;

        private static void OpenSession()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass,
                    typeof(NHibernate.ByteCode.Castle.ProxyFactoryFactory).AssemblyQualifiedName);
            configuration.SetProperty(
              NHibernate.Cfg.Environment.Dialect,
              typeof(NHibernate.Dialect.MsSql2012Dialect).AssemblyQualifiedName);
            configuration.SetProperty(
              NHibernate.Cfg.Environment.ConnectionString, ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            configuration.SetProperty(
              NHibernate.Cfg.Environment.FormatSql, "true");
            configuration.AddAssembly(Assembly.GetCallingAssembly());
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (_sessionFactory == null)
                OpenSession();
            return _sessionFactory.OpenSession();
        }

        public static IList<T> ReadAll()
        {
            using (var session = GetCurrentSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.QueryOver<T>().List();
                }
            }
        }

        public static void Save(T entity)
        {
            using (var session = GetCurrentSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public static void Delete(T entity)
        {
            using (var session = GetCurrentSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }

                }
            }
        }

        public static void Get(T entity)
        {
            using (var session = GetCurrentSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Get<T>(entity.Id);
                }
            }
        }
    }
}