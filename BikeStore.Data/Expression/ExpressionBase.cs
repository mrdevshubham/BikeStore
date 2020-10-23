using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BikeStore.Data.Expressions
{
    public class ExpressionBase<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> WhereClauses { get; set; }
        public List<Expression<Func<T,object>>> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
