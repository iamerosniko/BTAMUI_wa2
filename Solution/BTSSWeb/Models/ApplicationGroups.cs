using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class ApplicationGroups
    {
        [Key]
        public System.Guid ApplicationGroupID { get; set; }
        public int ApplicationID { get; set; }
        public int GroupID { get; set; }
    }
}