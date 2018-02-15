using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
//using Serilog.
namespace SerilogRD
{
    class Program
    {
        static void Main(string[] args)
        {
            string logConnString = "Data Source=zeus;Initial Catalog=pruebaSerilog;Integrated Security=True";
            var log = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.MSSqlServer(logConnString, tableName: "Logs",restrictedToMinimumLevel: LogEventLevel.Error)
                        .CreateLogger();



            log.Write(LogEventLevel.Information, "Que pasa troncu Hola Mostru");

            log.Write(LogEventLevel.Error, "HA PETAO {machineName}", new { MachineName = Environment.MachineName } );

            //log.Information("Retrieved {Count} records", new Coso {  Count = 1});

            Console.ReadLine();
        }
    }

    public class Coso
    {
        public int Count { get; set; }
    }
}
