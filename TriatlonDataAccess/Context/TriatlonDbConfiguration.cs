using System;
using System.Collections.Generic;
using System.Text;

namespace TriatlonDataAccess.Context
{
	public static class TriatlonDbConfiguration
	{
		public static string GetConnectionString()
		{
			return @"Server=(localdb)\mssqllocaldb;Database=aspnet-A9B09F27-4B72-4143-B3F7-FCA16AD356DE;Trusted_Connection=True;MultipleActiveResultSets=true";
		
		}
	}
}
