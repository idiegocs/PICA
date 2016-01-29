﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using KallSonysB2C.Models;

namespace KallSonysB2C.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                IdentityHelper.SignIn(manager, user, isPersistent: false);

                using (KallSonysB2C.Logic.ShoppingCartActions usersShoppingCart = new KallSonysB2C.Logic.ShoppingCartActions())
                {
                    String cartId = usersShoppingCart.GetCartId();
                    usersShoppingCart.MigrateCart(cartId, user.Id);
                }

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                if (result.Errors.FirstOrDefault().Contains("is already taken"))
                {
                    ErrorMessage.Text = "El usuario " + Email.Text + " ya existe. Por favor intente con otro Correo Electrónico.";
                }
                if (result.Errors.FirstOrDefault().Contains("at least"))
                {
                    ErrorMessage.Text = "Las contraseñas deben tener al menos 6 caracteres. Las contraseñas deben tener al menos un caractér o dígitos. Las contraseñas deben tener al menos una minúscula ('a' - 'z'). Las contraseñas deben tener al menos una mayúscula ('A' - 'Z').";
                }
            }
        }
    }
}