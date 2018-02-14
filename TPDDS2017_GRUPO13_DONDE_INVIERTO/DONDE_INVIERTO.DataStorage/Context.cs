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
                  typeof(NHibernate.Dialect.MsSql2012Dialect).AssemblyQualifiedName);
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

        public static IList<T> ReadAll<T>() where T : EditableEntity
        {

            using (var transaction = Session.BeginTransaction())
            {
                return Session.QueryOver<T>().List();
            }

        }

        public static void Save<T>(T entity) where T : EditableEntity
        {

            using (var transaction = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

        }

        public static void Save<T>(IList<T> entities) where T : EditableEntity
        {
            using (var transaction = Session.BeginTransaction())
            {
                try
                {
                    entities.ToList().ForEach(entity => Session.SaveOrUpdate(entity));
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

        }

        public static void Delete<T>(T entity) where T : EditableEntity
        {

            using (var transaction = Session.BeginTransaction())
            {
                try
                {
                Session.Delete(entity);
                Session.Flush();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }

            }
   
        }

        public static T Get<T>(T entity) where T : EditableEntity
        {

            using (var transaction = Session.BeginTransaction())
            {
                return Session.Get<T>(entity.Id);
            }
      
        }
    }
}