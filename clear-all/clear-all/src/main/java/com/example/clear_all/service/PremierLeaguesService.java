package com.example.clear_all.service;


import com.example.clear_all.dto.response.PremierLeagueStandingsQuery;
import com.example.clear_all.repository.PremierLeaguesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.List;

@Service
public class PremierLeaguesService {

    @Autowired
    private PremierLeaguesRepository premierLeaguesRepository;

    public List<PremierLeagueStandingsQuery> getPremierLeagueStandingsByLeagueId(BigDecimal leagueId) {
        return premierLeaguesRepository.findPremierLeagueStandingsByLeagueId(leagueId);
    }
}
