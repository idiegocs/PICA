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
import org.patrones.www._final.entity.pago.v1.Pago_tipo;

/**
 *
 * @author Diego
 */
public class PrincipalPago extends PagoWSBuilder {

    @Override
    public void buildPago(Pago_tipo pagoWS) {

        if (pago != null && pagoWS != null) {
            Cliente_tipo clienteWS = pagoWS.getCliente();
            if (clienteWS != null) {
                ClienteVO clienteVO = new ClienteVO();
                clienteVO.setIdCliente(clienteWS.getId_cliente());
                clienteVO.setNombre(clienteWS.getNombre());
                clienteVO.setApellido(clienteWS.getApellido());

                pago.setClientePago(clienteVO);

            }

            Entidad_bancaria_tipo entidadWS = pagoWS.getEntidad_bancaria();
            if (entidadWS != null) {
                EntidadBancariaVO entidadVO = new EntidadBancariaVO();
                entidadVO.setIdEntidad(entidadWS.getId_entidad());
                entidadVO.setNombreEntidad(entidadWS.getNombre());
                entidadVO.setPais(entidadWS.getPais());
                pago.setEntidadPago(entidadVO);
            }

            pago.setIdPago(pagoWS.getId_pago());
            pago.setValorPago(pagoWS.getValor_pago());
            pago.setFechaProgramada(pagoWS.getFecha_programada());
        }
    }

}
