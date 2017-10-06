using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class ApplicationGroupUsers
    {
        [Key]
        public System.Guid AppGroupUserID { get; set; }
        public System.Guid ApplicationGroupID { get; set; }
        public int UserID { get; set; }
    }
}