using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.Managers;
using TriatlonLogic.Models;

namespace Triatlon.Controllers
{
	public class KoridoController : Controller
	{
		// GET: KoridoController
		public ActionResult Index()
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.GetAll();

			return View(koridok);
		}


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
						return RedirectToAction("Select", "Eredmeny", new { area = "" });
					}

					var koridoManager = TDI.Resolve<KoridoManager>();
					var koridok = new List<Korido>();
					using (var sreader = new StreamReader(postedFile.OpenReadStream()))
					{

						//string[] headers = sreader.ReadLine().Split(';');
						while (!sreader.EndOfStream)
						{
							string[] rows = sreader.ReadLine().Split(';');

							koridoManager.Add(new Korido
							{
								//OID = Int64.Parse(rows[0].ToString()),
								ChipKod = rows[0].ToString(),
								Szakasz = rows[1].ToString(),
								KorSzama = Int32.Parse(rows[2].ToString()),
								Ido = TimeSpan.Parse(rows[3].ToString()),
								VersenyVersenyzoOID = Int64.Parse(rows[4].ToString())
							});

						}
					}

					return RedirectToAction("Select", "Eredmeny", new { area = "" });
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
			return RedirectToAction("Select", "Eredmeny", new { area = "" });
		}

		public ActionResult List(long oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.GetKoridok(oid);

			return View(koridok);
		}

		// GET: KoridoController/Details/5
		public ActionResult Details(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		// GET: KoridoController/Create
		public ActionResult Create()
		{
			return View(new Korido());
		}

		// POST: KoridoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var korido = new Korido()
				{
					ChipKod = collection["ChipKod"],
					Szakasz = collection["Szakasz"],
					KorSzama = Convert.ToInt32(collection["KorSzama"]),
					Ido = TimeSpan.Parse(collection["Ido"]),
					VersenyVersenyzoOID = Int64.Parse(collection["VersenyVersenyzoOID"]),
				};

				var koridoManager = TDI.Resolve<KoridoManager>();
				koridoManager.Add(korido);

				//return RedirectToAction(nameof(Index));
				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}
			catch
			{
				return View();
			}
		}

		// GET: KoridoController/Edit/5
		public ActionResult Edit(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		// POST: KoridoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var koridoManager = TDI.Resolve<KoridoManager>();

				var tempKorido = new Korido()
				{
					OID = oid,
					ChipKod = collection["ChipKod"],
					Szakasz = collection["Szakasz"],
					KorSzama = Convert.ToInt32(collection["KorSzama"]),
					Ido = TimeSpan.Parse(collection["Ido"]),
					VersenyVersenyzoOID = Int64.Parse(collection["VersenyVersenyzoOID"]),
				};

				koridoManager.Update(tempKorido);

				//return RedirectToAction(nameof(Index));
				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}
			catch
			{
				return View();
			}
		}

		// GET: KoridoController/Delete/5
		public ActionResult Delete(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		// POST: KoridoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var koridoManager = TDI.Resolve<KoridoManager>();
				koridoManager.Delete(oid);

				//return RedirectToAction(Request.UrlReferrer.ToString());
				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}

			catch
			{
				return View();
			}
		}
	}
}
