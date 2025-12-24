package com.example.clear_all.dto.response;


import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class CategoriesQuery {
    private BigDecimal id;
    private String categoryName;
    private String slug;
    private BigInteger parentId;
    private BigInteger displayOrder;
    private BigInteger createBy;
    private Date createDate;
    private BigInteger lastUpdateBy;
    private Date lastUpdateDate;
}
