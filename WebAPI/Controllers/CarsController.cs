using Business.Abstract;
using Business.Constants;
using Entities.Contrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarManager _carManager;

        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }

        [HttpGet("getallbydetails")]
        //[Authorize()]
        public IActionResult GetCarDetailDtos()
        {
            Thread.Sleep(1000);
            var result = _carManager.GetCarDetailDtos();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailpagebyid")]
        //[Authorize()]
        public IActionResult GetCarDetailPageById(int id)
        {
            
            var result = _carManager.GetCarDetailPageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        //[Authorize()]
        public IActionResult GetByBrand(int id)
        {
            var result = _carManager.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolor")]
        //[Authorize()]
        public IActionResult GetByColor(int id)
        {
            var result = _carManager.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("getcardetailsbybrandname")]
        //public IActionResult GetCarDetailsByBrandName(string brandName)
        //{
        //    var result = _carManager.GetCarDetailsByBrandName(brandName);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getcardetailsbycolorname")]
        //public IActionResult GetCarDetailsByColorName(string colorName)
        //{
        //    var result = _carManager.GetCarDetailsByColorName(colorName);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpGet("getall")]
        //[Authorize()]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);

            var result = _carManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.Success==true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
