package com.example.clear_all.controller;


import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.dto.response.CommentsQuery;
import com.example.clear_all.service.ArticleService;
import com.example.clear_all.service.CommentsService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/comments")
public class CommentsController {

    @Autowired
    private CommentsService commentService;


    //Chưa test

    @GetMapping
    public ResponseEntity<List<CommentsQuery>> getAllComment(){
        return ResponseEntity.ok(commentService.getAllComment());
    }
}
