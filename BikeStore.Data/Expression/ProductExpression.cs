﻿using BikeStore.Data.Expressions;
using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Expression
{
    public class ProductExpression
    {
        public ExpressionBase<Products> GetExpression()
        {
            ExpressionBase<Products> Obj = new ExpressionBase<Products>();

            Obj.WhereClauses = x => x.Id > 5;
            Obj.Includes.Add((x => x.Brand));
            Obj.Includes.Add((x => x.Category));
            Obj.Skip = 0;
            Obj.Take = 10;

            return Obj;
        }
    }
}
