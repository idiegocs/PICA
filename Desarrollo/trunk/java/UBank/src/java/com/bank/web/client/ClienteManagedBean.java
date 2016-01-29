/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.bank.web.client;

import com.bank.ejb.ClientFacadeBean;
import com.bank.vo.ClienteVO;
import com.bank.vo.GeneralVO;
import com.bank.vo.PagoPrestamoVO;
import com.bank.vo.PagoProgramadoVO;
import com.bank.vo.PagoVO;
import com.bank.vo.PrestamoVO;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;

/**
 *
 * @author Diego
 */
@ManagedBean
@SessionScoped
public class ClienteManagedBean {

    @EJB
    private ClientFacadeBean clientFacadeBean;

    private Long numeroCuenta =null;
    private double saldoCliente = 0;

    private List<PrestamoVO> listaPrestamos = new ArrayList<PrestamoVO>();

    private List<PagoVO> listaPagos = new ArrayList<PagoVO>();

    /**
     * Creates a new instance of ClienteManagedBean
     */
    public ClienteManagedBean() {

    }

    public String consultarSaldo() {
        try {
            String user = null;
            FacesContext fc = FacesContext.getCurrentInstance();
            ExternalContext externalContext = fc.getExternalContext();

            if (externalContext.getUserPrincipal() == null) {
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is null");

            } else {
                user = externalContext.getUserPrincipal().getName();
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is " + user);

            }
            ClienteVO cliente = new ClienteVO();
            cliente.setIdCliente(user);
            cliente.setNumeroCuenta(numeroCuenta);

            saldoCliente = clientFacadeBean.conseguirDatosCliente(cliente);

        } catch (Exception ex) {
            Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.SEVERE, null, ex);
            // Bring the error message using the Faces Context
            String errorMessage = "Error en Consulta de Saldo";

            /*FacesContext.getCurrentInstance().getApplication().
             getResourceBundle(FacesContext.getCurrentInstance(),"msg").
             getString("message_missing");*/
            // Add View Faces Message
            FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_ERROR,
                    errorMessage, errorMessage);
            // Add the message into context for a specific component
            FacesContext.getCurrentInstance().addMessage("form:message", message);

        }

        return null;
    }

    public String consultarPresatamos() {

        try {
            String user = null;
            FacesContext fc = FacesContext.getCurrentInstance();
            ExternalContext externalContext = fc.getExternalContext();

            if (externalContext.getUserPrincipal() == null) {
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is null");

            } else {
                user = externalContext.getUserPrincipal().getName();
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is " + user);

            }
            ClienteVO cliente = new ClienteVO();
            cliente.setIdCliente(user);

            listaPrestamos = clientFacadeBean.conseguirDatosPrestamo(cliente);

        } catch (Exception ex) {
            Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.SEVERE, null, ex);
            // Bring the error message using the Faces Context
            String errorMessage = "Error en Consulta de Prestamos";

            // Add View Faces Message
            FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_ERROR,
                    errorMessage, errorMessage);
            // Add the message into context for a specific component
            FacesContext.getCurrentInstance().addMessage("form:message", message);

        }

        return null;
    }

    public String consultarPagos() {

        try {
            String user = null;
            FacesContext fc = FacesContext.getCurrentInstance();
            ExternalContext externalContext = fc.getExternalContext();

            if (externalContext.getUserPrincipal() == null) {
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is null");

            } else {
                user = externalContext.getUserPrincipal().getName();
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is " + user);

            }
            ClienteVO cliente = new ClienteVO();
            cliente.setIdCliente(user);

            listaPagos = clientFacadeBean.conseguirDatosPagos(cliente);

        } catch (Exception ex) {
            Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.SEVERE, null, ex);
            // Bring the error message using the Faces Context
            String errorMessage = "Error en Consulta de Pagos";

            // Add View Faces Message
            FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_ERROR,
                    errorMessage, errorMessage);
            // Add the message into context for a specific component
            FacesContext.getCurrentInstance().addMessage("form:message", message);

        }

        return null;
    }

    public String realizarPago(long idEntidad, String idCliente, long idPago, Date fecha) {

        Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "Realizar Pago idEntidad " + idEntidad + " idCliente " + idCliente + " idPago " + idPago + " fecha " + fecha);
        try {
            String user = null;
            FacesContext fc = FacesContext.getCurrentInstance();
            ExternalContext externalContext = fc.getExternalContext();

            if (externalContext.getUserPrincipal() == null) {
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is null");

            } else {
                user = externalContext.getUserPrincipal().getName();
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is " + user);

            }

            PagoProgramadoVO pagoProgramado = new PagoProgramadoVO();
            pagoProgramado.setIdCliente(user);
            pagoProgramado.setIdEntidad(idEntidad);
            pagoProgramado.setIdPago(idPago);
            pagoProgramado.setFechaProgramada(fecha);

            GeneralVO respOP = clientFacadeBean.registrarPagoProgramado(pagoProgramado);

            if (respOP != null) {
                if ("CORRECTO".equals(respOP.getEstado())) {
                    String respMessage = " Se Programo el Pago #Transaccion: " + respOP.getTransaccion();

                    // Add View Faces Message
                    FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO,
                            respMessage, respMessage);
                    // Add the message into context for a specific component
                    FacesContext.getCurrentInstance().addMessage("form:message", message);
                } else {
                    String respWMessage = "No se Logro Programar el Pago #Transaccion: " + respOP.getTransaccion() + " Estado " + respOP.getMensaje();

                    // Add View Faces Message
                    FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_WARN,
                            respWMessage, respWMessage);
                    // Add the message into context for a specific component
                    FacesContext.getCurrentInstance().addMessage("form:message", message);

                }
            }

        } catch (Exception ex) {
            Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.SEVERE, null, ex);
            // Bring the error message using the Faces Context
            String errorMessage = "Error en Pago Programado";

            // Add View Faces Message
            FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_ERROR,
                    errorMessage, errorMessage);
            // Add the message into context for a specific component
            FacesContext.getCurrentInstance().addMessage("form:message", message);

        }

        return null;
    }
    
     public String realizarPagoPrestamo(long idEntidad, String idCliente, long idPrestamo, long valorPago) {

        Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "Realizar Pago idEntidad " + idEntidad + " idCliente " + idCliente + " idPrestamo " + idPrestamo + " valor pago " + valorPago);
        try {
            String user = null;
            FacesContext fc = FacesContext.getCurrentInstance();
            ExternalContext externalContext = fc.getExternalContext();

            if (externalContext.getUserPrincipal() == null) {
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is null");

            } else {
                user = externalContext.getUserPrincipal().getName();
                Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.INFO, "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!current principal is " + user);

            }

            PagoPrestamoVO pagoPrestamo = new PagoPrestamoVO();
            pagoPrestamo.setIdCliente(user);
            pagoPrestamo.setIdEntidad(idEntidad);
            pagoPrestamo.setIdPrestamo(idPrestamo);
            pagoPrestamo.setValorPagar(valorPago);

            GeneralVO respOP = clientFacadeBean.registrarPagoPrestamo(pagoPrestamo);

            if (respOP != null) {
                if ("CORRECTO".equals(respOP.getEstado())) {
                    String respMessage = " Se Registro el pago del Prestamo #Transaccion: " + respOP.getTransaccion();

                    // Add View Faces Message
                    FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO,
                            respMessage, respMessage);
                    // Add the message into context for a specific component
                    FacesContext.getCurrentInstance().addMessage("form:message", message);
                } else {
                    String respWMessage = "No se Logro Registrar El Pago del Prestamo #Transaccion: " + respOP.getTransaccion() + " Estado " + respOP.getMensaje();

                    // Add View Faces Message
                    FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_WARN,
                            respWMessage, respWMessage);
                    // Add the message into context for a specific component
                    FacesContext.getCurrentInstance().addMessage("form:message", message);

                }
            }

        } catch (Exception ex) {
            Logger.getLogger(ClienteManagedBean.class.getName()).log(Level.SEVERE, null, ex);
            // Bring the error message using the Faces Context
            String errorMessage = "Error en Registro de Pago Prestamo";

            // Add View Faces Message
            FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_ERROR,
                    errorMessage, errorMessage);
            // Add the message into context for a specific component
            FacesContext.getCurrentInstance().addMessage("form:message", message);

        }

        return null;
    }


    public Long getNumeroCuenta() {
        return numeroCuenta;
    }

    public void setNumeroCuenta(Long numeroCuenta) {
        this.numeroCuenta = numeroCuenta;
    }

    public double getSaldoCliente() {
        return saldoCliente;
    }

    public void setSaldoCliente(double saldoCliente) {
        this.saldoCliente = saldoCliente;
    }

    public List<PrestamoVO> getListaPrestamos() {
        return listaPrestamos;
    }

    public void setListaPrestamos(List<PrestamoVO> listaPrestamos) {
        this.listaPrestamos = listaPrestamos;
    }

    public List<PagoVO> getListaPagos() {
        return listaPagos;
    }

    public void setListaPagos(List<PagoVO> listaPagos) {
        this.listaPagos = listaPagos;
    }

}
