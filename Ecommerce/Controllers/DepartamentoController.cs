using Ecommerce.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        [HttpGet]
        [Route("CarregaDepartamento")]
        [AllowAnonymous]
        public async Task<IActionResult> CarregaDepartamento()
        {
            var responseFull = "";
         
            var baseAddress = new Uri("https://private-anon-3acfa3e1bd-maximatech.apiary-mock.com/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("/fullstack/departamento"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();

                    responseFull = responseData;
                }
            }

            var departamentoModelo = new List<DepartamentoModelo>();
            
            departamentoModelo = JsonConvert.DeserializeObject<List<DepartamentoModelo>>(responseFull);


            return Ok(departamentoModelo);
        }
    }
}
