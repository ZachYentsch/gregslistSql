// using gregslistSql.Models;
// using gregslistSql.Services;
// using Microsoft.AspNetCore.Mvc;

// namespace gregslistSql.Controllers
// {
//     [ApiController]
//     [Route("api/[Controller]")]
//     public class JobsController : ControllerBase
//     {
//         private readonly JobsService _js;
//         public JobsController(JobsService js)
//         {
//             _js = js;
//         }

//         // NOTE GET ALL
//         [HttpGet]
//         public ActionResult<List<Job>> getAll()
//         {
//             try
//             {
//                 return Ok(_js.getAll());
//             }
//             catch (System.Exception e)
//             {
//                 return new BadRequestObjectResult(e.Message);
//             }
//         }

//         // NOTE GET BY ID
//         [HttpGet("{jobId}")]
//         public ActionResult<Job> getById(string jobId)
//         {
//             try
//             {
//                 Job? foundJob = _js.getById(jobId);
//                 return foundJob;
//             }
//             catch (System.Exception e)
//             {
//                 return new BadRequestObjectResult(e.Message);
//             }
//         }

//         //  NOTE CREATE
//         [HttpPost]
//         public ActionResult<Job> create([FromBody] Job newJob)
//         {
//             try
//             {
//                 return Ok(_js.Create(newJob));
//             }
//             catch (System.Exception e)
//             {
//                 return new BadRequestObjectResult(e.Message);
//             }
//         }

//         // NOTE EDIT
//         [HttpPut("{jobId}")]
//         public ActionResult<Job> edit([FromBody] Job editedJob, string jobId)
//         {
//             try
//             {
//                 editedJob.Id = jobId;
//                 Job updatedJob = _js.Edit(editedJob, jobId);
//                 return Ok(updatedJob);
//             }
//             catch (System.Exception e)
//             {
//                 return new BadRequestObjectResult(e.Message);
//             }
//         }
//         // NOTE DELETE
//         [HttpDelete("{jobId}")]
//         public ActionResult<Job> delete(string jobId)
//         {
//             try
//             {
//                 return Ok(_js.Remove(jobId));
//             }
//             catch (System.Exception e)
//             {
//                 return new BadRequestObjectResult(e.Message);
//             }
//         }
//     }
// }