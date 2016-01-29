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
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "ProductoxCampania",schema = "Producto")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ProductoxCampania.findAll", query = "SELECT p FROM ProductoxCampania p"),
    @NamedQuery(name = "ProductoxCampania.findByIdProductoxCampania", query = "SELECT p FROM ProductoxCampania p WHERE p.idProductoxCampania = :idProductoxCampania"),
    @NamedQuery(name = "ProductoxCampania.findByIdProducto", query = "SELECT p FROM ProductoxCampania p WHERE p.idProducto = :idProducto"),
    @NamedQuery(name = "ProductoxCampania.findByPorcentajeDescuento", query = "SELECT p FROM ProductoxCampania p WHERE p.porcentajeDescuento = :porcentajeDescuento")})
public class ProductoxCampania implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name = "IdProductoxCampania")
    private Integer idProductoxCampania;
    @Basic(optional = false)
    @NotNull
    @Column(name = "IdProducto")
    private int idProducto;
    @Basic(optional = false)
    @NotNull
    @Column(name = "PorcentajeDescuento")
    private int porcentajeDescuento;
    @JoinColumn(name = "IdCampania", referencedColumnName = "IdCampania")
    @ManyToOne(optional = false)
    private Campania idCampania;

    public ProductoxCampania() {
    }

    public ProductoxCampania(Integer idProductoxCampania) {
        this.idProductoxCampania = idProductoxCampania;
    }

    public ProductoxCampania(Integer idProductoxCampania, int idProducto, int porcentajeDescuento) {
        this.idProductoxCampania = idProductoxCampania;
        this.idProducto = idProducto;
        this.porcentajeDescuento = porcentajeDescuento;
    }

    public Integer getIdProductoxCampania() {
        return idProductoxCampania;
    }

    public void setIdProductoxCampania(Integer idProductoxCampania) {
        this.idProductoxCampania = idProductoxCampania;
    }

    public int getIdProducto() {
        return idProducto;
    }

    public void setIdProducto(int idProducto) {
        this.idProducto = idProducto;
    }

    public int getPorcentajeDescuento() {
        return porcentajeDescuento;
    }

    public void setPorcentajeDescuento(int porcentajeDescuento) {
        this.porcentajeDescuento = porcentajeDescuento;
    }

    public Campania getIdCampania() {
        return idCampania;
    }

    public void setIdCampania(Campania idCampania) {
        this.idCampania = idCampania;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idProductoxCampania != null ? idProductoxCampania.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ProductoxCampania)) {
            return false;
        }
        ProductoxCampania other = (ProductoxCampania) object;
        if ((this.idProductoxCampania == null && other.idProductoxCampania != null) || (this.idProductoxCampania != null && !this.idProductoxCampania.equals(other.idProductoxCampania))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.campanias.ProductoxCampania[ idProductoxCampania=" + idProductoxCampania + " ]";
    }
    
}
