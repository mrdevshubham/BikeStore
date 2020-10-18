using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Models
{
    public class PaginData<T> where T : BaseEntity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }

    }
}
