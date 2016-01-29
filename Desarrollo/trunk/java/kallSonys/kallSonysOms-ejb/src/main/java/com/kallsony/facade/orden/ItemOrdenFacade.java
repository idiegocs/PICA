/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.orden;

import com.kallsony.entity.orden.ItemOrden;
import com.kallsony.entity.orden.ItemOrden_;
import com.kallsony.facade.general.AbstractFacade;
import java.math.BigDecimal;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.Root;

/**
 *
 * @author Diego
 */
@Stateless
public class ItemOrdenFacade extends AbstractFacade<ItemOrden> {

    @PersistenceContext(unitName = "kallsonysOmsOrdenes")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public ItemOrdenFacade() {
        super(ItemOrden.class);
    }

    public List<ItemOrden> findItemsOrden(BigDecimal idOrden) {
        List<ItemOrden> itemsOrden = null;

        Query q=getEntityManager().createNamedQuery("ItemOrden.findByOrden");
        q.setParameter("idorden",idOrden);
        
        itemsOrden = q.getResultList();

        return itemsOrden;

    }

}
