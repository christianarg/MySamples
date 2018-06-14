using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
//using Serilog.
namespace SerilogRD
{
	class Program
	{
		static void Main(string[] args)
		{
			string logConnString = "Data Source=zeus;Initial Catalog=pruebaSerilog;Integrated Security=True";
			var columnOptions = new ColumnOptions();
			columnOptions.AdditionalDataColumns = new Collection<DataColumn>
			{
				new DataColumn {DataType=typeof(string), ColumnName = "Category" },
				new DataColumn {DataType=typeof(string), ColumnName = "MachineName" },
				new DataColumn {DataType=typeof(string), ColumnName = "AppDomainName" },
				new DataColumn {DataType=typeof(string), ColumnName = "ProcessName" },
			};

			columnOptions.Properties.ExcludeAdditionalProperties = true;

			columnOptions.Store.Remove(StandardColumn.MessageTemplate);

			var log = new LoggerConfiguration()
						.Enrich.With(new CommonLogEnricher())
						.WriteTo.Console()
						.WriteTo.MSSqlServer(logConnString, tableName: "Logs", restrictedToMinimumLevel: LogEventLevel.Error, columnOptions: columnOptions)
						.CreateLogger();

			PruebaTraceService(log);
			//Pruebasbasicas(log);

			//log.Information("Retrieved {Count} records", new Coso {  Count = 1});

			Console.ReadLine();
		}

		private static void PruebaTraceService(Serilog.Core.Logger log)
		{
			var traceService = new TraceService { Logger = log };
			traceService.Trace(LogEventLevel.Information, "Hola", "Ha pasado esto", "General");
			traceService.Trace(LogEventLevel.Error, "Hola", "Ha petao", "General");
		}

		private static void Pruebasbasicas(Serilog.Core.Logger log)
		{
			log.Write(LogEventLevel.Information, "Que pasa troncu Hola Mostru");

			//log.Write(LogEventLevel.Error, "HA PETAO {MachineName}", new { MachineName = Environment.MachineName });
			//log.Write(LogEventLevel.Error, "HA PETAO2 ", new { MachineName = Environment.MachineName });
			log.Write(LogEventLevel.Error, "HA PETAO3", Environment.MachineName);

			//log.Write(LogEventLevel.Error,"")
		}
	}

	public class TraceService
	{
		public ILogger Logger { get; set; }

		public void Trace(LogEventLevel logLevel, string title, string message, string category)
		{
			string properties = "Category: {category}";
			Logger.Write(logLevel, $"{title}{Environment.NewLine}{message}.{Environment.NewLine}{properties}", category);
		}
	}

	public class CommonLogEnricher : ILogEventEnricher
	{
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName", Environment.MachineName));
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("AppDomainName", AppDomain.CurrentDomain.FriendlyName));
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ProcessName", Process.GetCurrentProcess().ProcessName));
		}
	}

	public class Coso
	{
		public int Count { get; set; }
	}
}
