using Client.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OvertimeProject.Models;
using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        public AccountRepository(Address address, string request = "Accounts/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> entities = new List<RegisterVM>();
            using (var response = await httpClient.GetAsync(request + "GetAllProfile"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
            /// isi codingan kalian disini
        }

        public async Task<RegisterVM> GetProfileById(int nip)
        {
            RegisterVM entity = new RegisterVM();
            using (var response = await httpClient.GetAsync(request + "GetProfileById/" + nip))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return entity;
            /// isi codingan kalian disini
        }
    }
}
