using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterSwimming.Components
{
    public partial class Trainer
    {
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName} {Patronymic}";
            }
        }
    }
}
