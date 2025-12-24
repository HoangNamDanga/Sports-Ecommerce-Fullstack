package com.example.clear_all.dto.response;


import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class User24hQuery {
    private BigDecimal id;
    private String username;
    private String fullname;
    private String phone;
    private String role;
    private Short inactive;
    private Date createdate;
    private String createby;
    private Date modifydate;
    private String modifyby;
    private String tokenactive;
    private Date dateactive;
    private String codeactive;
    private Date datecodeactive;
    private String center;
    private Short addgoogle;
    private BigInteger empid;

}
