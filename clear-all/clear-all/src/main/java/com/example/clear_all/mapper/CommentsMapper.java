package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.CommentsQuery;

import java.util.List;
import java.util.stream.Collectors;

public class CommentsMapper {

    public static CommentsQuery toDto(com.example.clear_all.model.Comments comment) {
        CommentsQuery dto = new CommentsQuery();
        dto.setId(comment.getId());
        dto.setArticleId(comment.getArticleId());
        dto.setUserId(comment.getUserId());
        dto.setContent(comment.getContent());
        dto.setParentCommentId(comment.getParentCommentId());
        dto.setIsApproved(comment.getIsApproved());
        dto.setCreateBy(comment.getCreateBy());
        dto.setCreateDate(comment.getCreateDate());
        dto.setLastUpdateBy(comment.getLastUpdateBy());
        dto.setLastUpdateDate(comment.getLastUpdateDate());
        return dto;
    }

    public static List<CommentsQuery> toDtoList(List<com.example.clear_all.model.Comments> comments) {
        return comments.stream()
                .map(CommentsMapper::toDto) // đến DTO
                .collect(Collectors.toList());
    }
}
