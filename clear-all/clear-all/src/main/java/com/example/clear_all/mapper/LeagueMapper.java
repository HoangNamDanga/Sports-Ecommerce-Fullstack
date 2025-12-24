package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.LeaguesQuery;
import com.example.clear_all.model.Leagues;

import java.util.List;
import java.util.stream.Collectors;

public class LeagueMapper {
    public static LeaguesQuery toDto(Leagues league) {
        LeaguesQuery dto = new LeaguesQuery();
        dto.setId(league.getId());
        dto.setLeagueName(league.getLeagueName());
        dto.setRegionCountry(league.getRegionCountry());
        dto.setDivision(league.getDivision());
        dto.setSeasonStart(league.getSeasonStart());
        dto.setSeasonEnd(league.getSeasonEnd());
        dto.setLogoUrl(league.getLogoUrl());
        dto.setCreateBy(league.getCreateBy());
        dto.setCreateDate(league.getCreateDate());
        dto.setLastUpdateBy(league.getLastUpdateBy());
        dto.setLastUpdateDate(league.getLastUpdateDate());
        return dto;
    }

    public static List<LeaguesQuery> toDtoList(List<com.example.clear_all.model.Leagues> leagues) {
        return leagues.stream()
                .map(LeagueMapper::toDto)
                .collect(Collectors.toList());
    }
}
