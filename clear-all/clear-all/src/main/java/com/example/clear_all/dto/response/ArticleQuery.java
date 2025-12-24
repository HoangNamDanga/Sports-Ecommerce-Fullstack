package com.example.clear_all.dto.response;

import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;


@Data
public class ArticleQuery {
    private BigDecimal id;
    private String title;
    private String summary;
    private String slug;
    private String featuredImage;
    private BigInteger viewCount;
    private Boolean isFeatured;
    private Date publishedAt;
    private BigInteger authorId;
    private BigInteger teamId;
    private BigInteger categoryId;
}
