package com.kallsony.managedbean.orden;

import com.kallsony.entity.orden.EstadoOrden;
import com.kallsony.util.JsfUtiles;
import com.kallsony.util.JsfUtiles.PersistAction;
import com.kallsony.facade.orden.EstadoOrdenFacade;

import java.io.Serializable;
import java.util.List;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;

@ManagedBean(name = "estadoOrdenController")
@SessionScoped
public class EstadoOrdenController implements Serializable {

    @EJB
    private com.kallsony.facade.orden.EstadoOrdenFacade ejbFacade;
    private List<EstadoOrden> items = null;
    private EstadoOrden selected;

    public EstadoOrdenController() {
    }

    public EstadoOrden getSelected() {
        return selected;
    }

    public void setSelected(EstadoOrden selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private EstadoOrdenFacade getFacade() {
        return ejbFacade;
    }

    public EstadoOrden prepareCreate() {
        selected = new EstadoOrden();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/BundleOrdenes").getString("EstadoOrdenCreated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/BundleOrdenes").getString("EstadoOrdenUpdated"));
    }

    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/BundleOrdenes").getString("EstadoOrdenDeleted"));
        if (!JsfUtiles.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<EstadoOrden> getItems() {
        if (items == null) {
            items = getFacade().findAll();
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
                    JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleOrdenes").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
                JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleOrdenes").getString("PersistenceErrorOccured"));
            }
        }
    }

    public List<EstadoOrden> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<EstadoOrden> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = EstadoOrden.class)
    public static class EstadoOrdenControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            EstadoOrdenController controller = (EstadoOrdenController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "estadoOrdenController");
            return controller.getFacade().find(getKey(value));
        }

        java.math.BigDecimal getKey(String value) {
            java.math.BigDecimal key;
            key = new java.math.BigDecimal(value);
            return key;
        }

        String getStringKey(java.math.BigDecimal value) {
            StringBuilder sb = new StringBuilder();
            sb.append(value);
            return sb.toString();
        }

        @Override
        public String getAsString(FacesContext facesContext, UIComponent component, Object object) {
            if (object == null) {
                return null;
            }
            if (object instanceof EstadoOrden) {
                EstadoOrden o = (EstadoOrden) object;
                return getStringKey(o.getIdestadoorden());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), EstadoOrden.class.getName()});
                return null;
            }
        }

    }

}
