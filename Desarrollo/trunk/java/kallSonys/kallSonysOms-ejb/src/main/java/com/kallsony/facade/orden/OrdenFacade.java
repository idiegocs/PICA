/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.orden;

import com.kallsony.entity.orden.FiltroOrdenVO;
import com.kallsony.entity.orden.Orden;
import com.kallsony.entity.orden.Orden_;
import com.kallsony.entity.orden.Usuario_;
import com.kallsony.facade.general.AbstractFacade;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import javax.ejb.Local;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.TemporalType;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.Root;

/**
 *
 * @author Diego
 */
@Stateless
public class OrdenFacade extends AbstractFacade<Orden> {

    @PersistenceContext(unitName = "kallsonysOmsOrdenes")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public OrdenFacade() {
        super(Orden.class);
    }

    public int countFiltrarOrden(String tipoFiltro, String valorFiltro) {

        CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
        javax.persistence.criteria.CriteriaQuery cq = cb.createQuery();
        javax.persistence.criteria.Root<Orden> prod = cq.from(Orden.class);
        cq.select(getEntityManager().getCriteriaBuilder().count(prod));
        if ("N".equals(tipoFiltro)) {
            BigInteger preorden = BigInteger.ONE;
            try {
                preorden = new BigInteger(valorFiltro);
            } catch (NumberFormatException n) {
                n.printStackTrace();
            } catch (Exception e) {
                e.printStackTrace();
            }

            cq.where(cb.equal(prod.get(Orden_.numpreorden), preorden));
        } else if ("U".equals(tipoFiltro)) {
            cq.where(cb.like((prod.get(Orden_.idcliente)).get(Usuario_.username), valorFiltro + "%"));
        }

        javax.persistence.Query q = getEntityManager().createQuery(cq);
        return ((Long) q.getSingleResult()).intValue();
    }

    public FiltroOrdenVO filtrarOrden(String tipoFiltro, String valorFiltro, int[] range) {
        FiltroOrdenVO filtro = new FiltroOrdenVO();

        int max = countFiltrarOrden(tipoFiltro, valorFiltro);
        System.out.println("Maximo " + max);
        filtro.setTotal(max);

        if (max != 0) {
            CriteriaBuilder cb = getEntityManager().getCriteriaBuilder();
            javax.persistence.criteria.CriteriaQuery<Orden> cq = cb.createQuery(Orden.class);

            Root<Orden> prod = cq.from(Orden.class);
            cq.select(prod);
            if ("N".equals(tipoFiltro)) {

                BigInteger preorden = BigInteger.ONE;
                try {
                    preorden = new BigInteger(valorFiltro);
                } catch (NumberFormatException n) {
                    n.printStackTrace();
                } catch (Exception e) {
                    e.printStackTrace();
                }
                System.out.println("preorden " + preorden);
                cq.where(cb.equal(prod.get(Orden_.numpreorden), preorden));
            } else if ("U".equals(tipoFiltro)) {
                cq.where(cb.like((prod.get(Orden_.idcliente)).get(Usuario_.username), valorFiltro + "%"));
            }

            javax.persistence.Query q = getEntityManager().createQuery(cq);

            q.setMaxResults(range[1] - range[0] + 1);
            System.out.println("rando dif " + ((range[1] - range[0]) + 1));
            System.out.println("rando ini " + range[0]);
            q.setFirstResult(range[0] - 1);
            filtro.setListaOrdenes(q.getResultList());
            System.out.println("maximo " + max + " lista " + filtro.getListaOrdenes().size());
        }
        return filtro;

    }

    public String consultarRankingProductos(Date ini, Date fin) {
        StringBuffer ids = new StringBuffer("");

        /*
        Date ini = null;
        Date fin = null;
        Calendar calendarIni = Calendar.getInstance();
        calendarIni.set(2015, 4, 21);
        ini = calendarIni.getTime();
        Calendar calendarFin = Calendar.getInstance();
        calendarFin.set(2015, 5, 1);
        fin = calendarFin.getTime();
        */

        System.out.println("Param ini " + ini + " fin " + fin);
        //Query q = this.getEntityManager().createNamedQuery("Orden.buscarProductosFechas");
        String sql = "SELECT * "
                + " FROM (select it.IDPRODUCTO, sum(it.CANTIDADITEM) as  totalCantidad from  ORDEN o JOIN ITEM_ORDEN it on it.IDORDEN=o.IDORDEN "
                + " where FECHAORDEN>= ? and FECHAORDEN<= ? "
                + " GROUP BY IDPRODUCTO ORDER BY totalCantidad desc) ";

        Query q = this.getEntityManager().createNativeQuery(sql);
        q.setParameter(1, ini, TemporalType.DATE);
        q.setParameter(2, fin, TemporalType.DATE);
        q.setMaxResults(20);

        List<Object[]> result = q.getResultList();

        try {
            if (result != null && !result.isEmpty()) {
                BigDecimal idProd = null;
                BigDecimal totalItem = null;

                for (Object[] resultElement : result) {
                    idProd = (BigDecimal) resultElement[0];
                    totalItem = (BigDecimal) resultElement[1];
                    ids.append("|");
                    ids.append(idProd);
                    System.out.println("idProd " + idProd + " totalItem " + totalItem + " ids " + ids);
                }

            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return ids.toString();
    }

}
