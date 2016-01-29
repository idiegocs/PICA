/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.campania;

import com.kallsony.entity.campania.Campania;
import com.kallsony.facade.general.AbstractFacade;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author Diego
 */
@Stateless
public class CampaniaFacade extends AbstractFacade<Campania> {
    @PersistenceContext(unitName = "kallsonysOmsCampanias")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public CampaniaFacade() {
        super(Campania.class);
    }
    
}
