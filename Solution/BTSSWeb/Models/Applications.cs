using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class Applications
    {
        [Key]
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public bool IsActive { get; set; }
    }
}