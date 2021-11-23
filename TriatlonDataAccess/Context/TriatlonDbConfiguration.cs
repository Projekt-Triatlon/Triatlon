using System;
using System.Collections.Generic;
using System.Text;

namespace TriatlonDataAccess.Context
{
	public static class TriatlonDbConfiguration
	{
		public static string GetConnectionString()
		{
			return @"Server=(localdb)\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";
		
		}
	}
}
