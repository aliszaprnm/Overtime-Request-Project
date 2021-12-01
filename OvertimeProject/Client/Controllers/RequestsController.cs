using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class RequestsController : BaseController<Request, RequestRepository, int>
    {
        public readonly RequestRepository repository;
        public RequestsController(RequestRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*public JsonResult AddRequest(OvertimeFormVM entity)
        {
            var result = repository.ApplyOvertime(entity);
            return Json(result);
        }*/
        public async Task<JsonResult> GetReq(int requestId)
        {
            var result = await repository.GetRequestById(requestId);
            return Json(result);
        }
    }
}
