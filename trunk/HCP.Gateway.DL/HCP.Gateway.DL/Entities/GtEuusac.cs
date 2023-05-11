﻿using System;
using System.Collections.Generic;

namespace HCP.Gateway.DL.Entities
{
    public partial class GtEuusac
    {
        public int UserGroup { get; set; }
        public int UserType { get; set; }
        public int UserRole { get; set; }
        public int MenuKey { get; set; }
        public int ActionId { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
