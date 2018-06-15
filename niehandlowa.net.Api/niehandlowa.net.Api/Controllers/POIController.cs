﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using niehandlowa.net.Bll.Models;
using niehandlowa.net.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace niehandlowa.net.Api.Controllers
{
    [Route("api/poi")]
    public class POIController : Controller
    {
        private readonly IPOIService _POIService;

        public POIController(IPOIService POIService)
        {
            _POIService = POIService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] POIModel model)
        {
            await _POIService.Create(model);
            return StatusCode(201);
        }

        [HttpGet("getPOI")]
        public async Task<IActionResult> GetPOI()
        {
            return Ok((await _POIService.GetAllPOIs()).First());
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _POIService.GetAllPOIs());
        }

        [HttpGet("GetPOIsByTypes/{types}")]
        public async Task<IActionResult> GetPOIsByTypes([FromRoute] string types)
        {
            List<string> splittedTypes = types.Split(',').ToList();
            List<int> typesInts = new List<int>();
            foreach (var splittedString in splittedTypes)
            {
                typesInts.Add(Int32.Parse(splittedString));
            }
            return Ok(await _POIService.GetPOIsByTypesList(typesInts));
        }

        [HttpGet("GetPOIsWithinDistance/{latitude}/{longtitude}/{distance}")]
        public async Task<IActionResult> GetPOIsWithinDistance([FromRoute] double latitude, [FromRoute] double longtitude, [FromRoute] int distance)
        {
            return Ok(await _POIService.GetPOIsWithinDistance(latitude, longtitude, distance));
        }

        [HttpGet("GetPOIsWithinDistanceByTypesList/{latitude}/{longtitude}/{distance}/{types}")]
        public async Task<IActionResult> GetPOIsWithinDistanceByTypesList([FromRoute] double latitude, [FromRoute] double longtitude, [FromRoute] int distance, [FromRoute] string types)
        {
            List<string> splittedTypes = types.Split(',').ToList();
            List<int> typesInts = new List<int>();
            foreach (var splittedString in splittedTypes)
            {
                typesInts.Add(Int32.Parse(splittedString));
            }

            return Ok(await _POIService.GetPOIsWithinDistanceByTypesList(latitude, longtitude, distance, typesInts));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] POIModel model)
        {
            await _POIService.Update(model);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _POIService.Delete(id);
            return Ok();
        }

        [HttpGet("GetNowOpenPOIs")]
        public async Task<IActionResult> GetNowOpenPOIs()
        {
            return Ok(await _POIService.GetNowOpenPOIs());
        }
    }
}