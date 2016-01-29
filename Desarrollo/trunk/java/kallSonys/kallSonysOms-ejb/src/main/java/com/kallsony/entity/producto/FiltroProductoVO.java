/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.producto;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Diego
 */
public class FiltroProductoVO {

    public FiltroProductoVO() {
        total=0;
        listaProductos=new ArrayList<Producto>();
    }
    
    private int total;
    
    private List<Producto> listaProductos;

    public int getTotal() {
        return total;
    }

    public void setTotal(int total) {
        this.total = total;
    }

    public List<Producto> getListaProductos() {
        return listaProductos;
    }

    public void setListaProductos(List<Producto> listaProductos) {
        this.listaProductos = listaProductos;
    }
    
    
    
}
