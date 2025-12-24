package com.example.clear_all.service;

import com.example.clear_all.dto.response.CommentsQuery;
import com.example.clear_all.dto.response.LeaguesQuery;
import com.example.clear_all.mapper.CommentsMapper;
import com.example.clear_all.mapper.LeagueMapper;
import com.example.clear_all.model.Comments;
import com.example.clear_all.model.Leagues;
import com.example.clear_all.repository.LeaguesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class LeaguesService {

    @Autowired
    private LeaguesRepository leaguesRepository;



    public List<LeaguesQuery> getAllLeagues(){
        List<Leagues> entities = leaguesRepository.findAll();
        return entities.stream()
                .map(LeagueMapper::toDto)
                .collect(Collectors.toList());
    }
}
