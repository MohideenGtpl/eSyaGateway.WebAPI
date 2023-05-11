﻿using System;
using System.Collections.Generic;

namespace HCP.Gateway.DL.Entities
{
    public partial class GtEuusml
    {
        public GtEuusml()
        {
            GtEuusfa = new HashSet<GtEuusfa>();
        }

        public int UserId { get; set; }
        public int BusinessKey { get; set; }
        public int MenuKey { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual GtEuusbl GtEuusbl { get; set; }
        public virtual GtEcmnfl MenuKeyNavigation { get; set; }
        public virtual ICollection<GtEuusfa> GtEuusfa { get; set; }
    }
}
