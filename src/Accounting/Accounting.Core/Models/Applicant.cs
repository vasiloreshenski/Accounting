namespace Accounting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Applicant
    {
        public Applicant(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public String Name { get; }

#if DEBUG
        public String DebugInfo() => $"{this.Id}; {this.Name}";
#endif
    }
}
