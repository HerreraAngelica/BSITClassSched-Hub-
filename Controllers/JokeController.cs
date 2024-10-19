using BSIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BSIT.Controllers
{
    public class JokeController : Controller
    {
        // GET: JokeController1
        public async Task<IActionResult> Index()
        {
            string url = "https://official-joke-api.appspot.com/random_joke";
            using HttpClient client = new HttpClient();
            Joke joke = null;

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                joke = JsonConvert.DeserializeObject<Joke>(result);
            }

            return View(joke); // Pass the joke object to the view
        }

        // GET: JokeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JokeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JokeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: JokeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JokeController1/Edit/5
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

        // GET: JokeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JokeController1/Delete/5
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
