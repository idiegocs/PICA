package com.kallsony.managedbean.orden;

import com.kallsony.app.appSingletonBean;
import com.kallsony.entity.orden.CategoriaCliente;
import com.kallsony.entity.orden.Ciudad;
import com.kallsony.entity.orden.Direccion;
import com.kallsony.entity.orden.FiltroUsuarioVO;
import com.kallsony.entity.orden.Usuario;
import com.kallsony.util.JsfUtiles;
import com.kallsony.util.JsfUtiles.PersistAction;
import com.kallsony.facade.orden.UsuarioFacade;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;

@ManagedBean(name = "usuarioController")
@SessionScoped
public class UsuarioController implements Serializable {

    @EJB
    private appSingletonBean appSingletonBean;

    @EJB
    private com.kallsony.facade.orden.UsuarioFacade ejbFacade;
    private List<Usuario> items = null;
    private Usuario selected;

    private String tipoFiltro = "A";
    private String valorFiltro = "";
    private boolean filtroActivo = false;

    private int tamanioPagina = 1;
    private int grupoOrden = 1;
    private long total = 0;
    private int maximaPagina = 1;

    private List<CategoriaCliente> listaCategorias = new ArrayList<CategoriaCliente>();
    private List<Ciudad> listaCiudades=new ArrayList<Ciudad>();

    final static org.apache.log4j.Logger log = org.apache.log4j.Logger.getLogger(UsuarioController.class.getName());

    public UsuarioController() {
    }

    @PostConstruct
    public void init() {
        listaCategorias = appSingletonBean.conseguirCategoriasCliente();
        listaCiudades=appSingletonBean.conseguirCiudades();
    }

    public Usuario getSelected() {
        
        if(selected!=null)
        {
            if(selected.getDireccion()==null)
            {
                selected.setDireccion(new Direccion());
                selected.getDireccion().setIdciudad(new Ciudad());
            }
            if(selected.getIdcategoria()==null)
            {
                selected.setIdcategoria(new CategoriaCliente());
            }
        }
        return selected;
    }

    public void setSelected(Usuario selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private UsuarioFacade getFacade() {
        return ejbFacade;
    }

    public Usuario prepareCreate() {
        selected = new Usuario();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/BundleOrdenes").getString("UsuarioCreated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/BundleOrdenes").getString("UsuarioUpdated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/BundleOrdenes").getString("UsuarioDeleted"));
        if (!JsfUtiles.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<Usuario> getItems() {
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

            items = getFacade().findRange(new int[]{0, tamanioPagina});
        }
        return items;

    }

    public void conseguirItems() {

        log.info("Tipo Filtro: " + tipoFiltro + " valorFiltro: " + valorFiltro);

        try {
            filtroActivo = true;

            String paginacion = FacesContext.getCurrentInstance().getExternalContext().getInitParameter("kallsony.paginacion");
            tamanioPagina = Integer.parseInt(paginacion);

            FiltroUsuarioVO filtro = getFacade().filtrarUsuario(tipoFiltro, valorFiltro, new int[]{1, tamanioPagina});

            paginar(filtro);
            selected = null;
            grupoOrden = 1;

            if (filtro != null) {
                items = filtro.getListaUsuarios();
            } else {
                items = new ArrayList<Usuario>();
            }
        } catch (Exception e) {
            log.error("Error busqueda producto", e);
        }

    }

    public void conseguirItemsGrupo() {
        log.info("Conseguir Items grupo");

        try {
            log.info("Grupo " + grupoOrden + " Tamaño pagina " + tamanioPagina + " total " + total);
            int rangoMin = ((grupoOrden - 1) * tamanioPagina);
            if (rangoMin == 0) {
                rangoMin = rangoMin + 1;
            }
            int rangoMax = grupoOrden * tamanioPagina;
            log.info("Min " + rangoMin + " Max " + rangoMax);

            FiltroUsuarioVO filtro = getFacade().filtrarUsuario(tipoFiltro, valorFiltro, new int[]{rangoMin, rangoMax});
            paginar(filtro);
            if (filtro != null) {
                items = filtro.getListaUsuarios();
            } else {
                items = new ArrayList<Usuario>();
            }

            selected = null;

        } catch (Exception e) {
            log.error("Error consulta paginacion productos ", e);
        }
    }

    private void paginar(FiltroUsuarioVO filtro) {
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

    public void reiniciarOrdenes() {
        log.info("Reiniciar...");
        items = null;
        grupoOrden = 1;
        maximaPagina = 1;
        total = 0;
        tamanioPagina = 1;
        selected = null;
        tipoFiltro = "A";
        valorFiltro = "";
        filtroActivo = false;

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

    public boolean isFiltroActivo() {
        return filtroActivo;
    }

    public void setFiltroActivo(boolean filtroActivo) {
        this.filtroActivo = filtroActivo;
    }

    public int getTamanioPagina() {
        return tamanioPagina;
    }

    public void setTamanioPagina(int tamanioPagina) {
        this.tamanioPagina = tamanioPagina;
    }

    public int getGrupoOrden() {
        return grupoOrden;
    }

    public void setGrupoOrden(int grupoOrden) {
        this.grupoOrden = grupoOrden;
    }

    public long getTotal() {
        return total;
    }

    public void setTotal(long total) {
        this.total = total;
    }

    public int getMaximaPagina() {
        return maximaPagina;
    }

    public void setMaximaPagina(int maximaPagina) {
        this.maximaPagina = maximaPagina;
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
                    JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleOrdenes").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
                JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleOrdenes").getString("PersistenceErrorOccured"));
            }
        }
    }

    public List<Usuario> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<Usuario> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = Usuario.class)
    public static class UsuarioControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            UsuarioController controller = (UsuarioController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "usuarioController");
            return controller.getFacade().find(getKey(value));
        }

        java.lang.Long getKey(String value) {
            java.lang.Long key;
            key = Long.valueOf(value);
            return key;
        }

        String getStringKey(java.lang.Long value) {
            StringBuilder sb = new StringBuilder();
            sb.append(value);
            return sb.toString();
        }

        @Override
        public String getAsString(FacesContext facesContext, UIComponent component, Object object) {
            if (object == null) {
                return null;
            }
            if (object instanceof Usuario) {
                Usuario o = (Usuario) object;
                return getStringKey(o.getIdusuario());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), Usuario.class.getName()});
                return null;
            }
        }

    }

    public List<CategoriaCliente> getListaCategorias() {
        return listaCategorias;
    }

    public void setListaCategorias(List<CategoriaCliente> listaCategorias) {
        this.listaCategorias = listaCategorias;
    }

    public List<Ciudad> getListaCiudades() {
        return listaCiudades;
    }

    public void setListaCiudades(List<Ciudad> listaCiudades) {
        this.listaCiudades = listaCiudades;
    }
    
    

}
