using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using InventoryRental.DAL;
using InventoryRental.Models;

namespace InventoryRental.Controllers
{
    public class ToolsController : Controller
    {
        private InventoryContext db = new InventoryContext();


        public static List<Tool> toolList = new List<Tool>
        {
            new Tool{ToolId = 1, Name = "Drill"},
            new Tool{ToolId = 2, Name = "Axe"},
            new Tool{ToolId = 3, Name = "Hammer"},

        };

        public ActionResult Index()
        {
            
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Tools").Result;
            // we are using IEnumerable because we only want to enumerate the collection and we are not going to add or delete elements
            IEnumerable<Tool> tools = response.Content.ReadAsAsync<IEnumerable<Tool>>().Result;
            return View(tools);
        }

        public ActionResult Edit(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tools/{Id}").Result;
            var tool = response.Content.ReadAsAsync<Tool>().Result;
            return View(tool);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Tool tool )
        {
            try {
                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Tools/{Id}", tool).Result;
                //we will refer to this in the Index.cshtml of the Tool so alertify can display the message.
                TempData["SuccessMessage"] = "Saved successfully.";

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View(tool);
            }
            catch {
                return View();
            }
        }

        public ActionResult Details(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tools/{Id}").Result;
            var tool = response.Content.ReadAsAsync<Tool>().Result;
            return View(tool);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tool tool)
        {
            try {
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Tools", tool).Result;
                //we will refer to this in the Index.cshtml of the Tool so alertify can display the message.
                TempData["SuccessMessage"] = "Tool added successfully.";

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }


        public ActionResult DisplayInventory()
        {
            var tool = new Tool() { Name = "The Avengers" };

            return View(tool);
        }

        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tools/{Id}").Result;
            var tool = response.Content.ReadAsAsync<Tool>().Result;
            return View(tool);
        }

        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Tools/{Id}").Result;
                //we will refer to this in the Index.cshtml of the Tool so alertify can display the message.
                TempData["SuccessMessage"] = "Tool deleted successfully.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}