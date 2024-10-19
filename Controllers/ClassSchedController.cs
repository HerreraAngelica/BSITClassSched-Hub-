using BSIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

namespace BSIT.Controllers
{
    public class ClassSchedController : Controller
    {

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:7276/api/schedule/classSchedules";
            List<Schedule> schedules = new List<Schedule>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    schedules = JsonConvert.DeserializeObject<List<Schedule>>(result);
                }
            }

            return View(schedules);
        }

        // GET: ClassSchedController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassSchedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassSchedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Schedule schedule)
        {
            string apiUrl = "https://localhost:7276/api/schedule/classSchedules";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(schedule), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(schedule);
        }

        // GET: ClassSchedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassSchedController/Edit/5
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

        // GET: ClassSchedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassSchedController/Delete/5
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
