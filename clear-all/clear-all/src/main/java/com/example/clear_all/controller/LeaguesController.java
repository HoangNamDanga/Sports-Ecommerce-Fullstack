package com.example.clear_all.controller;


import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.dto.response.LeaguesQuery;
import com.example.clear_all.service.ArticleService;
import com.example.clear_all.service.LeaguesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/leagues")
public class LeaguesController {

    @Autowired
    private LeaguesService leaguesService;


    //Chưa test

    @GetMapping
    public ResponseEntity<List<LeaguesQuery>> getAllLeagues(){
        return ResponseEntity.ok(leaguesService.getAllLeagues());
    }
}
