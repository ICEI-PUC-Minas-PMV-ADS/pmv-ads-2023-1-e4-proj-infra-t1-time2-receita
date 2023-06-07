using Microsoft.AspNetCore.Mvc;
using Freecipes_app.Models;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Text;



namespace Freecipes_app.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly string ENDPOINT = "https://backendfreecipes20230523214235.azurewebsites.net/api/Usuarios";
        private readonly HttpClient httpClient = null;
        private readonly string ENDPOINTAuthenticate = "https://backendfreecipes20230523214235.azurewebsites.net/api/Usuarios/authenticate";

        //construtor
        public UsuariosController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult CadastroConcluido()
        {
            ViewBag.Message = "Cadastro concluido :), seja muito bem vindo! Efetue Login para iniciar a navegação.";
            return View();
        }

        public IActionResult EdicaoConcluida()
        {
            ViewBag.Message = "Alteração efetuada com sucesso! :)";
            return View();
        }



        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Usuario> usuarios = null;

                //faz a requisição
                var response = await httpClient.GetAsync(ENDPOINT);
                //valida se teve sucesso
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(usuarios);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        //POST: Usuarios
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, Senha, Email")] Usuario usuario)
        {
            try
            {
                string json = JsonConvert.SerializeObject(usuario);

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



        public IActionResult Login()
        {
            return View();
        }

        // Login: Usuarios 
        [HttpPost]
        public async Task<IActionResult> Authenticate([Bind("Email,Senha")] Authenticate usuario)
        {
            try
            {
  
                string json = JsonConvert.SerializeObject(usuario);

                byte[] buffer = Encoding.UTF8.GetBytes(json);

                ByteArrayContent byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                string url = ENDPOINTAuthenticate;
                HttpResponseMessage response =
                    await httpClient.PostAsync(url, byteContent);

                if (response.IsSuccessStatusCode)
                {
                    var tokenJson = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<AuthenticateResponse>(tokenJson).jwtToken.ToString();
                    var usuarioId = JsonConvert.DeserializeObject<AuthenticateResponse>(tokenJson).usuario.ToString();

                    if (token != null)
                    {
                        HttpContext.Session.SetString("token", token);
                        HttpContext.Session.SetString("usuario", usuarioId);
                    }

                    return RedirectToAction("Index","Receitas");

                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }
             return View();
            }

           
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }



    }
}