using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SmartHealth.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);

        IEnumerable<U> GetBy<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> columns);

        int GetCount(Expression<Func<T, bool>> where);

        void AddMultiple(IEnumerable<T> list);

        void DeleteMultiple(IEnumerable<T> list);

        //Added by Mohammad Sohel Mia ,date:12 July 2016
        int ExecuteCommand(string sqlCommand, params object[] parameters);
        IEnumerable<T> ExecStoreProcedure<T>(string sql, params object[] parameters);

        IEnumerable<T> SQLQueryList<T>(string sql);
        T SQLQuery<T>(string sql);
    }
}