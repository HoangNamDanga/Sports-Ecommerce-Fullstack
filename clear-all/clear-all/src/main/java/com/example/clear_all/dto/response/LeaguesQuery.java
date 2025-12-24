package com.example.clear_all.dto.response;


import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class LeaguesQuery {
    private BigDecimal id;
    private String leagueName;
    private String regionCountry;
    private Short division;
    private Date seasonStart;
    private Date seasonEnd;
    private String logoUrl;
    private BigInteger createBy;
    private Date createDate;
    private BigInteger lastUpdateBy;
    private Date lastUpdateDate;
}
