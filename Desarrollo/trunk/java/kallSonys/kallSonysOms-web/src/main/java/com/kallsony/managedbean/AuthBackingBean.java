/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.managedbean;

import com.kallsony.util.JsfUtiles;
import java.io.Serializable;
import java.net.UnknownHostException;
import javax.faces.bean.ManagedBean;

import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import org.apache.log4j.Level;
import org.apache.log4j.Logger;

/**
 *
 * @author Diego
 */
@ManagedBean
@SessionScoped
public class AuthBackingBean implements Serializable {

    private static final long serialVersionUID = 916055190609044881L;
    private String server = "";
    private String host = "";
    private String eco = "";

    final static Logger log = Logger.getLogger(AuthBackingBean.class.getName());

    public String logout() {
        String result = "/welcome?faces-redirect=true";

        FacesContext context = FacesContext.getCurrentInstance();
        HttpServletRequest request = (HttpServletRequest) context.getExternalContext().getRequest();

        try {
            request.logout();

        } catch (ServletException e) {
            log.log(Level.ERROR, "Failed to logout user!", e);
            JsfUtiles.addErrorMessage(e,"Failed to logout user!");
            result = "/loginError?faces-redirect=true";
        }

        return result;
    }

    public String getServer() {
        try {
            server = java.net.InetAddress.getLocalHost().getHostAddress();

        } catch (UnknownHostException ex) {
            ex.printStackTrace();
        }
        return server;
    }

    public void setServer(String serverIp) {
        this.server = serverIp;
    }

    public String getHost() {

        try {
            host = java.net.InetAddress.getLocalHost().toString();
        } catch (UnknownHostException ex) {
            ex.printStackTrace();
        }
        return host;
    }

    public void setHost(String host) {
        this.host = host;
    }

    public String conseguirEco() {
        this.eco = eco + " hola";
        return null;
    }

    public String getEco() {
        return eco;
    }

    public void setEco(String eco) {
        this.eco = eco;
    }

}
