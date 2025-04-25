using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace APIFunctionAzure
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Returning long JSON data.");

            var employees = new List<object>
        {
            new { id = 1, name = "Alice Johnson", department = "HR", position = "Manager", hireDate = "2018-06-12" },
            new { id = 2, name = "Bob Smith", department = "IT", position = "Developer", hireDate = "2019-09-23" },
            new { id = 3, name = "Carol Martinez", department = "Finance", position = "Analyst", hireDate = "2020-03-17" },
            new { id = 4, name = "David Lee", department = "Marketing", position = "Coordinator", hireDate = "2021-11-04" },
            new { id = 5, name = "Eva Chen", department = "Sales", position = "Executive", hireDate = "2022-07-15" }
        };

            var response = new
            {
                status = "success",
                count = employees.Count,
                employees = employees
            };

            return new OkObjectResult(response);

        }
    }
}
