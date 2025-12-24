package com.example.clear_all.service;


import com.example.clear_all.dto.response.RelatedArticlesExtension;
import com.example.clear_all.dto.response.RelatedArticlesQuery;
import com.example.clear_all.mapper.RelatedArticleQueryExtensionMapper;
import com.example.clear_all.mapper.RelatedArticlesMapper;
import com.example.clear_all.model.RelatedArticles;
import com.example.clear_all.repository.RelatedArticlesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.math.BigInteger;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class RelatedArticleService {
    @Autowired
    private RelatedArticlesRepository repo;

    public List<RelatedArticlesExtension> getRelatedArticles(BigInteger articleId) {
        List<RelatedArticles> list = repo.findRelatedByPrimaryId(articleId);
        return RelatedArticleQueryExtensionMapper.toDtoList(list);
    }

    public List<RelatedArticlesQuery> getAllRelatedArticles(){
        List<RelatedArticles> entities = repo.findAll();
        return entities.stream()
                .map(RelatedArticlesMapper::toDto)
                .collect(Collectors.toList());
    }
}
