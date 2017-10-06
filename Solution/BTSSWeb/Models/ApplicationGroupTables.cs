using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class ApplicationGroupTables
    {
        [Key]
        public System.Guid AppGroupTableID { get; set; } //pk
        public System.Guid ApplicationGroupID { get; set; } //appgroup
        public int TableID { get; set; }
        public bool CanGet { get; set; }
        public bool CanPost { get; set; }
        public bool CanPut { get; set; }
        public bool CanDelete { get; set; }
    }
}