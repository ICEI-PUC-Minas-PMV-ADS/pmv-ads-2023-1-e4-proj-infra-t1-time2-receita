using Microsoft.AspNetCore.Mvc;
using Freecipes_app.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Freecipes_app.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly string ENDPOINT = "https://backendfreecipes20230523214235.azurewebsites.net/api/Receitas";
        private readonly HttpClient httpClient = null;
  
        //construtor
        public ReceitasController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                var token = HttpContext.Session.GetString("token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT + $"/UsuarioId{usuario}");
                //valida se teve sucesso
                if (!string.IsNullOrWhiteSpace(token))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                    var listaReceitas = receitas.ToList();
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        
        // GET: Receitas
        public async Task<IActionResult> GetTodas()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                var token = HttpContext.Session.GetString("token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT);
                //valida se teve sucesso
                if (!string.IsNullOrWhiteSpace(token))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                    var listaReceitas = receitas.ToList();
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // GET: Receitas
        public async Task<IActionResult> GetCafeManha()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT);

                string content = await response.Content.ReadAsStringAsync();
                    receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                    var listaReceitas = receitas.ToList();

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // GET: Receitas
        public async Task<IActionResult> GetAlmocoJantar()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT);

                string content = await response.Content.ReadAsStringAsync();
                receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                var listaReceitas = receitas.ToList();

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // GET: Receitas
        public async Task<IActionResult> GetSobremesa()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT);

                string content = await response.Content.ReadAsStringAsync();
                receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                var listaReceitas = receitas.ToList();

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // GET: Receitas
        public async Task<IActionResult> GetLanche()
        {

            try
            {
                List<Receita> receitas = null;

                httpClient.DefaultRequestHeaders.Clear();

                //faz a requisição
                var usuario = HttpContext.Session.GetString("usuario");
                var response = await httpClient.GetAsync(ENDPOINT);

                string content = await response.Content.ReadAsStringAsync();
                receitas = JsonConvert.DeserializeObject<List<Receita>>(content);
                var listaReceitas = receitas.ToList();

                return View(receitas);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        //POST: Receitas
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create( Receita receita)
        {
            try
            {
                string json = JsonConvert.SerializeObject(receita);

                byte[] buffer = Encoding.UTF8.GetBytes(json);

                ByteArrayContent byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                string url = ENDPOINT;
                HttpResponseMessage response =
                    await httpClient.PostAsync(url, byteContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");

                return RedirectToAction("CadastroConcluido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       
}
}
