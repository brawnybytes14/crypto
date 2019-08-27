// <copyright company="appZUI">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Rohit Kori</author>
// <date>08/22/2019</date>
using Microsoft.AspNetCore.Mvc;

namespace Crypto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiKeysController : ControllerBase
    {
        private readonly CryptoDbContext _context;
        public ApiKeysController(CryptoDbContext context)
        {
            _context = context;
        }
        // GET: api/ApiKeys
        [HttpGet]
        public ActionResult Get()
        {
            //try
            //{
            //    ApiKey key = new ApiKey();
            //    key.Key = Guid.NewGuid().ToString();
            //    _context.Add(key);
            //    _context.SaveChanges();

            //    return Ok(key.Key);

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return NotFound();

        }

    }
}
