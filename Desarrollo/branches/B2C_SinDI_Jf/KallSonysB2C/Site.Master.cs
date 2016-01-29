using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;
using KB2C.DTO;
using Microsoft.Practices.Unity;
using KB2C.Business;

namespace KallSonysB2C
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("canEdit"))
            {
                adminLink.Visible = true;
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
                ordersUser.Visible = true;
            else
                ordersUser.Visible = false;

        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                string cartStr = string.Format("Carrito ({0})", usersShoppingCart.GetCount());
                cartCount.InnerText = cartStr;
            }
        }

        public List<CategoriesDTO> GetCategories()
        {

            CategoriaBL obj = new CategoriaBL();
            List<CategoriesDTO> listCatSubcat = new List<CategoriesDTO>();


            List<CategoriesDTO> listaCatSes = null;

            try
            {
                listaCatSes = (List<CategoriesDTO>)Session["sesListaCategorias"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error GetCategories()" + e.Message);
                listaCatSes = null;
            }

            if (listaCatSes == null)
            {
                listCatSubcat = obj.GetCat_SubCategories();
                Session.Add("sesListaCategorias", listCatSubcat);
            }
            else
            {
                listCatSubcat = listaCatSes;
            }

            return listCatSubcat;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
            //se debe borrar la lista del carro.
            using (KallSonysB2C.Logic.ShoppingCartActions usersShoppingCart = new KallSonysB2C.Logic.ShoppingCartActions())
            {
                usersShoppingCart.EmptyCart();
            }
        }
    }

}