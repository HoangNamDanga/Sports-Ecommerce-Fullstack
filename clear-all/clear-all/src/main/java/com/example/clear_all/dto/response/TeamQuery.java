package com.example.clear_all.dto.response;

import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class TeamQuery {
    private BigDecimal id;
    private String teamName;
    private String teamCode;
    private String country;
    private String logoUrl;
    private BigInteger leagueId;
    private BigInteger foundedYear;
    private String stadium;
    private BigInteger createBy;
    private Date createDate;
    private BigInteger lastUpdateBy;
    private Date lastUpdateDate;
}
