package com.example.clear_all.dto.response;
import lombok.Data;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.math.BigDecimal;

@Data
public class PremierLeagueStandingsQuery {



    private BigDecimal teamId;        // Tương ứng với TEAM_ID (NUMBER)
    private String teamName;          // Tương ứng với TEAM_NAME (VARCHAR2)
    private Integer rankPosition;     // Sử dụng Integer thay vì Short cho RANK_POSITION (NUMBER(2,0))
    private Integer matchesPlayed;    // Sử dụng Integer thay vì Short cho MATCHES_PLAYED (NUMBER(3,0))
    private Integer wins;             // Sử dụng Integer thay vì Short cho WINS (NUMBER(3,0))
    private Integer draws;            // Sử dụng Integer thay vì Short cho DRAWS (NUMBER(3,0))
    private Integer losses;           // Sử dụng Integer thay vì Short cho LOSSES (NUMBER(3,0))
    private Integer goalsFor;         // Sử dụng Integer thay vì Short cho GOALS_FOR (NUMBER(3,0))
    private Integer goalsAgainst;     // Sử dụng Integer thay vì Short cho GOALS_AGAINST (NUMBER(3,0))
    private Integer goalDifference;   // Sử dụng Integer thay vì Short cho GOAL_DIFFERENCE (NUMBER(3,0))
    private Integer points;           // Sử dụng Integer thay vì Short cho POINTS (NUMBER(3,0))

    // Constructor để ánh xạ các giá trị từ query
    public PremierLeagueStandingsQuery(BigDecimal teamId, String teamName, Integer rankPosition, Integer matchesPlayed,
                                       Integer wins, Integer draws, Integer losses, Integer goalsFor, Integer goalsAgainst,
                                       Integer goalDifference, Integer points) {
        this.teamId = teamId;
        this.teamName = teamName;
        this.rankPosition = rankPosition;
        this.matchesPlayed = matchesPlayed;
        this.wins = wins;
        this.draws = draws;
        this.losses = losses;
        this.goalsFor = goalsFor;
        this.goalsAgainst = goalsAgainst;
        this.goalDifference = goalDifference;
        this.points = points;
    }

}
