﻿using System;
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
        IUnitPriceService _unitPriceService;
        public UnitPriceController(IUnitPriceService unitPriceService)
        {
            _unitPriceService = unitPriceService;
        }

        [HttpPost]
        public IActionResult Post([FromBody][Required]IEnumerable<Input> requests)
        {
            if (!ModelState.IsValid || requests == null || requests.Count() == 0)
                return BadRequest(ModelState);
            try
            {
                _unitPriceService.AddUnitPriceData(requests);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var unitPrices = _unitPriceService.GetUnitPrices(unitPriceType);
                return Ok(unitPrices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//shout/catch/throw/log
            }
        }
    }
}