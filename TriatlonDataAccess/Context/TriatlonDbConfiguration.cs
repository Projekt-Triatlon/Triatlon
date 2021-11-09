using System;
using System.Collections.Generic;
using System.Text;

namespace TriatlonDataAccess.Context
{
	public static class TriatlonDbConfiguration
	{
		public static string GetConnectionString()
		{
			return @"Data Source=localhost\;Initial Catalog=TriatlonDb;Integrated Security=True;";
		}
	}
}
