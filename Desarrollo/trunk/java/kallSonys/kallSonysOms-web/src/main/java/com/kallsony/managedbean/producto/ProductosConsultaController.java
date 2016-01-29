package com.kallsony.managedbean.producto;

import com.kallsony.entity.producto.FiltroProductoVO;
import com.kallsony.entity.producto.Producto;

import java.io.Serializable;
import java.util.List;

import javax.ejb.EJB;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import javax.faces.context.FacesContext;

import com.kallsony.facade.service.ProductoServiceFacade;
import com.kallsony.util.JsfUtiles;
import com.service.productos.ProductoDeralleFaltaProducto;
import java.util.Date;
import javax.faces.application.FacesMessage;

import org.apache.log4j.Logger;

@ManagedBean(name = "productoConsultaController")
@SessionScoped
public class ProductosConsultaController implements Serializable {

    @EJB
    private com.kallsony.facade.service.ProductoServiceFacade ejbFacade;
    private List<Producto> items = null;

    private int grupoProducto = 1;
    private int maximaPagina = 1;
    private Producto productoSeleccionado;
    private int page;
    private String tipoFiltro = "";
    private String valorFiltro = "";

    private Date fechaIni;
    private Date fechaFin;

    final static Logger log = Logger.getLogger(ProductosConsultaController.class.getName());

    public ProductosConsultaController() {
        this.productoSeleccionado = null;
    }

    private ProductoServiceFacade getFacade() {
        return ejbFacade;
    }

    private void consultarProductos() {
        log.info("Conseguir Items");
        int max = 0;
        String urlServ="";
        try {
            log.info("Grupo " + grupoProducto);
            log.info("Tipo Filtro " + tipoFiltro + " Valor Fitlro " + valorFiltro);
            productoSeleccionado = null;
            
            urlServ = FacesContext.getCurrentInstance().getExternalContext().getInitParameter("kallsony.ipservproductos");
            log.info("Url serv "+urlServ);
            FiltroProductoVO filtro = getFacade().conseguirProductos(urlServ,grupoProducto, tipoFiltro, valorFiltro, fechaIni, fechaFin);
            String paginacion = FacesContext.getCurrentInstance().getExternalContext().getInitParameter("kallsony.paginacion");
            int pg = Integer.parseInt(paginacion);
            max = filtro.getTotal() / pg;
            log.info("maximo reg " + max);

            if (max % pg != 0) {
                max = max + 1;
            }
            if (max == 0) {
                max = max + 1;
            }
            maximaPagina = max;

            log.info("maximaPagina " + maximaPagina);

            items = filtro.getListaProductos();

        } catch (ProductoDeralleFaltaProducto ex) {
            log.error("Error Falta Producto", ex);
            JsfUtiles.addErrorMessage("Error, Intente Nuevamente - ServiceProduc");

        } catch (Exception e) {
            log.error("Error Consulta Producto", e);
            JsfUtiles.addErrorMessage(e, "Error, Intente Nuevamente");
        }
    }

    public void conseguirItems() {

        grupoProducto = 1;
        if ("R".equals(tipoFiltro)) {
            if (diferenciaEnDias(fechaFin,fechaIni)<=60) {
                consultarProductos();
            }
            else{
                JsfUtiles.addErrorMessage("Diferencia Entre Fechas Mayor a 2 Meses");
            }
        } else {

            consultarProductos();
        }

    }

    public int diferenciaEnDias(Date fechaMayor, Date fechaMenor) 
    {
        long dif=fechaMayor.getTime() -fechaMenor.getTime();
      
        long dias = dif / (1000 * 60 * 60 * 24);
        log.info("dias en fechas "+dias);
        return (int) dias;
    }

    public void conseguirItemsGrupo() {

        consultarProductos();

    }

    public void reiniciarProductos() {
        grupoProducto = 1;
        maximaPagina = 1;
        tipoFiltro = "A";
        valorFiltro = "";
        items = null;
        fechaFin = null;
        fechaIni = null;

    }

    public List<Producto> getItems() {
        return items;
    }

    public void setItems(List<Producto> items) {
        this.items = items;
    }

    public Producto getProductoSeleccionado() {
        return productoSeleccionado;
    }

    public void setProductoSeleccionado(Producto productoSeleccionado) {
        this.productoSeleccionado = productoSeleccionado;
    }

    public int getGrupoProducto() {
        return grupoProducto;
    }

    public void setGrupoProducto(int grupoProducto) {
        this.grupoProducto = grupoProducto;
    }

    public int getMaximaPagina() {
        return maximaPagina;
    }

    public void setMaximaPagina(int maximaPagina) {
        this.maximaPagina = maximaPagina;
    }

    public int getPage() {
        return page;
    }

    public void setPage(int page) {
        this.page = page;
    }

    public String getTipoFiltro() {
        return tipoFiltro;
    }

    public void setTipoFiltro(String tipoFiltro) {
        this.tipoFiltro = tipoFiltro;
    }

    public String getValorFiltro() {
        return valorFiltro;
    }

    public void setValorFiltro(String valorFiltro) {
        this.valorFiltro = valorFiltro;
    }

    public Date getFechaIni() {
        return fechaIni;
    }

    public void setFechaIni(Date fechaIni) {
        this.fechaIni = fechaIni;
    }

    public Date getFechaFin() {
        return fechaFin;
    }

    public void setFechaFin(Date fechaFin) {
        this.fechaFin = fechaFin;
    }

}
