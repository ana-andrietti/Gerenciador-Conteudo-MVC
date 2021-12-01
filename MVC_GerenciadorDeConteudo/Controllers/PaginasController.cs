using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Text;
using LanguageExt.UnitsOfMeasure;
using NVelocity;
using NVelocity.App;
using System.IO;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            DateTime.TryParse(Request["data"], out DateTime data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.Salvar();
            Response.Redirect("/paginas");
        }

        public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }

        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        public ActionResult Preview(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                
                var pagina = Pagina.BuscaPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.Salvar();

                TempData["sucesso"] = "Página alterada com sucesso";
            }
            catch (Exception err)
            {
                TempData["erro"] = "Página não foi alterada (" + err.Message + ")";
            }

            Response.Redirect("/paginas");
        }    
        
        public ActionResult PreviewDinamico(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            NVelocity.App.Velocity.Init();

            var modelo = new
            {
                Header = "Lista dos dados dinamicos",
                Itens = new[]
                {
                    new {ID = 1, Nome = "Texto 001", Negrito = false},
                    new {ID = 2, Nome = "Texto 002", Negrito = true},
                    new {ID = 3, Nome = "Texto 003", Negrito = false}
                }
            };

            var velocityContext = new VelocityContext();
            velocityContext.Put("model", modelo);

            var html = new StringBuilder();
            bool result = NVelocity.App.Velocity.Evaluate(velocityContext, new StringWriter(html), "NomeParaCapturarLogError", new StringReader(pagina.Conteudo));

            ViewBag.Html = html.ToString();
            return View();
        }

        public string PreviewDinamicoNoTema(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            NVelocity.App.Velocity.Init();

            var modelo = new
            {
                Header = "Lista dos dados dinamicos",
                Itens = new[]
                {
                    new {ID = 1, Nome = "Texto 001", Negrito = false},
                    new {ID = 2, Nome = "Texto 002", Negrito = true},
                    new {ID = 3, Nome = "Texto 003", Negrito = false}
                }
            };

            var velocityContext = new VelocityContext();
            velocityContext.Put("model", modelo);
            velocityContext.Put("paginas", new Pagina().Lista());

            var html = new StringBuilder();
            bool result = NVelocity.App.Velocity.Evaluate(velocityContext, new StringWriter(html), "NomeParaCapturarLogError", new StringReader(pagina.Conteudo));

            return html.ToString();
        }
    }
}