using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Models
{
    internal class DeviceItem
    {
        public string DeviceId { get; set; }
        public string Status { get; set; }
        public string Placement { get; set; }
        public DateTime LastUpdated { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
