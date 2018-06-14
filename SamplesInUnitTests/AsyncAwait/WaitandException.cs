using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.AsyncAwait
{
	[TestClass]
	public class WaitandException
	{
		[TestMethod]
		public void When_Exception_in_Wait_Then_ExceptionPropagated()
		{
			bool exception = false;
			try
			{
				var task = DoAlgo();
				task.Wait();
			}
			catch (Exception)
			{
				exception = true;
			}
			Assert.IsTrue(exception);
		}

		public async Task DoAlgo()
		{
			throw new Exception("Putoo");
		}
	}
}
