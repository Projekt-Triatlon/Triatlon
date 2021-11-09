using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TriatlonLogic.DataTransferObjects
{

	public class EredmenyDisplayDto
	{
		public long OID { get; set; }
		public string VersenyNev { get; set; }
		public string VersenyzoNev { get; set; }
		public string ChipKod { get; set; }
		public TimeSpan UszasIdo { get; set; }
		public TimeSpan Depo1Ido { get; set; }
		public TimeSpan KerekparIdo { get; set; }
		public TimeSpan Depo2Ido { get; set; }
		public TimeSpan FutasIdo { get; set; }
		
		
	}
}
