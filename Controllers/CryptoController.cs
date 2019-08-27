// <copyright company="appZUI">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Rohit Kori</author>
// <date>08/22/2019</date>
using Crypto.Dtos;
using Crypto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Crypto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoDbContext _context;
        public CryptoController(CryptoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<History>> histories()
        {
            //try
            //{
            //    return Ok(_context.Histories.ToList());
            //}

            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return NotFound();
        }

        // POST: api/Crypto
        [HttpPost]
        public ActionResult Encrypt([FromBody] PathDto path, [FromHeader] string authorization)
        {
            try
            {
                var isAuthorized = _context.ApiKeys.Any(a => a.Key == authorization);
                if (String.IsNullOrEmpty(authorization) || !isAuthorized)
                {
                    return Unauthorized("Authorization mismatch.");
                }

                if (String.IsNullOrEmpty(path.InputPath) || !System.IO.File.Exists(path.InputPath))
                {
                    return BadRequest("Invaild input path.");
                }

                if (String.IsNullOrEmpty(path.OutputPath) || !Directory.Exists(Path.GetDirectoryName(path.OutputPath)))
                {
                    return BadRequest("Invaild output path.");
                }
                Console.WriteLine("Encryption started...");

                var startTime = DateTime.Now;

                var res = Services.Crypto.Encrypt(path);

                //foreach (string file in Directory.EnumerateFiles(path.InputPath, "*.xml"))
                //{
                //    string contents = System.IO.File.ReadAllText(file);
                //}


                var endTime = DateTime.Now;

                Console.WriteLine("Encryption successful...");

                //save the history
                History history = new History();
                history.FileTitle = Path.GetFileName(path.InputPath);
                history.InputFilePath = path.InputPath;
                history.OutputFilePath = path.OutputPath;
                history.StartTime = startTime;
                history.OperationType = 1;
                history.EndTime = endTime;
                _context.Add(history);
                _context.SaveChanges();

                //var kdj = Image.Jpeg(path.InputPath);
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Crypto
        [HttpPost]
        public ActionResult Decrypt([FromBody] PathDto path, [FromHeader] string authorization)
        {
            try
            {
                var isAuthorized = _context.ApiKeys.Any(a => a.Key == authorization);
                if (String.IsNullOrEmpty(authorization) || !isAuthorized)
                {
                    return Unauthorized("Authorization mismatch.");
                }

                if (String.IsNullOrEmpty(path.InputPath) || !System.IO.File.Exists(path.InputPath))
                {
                    return BadRequest("Invaild input path.");
                }

                if (String.IsNullOrEmpty(path.OutputPath) || !Directory.Exists(Path.GetDirectoryName(path.OutputPath)))
                {
                    return BadRequest("Invaild output path.");
                }
                Console.WriteLine("Decryption started...");
                var startTime = DateTime.Now;

                //string text = System.IO.File.ReadAllText(path.InputPath);
                var res = Services.Crypto.Decrypt(path);

                //System.IO.File.WriteAllText(path.OutputPath, res);

                var endTime = DateTime.Now;

                Console.WriteLine("Decryption successful...");

                //save the history
                History history = new History();
                history.FileTitle = Path.GetFileName(path.InputPath);
                history.InputFilePath = path.InputPath;
                history.OutputFilePath = path.OutputPath;
                history.StartTime = startTime;
                history.OperationType = 0;
                history.EndTime = endTime;
                _context.Add(history);
                _context.SaveChanges();

                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
