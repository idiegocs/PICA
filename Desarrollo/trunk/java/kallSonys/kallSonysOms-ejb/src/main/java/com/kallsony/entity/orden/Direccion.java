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
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "DIRECCION")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Direccion.findAll", query = "SELECT d FROM Direccion d"),
    @NamedQuery(name = "Direccion.findByIddireccion", query = "SELECT d FROM Direccion d WHERE d.iddireccion = :iddireccion"),
    @NamedQuery(name = "Direccion.findByNumerodireccion", query = "SELECT d FROM Direccion d WHERE d.numerodireccion = :numerodireccion"),
    @NamedQuery(name = "Direccion.findByCodigopostal", query = "SELECT d FROM Direccion d WHERE d.codigopostal = :codigopostal")})
public class Direccion implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id

    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator ="direcSeq")
    @SequenceGenerator(name = "direcSeq", sequenceName = "SEQ_DIRECCION", allocationSize = 1)
    @Column(name = "IDDIRECCION")
    private Long iddireccion;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 500)
    @Column(name = "NUMERODIRECCION")
    private String numerodireccion;
    @Size(max = 10)
    @Column(name = "CODIGOPOSTAL")
    private String codigopostal;
    @JoinColumn(name = "IDCIUDAD", referencedColumnName = "IDCIUDAD")
    @ManyToOne( optional = false)
    private Ciudad idciudad;

    public Direccion() {
    }

    public Direccion(Long iddireccion) {
        this.iddireccion = iddireccion;
    }

    public Direccion(Long iddireccion, String numerodireccion) {
        this.iddireccion = iddireccion;
        this.numerodireccion = numerodireccion;
    }

    public Long getIddireccion() {
        return iddireccion;
    }

    public void setIddireccion(Long iddireccion) {
        this.iddireccion = iddireccion;
    }

    public String getNumerodireccion() {
        return numerodireccion;
    }

    public void setNumerodireccion(String numerodireccion) {
        this.numerodireccion = numerodireccion;
    }

    public String getCodigopostal() {
        return codigopostal;
    }

    public void setCodigopostal(String codigopostal) {
        this.codigopostal = codigopostal;
    }

    public Ciudad getIdciudad() {
        return idciudad;
    }

    public void setIdciudad(Ciudad idciudad) {
        this.idciudad = idciudad;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iddireccion != null ? iddireccion.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Direccion)) {
            return false;
        }
        Direccion other = (Direccion) object;
        if ((this.iddireccion == null && other.iddireccion != null) || (this.iddireccion != null && !this.iddireccion.equals(other.iddireccion))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.ordenes.Direccion[ iddireccion=" + iddireccion + " ]";
    }
    
}
