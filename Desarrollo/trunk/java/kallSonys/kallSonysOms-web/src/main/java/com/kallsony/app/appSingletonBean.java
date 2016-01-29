/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.app;

import com.kallsony.entity.campania.Subcategoria;
import com.kallsony.entity.orden.CategoriaCliente;
import com.kallsony.entity.orden.Ciudad;
import com.kallsony.facade.campania.SubcategoriaFacade;
import com.kallsony.facade.orden.UsuarioFacade;
import java.util.List;
import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.ejb.Singleton;
import javax.ejb.Startup;

/**
 *
 * @author Diego
 */
@Startup
@Singleton
public class appSingletonBean {
    @EJB
    private UsuarioFacade usuarioFacade;
    @EJB
    private SubcategoriaFacade subcategoriaFacade;
    
    

    final static org.apache.log4j.Logger log = org.apache.log4j.Logger.getLogger(appSingletonBean.class.getName());
    
    List<Subcategoria> subcategorias;
    List<CategoriaCliente> categoriasCliente;
    List<Ciudad> ciudades;
            
    public appSingletonBean() {
        
        
        
    }
    
    @PostConstruct
    public void iniciar()
    {
        try
        {
        subcategorias= subcategoriaFacade.findAll();
        
        log.info("Subcategorias Iniciadas "+subcategorias.size());
        
        categoriasCliente=usuarioFacade.conseguirCategorias();
        log.info("Categorias Clientes Iniciadas "+categoriasCliente.size());
        
        ciudades=usuarioFacade.conseguirCiudades();
        log.info("Ciudades  "+ciudades.size());
        
        }
        catch(Exception e)
        {
            log.error("Erro al conseguir subcategorias",e);
        }
        
    }

    
   
    public List<Subcategoria> refrescarSubcategorias() {
        
         subcategorias= subcategoriaFacade.findAll();
         return subcategorias;
    }
    
     public List<Subcategoria> conseguirSubcategorias() {
        
         return subcategorias;
    }
     
      public List<CategoriaCliente> conseguirCategoriasCliente() {
        
         return categoriasCliente;
    }
      
       public List<Ciudad> conseguirCiudades() {
        
         return  ciudades;
    }

    // Add business logic below. (Right-click in editor and choose
   
}
