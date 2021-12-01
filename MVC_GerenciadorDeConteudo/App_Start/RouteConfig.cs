using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "sobre_ana_parametro",
                url: "sobre/{id}/ana",
                defaults: new { controller = "Home", action = "about", id = 0 }
            );

            routes.MapRoute(
                name: "sobre",
                url: "sobre",
                defaults: new { controller = "Home", action = "about" }
            );

            routes.MapRoute(
                name: "paginas",
                url: "paginas",
                defaults: new { controller = "Paginas", action = "Index" }
            );

            routes.MapRoute(
                name: "paginas_criar",
                url: "paginas/criar",
                defaults: new { controller = "Paginas", action = "Criar" }
            );

            routes.MapRoute(
                name: "paginas_novo",
                url: "paginas/novo",
                defaults: new { controller = "Paginas", action = "Novo" }
            );

            routes.MapRoute(
                name: "paginas_editar",
                url: "paginas/{id}/editar",
                defaults: new { controller = "Paginas", action = "Editar", id = 0 }
            );

            routes.MapRoute(
                name: "paginas_alterar",
                url: "paginas/{id}/alterar",
                defaults: new { controller = "Paginas", action = "Alterar", id = 0 }
            );

            routes.MapRoute(
                name: "paginas_excluir",
                url: "paginas/{id}/excluir",
                defaults: new { controller = "Paginas", action = "Excluir", id = 0 }
            );

            routes.MapRoute(
                name: "consulta_cep",
                url: "consulta-cep",
                defaults: new { controller = "Cep", action = "index" }
            );

            routes.MapRoute(
                name: "api_consulta_cep",
                url: "api/consulta-cep/{cep}",
                defaults: new { controller = "Cep", action = "Consulta", cep = "" }
            );

            routes.MapRoute(
                name: "paginas_preview",
                url: "paginas/{id}/preview",
                defaults: new { controller = "Paginas", action = "Preview", id = 0 }
            );

            routes.MapRoute(
                name: "paginas_preview_dinamico",
                url: "paginas/{id}/preview-dinamico",
                defaults: new { controller = "Paginas", action = "PreviewDinamico", id = 0 }
            );

            routes.MapRoute(
                name: "paginas_preview_dinamico_notema",
                url: "paginas/{id}/preview-dinamico-notema",
                defaults: new { controller = "Paginas", action = "PreviewDinamicoNoTema", id = 0 }
            );

            routes.MapRoute(
                name: "contato",
                url: "contato",
                defaults: new { controller = "Home", action = "contact" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
