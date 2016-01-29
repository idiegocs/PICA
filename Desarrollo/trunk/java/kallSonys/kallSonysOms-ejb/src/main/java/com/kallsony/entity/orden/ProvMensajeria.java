/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "PROV_MENSAJERIA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ProvMensajeria.findAll", query = "SELECT p FROM ProvMensajeria p"),
    @NamedQuery(name = "ProvMensajeria.findByIdprovMensajeria", query = "SELECT p FROM ProvMensajeria p WHERE p.idprovMensajeria = :idprovMensajeria"),
    @NamedQuery(name = "ProvMensajeria.findByCodigoProvMensajeria", query = "SELECT p FROM ProvMensajeria p WHERE p.codigoProvMensajeria = :codigoProvMensajeria"),
    @NamedQuery(name = "ProvMensajeria.findByNombreProvMensajeria", query = "SELECT p FROM ProvMensajeria p WHERE p.nombreProvMensajeria = :nombreProvMensajeria"),
    @NamedQuery(name = "ProvMensajeria.findByEstado", query = "SELECT p FROM ProvMensajeria p WHERE p.estado = :estado")})
public class ProvMensajeria implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "IDPROV_MENSAJERIA")
    private Long idprovMensajeria;
    @Size(max = 8)
    @Column(name = "CODIGO_PROV_MENSAJERIA")
    private String codigoProvMensajeria;
    @Size(max = 128)
    @Column(name = "NOMBRE_PROV_MENSAJERIA")
    private String nombreProvMensajeria;
    @Column(name = "ESTADO")
    private Short estado;

    public ProvMensajeria() {
    }

    public ProvMensajeria(Long idprovMensajeria) {
        this.idprovMensajeria = idprovMensajeria;
    }

    public Long getIdprovMensajeria() {
        return idprovMensajeria;
    }

    public void setIdprovMensajeria(Long idprovMensajeria) {
        this.idprovMensajeria = idprovMensajeria;
    }

    public String getCodigoProvMensajeria() {
        return codigoProvMensajeria;
    }

    public void setCodigoProvMensajeria(String codigoProvMensajeria) {
        this.codigoProvMensajeria = codigoProvMensajeria;
    }

    public String getNombreProvMensajeria() {
        return nombreProvMensajeria;
    }

    public void setNombreProvMensajeria(String nombreProvMensajeria) {
        this.nombreProvMensajeria = nombreProvMensajeria;
    }

    public Short getEstado() {
        return estado;
    }

    public void setEstado(Short estado) {
        this.estado = estado;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idprovMensajeria != null ? idprovMensajeria.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ProvMensajeria)) {
            return false;
        }
        ProvMensajeria other = (ProvMensajeria) object;
        if ((this.idprovMensajeria == null && other.idprovMensajeria != null) || (this.idprovMensajeria != null && !this.idprovMensajeria.equals(other.idprovMensajeria))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.ProvMensajeria[ idprovMensajeria=" + idprovMensajeria + " ]";
    }
    
}
