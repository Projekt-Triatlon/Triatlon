using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.Managers;
using TriatlonLogic.Models;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using System.Text;

namespace Triatlon.Controllers
{
	public class VersenyzoController : Controller
	{
		public ActionResult Index()
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzoList = versenyzoManager.GetAll();

			return View(versenyzoList);
		}


		//public ActionResult Index()
		//{
		//	return View();
		//}

		[HttpPost]
		public ActionResult Index(IFormFile postedFile)
		{
			if (postedFile != null)
			{
				try
				{
					string fileExtension = Path.GetExtension(postedFile.FileName);

					if (fileExtension != ".csv")
					{
						ViewBag.Message = "Csak .csv kiterjesztésű fájlt adhat meg!";
						return RedirectToAction(nameof(Index));
					}

					var versenyzoManager = TDI.Resolve<VersenyzoManager>();
					var versenyzok = new List<Versenyzo>();
					using (var sreader = new StreamReader(postedFile.OpenReadStream()))
					{

						//string[] headers = sreader.ReadLine().Split(';');
						while (!sreader.EndOfStream)
						{
							string[] rows = sreader.ReadLine().Split(';');

							versenyzoManager.Add(new Versenyzo
							{
								//OID = Int64.Parse(rows[0].ToString()),
								Nev = rows[0].ToString(),
								Nem = rows[1].ToString(),
								SzulIdo = DateTime.Parse(rows[2].ToString()),
								Egyesulet = rows[3].ToString(),
								Licence = rows[4].ToString()
							});

						}
					}

					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					ViewBag.Message = ex.Message;
				}
			}
			else
			{
				ViewBag.Message = "Kérem válassza ki a CSV fájlt először.";
			}
			return RedirectToAction(nameof(Index));
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

		public ActionResult DeleteAll()
		{
			var versenyzoManager = TDI.Resolve<VersenyzoManager>();
			var versenyzoList = versenyzoManager.GetAll();


			foreach (var item in versenyzoList)
			{
				versenyzoManager.Delete(item.OID);
			}

			return RedirectToAction("Index", "Versenyzo");
		}

	}
}
