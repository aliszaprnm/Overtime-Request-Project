using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeProject.Base;
using OvertimeProject.Models;
using OvertimeProject.Repository.Data;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : BaseController<Request, RequestRepository, int>
    {
        public readonly RequestRepository repo;
        public RequestsController(RequestRepository repo) : base(repo)
        {
            this.repo = repo;
        }
        [HttpPost("AddOvertime")]
        public IActionResult AddOvertime(OvertimeFormVM overtimeFormVM)
        {
            if (ModelState.IsValid)
            {
                var data = repo.ApplyRequest(overtimeFormVM);
                if (data > 0)
                {
                    return Ok(new { status = "Request Added" });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error" });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request", errorMessage = "Data input is not valid" });
            }
        }
        [HttpPost("AddListOvertime")]
        public IActionResult AddListOvertime(List<OvertimeFormVM> overtimeFormVM)
        {
            if (ModelState.IsValid)
            {
                var data = repo.ApplyListRequest(overtimeFormVM);
                if (data > 0)
                {
                    return Ok(new { status = "Request Added" });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error" });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request", errorMessage = "Data input is not valid" });
            }
        }
        [HttpGet("GetAllRequest")]
        public ActionResult GetAllRequest()
        {
            var get = repo.GetAllRequest();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
        //id userRequest
        [HttpGet("GetRequestById/{id}")]
        public ActionResult GetRequestById(int id)
        {
            var get = repo.GetRequestById(id);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }

        [HttpGet("GetRequestByStatusAndDate")]
        public ActionResult GetAllRequestByStatusAndDate([FromQuery(Name = "status")] int status, [FromQuery(Name = "requestDate")] DateTime reqDate)
        {
            var get = repo.GetRequestByStatusAndDate(status, reqDate);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }

        [HttpGet("GetRequestByStatusAndNIKAndDate")]
        public ActionResult GetAllRequestByStatusAndNIKAndDate([FromQuery(Name = "status")] int status, [FromQuery(Name = "NIK")] string NIK, [FromQuery(Name = "requestDate")] DateTime reqDate)
        {
            var get = repo.GetRequestByStatusAndNIKAndDate(status, NIK, reqDate);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }

        [HttpGet("GetRequestByNIK/{NIK}")]
        public ActionResult GetRequestByNIK(string NIK)
        {
            var get = repo.GetRequestByNIK(NIK);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        //buat Manager
        [HttpGet("GetAllRequestByStatusAndManagerId")]
        public ActionResult GetAllRequestByStatusAndManagerId([FromQuery(Name = "status")] int status, [FromQuery(Name = "managerId")] string managerId)
        {
            var get = repo.GetAllRequestByStatusAndManagerId(status, managerId);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [HttpGet("GetAllRequestByStatAndManagerId")]
        public ActionResult GetAllRequestByStatAndManagerId([FromQuery(Name = "status")] int status, [FromQuery(Name = "managerId")] string managerId)
        {
            var get = repo.GetAllRequestByStatAndManagerId(status, managerId);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [HttpGet("GetAllRequestByStatusAndNIK")]
        public ActionResult GetAllRequestByStatusAndNIK([FromQuery(Name = "status")] int status, [FromQuery(Name = "NIK")] string NIK)
        {
            var get = repo.GetAllRequestByStatusAndNIK(status, NIK);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        //buat Finance
        [HttpGet("GetAllRequestByStat")]
        public ActionResult GetAllRequestByStat([FromQuery(Name = "status")] int status)
        {
            var get = repo.GetAllRequestByStat(status);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [HttpGet("GetAllRequestByStatus")]
        public ActionResult GetAllRequestByStatus([FromQuery(Name = "status")] int status)
        {
            var get = repo.GetAllRequestByStatus(status);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("No Record");
            }
        }
        [HttpPut("Approval")]
        public IActionResult ApprovalRequest(ApprovalVM approvalVM)
        {
            if (ModelState.IsValid)
            {
                var approve = repo.ApproveRequest(approvalVM);
                if (approve > 0)
                {
                    if (approvalVM.Status == 3)
                    {
                        return Ok(new { status = "Rejected" });
                    }
                    else
                    {
                        return Ok(new { status = "Approved" });
                    }
                }
                else
                {
                    return Ok(new { status = "Cannot Change Request Error" });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request", errorMessage = "Data input is not valid" });
            }
        }
    }
}
