package com.example.clear_all.repository;

import com.example.clear_all.dto.response.FixtureMatchQueryRaw;

import java.util.List;

public interface MatchesRepositoryCustom {
    List<FixtureMatchQueryRaw> getAllFixturesFromStoredProcedure();
}
