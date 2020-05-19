using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class TypeMenu
    {
        public TypeMenu()
        {
            Dishes = new HashSet<Dishes>();
        }

        public Guid TypeMenuGuid { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
