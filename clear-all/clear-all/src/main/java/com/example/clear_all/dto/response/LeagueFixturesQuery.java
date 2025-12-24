package com.example.clear_all.dto.response;


import lombok.Data;

import java.util.List;

@Data
public class LeagueFixturesQuery {
    private String leagueName;
    private List<FixtureMatchQuery> matches;
}
