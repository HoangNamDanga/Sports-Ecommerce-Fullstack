package com.example.clear_all.controller;


import com.example.clear_all.dto.response.TeamQuery;
import com.example.clear_all.service.TeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/teams")
public class TeamController {

    @Autowired
    private TeamService teamService;

    @GetMapping
    public ResponseEntity<List<TeamQuery>> getAllTeams() {
        return ResponseEntity.ok(teamService.getAllTeams());
    }
}
