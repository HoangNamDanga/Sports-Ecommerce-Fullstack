/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import jakarta.persistence.Basic;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.NamedQueries;
import jakarta.persistence.NamedQuery;
import jakarta.persistence.Table;

/**
 *
 * @author admin
 */
@Entity
@Table(name = "APPROVE_LOGIN_USER24H")
public class ApproveLoginUser24h implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID")
    private BigDecimal id;
    
    
    @Column(name = "USER_ID")
    private BigInteger userId;
    
    
    @Column(name = "IP")
    private String ip;
    
    
    @Column(name = "ISLOGIN")
    private Short islogin;
    
    
    @Column(name = "ISLOGOUT")
    private Short islogout;

    public ApproveLoginUser24h() {
    }

    public ApproveLoginUser24h(BigDecimal id) {
        this.id = id;
    }

    public BigDecimal getId() {
        return id;
    }

    public void setId(BigDecimal id) {
        this.id = id;
    }

    public BigInteger getUserId() {
        return userId;
    }

    public void setUserId(BigInteger userId) {
        this.userId = userId;
    }

    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public Short getIslogin() {
        return islogin;
    }

    public void setIslogin(Short islogin) {
        this.islogin = islogin;
    }

    public Short getIslogout() {
        return islogout;
    }

    public void setIslogout(Short islogout) {
        this.islogout = islogout;
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
        if (!(object instanceof ApproveLoginUser24h)) {
            return false;
        }
        ApproveLoginUser24h other = (ApproveLoginUser24h) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.ApproveLoginUser24h[ id=" + id + " ]";
    }
    
}
