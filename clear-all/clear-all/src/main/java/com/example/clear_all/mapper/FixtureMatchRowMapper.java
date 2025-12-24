package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.FixtureMatchQueryRaw;

import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;


public class FixtureMatchRowMapper implements RowMapper<FixtureMatchQueryRaw> {

    @Override
    public FixtureMatchQueryRaw mapRow(ResultSet rs, int rowNum) throws SQLException {
        FixtureMatchQueryRaw raw = new FixtureMatchQueryRaw();
        raw.setId(rs.getBigDecimal("MATCHID"));
        raw.setHomeTeamName(rs.getString("HOMETEAMNAME"));
        raw.setAwayTeamName(rs.getString("AWAYTEAMNAME"));
        raw.setMatchDateTime(rs.getString("MATCHDATETIME"));
        raw.setStatus(rs.getString("STATUS"));
        raw.setLeagueName(rs.getString("LEAGUENAME"));
        return raw;
    }
}
