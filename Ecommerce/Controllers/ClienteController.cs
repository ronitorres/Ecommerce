using Microsoft.AspNetCore.Mvc;
using Ecommerce.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("CarregaDepartamento")]
        [AllowAnonymous]

        public async Task<IActionResult> CarregaCliente()
        {
            var responseFull = "";

            var baseAddress = new Uri("https://private-anon-b98488d6a3-maximatech.apiary-mock.com/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("fullstack"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();

                    responseFull = responseData;
                }
            }


                var clienteModelo = new List<ClienteModelo>();

                clienteModelo = JsonConvert.DeserializeObject<List<ClienteModelo>>(responseFull);


                 return Ok(clienteModelo);

            
        }
    }
}
