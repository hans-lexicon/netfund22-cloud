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
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace AzureFunctions
{
    public static class GetActivities
    {
        [FunctionName("GetActivities")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "activities")] HttpRequest req,
            ILogger log)
        {

            using IDbConnection conn = new SqlConnection(Environment.GetEnvironmentVariable("Sql"));
            var result = await conn.QueryAsync<Notification>("SELECT * FROM Activities");
            return new OkObjectResult(result);
        
        }
    }
}
