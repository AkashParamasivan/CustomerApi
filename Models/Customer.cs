using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerApi.Models
{
    public partial class Customer
    {
        public int Custid { get; set; }
        public string CustomerName { get; set; }
        public string Phoneno { get; set; }
        public string Mailid { get; set; }
    }
}
