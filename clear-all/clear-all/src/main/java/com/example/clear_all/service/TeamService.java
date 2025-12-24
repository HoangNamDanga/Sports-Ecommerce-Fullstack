package com.example.clear_all.service;

import com.example.clear_all.dto.response.TeamQuery;
import com.example.clear_all.mapper.TeamMapper;
import com.example.clear_all.model.Teams;
import com.example.clear_all.repository.TeamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class TeamService {
    @Autowired
    private TeamRepository teamRepository;

    public List<TeamQuery> getAllTeams() {
        List<Teams> teams = teamRepository.findAll();
        return teams.stream()
                .map(TeamMapper::toDto)
                .collect(Collectors.toList());
    }
}
