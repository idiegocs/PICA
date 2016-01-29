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
@Table(name = "FABRICANTE")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Fabricante.findAll", query = "SELECT f FROM Fabricante f"),
    @NamedQuery(name = "Fabricante.findByIdfabricante", query = "SELECT f FROM Fabricante f WHERE f.idfabricante = :idfabricante"),
    @NamedQuery(name = "Fabricante.findByCodigoFabricante", query = "SELECT f FROM Fabricante f WHERE f.codigoFabricante = :codigoFabricante"),
    @NamedQuery(name = "Fabricante.findByNombreFabricante", query = "SELECT f FROM Fabricante f WHERE f.nombreFabricante = :nombreFabricante"),
    @NamedQuery(name = "Fabricante.findByEstado", query = "SELECT f FROM Fabricante f WHERE f.estado = :estado")})
public class Fabricante implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "IDFABRICANTE")
    private Long idfabricante;
    @Size(max = 8)
    @Column(name = "CODIGO_FABRICANTE")
    private String codigoFabricante;
    @Size(max = 128)
    @Column(name = "NOMBRE_FABRICANTE")
    private String nombreFabricante;
    @Column(name = "ESTADO")
    private Short estado;

    public Fabricante() {
    }

    public Fabricante(Long idfabricante) {
        this.idfabricante = idfabricante;
    }

    public Long getIdfabricante() {
        return idfabricante;
    }

    public void setIdfabricante(Long idfabricante) {
        this.idfabricante = idfabricante;
    }

    public String getCodigoFabricante() {
        return codigoFabricante;
    }

    public void setCodigoFabricante(String codigoFabricante) {
        this.codigoFabricante = codigoFabricante;
    }

    public String getNombreFabricante() {
        return nombreFabricante;
    }

    public void setNombreFabricante(String nombreFabricante) {
        this.nombreFabricante = nombreFabricante;
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
        hash += (idfabricante != null ? idfabricante.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Fabricante)) {
            return false;
        }
        Fabricante other = (Fabricante) object;
        if ((this.idfabricante == null && other.idfabricante != null) || (this.idfabricante != null && !this.idfabricante.equals(other.idfabricante))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.Fabricante[ idfabricante=" + idfabricante + " ]";
    }
    
}
