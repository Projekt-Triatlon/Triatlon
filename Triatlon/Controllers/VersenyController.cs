using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.Managers;
using TriatlonLogic.Models;

namespace Triatlon.Controllers
{
	public class VersenyController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public VersenyController(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}


		// GET: VersenyController
		public ActionResult Index()
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var versenyek = versenyManager.GetAll();
			return View(versenyek);
		}

		public ActionResult Details(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}



		public ActionResult Create()
		{
			//var versenyManager = TDI.Resolve<VersenyManager>();
			//var versenyCreateDto = versenyManager.GetVersenyCreateDto();

			return View(new Verseny());
		}

		public ActionResult CreateFull()
		{
			//var versenyManager = TDI.Resolve<VersenyManager>();
			//var versenyCreateDto = versenyManager.GetVersenyCreateDto();

			return View(new Verseny());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var verseny = new Verseny()
				{
					Nev = collection["Nev"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag= Convert.ToDouble(collection["UTavolsag"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
				};

				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Add(verseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateFull(IFormCollection collection)
		{
			try
			{
				var verseny = new Verseny()
				{
					Nev = collection["Nev"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = Convert.ToBoolean(collection["UNeopren"]),
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Add(verseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		public ActionResult EditFull(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();

				var tempVerseny = new Verseny()
				{
					OID = oid,
					Nev = collection["Nev"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = Convert.ToBoolean(collection["UNeopren"]),
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				versenyManager.Update(tempVerseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditFull(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();

				var tempVerseny = new Verseny()
				{
					OID = oid,
					Nev = collection["Nev"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = false,
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				versenyManager.Update(tempVerseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		// POST: VersenyzoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Delete(oid);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}

}
