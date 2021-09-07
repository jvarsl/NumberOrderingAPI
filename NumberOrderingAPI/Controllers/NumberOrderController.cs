using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;


namespace NumberOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOrderController : Controller
    {
        [HttpGet]
        public ActionResult GetNumbers()
        {
            var content = Methods.ETLTools.ReturnFileContent();
            if (content is null || !content.Any())
            {
                return NotFound();
            }
            return Ok(content);
        }

        [HttpPost]
        public ActionResult PostNumbers([FromQuery] string input) //[FromBody] string[] input - if we accept json body
        {
            //validation and conversion to list
            List<BigInteger> valuesList;
            try
            {
                valuesList = Methods.ETLTools.StringToBigIntArray(input); //input.FirstOrDefault() - if we accept json body
            }
            catch (ArgumentException e)
            {
                if (e is ArgumentException || e is ArgumentNullException)
                {
                    return BadRequest(e.Message);
                }

                throw;
            }

            //sorting and writting results into file
            var sw = Stopwatch.StartNew();
            var sortedValues = Methods.SortingExtensions.BubbleSort(valuesList);
            sw.Stop();
            Methods.ETLTools.WriteIntoFile(sortedValues);
            Methods.ETLTools.WriteIntoFile($"Bubble sort: {sw.Elapsed}");

            sw.Restart();
            _ = Methods.SortingExtensions.SelectionSort(valuesList);
            sw.Stop();
            Methods.ETLTools.WriteIntoFile($"Selection sort: {sw.Elapsed}");


            return Created("", "File created");
        }
    }
}
