/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import jakarta.persistence.Basic;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.NamedQueries;
import jakarta.persistence.NamedQuery;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

/**
 *
 * @author admin
 */
@Entity
@Table(name = "USER24H")
public class User24h implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID")
    private BigDecimal id;
    @Column(name = "USERNAME")
    private String username;
    @Column(name = "PASSWORD")
    private String password;
    @Column(name = "INACTIVE")
    private Short inactive;
    @Column(name = "ROLE")
    private String role;
    @Column(name = "PHONE")
    private String phone;
    @Column(name = "FULLNAME")
    private String fullname;
    @Column(name = "MODIFYDATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifydate;
    @Column(name = "MODIFYBY")
    private String modifyby;
    @Column(name = "CREATEDATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdate;
    @Column(name = "CREATEBY")
    private String createby;
    @Column(name = "TOKENACTIVE")
    private String tokenactive;
    @Column(name = "DATEACTIVE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date dateactive;
    @Column(name = "CODEACTIVE")
    private String codeactive;
    @Column(name = "DATECODEACTIVE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date datecodeactive;
    @Column(name = "CENTER")
    private String center;
    @Column(name = "ADDGOOGLE")
    private Short addgoogle;
    @Column(name = "EMPID")
    private BigInteger empid;

    public User24h() {
    }

    public User24h(BigDecimal id) {
        this.id = id;
    }

    public BigDecimal getId() {
        return id;
    }

    public void setId(BigDecimal id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Short getInactive() {
        return inactive;
    }

    public void setInactive(Short inactive) {
        this.inactive = inactive;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getFullname() {
        return fullname;
    }

    public void setFullname(String fullname) {
        this.fullname = fullname;
    }

    public Date getModifydate() {
        return modifydate;
    }

    public void setModifydate(Date modifydate) {
        this.modifydate = modifydate;
    }

    public String getModifyby() {
        return modifyby;
    }

    public void setModifyby(String modifyby) {
        this.modifyby = modifyby;
    }

    public Date getCreatedate() {
        return createdate;
    }

    public void setCreatedate(Date createdate) {
        this.createdate = createdate;
    }

    public String getCreateby() {
        return createby;
    }

    public void setCreateby(String createby) {
        this.createby = createby;
    }

    public String getTokenactive() {
        return tokenactive;
    }

    public void setTokenactive(String tokenactive) {
        this.tokenactive = tokenactive;
    }

    public Date getDateactive() {
        return dateactive;
    }

    public void setDateactive(Date dateactive) {
        this.dateactive = dateactive;
    }

    public String getCodeactive() {
        return codeactive;
    }

    public void setCodeactive(String codeactive) {
        this.codeactive = codeactive;
    }

    public Date getDatecodeactive() {
        return datecodeactive;
    }

    public void setDatecodeactive(Date datecodeactive) {
        this.datecodeactive = datecodeactive;
    }

    public String getCenter() {
        return center;
    }

    public void setCenter(String center) {
        this.center = center;
    }

    public Short getAddgoogle() {
        return addgoogle;
    }

    public void setAddgoogle(Short addgoogle) {
        this.addgoogle = addgoogle;
    }

    public BigInteger getEmpid() {
        return empid;
    }

    public void setEmpid(BigInteger empid) {
        this.empid = empid;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof User24h)) {
            return false;
        }
        User24h other = (User24h) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.User24h[ id=" + id + " ]";
    }
    
}
