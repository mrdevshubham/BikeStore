using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Model.Response
{
    public class AuthResponse
    {
        public string username { get; set; }
        public string displayName { get; set; }
        public string token { get; set; }
    }
}
