/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.integration;

import com.bank.ejb.ClientFacadeBean;
import com.bank.vo.ClienteVO;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.Stateless;
import org.patrones.www._final.entity.cliente.v1.Cliente_tipo;
import org.patrones.www._final.entity.cuenta.v1.Cuenta_tipo;
import org.patrones.www._final.legacy.mainframe.v1.MainframeAdapterProxy;

/**
 *
 * @author Diego
 */
@Stateless
public class MainframeSessionBean {

    public long conseguirDatosCliente(ClienteVO cliente) throws Exception {
        long saldo = 0;

        try {
            MainframeAdapterProxy mainframeClient = new MainframeAdapterProxy();
            Cuenta_tipo cuentaWS = new Cuenta_tipo();
            cuentaWS.setId_cuenta(cliente.getNumeroCuenta());
            Cliente_tipo clienteWS = new Cliente_tipo();
            clienteWS.setId_cliente(cliente.idCliente);
            cuentaWS.setCliente(clienteWS);

            Cuenta_tipo cuentaResWS = mainframeClient.consultarCuenta(cuentaWS);
            saldo = cuentaResWS.getSaldo();
        } catch (RemoteException ex) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, ex);
            throw new Exception(ex);
        } catch (Exception e) {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.SEVERE, null, e);
            throw new Exception(e);
        } finally {
            Logger.getLogger(ClientFacadeBean.class.getName()).log(Level.INFO, "Saldo " + saldo);
        }

        return saldo;
    }

}
