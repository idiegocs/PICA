/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.service;

import com.kallsony.entity.producto.FiltroProductoVO;
import com.kallsony.facade.orden.OrdenFacade;
import com.service.productos.ConsultaProductoEntrada;
import com.service.productos.ConsultaProductoSalida;
import com.service.productos.Filtro;
import com.service.productos.Producto;
import com.service.productos.ProductoDeralleFaltaProducto;
import com.service.productos.Productos;
import com.service.productos.ProductosPort;
import com.service.productos.RespuestaFiltro;
import com.service.productos.ServiceProductos;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.net.URL;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.ejb.EJB;

import javax.ejb.Stateless;
import javax.xml.namespace.QName;

/**
 *
 * @author Diego
 */
@Stateless
public class ProductoServiceFacade {

    @EJB
    OrdenFacade ejbOrdenes;

    public ProductoServiceFacade() {

    }

    public FiltroProductoVO conseguirProductos(String strUrl, int paramPagina, String tipoFiltro, String valorFiltro, Date fechaIni, Date fechafin) throws ProductoDeralleFaltaProducto {

        URL url = null;
        QName qname = null;
        try {
            url = new URL(strUrl);

            qname = new QName("http://www.kallsony.com/final/operacion/consultaproducto", "ServiceProductos");
            System.out.println("Url "+strUrl);
        } catch (Exception e) {
            e.printStackTrace();
        }

        FiltroProductoVO filtroProducto = new FiltroProductoVO();
        List<com.kallsony.entity.producto.Producto> listProduc = new ArrayList<com.kallsony.entity.producto.Producto>();
        ServiceProductos serv = new ServiceProductos(url,qname);
        ProductosPort portProduct = serv.getProductosPortPt();
        ConsultaProductoEntrada entrada = new ConsultaProductoEntrada();
        Filtro filtro = new Filtro();

        String ids = "";
        int asciiValue = 124;
        char ch = (char) asciiValue;
        if (tipoFiltro.equals("R")) {
            ids = ejbOrdenes.consultarRankingProductos(fechaIni, fechafin);
            tipoFiltro = "I";

            ids = (ids + ch);
            valorFiltro = ids;
            System.out.println("ids " + ids);
        }

        filtro.setPagina(paramPagina);
        filtro.setTipoFiltro(tipoFiltro);
        filtro.setValorFiltro(valorFiltro);
        entrada.setFiltroProducto(filtro);
        ConsultaProductoSalida salida = null;
        Productos listaProductos = null;
        List<Producto> productos = null;
        RespuestaFiltro resFiltro = null;
        int pagina = 0;
        Long total = null;

        salida = portProduct.consultarProductos(entrada);

        resFiltro = salida.getRespuestaFiltro();
        pagina = resFiltro.getPagina();
        total = resFiltro.getTotalElementos();
        System.out.println("Productos - Pagina " + pagina + " Total Paginas " + total);

        filtroProducto.setTotal(total.intValue());
        listaProductos = salida.getListaProductos();
        productos = listaProductos.getProducto();
        if (productos != null) {
            //System.out.println("Productos " + productos.size());
            com.kallsony.entity.producto.Producto product = null;

            for (Producto prodWS : productos) {
                //System.out.println(prod);
                product = new com.kallsony.entity.producto.Producto();
                product.setIdProducto(prodWS.getIdProducto().intValue());
                product.setCodigoProducto(prodWS.getCodigoProducto());
                product.setNombreProducto(prodWS.getNombreProducto());
                product.setDescripcionProducto(prodWS.getDescripcionProducto());
                product.setIdSubcategoria(prodWS.getTipoProducto().getSubCategoria().getIdTipo());
                product.setNombreFabricante(prodWS.getFabricanteProducto());
                product.setPrecioUnitario(new BigDecimal(prodWS.getPrecioProducto()));
                product.setNombreImagenProducto(prodWS.getNombreImagenProducto());
                listProduc.add(product);
            }

            filtroProducto.setListaProductos(listProduc);

        }

        return filtroProducto;
    }

}
