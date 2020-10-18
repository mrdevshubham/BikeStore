using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeStore.Model.Response
{
    public class BaseFilterResponse<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
