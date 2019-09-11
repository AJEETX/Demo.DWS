using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Demo.DWS.Model;
using Demo.DWS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo.DWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitPriceController : ControllerBase
    {
        IFileService _fileService;
        public UnitPriceController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public IActionResult Post([FromBody][Required]IEnumerable<Input> requests)
        {
            if (!ModelState.IsValid || requests == null || requests.Count() == 0)
                return BadRequest(ModelState);
            try
            {
                _fileService.AddFileData(requests);
                return Get("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//shout/catch/throw/log
            }
        }
        [HttpGet("{unitPriceType}")]
        public IActionResult Get(string unitPriceType)
        {
            try
            {
                var unitPrices = _fileService.GetUnitPrices(unitPriceType);
                return Ok(unitPrices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//shout/catch/throw/log
            }
        }
    }
}