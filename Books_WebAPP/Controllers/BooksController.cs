using Books_WebAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Books_WebAPP.Controllers
{
    public class BooksController : Controller
    {
        private readonly IHttpClientFactory _client;

        public BooksController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                List<Books> list_books = await response.Content.ReadFromJsonAsync<List<Books>>();
                return View(list_books);
            }
            return View();
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Books book)
        {
            var client = _client.CreateClient("Books");

            var book_json = JsonConvert.SerializeObject(book);
            var response_content = new StringContent(book_json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(client.BaseAddress.ToString(), response_content);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                Books book = await response.Content.ReadFromJsonAsync<Books>();
                return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Books book)
        {
            var client = _client.CreateClient("Books");

            var book_json = JsonConvert.SerializeObject(book);
            var response_content = new StringContent(book_json, Encoding.UTF8, "application/json");
            var put_response = await client.PutAsync($"{client.BaseAddress}/{id}", response_content);

            if (put_response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}"); 
            if (response.IsSuccessStatusCode)
            {
                Books book = await response.Content.ReadFromJsonAsync<Books>();
                return View(book);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id, string? error)
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                Books book = await response.Content.ReadFromJsonAsync<Books>();
                if(error == "true")
                {
                    ViewBag.ErrorMessage = "La peticion no se realizo de manera correcta";
                }
                return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete_Method(int id)
        {
            var client = _client.CreateClient("Books");
            var delete_response = await client.DeleteAsync($"{client.BaseAddress}/{id}");

            if (delete_response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete", new { id = id , error = "true"});
            }
        }
    }
}
