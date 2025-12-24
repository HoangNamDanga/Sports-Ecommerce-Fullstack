package com.example.clear_all.controller;


import com.example.clear_all.dto.response.LeagueFixturesQuery;
import com.example.clear_all.service.MatchesService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/matches")
public class MatchesController {

    private final MatchesService _service;

    public MatchesController(MatchesService service) {
        _service = service;
    }

    @GetMapping("/fixtures")
    public ResponseEntity<List<LeagueFixturesQuery>> getFixtures() {
        return ResponseEntity.ok(_service.getFixtureMatches());
    }
}
