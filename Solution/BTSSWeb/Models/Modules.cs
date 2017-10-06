using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class Modules
    {
        [Key]
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
    }
}