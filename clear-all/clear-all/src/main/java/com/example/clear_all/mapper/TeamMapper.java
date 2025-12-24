package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.TeamQuery;
import com.example.clear_all.model.Teams;

public class TeamMapper {
    public static TeamQuery toDto(Teams team) {
        TeamQuery dto = new TeamQuery();
        dto.setId(team.getId());
        dto.setTeamName(team.getTeamName());
        dto.setTeamCode(team.getTeamCode());
        dto.setCountry(team.getCountry());
        dto.setLogoUrl(team.getLogoUrl());
        dto.setLeagueId(team.getLeagueId());
        dto.setFoundedYear(team.getFoundedYear());
        dto.setStadium(team.getStadium());
        dto.setCreateBy(team.getCreateBy());
        dto.setCreateDate(team.getCreateDate());
        dto.setLastUpdateBy(team.getLastUpdateBy());
        dto.setLastUpdateDate(team.getLastUpdateDate());
        return dto;
    }
}
