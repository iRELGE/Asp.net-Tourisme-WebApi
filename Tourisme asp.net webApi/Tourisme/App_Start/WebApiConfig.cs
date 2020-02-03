using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;

namespace Tourisme
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web
            // Configurer l'API Web pour utiliser uniquement l'authentification de jeton du porteur.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "Tout les postes par option et order",
              routeTemplate: "api/choioptionLimits/{prend}/{option}",
              defaults: new { controller = "Postes", action = "GetPostesAvis", prend = RouteParameter.Optional, option = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
          name: "les meilleurs activité",
          routeTemplate: "api/lesMeilleursActivites",
          defaults: new { controller = "Activites", action = "GetActivites", prend = RouteParameter.Optional, option = RouteParameter.Optional }
      );
            
            config.Routes.MapHttpRoute(
            name: "Poster une avis Pour un Poste",
            routeTemplate: "api/PosterUneAvis",
            defaults: new { controller = "Avis", action = "PostAvi", prend = RouteParameter.Optional, option = RouteParameter.Optional }
        );

            config.Routes.MapHttpRoute(
         name: "les photo et les pub de slider",
         routeTemplate: "api/SliderPubPhoto",
         defaults: new { controller = "PublicitNavBars", action = "GetPublicitNavBars", prend = RouteParameter.Optional, option = RouteParameter.Optional }
     );
            config.Routes.MapHttpRoute(
       name: "list de 3 avis aliatoir",
       routeTemplate: "api/listTroisavissRandom",
       defaults: new { controller = "Avis", action = "GetAvis", prend = RouteParameter.Optional, option = RouteParameter.Optional }
   );
            config.Routes.MapHttpRoute(
      name: "Detail Avi",
      routeTemplate: "api/AfficherUnPost/{id}",
      defaults: new { controller = "Postes", action = "GetPosteAvis", id = RouteParameter.Optional}
  );
            config.Routes.MapHttpRoute(
     name: "touts les postes d un etulisateur",
     routeTemplate: "api/AllUserPostsInfo/{id}",
     defaults: new { controller = "UserData", action = "GetUserPosts", id = RouteParameter.Optional }
 );
            config.Routes.MapHttpRoute(
   name: "delete poste",
   routeTemplate: "api/DeletePost/{id}",
   defaults: new { controller = "Postes", action = "DeletePoste", id = RouteParameter.Optional }
);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           //config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));
        }
    }
}
