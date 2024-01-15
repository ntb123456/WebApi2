using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiplyWebAPI.Controllers
{
    public class HomenewController : Controller
    {
        // GET: HomenewController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomenewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomenewController/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // GET: HomenewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Edit2(int id)
        {
            return View();
        }

        // POST: HomenewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomenewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomenewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
