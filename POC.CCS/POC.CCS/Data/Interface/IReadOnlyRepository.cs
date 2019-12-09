namespace POC.CCS.Data.Interface
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IReadOnlyRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(Expression<Func<T, bool>> predicate);
    }
}
