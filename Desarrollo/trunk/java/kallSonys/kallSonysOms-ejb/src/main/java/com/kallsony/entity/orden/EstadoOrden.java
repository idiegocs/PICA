/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "ESTADO_ORDEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EstadoOrden.findAll", query = "SELECT e FROM EstadoOrden e"),
    @NamedQuery(name = "EstadoOrden.findByIdestadoorden", query = "SELECT e FROM EstadoOrden e WHERE e.idestadoorden = :idestadoorden"),
    @NamedQuery(name = "EstadoOrden.findByNombreestadoorden", query = "SELECT e FROM EstadoOrden e WHERE e.nombreestadoorden = :nombreestadoorden")})
public class EstadoOrden implements Serializable {
    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE,generator ="estadoOrdenSeq" )
    @SequenceGenerator(name="estadoOrdenSeq",sequenceName="SEQ_ESTADO")
    @Column(name = "IDESTADOORDEN")
    private BigDecimal idestadoorden;
    @Size(max = 20)
    @Column(name = "NOMBREESTADOORDEN")
    private String nombreestadoorden;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idestadoorden")
    private List<Orden> ordenList;

    public EstadoOrden() {
    }

    public EstadoOrden(BigDecimal idestadoorden) {
        this.idestadoorden = idestadoorden;
    }

    public BigDecimal getIdestadoorden() {
        return idestadoorden;
    }

    public void setIdestadoorden(BigDecimal idestadoorden) {
        this.idestadoorden = idestadoorden;
    }

    public String getNombreestadoorden() {
        return nombreestadoorden;
    }

    public void setNombreestadoorden(String nombreestadoorden) {
        this.nombreestadoorden = nombreestadoorden;
    }

    @XmlTransient
    public List<Orden> getOrdenList() {
        return ordenList;
    }

    public void setOrdenList(List<Orden> ordenList) {
        this.ordenList = ordenList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idestadoorden != null ? idestadoorden.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EstadoOrden)) {
            return false;
        }
        EstadoOrden other = (EstadoOrden) object;
        if ((this.idestadoorden == null && other.idestadoorden != null) || (this.idestadoorden != null && !this.idestadoorden.equals(other.idestadoorden))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.EstadoOrden[ idestadoorden=" + idestadoorden + " ]";
    }
    
}
