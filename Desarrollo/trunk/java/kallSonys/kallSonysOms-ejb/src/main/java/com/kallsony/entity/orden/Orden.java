/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "ORDEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Orden.findAll", query = "SELECT o FROM Orden o"),
    @NamedQuery(name = "Orden.buscarProductosFechas", query = "SELECT it.idproducto, SUM(it.cantidaditem) AS TOTAL  FROM Orden o JOIN  O.itemOrdenList it WHERE o.fechaorden>= :paramFecIni AND o.fechaorden<=:paramFecFin GROUP BY it.idproducto ORDER BY TOTAL"),
    @NamedQuery(name = "Orden.findByIdorden", query = "SELECT o FROM Orden o WHERE o.idorden = :idorden"),
    @NamedQuery(name = "Orden.findByFechaorden", query = "SELECT o FROM Orden o WHERE o.fechaorden = :fechaorden"),
    @NamedQuery(name = "Orden.findByCantitemorden", query = "SELECT o FROM Orden o WHERE o.cantitemorden = :cantitemorden"),
    @NamedQuery(name = "Orden.findByTotalorden", query = "SELECT o FROM Orden o WHERE o.totalorden = :totalorden"),
    @NamedQuery(name = "Orden.findByNumpreorden", query = "SELECT o FROM Orden o WHERE o.numpreorden = :numpreorden")})
public class Orden implements Serializable {
    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE,generator ="OrderSeq" )
    @SequenceGenerator(name="OrderSeq",sequenceName="SEQ_ORDENES") 
    @Column(name = "IDORDEN")
    private BigDecimal idorden;
    
    @Column(name = "FECHAORDEN")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaorden;
    @Column(name = "CANTITEMORDEN")
    private BigInteger cantitemorden;
    @Column(name = "TOTALORDEN")
    private BigInteger totalorden;

   
    @Column(name = "NUMPREORDEN")
    private BigInteger numpreorden;
    @JoinColumn(name = "IDESTADOORDEN", referencedColumnName = "IDESTADOORDEN")
    @ManyToOne(fetch = FetchType.EAGER,optional = false)
    private EstadoOrden idestadoorden;
    @JoinColumn(name = "IDCLIENTE", referencedColumnName = "IDUSUARIO")
    @ManyToOne(fetch = FetchType.EAGER,optional = false)
    private Usuario idcliente;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idorden")
    private List<ItemOrden> itemOrdenList;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idorden")
    private List<Envio> envioList;
    @OneToMany(mappedBy = "idorden")
    private List<Ordencancelada> ordencanceladaList;

    public Orden() {
    }

    public Orden(BigDecimal idorden) {
        this.idorden = idorden;
    }

    public Orden(BigDecimal idorden, BigInteger numpreorden) {
        this.idorden = idorden;
        this.numpreorden = numpreorden;
    }

    public BigDecimal getIdorden() {
        return idorden;
    }

    public void setIdorden(BigDecimal idorden) {
        this.idorden = idorden;
    }

    public Date getFechaorden() {
        return fechaorden;
    }

    public void setFechaorden(Date fechaorden) {
        this.fechaorden = fechaorden;
    }

    public BigInteger getCantitemorden() {
        return cantitemorden;
    }

    public void setCantitemorden(BigInteger cantitemorden) {
        this.cantitemorden = cantitemorden;
    }

    public BigInteger getTotalorden() {
        return totalorden;
    }

    public void setTotalorden(BigInteger totalorden) {
        this.totalorden = totalorden;
    }

    public BigInteger getNumpreorden() {
        return numpreorden;
    }

    public void setNumpreorden(BigInteger numpreorden) {
        this.numpreorden = numpreorden;
    }

    public EstadoOrden getIdestadoorden() {
        return idestadoorden;
    }

    public void setIdestadoorden(EstadoOrden idestadoorden) {
        this.idestadoorden = idestadoorden;
    }

    public Usuario getIdcliente() {
        return idcliente;
    }

    public void setIdcliente(Usuario idcliente) {
        this.idcliente = idcliente;
    }

    @XmlTransient
    public List<ItemOrden> getItemOrdenList() {
        return itemOrdenList;
    }

    public void setItemOrdenList(List<ItemOrden> itemOrdenList) {
        this.itemOrdenList = itemOrdenList;
    }
    
    @XmlTransient
    public List<Ordencancelada> getOrdencanceladaList() {
        return ordencanceladaList;
    }

    public void setOrdencanceladaList(List<Ordencancelada> ordencanceladaList) {
        this.ordencanceladaList = ordencanceladaList;
    }

    @XmlTransient
    public List<Envio> getEnvioList() {
        return envioList;
    }

    public void setEnvioList(List<Envio> envioList) {
        this.envioList = envioList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idorden != null ? idorden.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Orden)) {
            return false;
        }
        Orden other = (Orden) object;
        if ((this.idorden == null && other.idorden != null) || (this.idorden != null && !this.idorden.equals(other.idorden))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.Orden[ idorden=" + idorden + " ]";
    }
    
}
