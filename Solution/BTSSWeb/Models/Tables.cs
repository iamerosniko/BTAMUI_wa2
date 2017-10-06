using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class Tables
    {
        [Key]
        public int TableID { get; set; }
        public string TableName { get; set; }
        public bool IsActive { get; set; }
    }
}