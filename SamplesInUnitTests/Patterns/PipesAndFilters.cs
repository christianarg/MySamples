using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// búsqueda google: https://www.google.es/search?q=c%23+pipes+and+filters+pattern&oq=c%23+pipes+and+filters+pattern&aqs=chrome..69i57j69i58.6159j0j7&sourceid=chrome&ie=UTF-8
namespace SamplesTestProyect.Patterns
{
	// https://eventuallyconsistent.net/tag/pipe-and-filters/
	// (ver) https://eventuallyconsistent.net/2013/08/12/messaging-as-a-programming-model-part-1/
	// falta ver https://eventuallyconsistent.net/tag/pipe-and-filters/
	namespace ExampleFromEventualyConsistent1
	{
		[TestClass]
		public class PipesAndFilters
		{
			[TestMethod]
			public void TestMethod1()
			{
				var loginPipeline = new PipeLine<LogInMessage>();

				loginPipeline.Register(new CheckUserSuppliedCredentials());

				loginPipeline.Execute(new LogInMessage());
							// .Register(new CheckApiKeyIsEnabledForClient(new ClientDetailsDao()))
							// .Register(new IsUserLoginAllowed())
							// .Register(new ValidateAgainstMembershipApi(new MembershipService()))
							// .Register(new GetUserDetails(new UserDetailsDao()));
							//.Register(new PublishUserLoggedInEvent(new GetBus()));
			}
		}

		public interface IFilter<T>
		{
			void Execute(T msg);
		}

		public class PipeLine<T>
		{
			private readonly List<IFilter<T>> _filters = new List<IFilter<T>>();

			public PipeLine<T> Register(IFilter<T> filter)
			{
				_filters.Add(filter);
				return this;
			}

			public void Execute(T input)
			{
				_filters.ForEach(f => f.Execute(input));
			}
		}

		public class LogInMessage
		{
			public string Username { get; set; }
			public string Password { get; set; }
			public bool Stop { get; set; }
			public List<string> Errors { get; set; }
		}

		public class CheckUserSuppliedCredentials : IFilter<LogInMessage>
		{
			//public void Excute(LogInMessage input)
			//{
			//	if (string.IsNullOrEmpty(input.Username) ||
			//			  string.IsNullOrEmpty(input.Password))
			//	{
			//		input.Stop = true;
			//		input.Errors.Add("Invalid credentials");
			//	}
			//}

			public void Execute(LogInMessage msg)
			{
				if (string.IsNullOrEmpty(msg.Username) ||
						  string.IsNullOrEmpty(msg.Password))
				{
					msg.Stop = true;
					msg.Errors.Add("Invalid credentials");
				}
			}
		}
	}

	// https://ayende.com/blog/3082/pipes-and-filters-the-ienumerable-appraoch
	namespace ExampleFromAyende
	{

		[TestClass]
		public class TrivialProcessesPipelineTest
		{
			[TestMethod]
			public void ExecuteTest()
			{
				var pipeline = new TrivialProcessesPipeline();
				pipeline.Execute();
			}
		}

		public class GetAllProcesses : IOperation<Process>
		{
			public IEnumerable<Process> Execute(IEnumerable<Process> input)
			{
				return Process.GetProcesses();
			}
		}

		public class LimitByWorkingSetSize : IOperation<Process>
		{
			public IEnumerable<Process> Execute(IEnumerable<Process> input)
			{
				int maxSizeBytes = 50 * 1024 * 1024;
				foreach (Process process in input)
				{
					if (process.WorkingSet64 > maxSizeBytes)
						yield return process;
				}
			}
		}

		public class PrintProcessName : IOperation<Process>
		{
			public IEnumerable<Process> Execute(IEnumerable<Process> input)
			{
				foreach (Process process in input)
				{
					System.Console.WriteLine(process.ProcessName);
				}
				yield break;
			}
		}

		public class TrivialProcessesPipeline : Pipeline<Process>
		{
			public TrivialProcessesPipeline()
			{
				Register(new GetAllProcesses());
				Register(new LimitByWorkingSetSize());
				Register(new PrintProcessName());
			}
		}

		public class Pipeline<T>
		{
			private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

			public Pipeline<T> Register(IOperation<T> operation)
			{
				operations.Add(operation);
				return this;
			}

			public void Execute()
			{
				IEnumerable<T> current = new List<T>();
				foreach (IOperation<T> operation in operations)
				{
					current = operation.Execute(current);
				}
				IEnumerator<T> enumerator = current.GetEnumerator();
				while (enumerator.MoveNext()) ;
			}
		}

		public interface IOperation<T>
		{
			IEnumerable<T> Execute(IEnumerable<T> input);
		}
	}
}
// meh: https://www.google.es/search?q=c%23+process+pattern&oq=c%23+proce&aqs=chrome.0.69i59j69i58j0j69i57j69i60j69i61.2064j0j7&sourceid=chrome&ie=UTF-8
// más: https://www.google.es/search?q=c%23+process+pattern&oq=c%23+proce&aqs=chrome.0.69i59j69i58j0j69i57j69i60j69i61.2064j0j7&sourceid=chrome&ie=UTF-8