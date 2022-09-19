using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using AzureFunctions.Models;
using Microsoft.Azure.Devices;

namespace AzureFunctions
{
    public static class GetDevices
    {
        private static readonly RegistryManager registryManager =
            RegistryManager.CreateFromConnectionString(Environment.GetEnvironmentVariable("IotHub"));

        [FunctionName("GetDevices")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "devices")] HttpRequest req,
            ILogger log)
        {
            var devices = await registryManager.GetDevicesAsync(1000);

            var list = new List<DeviceItem>();
            foreach (var device in devices)
                list.Add(new DeviceItem
                {
                    DeviceId = device.Id,
                    Status = device.ConnectionState.ToString(),
                    Placement = "",
                    LastUpdated = device.LastActivityTime,
                });

            return new OkObjectResult(list);
        }
    }
}
