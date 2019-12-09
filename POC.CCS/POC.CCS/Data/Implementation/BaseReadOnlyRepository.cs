namespace POC.CCS.Data.Implementation
{
    using POC.CCS.Data.Interface;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected abstract T[] Data { get; }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return Data.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return Data.AsQueryable();
        }
    }
}
