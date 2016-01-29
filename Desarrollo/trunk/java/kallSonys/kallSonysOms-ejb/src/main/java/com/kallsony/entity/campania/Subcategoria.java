/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.campania;

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
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "Subcategoria",schema = "Producto")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Subcategoria.findAll", query = "SELECT s FROM Subcategoria s"),
    @NamedQuery(name = "Subcategoria.findByIdSubcategoria", query = "SELECT s FROM Subcategoria s WHERE s.idSubcategoria = :idSubcategoria"),
    @NamedQuery(name = "Subcategoria.findByNombreSubcategoria", query = "SELECT s FROM Subcategoria s WHERE s.nombreSubcategoria = :nombreSubcategoria")})
public class Subcategoria implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name = "IdSubcategoria")
    private Integer idSubcategoria;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 64)
    @Column(name = "NombreSubcategoria")
    private String nombreSubcategoria;
    @JoinColumn(name = "IdCategoria", referencedColumnName = "IdCategoria")
    @ManyToOne(optional = false)
    private Categoria idCategoria;

    public Subcategoria() {
    }

    public Subcategoria(Integer idSubcategoria) {
        this.idSubcategoria = idSubcategoria;
    }

    public Subcategoria(Integer idSubcategoria, String nombreSubcategoria) {
        this.idSubcategoria = idSubcategoria;
        this.nombreSubcategoria = nombreSubcategoria;
    }

    public Integer getIdSubcategoria() {
        return idSubcategoria;
    }

    public void setIdSubcategoria(Integer idSubcategoria) {
        this.idSubcategoria = idSubcategoria;
    }

    public String getNombreSubcategoria() {
        return nombreSubcategoria;
    }

    public void setNombreSubcategoria(String nombreSubcategoria) {
        this.nombreSubcategoria = nombreSubcategoria;
    }

    public Categoria getIdCategoria() {
        return idCategoria;
    }

    public void setIdCategoria(Categoria idCategoria) {
        this.idCategoria = idCategoria;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idSubcategoria != null ? idSubcategoria.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Subcategoria)) {
            return false;
        }
        Subcategoria other = (Subcategoria) object;
        if ((this.idSubcategoria == null && other.idSubcategoria != null) || (this.idSubcategoria != null && !this.idSubcategoria.equals(other.idSubcategoria))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.campanias.Subcategoria[ idSubcategoria=" + idSubcategoria + " ]";
    }
    
}
