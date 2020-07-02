using System;
using System.Collections.Generic;

namespace OurReceipt.Api.Entities
{
    public partial class User
    {
        public User()
        {
            Receipt = new HashSet<Receipt>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
