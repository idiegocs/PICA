/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.kallsony.entity.orden;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
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
@Table(name = "ITEM_ORDEN")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ItemOrden.findAll", query = "SELECT i FROM ItemOrden i"),
    @NamedQuery(name = "ItemOrden.findByOrden", query = "SELECT i FROM ItemOrden i JOIN FETCH i.idorden WHERE i.idorden.idorden = :idorden"),
    @NamedQuery(name = "ItemOrden.findByIditem", query = "SELECT i FROM ItemOrden i WHERE i.iditem = :iditem"),
    @NamedQuery(name = "ItemOrden.findByTipoitem", query = "SELECT i FROM ItemOrden i WHERE i.tipoitem = :tipoitem"),
    @NamedQuery(name = "ItemOrden.findByIdproducto", query = "SELECT i FROM ItemOrden i WHERE i.idproducto = :idproducto"),
    @NamedQuery(name = "ItemOrden.findByCodigoproducto", query = "SELECT i FROM ItemOrden i WHERE i.codigoproducto = :codigoproducto"),
    @NamedQuery(name = "ItemOrden.findByNombreproducto", query = "SELECT i FROM ItemOrden i WHERE i.nombreproducto = :nombreproducto"),
    @NamedQuery(name = "ItemOrden.findByCantidaditem", query = "SELECT i FROM ItemOrden i WHERE i.cantidaditem = :cantidaditem"),
    @NamedQuery(name = "ItemOrden.findByValorunitarioitem", query = "SELECT i FROM ItemOrden i WHERE i.valorunitarioitem = :valorunitarioitem")})
public class ItemOrden implements Serializable {
    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE,generator ="ItemSeq" )
    @SequenceGenerator(name="ItemSeq",sequenceName="SEQ_ITEMORDEN")
    @Column(name = "IDITEM")
    private BigDecimal iditem;
    @Basic(optional = false)
    @NotNull
    @Column(name = "TIPOITEM")
    private BigInteger tipoitem;
    @Basic(optional = false)
    @NotNull
    @Column(name = "IDPRODUCTO")
    private long idproducto;
    @Size(max = 32)
    @Column(name = "CODIGOPRODUCTO")
    private String codigoproducto;
    @Size(max = 64)
    @Column(name = "NOMBREPRODUCTO")
    private String nombreproducto;
    @Column(name = "CANTIDADITEM")
    private BigInteger cantidaditem;
    @Basic(optional = false)
    @NotNull
    @Column(name = "VALORUNITARIOITEM")
    private BigInteger valorunitarioitem;
    @JoinColumn(name = "IDORDEN", referencedColumnName = "IDORDEN")
    @ManyToOne(optional = false)
    private Orden idorden;

    public ItemOrden() {
    }

    public ItemOrden(BigDecimal iditem) {
        this.iditem = iditem;
    }

    public ItemOrden(BigDecimal iditem, BigInteger tipoitem, long idproducto, BigInteger valorunitarioitem) {
        this.iditem = iditem;
        this.tipoitem = tipoitem;
        this.idproducto = idproducto;
        this.valorunitarioitem = valorunitarioitem;
    }

    public BigDecimal getIditem() {
        return iditem;
    }

    public void setIditem(BigDecimal iditem) {
        this.iditem = iditem;
    }

    public BigInteger getTipoitem() {
        return tipoitem;
    }

    public void setTipoitem(BigInteger tipoitem) {
        this.tipoitem = tipoitem;
    }

    public long getIdproducto() {
        return idproducto;
    }

    public void setIdproducto(long idproducto) {
        this.idproducto = idproducto;
    }

    public String getCodigoproducto() {
        return codigoproducto;
    }

    public void setCodigoproducto(String codigoproducto) {
        this.codigoproducto = codigoproducto;
    }

    public String getNombreproducto() {
        return nombreproducto;
    }

    public void setNombreproducto(String nombreproducto) {
        this.nombreproducto = nombreproducto;
    }

    public BigInteger getCantidaditem() {
        return cantidaditem;
    }

    public void setCantidaditem(BigInteger cantidaditem) {
        this.cantidaditem = cantidaditem;
    }

    public BigInteger getValorunitarioitem() {
        return valorunitarioitem;
    }

    public void setValorunitarioitem(BigInteger valorunitarioitem) {
        this.valorunitarioitem = valorunitarioitem;
    }

    public Orden getIdorden() {
        return idorden;
    }

    public void setIdorden(Orden idorden) {
        this.idorden = idorden;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iditem != null ? iditem.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ItemOrden)) {
            return false;
        }
        ItemOrden other = (ItemOrden) object;
        if ((this.iditem == null && other.iditem != null) || (this.iditem != null && !this.iditem.equals(other.iditem))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.ItemOrden[ iditem=" + iditem + " ]";
    }

}
