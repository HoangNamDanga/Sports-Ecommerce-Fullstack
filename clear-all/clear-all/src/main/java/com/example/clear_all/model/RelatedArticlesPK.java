/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;

import java.io.Serializable;
import java.math.BigInteger;
import jakarta.persistence.Basic;
import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;

/**
 *
 * @author admin
 */
@Embeddable
public class RelatedArticlesPK implements Serializable {

    @Basic(optional = false)
    @Column(name = "PRIMARY_ARTICLE_ID")
    private BigInteger primaryArticleId;
    @Basic(optional = false)
    @Column(name = "RELATED_ARTICLE_ID")
    private BigInteger relatedArticleId;

    public RelatedArticlesPK() {
    }

    public RelatedArticlesPK(BigInteger primaryArticleId, BigInteger relatedArticleId) {
        this.primaryArticleId = primaryArticleId;
        this.relatedArticleId = relatedArticleId;
    }

    public BigInteger getPrimaryArticleId() {
        return primaryArticleId;
    }

    public void setPrimaryArticleId(BigInteger primaryArticleId) {
        this.primaryArticleId = primaryArticleId;
    }

    public BigInteger getRelatedArticleId() {
        return relatedArticleId;
    }

    public void setRelatedArticleId(BigInteger relatedArticleId) {
        this.relatedArticleId = relatedArticleId;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (primaryArticleId != null ? primaryArticleId.hashCode() : 0);
        hash += (relatedArticleId != null ? relatedArticleId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof RelatedArticlesPK)) {
            return false;
        }
        RelatedArticlesPK other = (RelatedArticlesPK) object;
        if ((this.primaryArticleId == null && other.primaryArticleId != null) || (this.primaryArticleId != null && !this.primaryArticleId.equals(other.primaryArticleId))) {
            return false;
        }
        if ((this.relatedArticleId == null && other.relatedArticleId != null) || (this.relatedArticleId != null && !this.relatedArticleId.equals(other.relatedArticleId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.RelatedArticlesPK[ primaryArticleId=" + primaryArticleId + ", relatedArticleId=" + relatedArticleId + " ]";
    }
    
}
