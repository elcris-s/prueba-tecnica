using Books_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_WebAPI.Services
{
    public interface IBook
    {
        public Task<ActionResult<List<Books>>> Get();
        public Task<ActionResult<Books>> GetByID(int id);
        public Task<ActionResult> Post([FromBody] Books book);
        public Task<ActionResult> Put(int id, [FromBody] Books book);
        public Task<ActionResult> Delete(int id);

    }
}
