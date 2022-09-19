using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Models
{
    internal class Notification
    {
        public int Id { get; set; }
        public DateTime NotificationTime { get; set; }
        public string Message { get; set; }
    }
}
