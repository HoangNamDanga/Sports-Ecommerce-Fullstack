package com.example.clear_all.dto.response;

import lombok.Data;

import java.math.BigDecimal;


@Data
public class FixtureMatchQuery {
    private BigDecimal id;
    private String homeTeamName;
    private String awayTeamName;
    private String matchDateTime;
    private String status;
}
