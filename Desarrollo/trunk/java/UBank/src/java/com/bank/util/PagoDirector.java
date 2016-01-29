/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.util;

import com.bank.vo.PagoVO;
import org.patrones.www._final.entity.pago.v1.Pago_tipo;

/**
 *
 * @author Diego
 */
public class PagoDirector {

    private PagoWSBuilder pagoBuilder;

    public void setPagoBuilder(PagoWSBuilder pagoBuilder) {
        this.pagoBuilder = pagoBuilder;
    }

    public PagoVO getPago() {
        return pagoBuilder.getPago();
    }

    public void construirPago(Pago_tipo pagoWS) {
        pagoBuilder.crearNuevoPago();
        pagoBuilder.buildPago(pagoWS);

    }
}
