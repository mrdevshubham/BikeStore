using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Model.Filters
{
    public class GenericFilter
    {
        private int _currentPage;
        private int _recordsPerPage;
        public int currentpage 
        {
            get 
            {
                return _currentPage;
            }
            set 
            {
                if (value == 0)
                    _currentPage = 1;
                else
                    _currentPage = value;
            } 
        }
        public int recordsperpage 
        {
            get
            {
                return _recordsPerPage;
            }
            set
            {
                if (value == 0)
                    _recordsPerPage = 50;
                else
                    _recordsPerPage = value;
            }
        }
        public int totalrecords { get; set; }
    }
}
