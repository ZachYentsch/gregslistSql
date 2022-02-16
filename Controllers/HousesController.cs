using System.Collections.Generic;
using gregslistSql.Models;
using gregslistSql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistSql.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _hs;
        public HousesController(HousesService hs)
        {
            _hs = hs;
        }

        // NOTE GET ALL
        [HttpGet]
        public ActionResult<List<House>> getAll()
        {
            try
            {
                return Ok(_hs.get());
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE GET BY ID
        [HttpGet("{id}")]
        public ActionResult<House> getById(int id)
        {
            try
            {
                House foundHouse = _hs.getById(id);
                return foundHouse;
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE CREATE
        [HttpPost]
        public ActionResult<House> create([FromBody] House newHouse)
        {
            try
            {
                return Ok(_hs.Create(newHouse));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE EDIT
        [HttpPut("{id}")]
        public ActionResult<House> edit([FromBody] House updated, int id)
        {
            try
            {
                updated.Id = id;
                House updatedHouse = _hs.Edit(updated, id);
                return Ok(updatedHouse);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE DELETE
        [HttpDelete("{id}")]
        public ActionResult<House> delete(int id)
        {
            try
            {
                _hs.Remove(id);
                return Ok("House Deleted");
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}