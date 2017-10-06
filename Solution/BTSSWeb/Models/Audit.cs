using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class Audit
    {
        [Key]
        public System.Guid AuditID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Application { get; set; }
        public string Table { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
    }
}