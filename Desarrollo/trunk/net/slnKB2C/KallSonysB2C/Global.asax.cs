using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;
using KB2C.Business;

namespace KallSonysB2C
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            //Database.SetInitializer(new ProductDatabaseInitializer());

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();

            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);

            loadParametricObjects();

        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ProductsByCategoryRoute", "Category/{categoryName}", "~/ProductList.aspx");

            //routes.MapPageRoute("ProductByNameRoute", "Product/{productName}", "~/ProductDetails.aspx");

            routes.MapPageRoute("ProductByNameRoute", "Product/{productId}", "~/ProductDetails.aspx");

            routes.MapPageRoute("DealsByNameRoute", "Deals/{dealName}", "~/DealsDetails.aspx");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
                }
            }
        }

        void loadParametricObjects()
        {
            Application["Pais"] = null;
            Application["Departamento"] = null;
            Application["Ciudad"] = null;
            Application["EstadoOrden"] = null;

            ParametricaBL objUbi = new ParametricaBL();

            try
            {
                Application["Pais"] = objUbi.getPais();
                Application["Departamento"] = objUbi.getDepartamento();
                Application["Ciudad"] = objUbi.getCiudad();
                Application["EstadoOrden"] = objUbi.getEstadoOrden();
            }
            catch (Exception)
            {
                KallSonysB2C.Logic.MessageBox.Show("Error al cargar las Paramétricas de Ubicación Geográfica..!");
            }

        }
    }
}