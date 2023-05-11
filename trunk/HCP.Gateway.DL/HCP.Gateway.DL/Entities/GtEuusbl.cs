﻿using System;
using System.Collections.Generic;

namespace HCP.Gateway.DL.Entities
{
    public partial class GtEuusbl
    {
        public GtEuusbl()
        {
            GtEuusml = new HashSet<GtEuusml>();
        }

        public int UserId { get; set; }
        public int BusinessKey { get; set; }
        public int? UserGroup { get; set; }
        public int? UserType { get; set; }
        public bool AllowMtfy { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual ICollection<GtEuusml> GtEuusml { get; set; }
    }
}
