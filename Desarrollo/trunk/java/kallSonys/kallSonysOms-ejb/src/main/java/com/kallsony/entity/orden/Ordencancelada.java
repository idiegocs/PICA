/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Diego
 */
@Entity
@Table(name = "ORDENCANCELADA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Ordencancelada.findAll", query = "SELECT o FROM Ordencancelada o"),
    @NamedQuery(name = "Ordencancelada.findByIdcancelada", query = "SELECT o FROM Ordencancelada o WHERE o.idcancelada = :idcancelada"),
    @NamedQuery(name = "Ordencancelada.findByUsuario", query = "SELECT o FROM Ordencancelada o WHERE o.usuario = :usuario"),
    @NamedQuery(name = "Ordencancelada.findByComentario", query = "SELECT o FROM Ordencancelada o WHERE o.comentario = :comentario"),
    @NamedQuery(name = "Ordencancelada.findByFecha", query = "SELECT o FROM Ordencancelada o WHERE o.fecha = :fecha")})
public class Ordencancelada implements Serializable {
    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "IDCANCELADA")
    private BigDecimal idcancelada;
    @Size(max = 50)
    @Column(name = "USUARIO")
    private String usuario;
    @Size(max = 80)
    @Column(name = "COMENTARIO")
    private String comentario;
    @Column(name = "FECHA")
    @Temporal(TemporalType.TIMESTAMP)
    private Date fecha;
    @JoinColumn(name = "IDORDEN", referencedColumnName = "IDORDEN")
    @ManyToOne
    private Orden idorden;

    public Ordencancelada() {
    }

    public Ordencancelada(BigDecimal idcancelada) {
        this.idcancelada = idcancelada;
    }

    public BigDecimal getIdcancelada() {
        return idcancelada;
    }

    public void setIdcancelada(BigDecimal idcancelada) {
        this.idcancelada = idcancelada;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getComentario() {
        return comentario;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
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
        hash += (idcancelada != null ? idcancelada.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Ordencancelada)) {
            return false;
        }
        Ordencancelada other = (Ordencancelada) object;
        if ((this.idcancelada == null && other.idcancelada != null) || (this.idcancelada != null && !this.idcancelada.equals(other.idcancelada))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.ordenes.Ordencancelada[ idcancelada=" + idcancelada + " ]";
    }
    
}
