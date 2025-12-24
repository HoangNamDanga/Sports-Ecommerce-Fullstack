package com.example.clear_all.repository;

import com.example.clear_all.dto.response.PremierLeagueStandingsQuery;
import com.example.clear_all.model.PremierLeagueStandings;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.math.BigDecimal;
import java.util.List;

public interface PremierLeaguesRepository extends JpaRepository<PremierLeagueStandings, BigDecimal> {

    @Query(value = "SELECT TEAM_ID AS teamId, TEAM_NAME AS teamName, RANK_POSITION AS rankPosition, " +
            "MATCHES_PLAYED AS matchesPlayed, WINS AS wins, DRAWS AS draws, LOSSES AS losses, " +
            "GOALS_FOR AS goalsFor, GOALS_AGAINST AS goalsAgainst, GOAL_DIFFERENCE AS goalDifference, " +
            "POINTS AS points FROM PREMIER_LEAGUE_STANDINGS WHERE LEAGUE_ID = :leagueId ORDER BY RANK_POSITION",
            nativeQuery = true)
    List<PremierLeagueStandingsQuery> findPremierLeagueStandingsByLeagueId(@Param("leagueId") BigDecimal leagueId);
}
