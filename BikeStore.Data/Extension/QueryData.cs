using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BikeStore.Data.Extension
{
    public class QueryData<T> where T : BaseEntity
    {
        public IQueryable<T> GetQuery(IQueryable<T> query, Expression<Func<T, bool>> criteria)
        {
            query.Where(criteria);

            return query;
        }
    }
}
