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
	public class EredmenyController : Controller
	{
		public ActionResult Index()
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmenyek = eredmenyManager.GetAll();

			return View(eredmenyek);
		}

		// GET: EredmenyController/Details/5
		public ActionResult Details(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.GetEredmenyDisplayDto(oid);

			return View(eredmeny);
		}

		public ActionResult Create()
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmenyCreateDto = eredmenyManager.GetEredmenyCreateDto();

			return View(eredmenyCreateDto);


			//return View(new VersenyVersenyzo());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var eredmeny = new VersenyVersenyzo();
				eredmeny.ChipKod = collection["ChipKod"];
				eredmeny.UszasIdo = TimeSpan.Parse(collection["UszasIdo"]);
				eredmeny.Depo1Ido = TimeSpan.Parse(collection["Depo1Ido"]);
				eredmeny.KerekparIdo = TimeSpan.Parse(collection["KerekparIdo"]);
				eredmeny.Depo2Ido = TimeSpan.Parse(collection["Depo2Ido"]);
				eredmeny.FutasIdo = TimeSpan.Parse(collection["FutasIdo"]);
				eredmeny.VersenyzoOID = Convert.ToInt64(collection["VersenyzoOID"]);
				eredmeny.VersenyOID = Convert.ToInt64(collection["VersenyOID"]);

				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				eredmenyManager.Add(eredmeny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: EredmenyController/Edit/5
		public ActionResult Edit(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.Get(oid);

			return View(eredmeny);
		}

		// POST: EredmenyController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();

				var tempEredmeny = new VersenyVersenyzo()
				{
					OID = oid,
					ChipKod = collection["ChipKod"],
					UszasIdo = TimeSpan.Parse(collection["UszasIdo"]),
					Depo1Ido = TimeSpan.Parse(collection["Depo1Ido"]),
					KerekparIdo = TimeSpan.Parse(collection["KerekparIdo"]),
					Depo2Ido = TimeSpan.Parse(collection["Depo2Ido"]),
					FutasIdo = TimeSpan.Parse(collection["FutasIdo"]),
					//VersenyzoOID = Convert.ToInt32(collection["VersenyzoOID"]),
					//VersenyOID = Convert.ToInt32(collection["VersenyOID"]),
				};

				eredmenyManager.Update(tempEredmeny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: EredmenyController/Delete/5
		public ActionResult Delete(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.Get(oid);

			return View(eredmeny);
		}

		// POST: EredmenyController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				//eredmenyManager.SetDeleted(oid);
				eredmenyManager.Delete(oid);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
