using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class ApplicationGroupModules
    {
        [Key]
        public System.Guid AppGroupModuleID { get; set; }
        public System.Guid ApplicationGroupID { get; set; }
        public int ModuleID { get; set; }
    }
}