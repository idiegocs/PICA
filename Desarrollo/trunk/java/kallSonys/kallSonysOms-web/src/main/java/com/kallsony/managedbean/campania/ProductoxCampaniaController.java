package com.kallsony.managedbean.campania;

import com.kallsony.entity.campania.ProductoxCampania;
import com.kallsony.util.JsfUtiles;
import com.kallsony.util.JsfUtiles.PersistAction;
import com.kallsony.facade.campania.ProductoxCampaniaFacade;

import java.io.Serializable;
import java.util.ArrayList;
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

@ManagedBean(name = "productoxCampaniaController")
@SessionScoped
public class ProductoxCampaniaController implements Serializable {

    @EJB
    private com.kallsony.facade.campania.ProductoxCampaniaFacade ejbFacade;
    private List<ProductoxCampania> items = null;
    private ProductoxCampania selected;

    public ProductoxCampaniaController() {
    }

    public ProductoxCampania getSelected() {
        return selected;
    }

    public void setSelected(ProductoxCampania selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private ProductoxCampaniaFacade getFacade() {
        return ejbFacade;
    }

    public ProductoxCampania prepareCreate() {
        selected = new ProductoxCampania();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/BundleCampanias").getString("ProductoxCampaniaCreated"));
        if (!JsfUtiles.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/BundleCampanias").getString("ProductoxCampaniaUpdated"));
    }

    
    
    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/BundleCampanias").getString("ProductoxCampaniaDeleted"));
        if (!JsfUtiles.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<ProductoxCampania> getItems() {
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
                    JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleCampanias").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
                JsfUtiles.addErrorMessage(ex, ResourceBundle.getBundle("/BundleCampanias").getString("PersistenceErrorOccured"));
            }
        }
    }

    public List<ProductoxCampania> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<ProductoxCampania> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = ProductoxCampania.class)
    public static class ProductoxCampaniaControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            ProductoxCampaniaController controller = (ProductoxCampaniaController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "productoxCampaniaController");
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
            if (object instanceof ProductoxCampania) {
                ProductoxCampania o = (ProductoxCampania) object;
                return getStringKey(o.getIdProductoxCampania());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), ProductoxCampania.class.getName()});
                return null;
            }
        }

    }

}
