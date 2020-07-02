using System;
using System.Collections.Generic;

namespace OurReceipt.Api.Entities
{
    public partial class Receipt
    {
        public long Id { get; set; }
        public string Origin { get; set; }
        public long Value { get; set; }
        public string Date { get; set; }
        public long User { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
