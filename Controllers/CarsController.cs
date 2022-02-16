using System.Collections.Generic;
using gregslistSql.Models;
using gregslistSql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistSql.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;
        public CarsController(CarsService cs)
        {
            _cs = cs;
        }

        // NOTE GET ALL
        [HttpGet]
        public ActionResult<List<Car>> getAll()
        {
            try
            {
                return Ok(_cs.get());
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE GET BY ID
        [HttpGet("{carId}")]
        public ActionResult<Car> getById(int carId)
        {
            try
            {
                Car foundCar = _cs.getById(carId);
                return foundCar;
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE CREATE
        [HttpPost]
        public ActionResult<Car> create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_cs.Create(newCar));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE EDIT
        [HttpPut("{id}")]
        public ActionResult<Car> edit([FromBody] Car updated, int id)
        {
            try
            {
                updated.Id = id;
                Car updatedCar = _cs.Edit(updated, id);
                return Ok(updatedCar);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE DELETE
        [HttpDelete("{id}")]
        public ActionResult<Car> delete(int id)
        {
            try
            {
                _cs.remove(id);
                return Ok("Deleted");
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
};
