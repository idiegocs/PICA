package com.kallsony.managedbean.producto;

import com.kallsony.app.appSingletonBean;
import com.kallsony.entity.campania.Subcategoria;
import com.kallsony.entity.producto.FiltroProductoVO;
import com.kallsony.entity.producto.Producto;
import com.kallsony.util.JsfUtiles;
import com.kallsony.util.JsfUtiles.PersistAction;
import com.kallsony.facade.producto.ProductoFacade;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;
import javax.annotation.PostConstruct;

import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;

@ManagedBean(name = "productoController")
@SessionScoped
public class ProductosController implements Serializable {
    @EJB
    private appSingletonBean appSingletonBean;

    @EJB
    private com.kallsony.facade.producto.ProductoFacade ejbFacade;

    final static org.apache.log4j.Logger log = org.apache.log4j.Logger.getLogger(ProductosController.class.getName());
    private List<Producto> items = null;
    private Producto selected;
    private int grupoProducto = 1;
    private int maximaPagina = 1;
    private long total = 0;
    private int tamanioPagina = 1;

    private String tipoFiltro = "A";
    private String valorFiltro = "";
    private boolean filtroActivo = false;
    
    private List<Subcategoria> listaSubcategorias;

    public ProductosController() {
    }

    public Producto getSelected() {
        return selected;
    }

    @PostConstruct
    public void iniciar()
    {
        try
        {
        listaSubcategorias=appSingletonBean.conseguirSubcategorias();
        }
        catch(Exception e)
        {
           log.error("error al conseguir categorias lc ",e);
        }
    }
    
    public void setSelected(Producto selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private ProductoFacade getFacade() {
        return ejbFacade;
    }

    public Producto prepareCreate() {
        selected = new Producto();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/BundleProducto").getString("ProductoCreated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/BundleProducto").getString("ProductoUpdated"));
    }

    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/BundleProducto").getString("ProductoDeleted"));
        if (!JsfUtiles.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<Producto> getItems() {
        int max = 0;

        if (items == null) {
            total = getFacade().count();

            String paginacion = FacesContext.getCurrentInstance().getExternalContext().getInitParameter("kallsony.paginacion");
            tamanioPagina = Integer.parseInt(paginacion);

            max = (int) (total / tamanioPagina);
            log.info("maximo reg " + max + " Tamanio pag " + tamanioPagina);

            if (max % tamanioPagina != 0) {
                max = max + 1;
            }
            if (max == 0) {
                max = max + 1;
            }
            maximaPagina = max;
            log.info("maximaPagina " + maximaPagina);

            items = getFacade().findRange(new int[]{1, tamanioPagina});
        }
        return items;
    }

    private void persist(PersistAction persistAction, String successMessage) {
        if (selected != null) {
            setEmbeddableKeys();
            try {
                if (persistAction != PersistAction.DELETE) {
                    getFacade().edit(selected);
                } else {
                    getFacade().remove(selected);
                }
                JsfUtiles.addSuccessMessage(successMessage);
            } catch (EJBException ex) {
                String msg = "";
                Throwable cause = ex.getCause();
                if (cause != null) {
                    msg = cause.getLocalizedMessage();
                }
                if (msg.length() > 0) {
                    JsfUtiles.addErrorMessage(msg);
                } else {
                    JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleProducto").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                log.error(null, ex);
                JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleProducto").getString("PersistenceErrorOccured"));
            }
        }
    }

    public List<Producto> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<Producto> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = Producto.class)
    public static class ProductoControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            ProductosController controller = (ProductosController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "productoController");
            return controller.getFacade().find(getKey(value));
        }

        java.lang.Integer getKey(String value) {
            java.lang.Integer key;
            key = Integer.valueOf(value);
            return key;
        }

        String getStringKey(java.lang.Integer value) {
            StringBuilder sb = new StringBuilder();
            sb.append(value);
            return sb.toString();
        }

        @Override
        public String getAsString(FacesContext facesContext, UIComponent component, Object object) {
            if (object == null) {
                return null;
            }
            if (object instanceof Producto) {
                Producto o = (Producto) object;
                return getStringKey(o.getIdProducto());
            } else {
                log.error("object {0} is of type {1}; expected type: {2}");
                return null;
            }
        }

    }

    public void conseguirItemsGrupo() {
        log.info("Conseguir Items grupo");

        try {
            log.info("Grupo " + grupoProducto + " Tamaño pagina " + tamanioPagina + " total " + total);
            int rangoMin = ((grupoProducto - 1) * tamanioPagina);
            if (rangoMin == 0) {
                rangoMin = rangoMin + 1;
            }
            int rangoMax = grupoProducto * tamanioPagina;
            log.info("Min " + rangoMin + " Max " + rangoMax);

            FiltroProductoVO filtro = getFacade().filtrarProducto(tipoFiltro, valorFiltro, new int[]{rangoMin, rangoMax});
            paginar(filtro);
            if (filtro != null) {
                items = filtro.getListaProductos();
            } else {
                items = new ArrayList<Producto>();
            }

            selected = null;

        } catch (Exception e) {
            log.error("Error consulta paginacion productos ", e);
        }
    }

    public void conseguirItems() {

        log.info("Tipo Filtro: " + tipoFiltro + " valorFiltro: " + valorFiltro);

        try {
            filtroActivo = true;

            String paginacion = FacesContext.getCurrentInstance().getExternalContext().getInitParameter("kallsony.paginacion");
            tamanioPagina = Integer.parseInt(paginacion);

            FiltroProductoVO filtro = getFacade().filtrarProducto(tipoFiltro, valorFiltro, new int[]{1, tamanioPagina});

            paginar(filtro);
            selected = null;
            grupoProducto = 1;

            if (filtro != null) {
                items = filtro.getListaProductos();
            } else {
                items = new ArrayList<Producto>();
            }
        } catch (Exception e) {
            log.error("Error busqueda producto", e);
        }

    }

    private void paginar(FiltroProductoVO filtro) {
        int max = 0;
        total = 0;
        if (filtro != null) {
            total = filtro.getTotal();

        }

        log.info("Total " + total);
        if (total > 0) {
            max = (int) (total / tamanioPagina);
            log.info("Total " + total + " maximo reg " + max + " Tamanio pag " + tamanioPagina);

            if (max % tamanioPagina != 0) {
                max = max + 1;
            }

        }

        if (max == 0) {
            max = max + 1;
        }

        maximaPagina = max;
        log.info("maximaPagina " + maximaPagina);
    }

    public void reiniciarProductos() {
        log.info("Reiniciar...");
        items = null;
        grupoProducto = 1;
        maximaPagina = 1;
        total = 0;
        tamanioPagina = 1;
        selected = null;
        tipoFiltro = "A";
        valorFiltro = "";
        filtroActivo = false;

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

    public long getTotal() {
        return total;
    }

    public void setTotal(long total) {
        this.total = total;
    }

    public String getValorFiltro() {
        return valorFiltro;
    }

    public void setValorFiltro(String valorFiltro) {
        this.valorFiltro = valorFiltro;
    }

    public String getTipoFiltro() {
        return tipoFiltro;
    }

    public void setTipoFiltro(String tipoFiltro) {
        this.tipoFiltro = tipoFiltro;
    }

    public int getTamanioPagina() {
        return tamanioPagina;
    }

    public void setTamanioPagina(int tamanioPagina) {
        this.tamanioPagina = tamanioPagina;
    }

    public boolean isFiltroActivo() {
        return filtroActivo;
    }

    public void setFiltroActivo(boolean filtroActivo) {
        this.filtroActivo = filtroActivo;
    }

    public List<Subcategoria> getListaSubcategorias() {
        return listaSubcategorias;
    }

    public void setListaSubcategorias(List<Subcategoria> listaSubcategorias) {
        this.listaSubcategorias = listaSubcategorias;
    }
    
    

}
