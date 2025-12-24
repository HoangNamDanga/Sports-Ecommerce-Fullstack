package com.example.clear_all.dto.response;


import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class CommentsQuery {
    private BigDecimal id;
    private BigInteger articleId;
    private BigInteger userId;
    private String content;
    private BigInteger parentCommentId;
    private Short isApproved;
    private BigInteger createBy;
    private Date createDate;
    private BigInteger lastUpdateBy;
    private Date lastUpdateDate;
}
