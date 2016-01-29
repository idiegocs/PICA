/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.ejb;

import com.bank.integration.MainframeSessionBean;
import com.bank.integration.PagosSessionBean;
import com.bank.integration.PrestamoSessionBean;
import com.bank.vo.ClienteVO;
import com.bank.vo.GeneralVO;
import com.bank.vo.PagoPrestamoVO;
import com.bank.vo.PagoProgramadoVO;
import com.bank.vo.PagoVO;
import com.bank.vo.PrestamoVO;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;

/**
 *
 * @author Diego Castaneda
 */
@Stateless
public class ClientFacadeBean {

    @EJB
    private PagosSessionBean pagosSessionBean;
    @EJB
    private PrestamoSessionBean prestamoSessionBean;
    @EJB
    private MainframeSessionBean mainframeSessionBean;

    public long conseguirDatosCliente(ClienteVO cliente) throws Exception {

        return mainframeSessionBean.conseguirDatosCliente(cliente);
    }

    public List<PrestamoVO> conseguirDatosPrestamo(ClienteVO cliente) throws Exception {

        return prestamoSessionBean.conseguirDatosPrestamo(cliente);
    }

    public List<PagoVO> conseguirDatosPagos(ClienteVO cliente) throws Exception {
        return pagosSessionBean.conseguirDatosPagos(cliente);
    }
    
     public GeneralVO registrarPagoProgramado(PagoProgramadoVO pagoProgramado) throws Exception {
        return pagosSessionBean.registrarPagoProgramado(pagoProgramado);
    }
     
     
    public GeneralVO registrarPagoPrestamo(PagoPrestamoVO pagoPrestamo ) throws Exception {
        return pagosSessionBean.registrarPagoPrestamo(pagoPrestamo);
    }

}
