using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class Shopper
    {
        public String name { get; set; }
        public String address { get; set; }
        public String zipcode { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String countryCode { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String birthDate { get; set; }
        public String idNumber { get; set; }
        public String ipAddress { get; set; }
    }
}
