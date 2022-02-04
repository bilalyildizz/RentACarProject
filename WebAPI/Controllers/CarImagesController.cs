using System;
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
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]

        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);

            if (result.Success)
            {
                return Ok("Ekleme Başarılı");

            }

            return BadRequest(" İşlem Başarısız");

        }

        [HttpPost("delete")]
        public IActionResult Delete( [FromForm] int Id)
        {
            var carImage = _carImageService.GetById(Id).Data;
            if (carImage == null)
            {
                return BadRequest( Id +" nlll");
            }
            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok("Silme Başarılı");

            }

            return BadRequest(" İşlem Başarısız");

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] int Id)
        {
            var carImage = _carImageService.GetById(Id).Data;
            var result = _carImageService.Update(file,carImage);


            if (result.Success)
            {
                return Ok("Silme Başarılı");

            }

            return BadRequest(" İşlem Başarısız");

        }

    }
}
