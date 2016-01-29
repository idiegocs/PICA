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
abstract class PrestamoWSBuilder {

    protected PrestamoVO prestamo;

    public PrestamoVO getPrestamo() {
        return prestamo;
    }

    public void crearNuevoPrestamo() {
        prestamo = new PrestamoVO();

    }
    
    public abstract void buildPrestamo(Prestamo_tipo prestamoWS);

}
