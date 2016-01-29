using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using KallSonysB2C.Models;
using KB2C.DTO;


namespace KallSonysB2C.Logic
{
    public class ShoppingCartActions : System.Web.UI.Page
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        private static bool itemAddedToCart { get; set; }

        public string msjErrorAddingToCart { get; set; }

        //busca un producto dentro de la lista de productos en session
        public ProductosDTO buscarProducto(long idProducto)
        {
            List<ProductosDTO> listaProductos = (List<ProductosDTO>)Session["sesListaProductos"];
            if (listaProductos != null)
            {
                foreach (var unProducto in listaProductos)
                {
                    if (unProducto.idProducto == idProducto)
                    {
                        return unProducto;
                    }
                }
            }

            return null;
        }

        //busca una campaña dentro de la lista de campañas en session
        public CampaniasDTO buscarCampania(int idCampania)
        {
            List<CampaniasDTO> listaCampanias = (List<CampaniasDTO>)Session["sesListaCampanias"];
            if (listaCampanias != null)
            {
                foreach (var campania in listaCampanias)
                {
                    if (campania.IdCampania == idCampania)
                    {
                        return campania;
                    }
                }
            }

            return null;
        }

        //busca un producto dentro de la lista  de carItem  en session
        public CartItem buscarCarItem(long idProducto, string idShopingCar, string tipoItem)
        {
            List<CartItem> listaCarItem = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error  buscarCarItem " + e.Message);
                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.ProductId == idProducto && unCarItem.CartId.Equals(idShopingCar) && unCarItem.Product.TipoItem == tipoItem)
                    {
                        return unCarItem;
                    }
                }
            }


            return null;
        }
        public bool AddToCart(long id, string tipoItem)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();
            itemAddedToCart = false;

            // producto o campania especifico en session.
            switch (tipoItem)
            {
                case "P":
                    var productItem = buscarProducto(id);
                    addProductoToCart(productItem, id, tipoItem);
                    break;
                case "C":
                    var campaniaItem = buscarCampania(Convert.ToInt32(id));
                    addCampaniaToCart(campaniaItem, id, tipoItem);
                    break;
            }

            return itemAddedToCart;
        }

        private void addProductoToCart(ProductosDTO productItem, long id, string tipoItem)
        {
            List<CartItem> listaCartItem = null;
            CartItem unCarItem = null;

            if (productItem != null)
            {
                try
                {
                    listaCartItem = (List<CartItem>)Session["sesListaCartItem"];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error  addProductoToCart " + e.Message);
                    listaCartItem = null;
                }

                if (listaCartItem == null)
                {
                    listaCartItem = new List<CartItem>();
                    unCarItem = new CartItem();
                    unCarItem.ItemId = Guid.NewGuid().ToString();
                    unCarItem.CartId = ShoppingCartId;
                    unCarItem.ProductId = id;
                    unCarItem.Product = productItem;
                    unCarItem.Quantity = 1;
                    unCarItem.DateCreated = DateTime.Now;
                    unCarItem.Product.TipoItem = tipoItem;
                    unCarItem.valorUnitarioItem = productItem.precioProducto;
                    unCarItem.NombreItem = productItem.nombreProducto;

                    listaCartItem.Add(unCarItem);
                    Session.Add("sesListaCartItem", listaCartItem); 
                    
                    itemAddedToCart = true;
                }
                else
                {
                    //busca en la lista de carItem el objeto. y aumenta su cantidad
                    unCarItem = buscarCarItem(id, ShoppingCartId, tipoItem);
                    if (unCarItem != null)
                    {
                        unCarItem.Quantity = unCarItem.Quantity + 1;
                        itemAddedToCart = true;
                    }
                    else
                    {
                        itemAddedToCart = canAddItemsToCart();
                        if (itemAddedToCart)
                        {
                            unCarItem = new CartItem();
                            unCarItem.ItemId = Guid.NewGuid().ToString();
                            unCarItem.CartId = ShoppingCartId;
                            unCarItem.ProductId = id;
                            unCarItem.Product = productItem;
                            unCarItem.Quantity = 1;
                            unCarItem.DateCreated = DateTime.Now;
                            unCarItem.Product.TipoItem = tipoItem;
                            unCarItem.valorUnitarioItem = productItem.precioProducto;
                            unCarItem.NombreItem = productItem.nombreProducto;

                            listaCartItem.Add(unCarItem);
                            Session.Add("sesListaCartItem", listaCartItem);
                        }
                        else 
                        {
                            StringBuilder msj = new StringBuilder();
                            msj.Append("Lo sentimos, no puede agregar más items al carrito de compras debido a que ");
                            msj.Append("la cantidad máxima de items permitida es: " + cantidadMaximaItemsCarro().ToString());
                            msjErrorAddingToCart = msj.ToString();
                        }
                        
                    }
                }
            }
            else
            {
                Console.Write("No se Encontro el Producto");
                throw new Exception("ERROR: No se encontro el Producto");
            }
        }

        private void addCampaniaToCart(CampaniasDTO campaniaItem, long id, string tipoItem)
        {
            List<CartItem> listaCartItem = null;
            CartItem unCarItem = null;

            if (campaniaItem != null)
            {
                try
                {
                    listaCartItem = (List<CartItem>)Session["sesListaCartItem"];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error addCampaniaToCart " + e.Message);
                    listaCartItem = null;
                }

                if (listaCartItem == null)
                {
                    listaCartItem = new List<CartItem>();
                    unCarItem = new CartItem();
                    unCarItem.ItemId = Guid.NewGuid().ToString();
                    unCarItem.CartId = ShoppingCartId;
                    unCarItem.ProductId = id;
                    unCarItem.Product = new ProductosDTO();
                    unCarItem.Product.nombreProducto = campaniaItem.Nombre;
                    unCarItem.Product.precioProducto = campaniaItem.ValorUnitarioCampania;
                    unCarItem.Campania = campaniaItem;
                    unCarItem.Quantity = 1;
                    unCarItem.DateCreated = DateTime.Now;
                    unCarItem.Product.TipoItem = tipoItem;
                    unCarItem.valorUnitarioItem = campaniaItem.ValorUnitarioCampania;
                    unCarItem.NombreItem = campaniaItem.Nombre;

                    listaCartItem.Add(unCarItem);
                    Session.Add("sesListaCartItem", listaCartItem);

                    itemAddedToCart = true;
                }
                else
                {
                    //busca en la lista de carItem el objeto. y aumenta su cantidad
                    unCarItem = buscarCarItem(id, ShoppingCartId, tipoItem);
                    if (unCarItem != null)
                    {
                        unCarItem.Quantity = unCarItem.Quantity + 1;
                        itemAddedToCart = true;
                    }
                    else
                    {
                        itemAddedToCart = canAddItemsToCart();
                        if (itemAddedToCart)
                        {
                            unCarItem = new CartItem();
                            unCarItem.ItemId = Guid.NewGuid().ToString();
                            unCarItem.CartId = ShoppingCartId;
                            unCarItem.ProductId = id;
                            unCarItem.Product = new ProductosDTO();
                            unCarItem.Product.nombreProducto = campaniaItem.Nombre;
                            unCarItem.Product.precioProducto = campaniaItem.ValorUnitarioCampania;
                            unCarItem.Campania = campaniaItem;
                            unCarItem.Quantity = 1;
                            unCarItem.DateCreated = DateTime.Now;
                            unCarItem.Product.TipoItem = tipoItem;
                            unCarItem.valorUnitarioItem = campaniaItem.ValorUnitarioCampania;
                            unCarItem.NombreItem = campaniaItem.Nombre;

                            listaCartItem.Add(unCarItem);
                            Session.Add("sesListaCartItem", listaCartItem);
                        }
                        else
                        {
                            StringBuilder msj = new StringBuilder();
                            msj.Append("Lo sentimos, no puede agregar más items al carrito de compras debido a que ");
                            msj.Append("la cantidad máxima de items permitida es: " + cantidadMaximaItemsCarro().ToString());
                            msjErrorAddingToCart = msj.ToString();
                        }
                    }
                }
            }
            else
            {
                Console.Write("No se Encontro la Campaña");
                throw new Exception("ERROR: No se encontro la Campaña");
            }
        }

        public string GetCartId()
        {
            //verificar ID
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            List<CartItem> listaCarItem = null;
            List<CartItem> listaResultCar = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error GetCartItems " + e.Message);
                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                listaResultCar = new List<CartItem>();

                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.CartId.Equals(ShoppingCartId))
                    {
                        listaResultCar.Add(unCarItem);
                    }
                }
            }

            return listaResultCar;
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();

            // Multiply product price by quantity of that product to get the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            double totalItems = 0;

            List<CartItem> listaCarItem = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error GetTotal " + e.Message);

                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.CartId.Equals(ShoppingCartId))
                    {
                        //if (unCarItem.Product != null)
                        //{
                            totalItems = totalItems + (double)(unCarItem.Quantity * unCarItem.valorUnitarioItem);
                        //}
                    }
                }
            }
            total = (decimal?)totalItems;

            return total ?? decimal.Zero;
        }

        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        // actualizar campos
        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            try
            {
                int CartItemCount = CartItemUpdates.Count();
                List<CartItem> myCart = GetCartItems();
                foreach (var cartItem in myCart)
                {
                    // Iterate through all rows within shopping cart list
                    for (int i = 0; i < CartItemCount; i++)
                    {
                        /*
                        if (cartItem.Product.idProducto == CartItemUpdates[i].ProductId)
                        {
                            if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                            {
                                RemoveItem(cartId, cartItem.ProductId);
                            }
                            else
                            {
                                UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity);
                            }
                        }
                        */
                        if (cartItem.ProductId == CartItemUpdates[i].ProductId)
                        {
                            if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                            {
                                RemoveItem(cartId, cartItem.ProductId, CartItemUpdates[i].tipo);
                            }
                            else
                            {
                                UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity, CartItemUpdates[i].tipo);
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: No es posible actualizar el carrito de compras - " + exp.Message.ToString(), exp);
            }
        }

        public void RemoveItem(string removeCartID, long removeProductID, String Tipo)
        {
            try
            {
                List<CartItem> listaCarItem = null;
                try
                {
                    listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error RemoveItem " + e.Message);
                    listaCarItem = null;
                }

                if (listaCarItem != null)
                {
                    CartItem unCarItemRemove = null;
                    foreach (var unCarItem in listaCarItem)
                    {
                        if (unCarItem.ProductId == removeProductID && unCarItem.CartId.Equals(removeCartID) && unCarItem.Product.TipoItem==Tipo)
                        {
                            unCarItemRemove = unCarItem;
                            break;
                        }
                    }
                    if (unCarItemRemove != null)
                    {
                        listaCarItem.Remove(unCarItemRemove);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: No es posible remover el item del carro - " + exp.Message.ToString(), exp);
            }
        }

        public void UpdateItem(string updateCartID, long updateProductID, int quantity, string tipo)
        {
            try
            {
                List<CartItem> listaCarItem = null;
                try
                {
                    listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error UpdateItem " + e.Message);
                    listaCarItem = null;
                }

                if (listaCarItem != null)
                {
                    foreach (var unCarItem in listaCarItem)
                    {
                        if (unCarItem.ProductId == updateProductID && unCarItem.CartId.Equals(updateCartID) && unCarItem.Product.TipoItem==tipo)
                        {
                            unCarItem.Quantity = quantity;

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: No es posible actualizar el item del carro - " + exp.Message.ToString(), exp);
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();

            List<CartItem> listaCarItem = null;
            List<CartItem> listaNewCarItem = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error EmptyCart "+e.Message);
                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                listaNewCarItem = new List<CartItem>();

                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.CartId != (ShoppingCartId))
                    {
                        listaNewCarItem.Add(unCarItem);
                    }
                }

                listaCarItem = null;
                Session.Add("sesListaCartItem", listaNewCarItem);
            }
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = 0;

            List<CartItem> listaCarItem = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error GetCount" + e.Message);
                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.CartId.Equals(ShoppingCartId))
                    {
                        count = count + 1;
                    }
                }
            }

            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
            public String tipo;
        }

        public void MigrateCart(string cartId, string userName)
        {
            List<CartItem> listaCarItem = null;
            try
            {
                listaCarItem = (List<CartItem>)Session["sesListaCartItem"];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cargarProductos " + e.Message);
                listaCarItem = null;
            }

            if (listaCarItem != null)
            {
                foreach (var unCarItem in listaCarItem)
                {
                    if (unCarItem.CartId.Equals(cartId))
                    {
                        unCarItem.CartId = userName;
                    }
                }
            }

            HttpContext.Current.Session[CartSessionKey] = userName;
        }

        public int cantidadMaximaItemsCarro() 
        {
            return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["cantMaximaItemsCarro"]);
        }

        public bool canAddItemsToCart() 
        {
            bool canAdd = false;
            List<CartItem> listaCarItem = null;
            int cantMaximaItemsCarro = cantidadMaximaItemsCarro();
            listaCarItem = (List<CartItem>)Session["sesListaCartItem"];

            if (listaCarItem != null)
            {

                if (listaCarItem.Count() < cantMaximaItemsCarro)
                    canAdd = true;
                else
                    canAdd = false;
            }
            else
            {
                canAdd = true;
            }

            return canAdd;
        }
    }
}