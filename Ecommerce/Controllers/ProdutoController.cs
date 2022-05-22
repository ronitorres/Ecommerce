using Ecommerce.Modelos;
using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoController : ControllerBase
    {

        [HttpGet]
        [Route("CarregaProduto")]
        [AllowAnonymous]

        public async Task<IActionResult> CarregaProduto()
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

            var produtoModelo = new List<ProdutoModelo>();

            produtoModelo = JsonConvert.DeserializeObject<List<ProdutoModelo>>(responseFull);


            return Ok(produtoModelo);

           
        }
    }
}
