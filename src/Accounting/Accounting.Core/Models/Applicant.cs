namespace Accounting.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("{DebugInfo()}")]
    public class Applicant : PropertyChangedBase, INotifyPropertyChanged
    {
        private int id;
        private String name;

        public Applicant(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.OnPropertyChnaged(nameof(this.Id));
                }
            }
            get => this.id;
        }

        public String Name
        {
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChnaged(nameof(this.Name));
                }
            }
            get => this.name;
        }

#if DEBUG
        public String DebugInfo() => $"{this.Id}; {this.Name}";
#endif
    }
}
