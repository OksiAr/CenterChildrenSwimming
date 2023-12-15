using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterSwimming.Components
{
    public partial class ClientServiceDate
    {
        public DateTime TimeEnd
        {
            get
            {
                return DateOfLesson.AddMinutes(ClientService.Service.DurationInMinutes);
            }
        }
      

    }
}
