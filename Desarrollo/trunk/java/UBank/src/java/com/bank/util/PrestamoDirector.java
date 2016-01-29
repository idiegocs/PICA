/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.util;

import com.bank.vo.PrestamoVO;
import org.patrones.www._final.entity.prestamo.v1.Prestamo_tipo;

/**
 *
 * @author Diego
 */
public class PrestamoDirector {

    private PrestamoWSBuilder prestamoBuilder;

    public void setPrestamoBuilder(PrestamoWSBuilder prestamoBuilder) {
        this.prestamoBuilder = prestamoBuilder;
    }

    public PrestamoVO getPrestamo() {
        return prestamoBuilder.getPrestamo();
    }

    public void construirPrestamo(Prestamo_tipo prestamoWS) {
        prestamoBuilder.crearNuevoPrestamo();
        prestamoBuilder.buildPrestamo(prestamoWS);

    }
}
