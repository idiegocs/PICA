/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.vo;

import java.util.Date;

/**
 *
 * @author Diego
 */
public class PagoPrestamoVO {
    
    private String idCliente;
    private long idPrestamo;
    private long  idEntidad;
    private long valorPagar;

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public long getIdPrestamo() {
        return idPrestamo;
    }

    public void setIdPrestamo(long idPrestamo) {
        this.idPrestamo = idPrestamo;
    }

  

    public long getIdEntidad() {
        return idEntidad;
    }

    public void setIdEntidad(long idEntidad) {
        this.idEntidad = idEntidad;
    }

    public long getValorPagar() {
        return valorPagar;
    }

    public void setValorPagar(long valorPagar) {
        this.valorPagar = valorPagar;
    }

   
    
    
    
}
