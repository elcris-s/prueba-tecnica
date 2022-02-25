using Books_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;
using System.Web.Http.Description;

namespace Books_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IHttpClientFactory _client;

        public BooksController(IHttpClientFactory client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> Get()
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                List<Books> list_books = await response.Content.ReadFromJsonAsync<List<Books>>();
                return Ok(list_books);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Books>> GetByID(int id)
        {
            var client = _client.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}"); // make request
            if (response.IsSuccessStatusCode)
            {
                Books book = await response.Content.ReadFromJsonAsync<Books>();
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Books book)
        {
            if (ModelState.IsValid)
            {
                var client = _client.CreateClient("Books");

                var book_json = JsonConvert.SerializeObject(book); 
                var response_content = new StringContent(book_json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress.ToString(), response_content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(book);
                }
                else
                {
                    return BadRequest(book);
                }
            }
            return BadRequest(book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] Books book)
        {
            var client = _client.CreateClient("Books");

            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (ModelState.IsValid)
                {
                    var book_json = JsonConvert.SerializeObject(book);
                    var response_content = new StringContent(book_json, Encoding.UTF8, "application/json");
                    var put_response = await client.PutAsync($"{client.BaseAddress}/{id}", response_content);

                    if (put_response.IsSuccessStatusCode)
                    {
                        return Ok(book);
                    }
                    else
                    {
                        return BadRequest(book);
                    }
                }
                return BadRequest();
            }
            return NotFound(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = _client.CreateClient("Books");

            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var delete_response = await client.DeleteAsync($"{client.BaseAddress}/{id}");

                if (delete_response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}
