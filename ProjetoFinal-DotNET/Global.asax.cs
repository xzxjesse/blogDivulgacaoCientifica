using ProjetoFinal_DotNET.Dao.Repository;
using ProjetoFinal_DotNET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ProjetoFinal_DotNET
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var artigoRepository = new ArtigoRepository();

            Application["ArtigoRepository"] = artigoRepository;
            Application["ArtigoService"] = new ArtigoService(artigoRepository);
        }
    }
}