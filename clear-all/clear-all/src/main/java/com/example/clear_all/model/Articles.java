/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;

import jakarta.persistence.*;
import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Collection;
import java.util.Date;
import jakarta.persistence.NamedQueries;
import jakarta.persistence.NamedQuery;

/**
 *
 * @author admin
 */
@Entity
@Table(name = "ARTICLES")
@Data
public class Articles implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private BigDecimal id;
    @Column(name = "TITLE")
    private String title;
    @Lob
    @Column(name = "CONTENT")
    private String content;
    @Column(name = "SUMMARY")
    private String summary;
    @Column(name = "AUTHOR_ID")
    private BigInteger authorId;
    @Column(name = "TEAM_ID")
    private BigInteger teamId;
    @Column(name = "PUBLISHED_AT")
    @Temporal(TemporalType.TIMESTAMP)
    private Date publishedAt;
    @Column(name = "SLUG")
    private String slug;
    @Column(name = "FEATURED_IMAGE")
    private String featuredImage;
    @Column(name = "VIEW_COUNT")
    private BigInteger viewCount;
    @Column(name = "IS_FEATURED")
    private Boolean isFeatured;
    @Basic(optional = false)
    @Column(name = "CREATE_BY")
    private BigInteger createBy;
    @Basic(optional = false)
    @Column(name = "CREATE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date createDate;
    @Column(name = "LAST_UPDATE_BY")
    private BigInteger lastUpdateBy;
    @Basic(optional = false)
    @Column(name = "LAST_UPDATE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date lastUpdateDate;
    @Column(name = "CATEGORY_ID")
    private BigInteger categoryId;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "articles")
    private Collection<com.example.clear_all.model.RelatedArticles> relatedArticlesCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "articles1")
    private Collection<com.example.clear_all.model.RelatedArticles> relatedArticlesCollection1;

    public Articles() {
    }

    public Articles(BigDecimal id) {
        this.id = id;
    }

    public Articles(BigDecimal id, BigInteger createBy, Date createDate, Date lastUpdateDate) {
        this.id = id;
        this.createBy = createBy;
        this.createDate = createDate;
        this.lastUpdateDate = lastUpdateDate;
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
        if (!(object instanceof Articles)) {
            return false;
        }
        Articles other = (Articles) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.Articles[ id=" + id + " ]";
    }
    
}
