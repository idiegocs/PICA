﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace KallSonysB2C
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {
                GetShoppingCartItems();
            }
        }
                
        public void GetShoppingCartItems()
        {
            List<CartItem> listaItems = null;
            decimal cartTotal = 0;

            using (ShoppingCartActions actions = new ShoppingCartActions())
            {
                listaItems = actions.GetCartItems();
                if (listaItems != null)
                {
                    CartList.DataSource = listaItems.ToList();
                    CartList.DataBind();
                    mostrarControles(listaItems.Count());
                }
                else 
                {
                    mostrarControles(0);
                }

                

                cartTotal = actions.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
            }
        }

        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    cartUpdates[i].ProductId = Convert.ToInt32(getDataKeyName(i, "ProductID"));
                    cartUpdates[i].tipo = getDataKeyName(i, "TipoItem");

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                //actualiza los productos en el carro compras.
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                GetShoppingCartItems();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                mostrarControles(CartList.Rows.Count);
                return usersShoppingCart.GetCartItems();
            }
        }

        private string getDataKeyName(int index, string dataKeyName) 
        {
            return CartList.DataKeys[CartList.Rows[index].RowIndex].Values[dataKeyName].ToString();
        }

        void mostrarControles(int cantItemsCarro) 
        {
            if (cantItemsCarro == 0)
            {
                LabelTotalText.Text = "";
                lblTotal.Text = "";
                ShoppingCartTitle.InnerText = "El carrito de compras está vacío";
                UpdateBtn.Visible = false;
                PagoBtn.Visible = false;
            }
            else 
            {
                UpdateBtn.Visible = true;
                PagoBtn.Visible = true;
            }
        }
        
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void PagoBtn_Click(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
            }
            Response.Redirect("Checkout/CheckoutStart.aspx");
        }
    }
}