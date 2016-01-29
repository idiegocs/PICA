/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.facade.service;

import com.kallsony.entity.orden.EstadoOrden;
import com.kallsony.entity.orden.Orden;
import com.kallsony.facade.orden.OrdenFacade;
import com.kallsonys.service.cancelar.BPELCancelar;
import com.kallsonys.service.cancelar.CancelarEntrada;
import com.kallsonys.service.cancelar.CancelarSalida;
import com.kallsonys.service.cancelar.ServiceCancelarOrdenEp;
import java.math.BigDecimal;
import java.net.URL;
import javax.ejb.EJB;

import javax.ejb.Stateless;
import javax.xml.namespace.QName;

/**
 *
 * @author Diego
 */
@Stateless
public class CancelarServiceFacade {

    @EJB
    OrdenFacade ejbOrdenes;

    public CancelarServiceFacade() {

    }

    public boolean cancelarOrden(String strUrl,int IdOrden, String idUsuario, String Comentario) throws Exception {

        boolean resp=false;
        URL url = null;
        QName qname = null;
        try {
            url = new URL(strUrl);

            qname = new QName("http://xmlns.oracle.com/Appkallsonys/ProjectCancelar/BPELCancelar", "ServiceCancelarOrden_ep");
            System.out.println("Url "+strUrl);
        } catch (Exception e) {
            e.printStackTrace();
        }

       CancelarEntrada entrada=null;
       CancelarSalida  salida=null;
       ServiceCancelarOrdenEp serv = new ServiceCancelarOrdenEp(url,qname);
       
       BPELCancelar port=serv.getBPELCancelarPt();
       entrada=new CancelarEntrada();
       entrada.setIdOrden(IdOrden);
       entrada.setNombreUsuario(idUsuario);
       entrada.setComentario(Comentario);
       salida=port.cancelarOrden(entrada);
       
       if(salida!=null)
       {
           //se inicio el proceso de compensacion de cancelacion
           if(salida.isEstado())
           {
               //se cambia el estado de la orden
               Orden ordenCancelar=ejbOrdenes.find(new BigDecimal(IdOrden));
               EstadoOrden estadoCancelado=new EstadoOrden();
               estadoCancelado.setIdestadoorden(new BigDecimal(7));
               ordenCancelar.setIdestadoorden(estadoCancelado);
               
               resp=true;
           }
       }
        
        

        return resp;
    }

}
