package com.example.clear_all.controller;


import com.example.clear_all.dto.response.User24hQuery;
import com.example.clear_all.service.User24hService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/user24h")
public class User24hController {

    @Autowired
    private User24hService user24hService;

    @GetMapping
    public ResponseEntity<List<User24hQuery>> getAllUsers() {
        return ResponseEntity.ok(user24hService.getAllUsers());
    }
}
