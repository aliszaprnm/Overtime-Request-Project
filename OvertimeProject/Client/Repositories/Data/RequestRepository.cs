using Client.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        public RequestRepository(Address address, string request = "Requests/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        /*public HttpStatusCode ApplyOvertime(OvertimeFormVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "AddListOvertime", content).Result;
            return result.StatusCode;
        }*/
        /*public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> entities = new List<RegisterVM>();
            using (var response = await httpClient.GetAsync(request + "GetAllProfile"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
        }*/
        public async Task<List<OvertimeResponseVM>> GetRequestById(int requestId)
        {
            List<OvertimeResponseVM> entity = new List<OvertimeResponseVM>();
            using (var response = await httpClient.GetAsync(request + "GetRequestById/" + requestId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<List<OvertimeResponseVM>>(apiResponse);
            }
            return entity;
        }
    }
}
