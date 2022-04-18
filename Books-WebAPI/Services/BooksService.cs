using Books_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Books_WebAPI.Services
{
    public class BooksService : IBook
    {
        private readonly IHttpClientFactory _client;

        public BooksService(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<ActionResult<List<Books>>> Get()
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                List<Books> list_books = await response.Content.ReadFromJsonAsync<List<Books>>();
                return list_books;
            }
            return null;
        }

        public async Task<ActionResult<Books>> GetByID(int id)
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                Books book = await response.Content.ReadFromJsonAsync<Books>();
                return book;
            }
            return null;
        }

        public Task<ActionResult> Post([FromBody] Books book)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Put(int id, [FromBody] Books book)
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
