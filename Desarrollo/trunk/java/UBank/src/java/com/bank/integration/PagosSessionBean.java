/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.integration;

import com.bank.ejb.ClientFacadeBean;
import com.bank.util.PagoDirector;
import com.bank.util.PrincipalPago;
import com.bank.vo.ClienteVO;
import com.bank.vo.GeneralVO;
import com.bank.vo.PagoPrestamoVO;
import com.bank.vo.PagoProgramadoVO;
import com.bank.vo.PagoVO;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.Stateless;
import org.patrones.www._final.entity.cliente.v1.Cliente_tipo;
import org.patrones.www._final.entity.entidad_bancaria.v1.Entidad_bancaria_tipo;
import org.patrones.www._final.entity.operacion.general.v1.General_type;
import org.patrones.www._final.entity.operacion.pagos.consulta.v1.Consultar_pago_tipo;
import org.patrones.www._final.entity.operacion.pagos.consulta.v1.Resultado_pago_tipo;
import org.patrones.www._final.entity.operacion.pagos.ejecutar.v1.Ejecutar_pago_tipo;
import org.patrones.www._final.entity.operacion.pagos.ejecutar.v1.Respuesta_pago_tipo;
import org.patrones.www._final.entity.operacion.prestamo.ejecutar.v1.Prestamo_pago_tipo;
import org.patrones.www._final.entity.operacion.prestamo.ejecutar.v1.Respuesta_prestamo_pago;
import org.patrones.www._final.entity.pago.v1.Pago_tipo;
import org.patrones.www._final.entity.prestamo.v1.Prestamo_tipo;
import org.patrones.www._final.sistema.pagos.ejecucion.v1.EjecutarPagosProxy;
import org.patrones.www._final.sistema.pagos.v1.PagosProxy;
import org.patrones.www._final.sistema.prestamo.ejecucion.v1.EjecutarPrestamoPagoProxy;

/**
 *
 * @author Diego
 */
@Stateless
public class PagosSessionBean {

    public List<PagoVO> conseguirDatosPagos(ClienteVO cliente) throws Exception {
        List<PagoVO> listaPagos = new ArrayList<PagoVO>();

        PagosProxy pagosClient = null;
        Consultar_pago_tipo consultaPago = null;
        Cliente_tipo clienteTipo = null;
        Resultado_pago_tipo resultadoPagoWS = null;
        try {

            pagosClient = new PagosProxy();
            consultaPago = new Consultar_pago_tipo();
            clienteTipo = new Cliente_tipo();
            clienteTipo.setId_cliente(cliente.getIdCliente());

            consultaPago.setCliente(clienteTipo);

            resultadoPagoWS = pagosClient.consultarPagos(consultaPago);

            if (resultadoPagoWS != null) {
                Pago_tipo[] pagosArreglo = resultadoPagoWS.getPagos();

                Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "pagosArreglo " + pagosArreglo.length);

                PagoVO pagoVO = null;

                for (Pago_tipo pago : pagosArreglo) {

                    //patron builder
                    PagoDirector pDirector = new PagoDirector();
                    //tipo builder
                    PrincipalPago pagobuilder = new PrincipalPago();
                    pDirector.setPagoBuilder(pagobuilder);

                    pDirector.construirPago(pago);
                    pagoVO = pDirector.getPago();

                    if (pagoVO != null) {
                        listaPagos.add(pagoVO);
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
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "ListaPagos " + listaPagos.size());
        }

        return listaPagos;
    }

    public GeneralVO registrarPagoProgramado(PagoProgramadoVO pagoProgramado) throws Exception {
        GeneralVO estado = new GeneralVO();

        EjecutarPagosProxy proxy = null;
        Ejecutar_pago_tipo pagoWS = null;
        Pago_tipo pagoTipo = null;
        Cliente_tipo cliente = null;
        Respuesta_pago_tipo resPago = null;
        Entidad_bancaria_tipo entidad = null;

        try {

            pagoWS = new Ejecutar_pago_tipo();
            pagoTipo=new Pago_tipo();
            //cliente
            cliente = new Cliente_tipo();
            cliente.setId_cliente(pagoProgramado.getIdCliente());
            pagoTipo.setCliente(cliente);

            //entidad
            entidad = new Entidad_bancaria_tipo();
            entidad.setId_entidad(pagoProgramado.getIdEntidad());
            entidad.setNombre("");
            entidad.setPais("");
            pagoTipo.setEntidad_bancaria(entidad);

            //pago
            pagoTipo.setId_pago(pagoProgramado.getIdPago());
            //fechaProgramada
            pagoTipo.setFecha_programada(pagoProgramado.getFechaProgramada());
            pagoTipo.setValor_pago(0l);
            pagoWS.setPago(pagoTipo);

            //proxyWS
            proxy=new EjecutarPagosProxy();
            resPago = proxy.ejecutarPago(pagoWS);

            if (resPago != null) {

                General_type genResp = resPago.getRespuestaGeneral();

                if (genResp != null) {
                    estado.setEstado(genResp.getEstado());
                    estado.setMensaje(genResp.getMensaje());
                    estado.setTransaccion(genResp.getTransaccion());
                }
            }

        } catch (RemoteException ex) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, ex);
            throw new Exception(ex);
        } catch (Exception e) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, e);
            throw new Exception(e);

        } finally {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "registrarPagoProgramado " + estado);
        }

        return estado;
    }
    

            
    public GeneralVO registrarPagoPrestamo(PagoPrestamoVO pagoPrestamo) throws Exception {
        GeneralVO estado = new GeneralVO();

        EjecutarPrestamoPagoProxy proxy = null;
        
        Prestamo_pago_tipo pagoWS = null;
        Prestamo_tipo prestamoTipo = null;
        
        
        Cliente_tipo cliente = null;
        Respuesta_prestamo_pago resPrestamo= null;
        Entidad_bancaria_tipo entidad = null;

        try {

            pagoWS = new Prestamo_pago_tipo();
            
            prestamoTipo=new Prestamo_tipo();
            //cliente
            cliente = new Cliente_tipo();
            cliente.setId_cliente(pagoPrestamo.getIdCliente());
            
            prestamoTipo.setCliente(cliente);

            //entidad
            entidad = new Entidad_bancaria_tipo();
            entidad.setId_entidad(pagoPrestamo.getIdEntidad());
            entidad.setNombre("");
            entidad.setPais("");
            prestamoTipo.setEntidad_bancaria(entidad);

            //pago
            prestamoTipo.setId_prestamo(pagoPrestamo.getIdPrestamo());
            
            prestamoTipo.setValor_prestamo(pagoPrestamo.getValorPagar());
            
            pagoWS.setPrestamo(prestamoTipo);

            //proxyWS
            proxy=new EjecutarPrestamoPagoProxy();
            resPrestamo = proxy.ejecutarPrestamoPago(pagoWS);

            if (resPrestamo != null) {

                General_type genResp = resPrestamo.getRespuestaGeneral();

                if (genResp != null) {
                    estado.setEstado(genResp.getEstado());
                    estado.setMensaje(genResp.getMensaje());
                    estado.setTransaccion(genResp.getTransaccion());
                }
            }

        } catch (RemoteException ex) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, ex);
            throw new Exception(ex);
        } catch (Exception e) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, e);
            throw new Exception(e);

        } finally {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "registrarPagoPrestamo " + estado);
        }

        return estado;
    }
}
