/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;
import com.example.clear_all.model.RelatedArticles;
import java.io.Serializable;
import java.math.BigInteger;
import java.util.Date;
import jakarta.persistence.Column;
import jakarta.persistence.EmbeddedId;
import jakarta.persistence.Entity;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
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
@Table(name = "RELATED_ARTICLES")
public class RelatedArticles implements Serializable {

    private static final long serialVersionUID = 1L;
    @lombok.Setter
    @lombok.Getter
    @EmbeddedId
    protected com.example.clear_all.model.RelatedArticlesPK relatedArticlesPK;
    
    
    @Column(name = "RELATION_TYPE")
    private String relationType;
    
    
    @Column(name = "CREATED_AT")
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdAt;
    
    
    @JoinColumn(name = "RELATED_ARTICLE_ID", referencedColumnName = "ID", insertable = false, updatable = false)
    @ManyToOne(optional = false)
    private Articles articles;
    
    
    @JoinColumn(name = "PRIMARY_ARTICLE_ID", referencedColumnName = "ID", insertable = false, updatable = false)
    @ManyToOne(optional = false)
    private Articles articles1;

    public RelatedArticles() {
    }

    public RelatedArticles(com.example.clear_all.model.RelatedArticlesPK relatedArticlesPK) {
        this.relatedArticlesPK = relatedArticlesPK;
    }

    public RelatedArticles(BigInteger primaryArticleId, BigInteger relatedArticleId) {
        this.relatedArticlesPK = new com.example.clear_all.model.RelatedArticlesPK(primaryArticleId, relatedArticleId);
    }

    public String getRelationType() {
        return relationType;
    }

    public void setRelationType(String relationType) {
        this.relationType = relationType;
    }

    public Date getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    public Articles getArticles() {
        return articles;
    }

    public void setArticles(Articles articles) {
        this.articles = articles;
    }

    public Articles getArticles1() {
        return articles1;
    }

    public void setArticles1(Articles articles1) {
        this.articles1 = articles1;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (relatedArticlesPK != null ? relatedArticlesPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof RelatedArticles)) {
            return false;
        }
        RelatedArticles other = (RelatedArticles) object;
        if ((this.relatedArticlesPK == null && other.relatedArticlesPK != null) || (this.relatedArticlesPK != null && !this.relatedArticlesPK.equals(other.relatedArticlesPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.RelatedArticles[ relatedArticlesPK=" + relatedArticlesPK + " ]";
    }
    
}
