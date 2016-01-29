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
public class PagoVO {
    
    private ClienteVO clientePago;
    private EntidadBancariaVO entidadPago;
    
    private long idPago;
    private long valorPago;
    
    private Date fechaProgramada;
    

    public ClienteVO getClientePago() {
        return clientePago;
    }

    public void setClientePago(ClienteVO clientePago) {
        this.clientePago = clientePago;
    }

    public EntidadBancariaVO getEntidadPago() {
        return entidadPago;
    }

    public void setEntidadPago(EntidadBancariaVO entidadPago) {
        this.entidadPago = entidadPago;
    }

    public long getIdPago() {
        return idPago;
    }

    public void setIdPago(long idPago) {
        this.idPago = idPago;
    }

    public long getValorPago() {
        return valorPago;
    }

    public void setValorPago(long valorPago) {
        this.valorPago = valorPago;
    }

    public Date getFechaProgramada() {
        return fechaProgramada;
    }

    public void setFechaProgramada(Date fechaProgramada) {
        this.fechaProgramada = fechaProgramada;
    }
    
    
    
    
}
