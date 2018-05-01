using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LiteDbContext
{
    /// <summary>
    /// Implementation of a Similar DbSet for a LiteDatabase
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public class LiteDbSet<T>
    {
        private readonly LiteDatabase _db;

        /// <summary>
        /// Instantiate a LiteDbSet
        /// </summary>
        /// <param name="db">Database</param>
        public LiteDbSet(LiteDatabase db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns an Enumerable of the selected entity
        /// </summary>
        public IEnumerable<T> AsEnumerable() => _db.GetCollection<T>().FindAll();

        /// <summary>
        /// Realize a Query on desired collection
        /// </summary>
        /// <param name="expression">Expression to search</param>
        /// <param name="skip">Number of entities skip</param>
        /// <param name="limit">Limit of search</param>
        /// <returns></returns>
        public IEnumerable<T> Where(Expression<Func<T, bool>> expression,
            int skip = 0, int limit = 2147483647) =>
            _db.GetCollection<T>().Find(expression, skip, limit);

        /// <summary>
        /// Insert data to a collection
        /// </summary>
        public void Add(T entity) => _db.GetCollection<T>().Insert(entity);

        /// <summary>
        /// Adds a range of entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int AddRange(List<T> entities) => _db.GetCollection<T>().InsertBulk(entities);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <returns>Success of process</returns>
        public bool Update(T entity) => _db.GetCollection<T>().Update(entity);

        /// <summary>
        /// Update a collection of entities
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public int Update(IEnumerable<T> entities) => _db.GetCollection<T>().Update(entities);

        /// <summary>
        /// Update or insert an entity
        /// </summary>
        public bool Upsert(T entity) => _db.GetCollection<T>().Upsert(entity);

        /// <summary>
        /// Update or insert a collection of entities
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public int Upsert(IEnumerable<T> entity) => _db.GetCollection<T>().Upsert(entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        public bool Delete(BsonValue id) => _db.GetCollection<T>().Delete(id);

        /// <summary>
        /// Delete entities by expression
        /// </summary>
        public int DeleteByExp(Expression<Func<T, bool>> expression) =>
            _db.GetCollection<T>().Delete(expression);

        /// <summary>
        /// return FirstOrDefault
        /// </summary>
        public T FirstOrDefault() => _db.GetCollection<T>().FindAll().FirstOrDefault();

        /// <summary>
        /// return FirstOrDefault
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> expression) =>
            _db.GetCollection<T>().FindOne(expression);

        /// <summary>
        /// Configure indices of the collection
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expIndices"></param>
        public void ConfigureIndices<K>(Expression<Func<T, K>> expIndices, bool unique = false) =>
                _db.GetCollection<T>().EnsureIndex(expIndices, unique);

        /// <summary>
        /// Configure indices of the collection
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expIndices"></param>
        public void ConfigureIndices<K>(Expression<Func<T, K>> expIndices, string expression, bool unique = false) =>
                _db.GetCollection<T>().EnsureIndex(expIndices, expression, unique);
    }
}
