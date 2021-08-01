using System;
using System.Reflection;
using DbUp;

namespace ClimbingClubInventory.dbup
{
	class Program
	{
		public static int Main(string[] args)
		{
			if (args.Length != 1 || (args[0] != "plan" && args[0] != "execute"))
			{
				Console.Error.WriteLine("Invalid arguments. Provide a single argument of either plan or execute.");
				return -1;
			}

			var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
			Console.WriteLine($"connectionString: {connectionString}");
			EnsureDatabase.For.PostgresqlDatabase(connectionString);

			var changes = DeployChanges.To
				.PostgresqlDatabase(connectionString)
				.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
				.LogToConsole()
				.Build();

			if (args[0] == "plan")
			{
				var scriptsToRun = changes.GetScriptsToExecute();
				foreach (var script in scriptsToRun)
				{
					Console.WriteLine(script.Name);
				}
				return 0;
			}
			var result = changes.PerformUpgrade();
			if (!result.Successful)
			{
				Console.Error.WriteLine(result.Error);
				return -1;
			}
			Console.WriteLine("Upgrade Successful");
			return 1;
		}
	}
}
