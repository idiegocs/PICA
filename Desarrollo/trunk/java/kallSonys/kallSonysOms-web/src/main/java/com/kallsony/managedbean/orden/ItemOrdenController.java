package com.kallsony.managedbean.orden;

import com.kallsony.entity.orden.ItemOrden;
import com.kallsony.util.JsfUtiles;
import com.kallsony.util.JsfUtiles.PersistAction;
import com.kallsony.facade.orden.ItemOrdenFacade;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
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

@ManagedBean(name = "itemOrdenController")
@SessionScoped
public class ItemOrdenController implements Serializable {

    @EJB
    private com.kallsony.facade.orden.ItemOrdenFacade ejbFacade;
    private List<ItemOrden> items = null;
    private ItemOrden selected;
    
    private BigDecimal idOrden;
    
     final static org.apache.log4j.Logger log = org.apache.log4j.Logger.getLogger(ItemOrdenController.class.getName());

    public ItemOrdenController() {
        idOrden=new BigDecimal(BigInteger.ZERO);
    }

    public ItemOrden getSelected() {
        return selected;
    }

    public void setSelected(ItemOrden selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private ItemOrdenFacade getFacade() {
        return ejbFacade;
    }

    public ItemOrden prepareCreate() {
        selected = new ItemOrden();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/BundleOrdenes").getString("ItemOrdenCreated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/BundleOrdenes").getString("ItemOrdenUpdated"));
    }

    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/BundleOrdenes").getString("ItemOrdenDeleted"));
        if (!JsfUtiles.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<ItemOrden> getItems() {
        
         
            if(idOrden!= BigDecimal.valueOf(0l))
            {
                log.info("Id Orden "+idOrden);
                items = getFacade().findItemsOrden(idOrden);
            }else
            {
                log.info("All Id OrdenItem "+idOrden);
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

    public BigDecimal getIdOrden() {
        return idOrden;
    }

    public void setIdOrden(BigDecimal idOrden) {
        this.idOrden = idOrden;
    }
    
    

    public List<ItemOrden> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<ItemOrden> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = ItemOrden.class)
    public static class ItemOrdenControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            ItemOrdenController controller = (ItemOrdenController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "itemOrdenController");
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
            if (object instanceof ItemOrden) {
                ItemOrden o = (ItemOrden) object;
                return getStringKey(o.getIditem());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), ItemOrden.class.getName()});
                return null;
            }
        }

    }

}
