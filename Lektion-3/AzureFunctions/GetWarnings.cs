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
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace AzureFunctions
{
    public static class GetWarnings
    {
        [FunctionName("GetWarnings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "warnings")] HttpRequest req,
            ILogger log)
        {

            using IDbConnection conn = new SqlConnection(Environment.GetEnvironmentVariable("Sql"));
            var result = await conn.QueryAsync<Notification>("SELECT * FROM Warnings");
            return new OkObjectResult(result);

        }
    }
}
