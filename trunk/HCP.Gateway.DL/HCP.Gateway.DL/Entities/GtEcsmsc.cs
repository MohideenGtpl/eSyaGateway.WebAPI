using System;
using System.Collections.Generic;

namespace HCP.Gateway.DL.Entities
{
    public partial class GtEcsmsc
    {
        public string ReminderType { get; set; }
        public string Smsid { get; set; }
        public long ReferenceKey { get; set; }
        public bool SendStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
