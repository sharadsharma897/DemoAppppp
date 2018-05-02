using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class Medicine
    {
        public string MedicineName { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Status { get; set; }
    }
}