﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }



        [HttpGet("getbyid")]

        public IActionResult GetById(int Id)
        {
            var result = _colorService.GetById(Id);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]

        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Upgrade(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }



    }
}
