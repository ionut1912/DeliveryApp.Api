using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts
{
    public class AddUserConfigRequest
    {
        public  string Language { get; set; }
        public  UserConfigDto UserConfig { get; set; }
    }
}
