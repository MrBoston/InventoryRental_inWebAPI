﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using InventoryRental.DAL;
using InventoryRental.Models;

namespace InventoryRental.Controllers
{
    public class CustomersController : Controller
    {
        private InventoryContext db = new InventoryContext();

        public static List<Customer> customerList = new List<Customer>
        {
            new Customer{CustomerId = 1, FName = "John Smith", Phone="3390 0675"},
            new Customer{CustomerId = 2, FName = "Mary Parks", Phone="3855 1515"},
            new Customer{CustomerId = 3, FName = "Robert Boyd", Phone="3290 9090"},

        };

        // GET: Customers
        public ActionResult Index()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Customers").Result;
            IEnumerable<Customer> customers = response.Content.ReadAsAsync < IEnumerable<Customer>>().Result;
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Customers/{Id}").Result;
            var customer = response.Content.ReadAsAsync<Customer>().Result;
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Customers", customer).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Customers/{Id}").Result;
            var customer = response.Content.ReadAsAsync<Customer>().Result;
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Customer customer)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Customers/{Id}", customer).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int Id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Customers/{Id}").Result;
            var customer = response.Content.ReadAsAsync<Customer>().Result;

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, Customer customer)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Customers/{Id}").Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}