using System;
using System.Collections.Generic;
using System.Text;
using TriatlonDataAccess.Context;
using TriatlonDataAccess.Interfaces;
using TriatlonLogic.Models;

namespace TriatlonDataAccess.Repositories
{
	
	public class VersenyzoRepository : BaseRepository<Versenyzo, TriatlonContext>, IVersenyzoRepository
	{
	}
}
