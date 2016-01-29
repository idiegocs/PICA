/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.producto;

import com.kallsony.entity.producto.FiltroProductoVO;
import com.kallsony.entity.producto.Producto;
import com.kallsony.entity.producto.Producto_;
import com.kallsony.facade.general.AbstractFacade;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.Root;
import org.eclipse.persistence.jpa.JpaQuery;

/**
 *
 * @author Diego
 */
@Stateless
public class ProductoFacade extends AbstractFacade<Producto> {

    @PersistenceContext(unitName = "kallsonysOmsProductos")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public ProductoFacade() {
        super(Producto.class);
    }

    public int countFiltrarProducto(String tipoFiltro, String valorFiltro) {

        CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
        javax.persistence.criteria.CriteriaQuery cq = cb.createQuery();
        javax.persistence.criteria.Root<Producto> prod = cq.from(Producto.class);
        cq.select(getEntityManager().getCriteriaBuilder().count(prod));
        if ("N".equals(tipoFiltro)) {
            cq.where(cb.like(prod.get(Producto_.nombreProducto), "%" + valorFiltro + "%"));
        } else if ("C".equals(tipoFiltro)) {
            cq.where(cb.like(prod.get(Producto_.codigoProducto), "%" + valorFiltro + "%"));
        } else if ("D".equals(tipoFiltro)) {
            cq.where(cb.like(prod.get(Producto_.descripcionProducto), "%" + valorFiltro + "%"));
        } else if ("F".equals(tipoFiltro)) {

            cq.where(cb.like(prod.get(Producto_.nombreFabricante), "%" + valorFiltro + "%"));
        }

        javax.persistence.Query q = getEntityManager().createQuery(cq);
        return ((Long) q.getSingleResult()).intValue();
    }

    public FiltroProductoVO filtrarProducto(String tipoFiltro, String valorFiltro, int[] range) {
        FiltroProductoVO filtro = new FiltroProductoVO();

        int max = countFiltrarProducto(tipoFiltro, valorFiltro);
        System.out.println("Maximo " + max);
        filtro.setTotal(max);
        
        if (max != 0) {
            CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
            javax.persistence.criteria.CriteriaQuery<Producto> cq = cb.createQuery(Producto.class);

            Root<Producto> prod = cq.from(Producto.class);
            cq.select(prod);
            if ("N".equals(tipoFiltro)) {

                cq.where(cb.like(prod.get(Producto_.nombreProducto), "%" + valorFiltro + "%"));
            } else if ("C".equals(tipoFiltro)) {

                cq.where(cb.like(prod.get(Producto_.codigoProducto), "%" + valorFiltro + "%"));
            } else if ("D".equals(tipoFiltro)) {

                cq.where(cb.like(prod.get(Producto_.descripcionProducto), "%" + valorFiltro + "%"));
            } else if ("F".equals(tipoFiltro)) {

                cq.where(cb.like(prod.get(Producto_.nombreFabricante), "%" + valorFiltro + "%"));
            }

            /*
             TypedQuery findProductos = em.createQuery(cq);
             String sQuery=findProductos.unwrap(JpaQuery.class).getDatabaseQuery().getSQLString(); 
             System.out.println("valor Filtro "+valorFiltro+ " Query "+sQuery);
             */
            javax.persistence.Query q = getEntityManager().createQuery(cq);

            q.setMaxResults(range[1] - range[0] + 1);
            System.out.println("rando dif "+((range[1] - range[0]) + 1));
            System.out.println("rando ini "+range[0]);
            q.setFirstResult(range[0]-1);
            filtro.setListaProductos(q.getResultList());
        }

        return filtro;
    }
}
