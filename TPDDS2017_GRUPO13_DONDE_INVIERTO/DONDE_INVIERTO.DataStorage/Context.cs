using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using TrailHealth.Integration.Disconnected;
using System.Linq;

namespace DONDE_INVIERTO.DataStorage
{
    public class Context : IDisposable
    {
        private static ISessionFactory _sessionFactory;
        private static ISession _session;

        private static string GetConectionString()
        {
            var connection = "Data Source=" + ConfigurationManager.AppSettings["Server"] +
                   ";Initial Catalog=" + ConfigurationManager.AppSettings["Database"] +
                   ";Connection Timeout=" + ConfigurationManager.AppSettings["Timeout"];
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IntegratedSecurity"]))
                return connection + ";Integrated Security=true";
            else
                return connection + ";User ID=" + ConfigurationManager.AppSettings["User"] +
                   ";Password=" + ConfigurationManager.AppSettings["Password"];
        }
        public static ISession Session
        {
            get { return OpenSession(); }
        }

        private static ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                var configuration = new NHibernate.Cfg.Configuration();
                configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass,
                        typeof(NHibernate.Bytecode.DefaultProxyFactoryFactory).AssemblyQualifiedName);
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.Dialect,
                  typeof(NHibernate.Dialect.MySQLDialect).AssemblyQualifiedName);
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.ConnectionString, GetConectionString());
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.FormatSql, "true");
                configuration.AddAssembly(Assembly.GetCallingAssembly());
                _sessionFactory = configuration.BuildSessionFactory();
                _session = _sessionFactory.OpenSession();
            }
            return _session;
        }

        public void Dispose()
        {
            Session.Close();
            Session.Dispose();
            _sessionFactory = null;
        }

        public static IList<T> ReadAll<T>() where T: EditableEntity
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.QueryOver<T>().List();
                }
            }
        }

        public static void Save<T>(T entity) where T: EditableEntity
        {
            using (var session = OpenSession())
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

        public static void Save<T>(IList<T> entities) where T : EditableEntity
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        entities.ToList().ForEach(entity => session.SaveOrUpdate(entity));
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public static void Delete<T>(T entity) where T: EditableEntity
        {
            using (var session = OpenSession())
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

        public static T Get<T>(T entity) where T: EditableEntity
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.Get<T>(entity.Id);
                }
            }
        }
    }
}