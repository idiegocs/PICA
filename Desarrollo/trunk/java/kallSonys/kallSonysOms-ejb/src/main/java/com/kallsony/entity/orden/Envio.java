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
@Table(name = "ENVIO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Envio.findAll", query = "SELECT e FROM Envio e"),
    @NamedQuery(name = "Envio.findByIdenvio", query = "SELECT e FROM Envio e WHERE e.idenvio = :idenvio"),
    @NamedQuery(name = "Envio.findByNombres", query = "SELECT e FROM Envio e WHERE e.nombres = :nombres"),
    @NamedQuery(name = "Envio.findByApellidos", query = "SELECT e FROM Envio e WHERE e.apellidos = :apellidos"),
    @NamedQuery(name = "Envio.findByTipodocumento", query = "SELECT e FROM Envio e WHERE e.tipodocumento = :tipodocumento"),
    @NamedQuery(name = "Envio.findByNumerodocumento", query = "SELECT e FROM Envio e WHERE e.numerodocumento = :numerodocumento"),
    @NamedQuery(name = "Envio.findByEmail", query = "SELECT e FROM Envio e WHERE e.email = :email"),
    @NamedQuery(name = "Envio.findByTelefono", query = "SELECT e FROM Envio e WHERE e.telefono = :telefono"),
    @NamedQuery(name = "Envio.findByNumerodrirec", query = "SELECT e FROM Envio e WHERE e.numerodrirec = :numerodrirec"),
    @NamedQuery(name = "Envio.findByCompaniaenvio", query = "SELECT e FROM Envio e WHERE e.companiaenvio = :companiaenvio"),
    @NamedQuery(name = "Envio.findByEnviado", query = "SELECT e FROM Envio e WHERE e.enviado = :enviado"),
    @NamedQuery(name = "Envio.findByTitulartarjeta", query = "SELECT e FROM Envio e WHERE e.titulartarjeta = :titulartarjeta"),
    @NamedQuery(name = "Envio.findByNumerotarjeta", query = "SELECT e FROM Envio e WHERE e.numerotarjeta = :numerotarjeta")})
public class Envio implements Serializable {
    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "IDENVIO")
    private BigDecimal idenvio;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 80)
    @Column(name = "NOMBRES")
    private String nombres;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 80)
    @Column(name = "APELLIDOS")
    private String apellidos;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 3)
    @Column(name = "TIPODOCUMENTO")
    private String tipodocumento;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 50)
    @Column(name = "NUMERODOCUMENTO")
    private String numerodocumento;
    // @Pattern(regexp="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", message="Invalid email")//if the field contains email address consider using this annotation to enforce field validation
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 80)
    @Column(name = "EMAIL")
    private String email;
    @Size(max = 20)
    @Column(name = "TELEFONO")
    private String telefono;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 60)
    @Column(name = "NUMERODRIREC")
    private String numerodrirec;
    @Size(max = 30)
    @Column(name = "COMPANIAENVIO")
    private String companiaenvio;
    @Basic(optional = false)
    @NotNull
    @Column(name = "ENVIADO")
    private BigInteger enviado;
    @Size(max = 30)
    @Column(name = "TITULARTARJETA")
    private String titulartarjeta;
    @Size(max = 40)
    @Column(name = "NUMEROTARJETA")
    private String numerotarjeta;
    @JoinColumn(name = "IDCIUDAD", referencedColumnName = "IDCIUDAD")
    @ManyToOne(optional = false)
    private Ciudad idciudad;
    @JoinColumn(name = "IDORDEN", referencedColumnName = "IDORDEN")
    @ManyToOne(optional = false)
    private Orden idorden;

    public Envio() {
    }

    public Envio(BigDecimal idenvio) {
        this.idenvio = idenvio;
    }

    public Envio(BigDecimal idenvio, String nombres, String apellidos, String tipodocumento, String numerodocumento, String email, String numerodrirec, BigInteger enviado) {
        this.idenvio = idenvio;
        this.nombres = nombres;
        this.apellidos = apellidos;
        this.tipodocumento = tipodocumento;
        this.numerodocumento = numerodocumento;
        this.email = email;
        this.numerodrirec = numerodrirec;
        this.enviado = enviado;
    }

    public BigDecimal getIdenvio() {
        return idenvio;
    }

    public void setIdenvio(BigDecimal idenvio) {
        this.idenvio = idenvio;
    }

    public String getNombres() {
        return nombres;
    }

    public void setNombres(String nombres) {
        this.nombres = nombres;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public String getTipodocumento() {
        return tipodocumento;
    }

    public void setTipodocumento(String tipodocumento) {
        this.tipodocumento = tipodocumento;
    }

    public String getNumerodocumento() {
        return numerodocumento;
    }

    public void setNumerodocumento(String numerodocumento) {
        this.numerodocumento = numerodocumento;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getNumerodrirec() {
        return numerodrirec;
    }

    public void setNumerodrirec(String numerodrirec) {
        this.numerodrirec = numerodrirec;
    }

    public String getCompaniaenvio() {
        return companiaenvio;
    }

    public void setCompaniaenvio(String companiaenvio) {
        this.companiaenvio = companiaenvio;
    }

    public BigInteger getEnviado() {
        return enviado;
    }

    public void setEnviado(BigInteger enviado) {
        this.enviado = enviado;
    }

    public String getTitulartarjeta() {
        return titulartarjeta;
    }

    public void setTitulartarjeta(String titulartarjeta) {
        this.titulartarjeta = titulartarjeta;
    }

    public String getNumerotarjeta() {
        return numerotarjeta;
    }

    public void setNumerotarjeta(String numerotarjeta) {
        this.numerotarjeta = numerotarjeta;
    }

    public Ciudad getIdciudad() {
        return idciudad;
    }

    public void setIdciudad(Ciudad idciudad) {
        this.idciudad = idciudad;
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
        hash += (idenvio != null ? idenvio.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Envio)) {
            return false;
        }
        Envio other = (Envio) object;
        if ((this.idenvio == null && other.idenvio != null) || (this.idenvio != null && !this.idenvio.equals(other.idenvio))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.entity.ordenes.Envio[ idenvio=" + idenvio + " ]";
    }
    
}
