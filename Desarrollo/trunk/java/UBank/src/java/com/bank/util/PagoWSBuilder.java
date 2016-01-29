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
abstract class PagoWSBuilder {

    protected PagoVO pago;

    public PagoVO getPago() {
        return pago;
    }

    public void crearNuevoPago() {
        pago = new PagoVO();

    }
    
    public abstract void buildPago(Pago_tipo pagoWS);

}
