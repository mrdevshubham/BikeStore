using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Model.Request
{
    public class StoreRequestModel
    {
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
