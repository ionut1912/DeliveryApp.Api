using DeliveryApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Contracts
{
   public class EditUserConfigRequest
    {
        public string Language { get; set; }
        public UserConfigDto Configs { get; set; }
    }
}
