/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.orden;

import com.kallsony.entity.orden.CategoriaCliente;
import com.kallsony.entity.orden.Ciudad;
import com.kallsony.entity.orden.FiltroUsuarioVO;
import com.kallsony.entity.orden.Usuario;
import com.kallsony.entity.orden.Usuario_;
import com.kallsony.facade.general.AbstractFacade;
import java.util.ArrayList;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.Root;

/**
 *
 * @author Diego
 */
@Stateless
public class UsuarioFacade extends AbstractFacade<Usuario> {

    @PersistenceContext(unitName = "kallsonysOmsOrdenes")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public UsuarioFacade() {
        super(Usuario.class);
    }

    public int countFiltrarOrden(String tipoFiltro, String valorFiltro) {

        CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
        javax.persistence.criteria.CriteriaQuery cq = cb.createQuery();
        javax.persistence.criteria.Root<Usuario> prod = cq.from(Usuario.class);
        cq.select(getEntityManager().getCriteriaBuilder().count(prod));
        if ("U".equals(tipoFiltro)) {
            cq.where(cb.like(prod.get(Usuario_.username), valorFiltro + "%"));
        } else if ("N".equals(tipoFiltro)) {
            cq.where(cb.like(prod.get(Usuario_.numerodocumento), valorFiltro + "%"));
        }

        javax.persistence.Query q = getEntityManager().createQuery(cq);
        return ((Long) q.getSingleResult()).intValue();
    }

    public FiltroUsuarioVO filtrarUsuario(String tipoFiltro, String valorFiltro, int[] range) {
        FiltroUsuarioVO filtro = new FiltroUsuarioVO();

        int max = countFiltrarOrden(tipoFiltro, valorFiltro);
        System.out.println("Maximo " + max);
        filtro.setTotal(max);

        if (max != 0) {
            CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
            javax.persistence.criteria.CriteriaQuery<Usuario> cq = cb.createQuery(Usuario.class);

            Root<Usuario> prod = cq.from(Usuario.class);
            cq.select(prod);
            if ("U".equals(tipoFiltro)) {
                cq.where(cb.like(prod.get(Usuario_.username), valorFiltro + "%"));
            } else if ("N".equals(tipoFiltro)) {
                cq.where(cb.like(prod.get(Usuario_.numerodocumento), valorFiltro + "%"));
            }

            javax.persistence.Query q = getEntityManager().createQuery(cq);

            q.setMaxResults(range[1] - range[0] + 1);
            System.out.println("rando dif " + ((range[1] - range[0]) + 1));
            System.out.println("rando ini " + range[0]);
            q.setFirstResult(range[0] - 1);
            filtro.setListaUsuarios(q.getResultList());
            System.out.println("maximo " + max + " lista " + filtro.getListaUsuarios().size());
        }
        return filtro;

    }
    
    
    public List<CategoriaCliente> conseguirCategorias()
    {
        List<CategoriaCliente> lcategorrias;
        lcategorrias = new ArrayList<CategoriaCliente>();
        
        javax.persistence.Query q = getEntityManager().createNamedQuery("CategoriaCliente.findAll");
        lcategorrias=q.getResultList();
        
        return lcategorrias;
    }
    
    public List<Ciudad> conseguirCiudades()
    {
        List<Ciudad> lciudades;
        lciudades = new ArrayList<Ciudad>();
        
        javax.persistence.Query q = getEntityManager().createNamedQuery("Ciudad.findAll");
        lciudades=q.getResultList();
        
        return lciudades;
    }

}
