using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class InquiryResult
    {
        public bool Result { get; set; }
        public List<Modules> Modules { get; set; }
    }
}