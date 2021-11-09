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
	public class VersenyzoController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public VersenyzoController(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		public ActionResult Index()
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzoList = versenyzoManager.GetAll();

			return View(versenyzoList);
		}

		// GET: VersenyzoController/Details/5
		public ActionResult Details(int oid)
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzo = versenyzoManager.Get(oid);

			return View(versenyzo);
		}

		public ActionResult Create()
		{
			return View(new Versenyzo());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var versenyzoManager = TDI.Resolve<VersenyzoManager>();

				var versenyzo = new Versenyzo()
				{
					Nev = collection["Nev"],
					Nem = collection["Nem"],
					SzulIdo = Convert.ToDateTime(collection["SzulIdo"]),
					Egyesulet = collection["Egyesulet"],
					Licence = collection["Licence"]
				};

				versenyzoManager.Add(versenyzo);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: VersenyzoController/Edit/5
		public ActionResult Edit(int oid)
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzo = versenyzoManager.Get(oid);

			return View(versenyzo);
		}

		// POST: VersenyzoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var versenyzoManager = TDI.Resolve<VersenyzoManager>();

				var tempVersenyzo = new Versenyzo()
				{
					OID = oid,
					Nev = collection["Nev"],
					Nem = collection["Nem"],
					SzulIdo = Convert.ToDateTime(collection["SzulIdo"]),
					Egyesulet = collection["Egyesulet"],
					Licence = collection["Licence"],
				};

				versenyzoManager.Update(tempVersenyzo);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: VersenyzoController/Delete/5
		public ActionResult Delete(int oid)
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzo = versenyzoManager.Get(oid);

			return View(versenyzo);
		}

		// POST: VersenyzoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var versenyzoManager = TDI.Resolve<VersenyzoManager>();
				//versenyzoManager.SetDeleted(oid);
				versenyzoManager.Delete(oid);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
