using Microsoft.Extensions.Configuration;
using OvertimeProject.Context;
using OvertimeProject.Handler;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeProject.Repository.Data
{
    public class RequestRepository : GeneralRepository<MyContext, Request, int>
    {
        private readonly EmailHandler sendEmail = new EmailHandler();
        private readonly MyContext myContext;
        public IConfiguration configuration { get; }
        public RequestRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            myContext.Set<Request>();
            this.configuration = configuration;
        }
        public int ApplyRequest(OvertimeFormVM overtimeFormVM)
        {
            var request = new Request
            {
                OvertimeName = overtimeFormVM.OvertimeName,
                RequestDate = overtimeFormVM.RequestDate,
                StartTime = overtimeFormVM.StartTime,
                EndTime = overtimeFormVM.EndTime,
                Task = overtimeFormVM.Task,
                Commission = 0
            };
            myContext.Add(request);
            myContext.SaveChanges();
            var userRequest = new UserRequest
            {
                NIK = overtimeFormVM.NIP,
                RequestId = request.RequestId,
                Email = overtimeFormVM.Email,
                Status = StatusRequest.Pending
            };
            myContext.Add(userRequest);
            var result = myContext.SaveChanges();
            return result;
        }
        public int ApplyListRequest(List<OvertimeFormVM> overtimeFormVM)
        {
            var result = 0;
            if (overtimeFormVM.Count == 0)
            {
                return 0;
            }
            foreach (var item in overtimeFormVM)
            {
                var request = new Request
                {
                    OvertimeName = item.OvertimeName,
                    RequestDate = item.RequestDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Task = item.Task,
                    Commission = 0
                };
                myContext.Add(request);
                myContext.SaveChanges();
                var userRequest = new UserRequest
                {
                    NIK = item.NIP,
                    RequestId = request.RequestId,
                    Email = item.Email,
                    Status = StatusRequest.Pending
                };
                myContext.Add(userRequest);
                result = myContext.SaveChanges();
            }
            return result;
        }
        public IEnumerable<OvertimeResponseVM> GetAllRequest()
        {
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                select new OvertimeResponseVM
                {
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        public IEnumerable<OvertimeResponseVM> GetRequestById(int id)
        {
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                where f.UserRequestId == id
                select new OvertimeResponseVM
                {
                    AccountId = e.NIK,
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        public IEnumerable<OvertimeResponseVM> GetRequestByNIK(string NIK)
        {
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                where e.NIK == NIK
                select new OvertimeResponseVM
                {
                    AccountId = e.NIK,
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        //buatManager
        public IEnumerable<OvertimeResponseVM> GetAllRequestByStatusAndManagerId(int status, string managerId)
        {
            var request = StatusRequest.Pending;
            if (status == 1)
            {
                request = StatusRequest.ApproveByManager;
            }
            else if (status == 2)
            {
                request = StatusRequest.ApproveByFinance;
            }
            else if (status == 3)
            {
                request = StatusRequest.Reject;
            }
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                where f.Status == request && e.ManagerId == managerId
                select new OvertimeResponseVM
                {
                    AccountId = e.NIK,
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        public IEnumerable<OvertimeResponseVM> GetAllRequestByStatusAndNIK(int status, string NIK)
        {
            var request = StatusRequest.Pending;
            if (status == 1)
            {
                request = StatusRequest.ApproveByManager;
            }
            else if (status == 2)
            {
                request = StatusRequest.ApproveByFinance;
            }
            else if (status == 3)
            {
                request = StatusRequest.Reject;
            }
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                where f.Status == request && e.NIK == NIK
                select new OvertimeResponseVM
                {
                    AccountId = e.NIK,
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        //buat Finance
        public IEnumerable<OvertimeResponseVM> GetAllRequestByStatus(int status)
        {
            var request = StatusRequest.Pending;
            if (status == 1)
            {
                request = StatusRequest.ApproveByManager;
            }
            else if (status == 2)
            {
                request = StatusRequest.ApproveByFinance;
            }
            else if (status == 3)
            {
                request = StatusRequest.Reject;
            }
            var all = (
                from e in myContext.Employees
                join f in myContext.UserRequests on e.NIK equals f.NIK
                join o in myContext.Requests on f.RequestId equals o.RequestId
                where f.Status == request
                select new OvertimeResponseVM
                {
                    AccountId = e.NIK,
                    RequestId = f.Request.RequestId,
                    OvertimeName = f.Request.OvertimeName,
                    RequestDate = f.Request.RequestDate,
                    NIK = f.NIK,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StartTime = f.Request.StartTime,
                    EndTime = f.Request.EndTime,
                    Task = f.Request.Task,
                    Commission = f.Request.Commission,
                    Status = f.Status
                }).ToList();
            return all;
        }
        public int ListApproveRequest(List<ApprovalVM> approvalVM)
        {
            if (approvalVM.Count == 0)
            {
                return 0;
            }
            foreach (var item in approvalVM)
            {
                UserRequest userRequest = myContext.UserRequests.Find(item.RequestId);
                if (userRequest == null)
                {
                    return 0;
                }
                if (item.Status == 1)
                {
                    userRequest.Status = StatusRequest.ApproveByManager;
                }
                else if (item.Status == 2)
                {
                    userRequest.Status = StatusRequest.ApproveByFinance;
                }
                else if (item.Status == 3)
                {
                    userRequest.Status = StatusRequest.Reject;
                }
                myContext.Update(userRequest);
                myContext.SaveChanges();
            }
            return 1;
        }

        //ubah commission
        public int ApproveRequest(ApprovalVM approvalVM)
        {
            UserRequest userRequest = myContext.UserRequests.Find(approvalVM.RequestId);
            /*var req = myContext.Requests.Where(x => x.RequestId.Equals(approvalVM.RequestId)).FirstOrDefault();*/
            Request request = myContext.Requests.Find(approvalVM.RequestId);
            Employee employees = myContext.Employees.Find(approvalVM.NIK);
            var totalSecStart = (request.StartTime.Hour * 3600) + (request.StartTime.Minute * 60);
            var totalSecEnd = (request.EndTime.Hour * 3600) + (request.EndTime.Minute * 60);
            var diffHours = (totalSecEnd - totalSecStart) / 3600;
            var day = request.RequestDate.ToString("dddd");
            double commision = 0;
            double ket = 0.00578035;
            if (userRequest == null)
            {
                return 0;
            }
            if (approvalVM.Status == 1)
            {
                userRequest.Status = StatusRequest.ApproveByManager;
                sendEmail.SendApproveNotificationToEmployeebyManager(userRequest.Email);
            }
            else if (approvalVM.Status == 2)
            {
                if (day == "Saturday" || day == "Sunday")
                {
                    if ((int)diffHours <= 8)
                    {
                        commision += ((int)diffHours) * 2 * ket * employees.Salary;
                    }
                    else if ((int)diffHours == 9)
                    {
                        commision += 8 * 2 * ket * employees.Salary;
                        commision += 3 * ket * employees.Salary;
                    }
                    else if ((int)diffHours >= 9)
                    {
                        commision += 8 * 2 * ket * employees.Salary;
                        commision += 3 * ket * employees.Salary;
                        commision += ((int)diffHours - 9) * 4 * ket * employees.Salary;
                    }
                }
                else
                {
                    if ((int)diffHours == 1)
                    {
                        commision += 1 * 1.5 * ket * employees.Salary;
                    }
                    else if ((int)diffHours >= 1)
                    {
                        commision += 1 * 1.5 * ket * employees.Salary;
                        commision += ((int)diffHours - 1) * 2 * ket * employees.Salary;
                    }
                }
                commision = Math.Round(commision, 2);
                userRequest.Status = StatusRequest.ApproveByFinance;
                request.Commission = (int)commision;
                sendEmail.SendApproveNotificationToEmployeebyFinance(userRequest.Email);
            }
            /*else if (approvalVM.Status == 2)
            {
                userRequest.Status = StatusRequest.Reject;
                sendEmail.SendApproveNotificationToEmployeebyFinance(userRequest.Email);
            }*/
            else if (approvalVM.Status == 3)
            {
                userRequest.Status = StatusRequest.Reject;
                sendEmail.SendRejectNotificationToEmployee(userRequest.Email);
            }
            myContext.Update(userRequest);
            myContext.SaveChanges();
            return 1;
        }
    }
}
