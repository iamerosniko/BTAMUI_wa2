﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class Groups
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
    }
}