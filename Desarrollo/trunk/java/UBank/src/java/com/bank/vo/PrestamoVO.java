/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.vo;

/**
 *
 * @author Diego
 */
public class PrestamoVO {
    
    private ClienteVO clientePrestamo;
    
    private EntidadBancariaVO entidadPrestamo;
    
    private long idPrestamo;
    
    private  long valorPrestamo;
    
    private long saldoActual;
    
    private double tasaInteres;
    
    private long valorPagar;

    public ClienteVO getClientePrestamo() {
        return clientePrestamo;
    }

    public void setClientePrestamo(ClienteVO clientePrestamo) {
        this.clientePrestamo = clientePrestamo;
    }

    public EntidadBancariaVO getEntidadPrestamo() {
        return entidadPrestamo;
    }

    public void setEntidadPrestamo(EntidadBancariaVO entidadPrestamo) {
        this.entidadPrestamo = entidadPrestamo;
    }

    public long getIdPrestamo() {
        return idPrestamo;
    }

    public void setIdPrestamo(long idPrestamo) {
        this.idPrestamo = idPrestamo;
    }

    public long getValorPrestamo() {
        return valorPrestamo;
    }

    public void setValorPrestamo(long valorPrestamo) {
        this.valorPrestamo = valorPrestamo;
    }

    public long getSaldoActual() {
        return saldoActual;
    }

    public void setSaldoActual(long saldoActual) {
        this.saldoActual = saldoActual;
    }

    public double getTasaInteres() {
        return tasaInteres;
    }

    public void setTasaInteres(double tasaInteres) {
        this.tasaInteres = tasaInteres;
    }

    public long getValorPagar() {
        return valorPagar;
    }

    public void setValorPagar(long valorPagar) {
        this.valorPagar = valorPagar;
    }
    
    
    
    
}
