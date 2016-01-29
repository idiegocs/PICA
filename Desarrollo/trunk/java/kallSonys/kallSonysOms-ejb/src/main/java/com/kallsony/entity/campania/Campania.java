/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.campania;

import java.io.Serializable;

import java.util.Date;
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
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "Campania",schema = "Producto")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Campania.findAll", query = "SELECT c FROM Campania c"),
    @NamedQuery(name = "Campania.findByIdCampania", query = "SELECT c FROM Campania c WHERE c.idCampania = :idCampania"),
    @NamedQuery(name = "Campania.findByNombre", query = "SELECT c FROM Campania c WHERE c.nombre = :nombre"),
    @NamedQuery(name = "Campania.findByFechaInicio", query = "SELECT c FROM Campania c WHERE c.fechaInicio = :fechaInicio"),
    @NamedQuery(name = "Campania.findByFechaFin", query = "SELECT c FROM Campania c WHERE c.fechaFin = :fechaFin"),
    @NamedQuery(name = "Campania.findByEstado", query = "SELECT c FROM Campania c WHERE c.estado = :estado"),
    @NamedQuery(name = "Campania.findByNombreImagenCampania", query = "SELECT c FROM Campania c WHERE c.nombreImagenCampania = :nombreImagenCampania")})
public class Campania implements Serializable {

    @OneToMany(cascade = CascadeType.ALL, mappedBy = "idCampania")
    private List<ProductoxCampania> productoxCampaniaList;
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name = "IdCampania")
    private Integer idCampania;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 80)
    @Column(name = "Nombre")
    private String nombre;
    @Basic(optional = false)
    @NotNull
    @Column(name = "FechaInicio")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaInicio;
    @Basic(optional = false)
    @NotNull
    @Column(name = "FechaFin")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaFin;
    @Basic(optional = false)
    @NotNull
    @Column(name = "Estado")
    private boolean estado;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 56)
    @Column(name = "NombreImagenCampania")
    private String nombreImagenCampania;

    public Campania() {
    }

    public Campania(Integer idCampania) {
        this.idCampania = idCampania;
    }

    public Campania(Integer idCampania, String nombre, Date fechaInicio, Date fechaFin, boolean estado, String nombreImagenCampania) {
        this.idCampania = idCampania;
        this.nombre = nombre;
        this.fechaInicio = fechaInicio;
        this.fechaFin = fechaFin;
        this.estado = estado;
        this.nombreImagenCampania = nombreImagenCampania;
    }

    public Integer getIdCampania() {
        return idCampania;
    }

    public void setIdCampania(Integer idCampania) {
        this.idCampania = idCampania;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Date getFechaInicio() {
        return fechaInicio;
    }

    public void setFechaInicio(Date fechaInicio) {
        this.fechaInicio = fechaInicio;
    }

    public Date getFechaFin() {
        return fechaFin;
    }

    public void setFechaFin(Date fechaFin) {
        this.fechaFin = fechaFin;
    }

    public boolean getEstado() {
        return estado;
    }

    public void setEstado(boolean estado) {
        this.estado = estado;
    }

    public String getNombreImagenCampania() {
        return nombreImagenCampania;
    }

    public void setNombreImagenCampania(String nombreImagenCampania) {
        this.nombreImagenCampania = nombreImagenCampania;
    }

    @XmlTransient
    public List<ProductoxCampania> getProductoxCampaniaList() {
        return productoxCampaniaList;
    }

    public void setProductoxCampaniaList(List<ProductoxCampania> productoxCampaniaList) {
        this.productoxCampaniaList = productoxCampaniaList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idCampania != null ? idCampania.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Campania)) {
            return false;
        }
        Campania other = (Campania) object;
        if ((this.idCampania == null && other.idCampania != null) || (this.idCampania != null && !this.idCampania.equals(other.idCampania))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.campanias.Campania[ idCampania=" + idCampania + " ]";
    }

}
