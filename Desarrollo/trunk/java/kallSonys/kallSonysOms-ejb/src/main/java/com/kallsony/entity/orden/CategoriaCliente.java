/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.kallsony.entity.orden;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
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
@Table(name = "CATEGORIA_CLIENTE")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "CategoriaCliente.findAll", query = "SELECT c FROM CategoriaCliente c"),
    @NamedQuery(name = "CategoriaCliente.findByIdcategoria", query = "SELECT c FROM CategoriaCliente c WHERE c.idcategoria = :idcategoria"),
    @NamedQuery(name = "CategoriaCliente.findByNombreCategoria", query = "SELECT c FROM CategoriaCliente c WHERE c.nombreCategoria = :nombreCategoria")})
public class CategoriaCliente implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator ="catSeq")
    @SequenceGenerator(name = "catSeq", sequenceName = "SEQ_CATEGORIACLIENTE", allocationSize = 1)
    @Column(name = "IDCATEGORIA")
    private Long idcategoria;
    @Size(max = 128)
    @Column(name = "NOMBRE_CATEGORIA")
    private String nombreCategoria;
    @OneToMany(mappedBy = "idcategoria")
    private List<Usuario> usuarioList;

    public CategoriaCliente() {
    }

    public CategoriaCliente(Long idcategoria) {
        this.idcategoria = idcategoria;
    }

    public Long getIdcategoria() {
        return idcategoria;
    }

    public void setIdcategoria(Long idcategoria) {
        this.idcategoria = idcategoria;
    }

    public String getNombreCategoria() {
        return nombreCategoria;
    }

    public void setNombreCategoria(String nombreCategoria) {
        this.nombreCategoria = nombreCategoria;
    }

    @XmlTransient
    public List<Usuario> getUsuarioList() {
        return usuarioList;
    }

    public void setUsuarioList(List<Usuario> usuarioList) {
        this.usuarioList = usuarioList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idcategoria != null ? idcategoria.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof CategoriaCliente)) {
            return false;
        }
        CategoriaCliente other = (CategoriaCliente) object;
        if ((this.idcategoria == null && other.idcategoria != null) || (this.idcategoria != null && !this.idcategoria.equals(other.idcategoria))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.kallsony.entity.orden.CategoriaCliente[ idcategoria=" + idcategoria + " ]";
    }
    
}
