using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace callerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", true, true)
          .Build();
            Console.WriteLine($"API url value {config["webApiHost"]}");
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:60464/api/");
                client.BaseAddress = new Uri(config["webApiHost"]);
                //HTTP GET
                var responseTask = client.GetAsync("home/employees");
                //var responseTask = client.GetAsync("");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Employee[]>();
                    //var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    //Console.WriteLine(readTask.Result);

                     var students = readTask.Result;

                    foreach (var student in students)
                    {
                        Console.WriteLine(student.Name);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
