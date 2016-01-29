/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Diego
 */
public class FiltroOrdenVO {

    public FiltroOrdenVO() {
       total=0;
        listaOrdenes=new ArrayList<Orden>();
    }
    
    private int total;
    
    private List<Orden> listaOrdenes;

    public int getTotal() {
        return total;
    }

    public void setTotal(int total) {
        this.total = total;
    }

    public List<Orden> getListaOrdenes() {
        return listaOrdenes;
    }

    public void setListaOrdenes(List<Orden> listaOrdenes) {
        this.listaOrdenes = listaOrdenes;
    }
    
    
    
}
