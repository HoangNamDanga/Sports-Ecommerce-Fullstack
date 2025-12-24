package com.example.clear_all.controller;


import com.example.clear_all.dto.response.LeaguesQuery;
import com.example.clear_all.dto.response.RelatedArticlesExtension;
import com.example.clear_all.dto.response.RelatedArticlesQuery;
import com.example.clear_all.dto.response.TeamQuery;
import com.example.clear_all.service.RelatedArticleService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.math.BigInteger;
import java.util.List;

@RestController
@RequestMapping("/api/relatedArticles")
public class RelatedArticlesController {

    @Autowired
    private RelatedArticleService _service;


    //Chưa test
    @GetMapping
    public ResponseEntity<List<RelatedArticlesQuery>> getAllRelatedArticles() {
        return ResponseEntity.ok(_service.getAllRelatedArticles());
    }

    @GetMapping("/{primaryArticleId}")
    public ResponseEntity<List<RelatedArticlesExtension>> getRelatedArticlesByPrimaryId(
            @PathVariable("primaryArticleId") BigInteger primaryArticleId) {
        return ResponseEntity.ok(_service.getRelatedArticles(primaryArticleId));
    }
}
