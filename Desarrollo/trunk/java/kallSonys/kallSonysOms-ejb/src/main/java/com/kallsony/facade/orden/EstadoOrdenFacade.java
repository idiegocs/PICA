/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.orden;

import com.kallsony.entity.orden.EstadoOrden;
import com.kallsony.facade.general.AbstractFacade;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author Diego
 */
@Stateless
public class EstadoOrdenFacade extends AbstractFacade<EstadoOrden> {
    @PersistenceContext(unitName = "kallsonysOmsOrdenes")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public EstadoOrdenFacade() {
        super(EstadoOrden.class);
    }
    
}
