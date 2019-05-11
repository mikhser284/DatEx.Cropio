using System;
using System;
using System.Linq;
using DatEx.Cropio.Proxy.ODataApi.Default;

namespace DatEx.Cropio.Proxy.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething();
        }

        public async static void DoSomething()
        {
            Container container = new Container(new Uri("https://localhost:44340/odata/"));

            //container.Alerts.ExecuteAsync().

            foreach(var e in container.Alerts.ToList())//.Where(x => x.Id > 0))//.Expand(x => x.CreatedByUser))
            {
                String output = "\n\n"
                    + "\nId:          " + e.Id
                    + "\nDescription: " + e.Description
                    + "";
                Console.Write(output);
            }
        }
    }
}
