package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.RelatedArticlesQuery;
import com.example.clear_all.model.RelatedArticles;

import java.util.List;
import java.util.stream.Collectors;

public class RelatedArticlesMapper {
    public static RelatedArticlesQuery toDto(RelatedArticles entity) {
        RelatedArticlesQuery dto = new RelatedArticlesQuery();
        dto.setPrimaryArticleId(entity.getRelatedArticlesPK().getPrimaryArticleId());
        dto.setRelatedArticleId(entity.getRelatedArticlesPK().getRelatedArticleId());
        dto.setRelationType(entity.getRelationType());
        dto.setCreatedAt(entity.getCreatedAt());
        return dto;
    }

    public static List<RelatedArticlesQuery> toDtoList(List<RelatedArticles> list) {
        return list.stream()
                .map(RelatedArticlesMapper::toDto)
                .collect(Collectors.toList());
    }


}
