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
public class FiltroUsuarioVO {

    private int total;

    private List<Usuario> listaUsuarios;

    public FiltroUsuarioVO() {
        total = 0;
        listaUsuarios = new ArrayList<Usuario>();
    }

    public int getTotal() {
        return total;
    }

    public void setTotal(int total) {
        this.total = total;
    }

    public List<Usuario> getListaUsuarios() {
        return listaUsuarios;
    }

    public void setListaUsuarios(List<Usuario> listaUsuarios) {
        this.listaUsuarios = listaUsuarios;
    }

}
