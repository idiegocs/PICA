/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.integration;

import com.bank.ejb.ClientFacadeBean;
import com.bank.vo.ClienteVO;
import com.bank.vo.PrestamoVO;
import com.bank.util.PrestamoDirector;
import com.bank.util.PrincipalPrestamo;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.Stateless;
import org.patrones.www._final.entity.cliente.v1.Cliente_tipo;

import org.patrones.www._final.entity.operacion.prestamo.v1.Consultar_prestamo_tipo;
import org.patrones.www._final.entity.operacion.prestamo.v1.Resultado_prestamo_tipo;
import org.patrones.www._final.entity.prestamo.v1.Prestamo_tipo;
import org.patrones.www._final.provedores.prestamos.v1.PrestamosProxy;

/**
 *
 * @author Diego
 */
@Stateless
public class PrestamoSessionBean {

    public List<PrestamoVO> conseguirDatosPrestamo(ClienteVO cliente) throws Exception {
        List<PrestamoVO> listaPrestamo = new ArrayList<PrestamoVO>();

        PrestamosProxy prestamoClient = null;
        Consultar_prestamo_tipo cuentaPrestamoWS = null;

        try {
            Cliente_tipo clienteEntradaWS = new Cliente_tipo();
            clienteEntradaWS.setId_cliente(cliente.idCliente);
            cuentaPrestamoWS = new Consultar_prestamo_tipo();
            cuentaPrestamoWS.setCliente(clienteEntradaWS);
            prestamoClient = new PrestamosProxy();

            Resultado_prestamo_tipo cuentaPrestamoResWS = prestamoClient.consultarPrestamos(cuentaPrestamoWS);

            if (cuentaPrestamoResWS != null) {
                Prestamo_tipo[] prestamosArreglo = cuentaPrestamoResWS.getPrestamos();
                Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "prestamosArreglo " +prestamosArreglo.length);
                PrestamoVO prestamoVO = null;
                for (Prestamo_tipo prestamo : prestamosArreglo) {
               
                    //patron builder
                    PrestamoDirector pDirector = new PrestamoDirector();
                    //tipo builder
                    PrincipalPrestamo prestamobuilder = new PrincipalPrestamo();
                    pDirector.setPrestamoBuilder(prestamobuilder);
                    
                    pDirector.construirPrestamo(prestamo);
                    prestamoVO = pDirector.getPrestamo();
                    
                    if (prestamoVO != null) {
                        listaPrestamo.add(prestamoVO);
                    }
                }
            }
        } catch (RemoteException ex) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, ex);
            throw new Exception(ex);
        } catch (Exception e) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, e);
            throw new Exception(e);
        } finally {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "ListaPrestamos " + listaPrestamo.size());
        }

        return listaPrestamo;
    }
}
