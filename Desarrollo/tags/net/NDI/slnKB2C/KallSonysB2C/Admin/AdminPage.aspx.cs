﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;
using KB2C.Business;
using KB2C.DTO;

namespace KallSonysB2C.Admin
{
  public partial class AdminPage : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string productAction = Request.QueryString["ProductAction"];
      if (productAction == "add")
      {
        LabelAddStatus.Text = "Product added!";
      }

      if (productAction == "remove")
      {
        LabelRemoveStatus.Text = "Product removed!";
      }
    }

    protected void AddProductButton_Click(object sender, EventArgs e)
    {
      Boolean fileOK = false;
      String path = Server.MapPath("~/Catalog/Images/");
      if (ProductImage.HasFile)
      {
        String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
        for (int i = 0; i < allowedExtensions.Length; i++)
        {
          if (fileExtension == allowedExtensions[i])
          {
            fileOK = true;
          }
        }
      }

      if (fileOK)
      {
        try
        {
          // Save to Images folder.
          ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
          // Save to Images/Thumbs folder.
          ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
        }
        catch (Exception ex)
        {
          LabelAddStatus.Text = ex.Message;
        }

        // Add product data to DB.
        AddProducts products = new AddProducts();
        bool addSuccess = products.AddProduct(AddProductName.Text, AddProductDescription.Text,
            AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
        if (addSuccess)
        {
          // Reload the page.
          string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
          Response.Redirect(pageUrl + "?ProductAction=add");
        }
        else
        {
          LabelAddStatus.Text = "Unable to add new product to database.";
        }
      }
      else
      {
        LabelAddStatus.Text = "Unable to accept file type.";
      }
    }

    /*
    public IQueryable GetCategories()
    {
      var _db = new KallSonysB2C.Models.ProductContext();
      IQueryable query = _db.Categories;
      return query;
    }
    */
    public List<CategoriesDTO> GetCategories()
    {
        CategoriaBL obj = new CategoriaBL();
        List<CategoriesDTO> listCatSubcat = new List<CategoriesDTO>();
        

       List<CategoriesDTO> listaCatSes =null;
        
        try
        {
            listaCatSes=(List<CategoriesDTO>)Session["sesListaCategorias"];
        }
        catch(Exception e)
        {
            Console.WriteLine("Error  GetCategories " + e.Message);
             listaCatSes =null;
        }

        if(listaCatSes==null)
        {

            listCatSubcat = obj.GetCat_SubCategories();
            Session.Add("sesListaCategorias",listCatSubcat);
        }
        else
        {
            listCatSubcat = listaCatSes;
        }

        return listCatSubcat;
    }
      /*
    public IQueryable GetProducts()
    {
      var _db = new KallSonysB2C.Models.ProductContext();
      IQueryable query = _db.Products;
      return query;
    }*/

    public List<ProductosDTO> GetProducts()
    {
        ProductoBL obj = new ProductoBL();
        Parametros p = new Parametros();
        List<ProductosDTO> listaProductos = new List<ProductosDTO>();

        listaProductos = obj.listaProductos(p.SinFiltro, "", 1);
        return listaProductos;
    }

    protected void RemoveProductButton_Click(object sender, EventArgs e)
    {
    /*
      using (var _db = new KallSonysB2C.Models.ProductContext())
      {
        int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
        var myItem = (from c in _db.Products where c.ProductID == productId select c).FirstOrDefault();
        if (myItem != null)
        {
          _db.Products.Remove(myItem);
          _db.SaveChanges();

          // Reload the page.
          string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
          Response.Redirect(pageUrl + "?ProductAction=remove");
        }
        else
        {
          LabelRemoveStatus.Text = "Unable to locate product.";
        }
      }
    */
    }
  }
}