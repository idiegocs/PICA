/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.util;

import com.bank.vo.ClienteVO;
import com.bank.vo.EntidadBancariaVO;
import org.patrones.www._final.entity.cliente.v1.Cliente_tipo;
import org.patrones.www._final.entity.entidad_bancaria.v1.Entidad_bancaria_tipo;
import org.patrones.www._final.entity.prestamo.v1.Prestamo_tipo;

/**
 *
 * @author Diego
 */
public class PrincipalPrestamo extends PrestamoWSBuilder {

    public void buildPrestamo(Prestamo_tipo prestamoWS) {

        if (prestamoWS != null && prestamo != null) {
            Cliente_tipo clienteWS = prestamoWS.getCliente();
            if (clienteWS != null) {
                ClienteVO clienteVO = new ClienteVO();
                clienteVO.setIdCliente(clienteWS.getId_cliente());
                clienteVO.setNombre(clienteWS.getNombre());
                clienteVO.setApellido(clienteWS.getApellido());

                prestamo.setClientePrestamo(clienteVO);

            }

            Entidad_bancaria_tipo entidadWS = prestamoWS.getEntidad_bancaria();
            if (entidadWS != null) {
                EntidadBancariaVO entidadVO = new EntidadBancariaVO();
                entidadVO.setIdEntidad(entidadWS.getId_entidad());
                entidadVO.setNombreEntidad(entidadWS.getNombre());
                entidadVO.setPais(entidadWS.getPais());
                prestamo.setEntidadPrestamo(entidadVO);
            }

            prestamo.setIdPrestamo(prestamoWS.getId_prestamo());
            prestamo.setSaldoActual(prestamoWS.getSaldo_actual());
            prestamo.setValorPrestamo(prestamoWS.getValor_prestamo());
            prestamo.setTasaInteres(prestamoWS.getTasa_interes());
        }

    }

}
