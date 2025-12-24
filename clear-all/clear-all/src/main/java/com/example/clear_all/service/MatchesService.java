package com.example.clear_all.service;


import com.example.clear_all.dto.response.FixtureMatchQuery;
import com.example.clear_all.dto.response.FixtureMatchQueryRaw;
import com.example.clear_all.dto.response.LeagueFixturesQuery;
import com.example.clear_all.repository.MatchesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class MatchesService {
    private final MatchesRepository matchesRepository;


    @Autowired
    public MatchesService(MatchesRepository matchesRepository) {
        this.matchesRepository = matchesRepository;
    }

    public List<LeagueFixturesQuery> getFixtureMatches(){
        List<FixtureMatchQueryRaw> rawFixtures = matchesRepository.getAllFixturesFromStoredProcedure();

        return rawFixtures.stream()
                .collect(Collectors.groupingBy(FixtureMatchQueryRaw::getLeagueName))
                .entrySet().stream()
                .map(groupEntry -> {
                    LeagueFixturesQuery leagueGroup = new LeagueFixturesQuery();
                    leagueGroup.setLeagueName(groupEntry.getKey());

                    List<FixtureMatchQuery> matchList = groupEntry.getValue().stream()
                            .map(raw -> {
                                FixtureMatchQuery match = new FixtureMatchQuery();
                                match.setId(raw.getId());
                                match.setHomeTeamName(raw.getHomeTeamName());
                                match.setAwayTeamName(raw.getAwayTeamName());
                                match.setMatchDateTime(raw.getMatchDateTime());
                                match.setStatus(raw.getStatus());
                                return match;
                            })
                            .sorted(Comparator.comparing(FixtureMatchQuery::getMatchDateTime))
                            .collect(Collectors.toList());

                    leagueGroup.setMatches(matchList);

                    return leagueGroup;
                }).collect(Collectors.toList());
    }
}
