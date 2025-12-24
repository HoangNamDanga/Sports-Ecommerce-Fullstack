package com.example.clear_all.service;


import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.dto.response.CommentsQuery;
import com.example.clear_all.mapper.ArticleMapper;
import com.example.clear_all.mapper.CommentsMapper;
import com.example.clear_all.model.Articles;
import com.example.clear_all.model.Comments;
import com.example.clear_all.repository.ArticlesRepository;
import com.example.clear_all.repository.CommentsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CommentsService {
    @Autowired
    private CommentsRepository commentRepository;


    public List<CommentsQuery> getAllComment(){
        List<Comments> entities = commentRepository.findAll();
        return entities.stream()
                .map(CommentsMapper::toDto)
                .collect(Collectors.toList());
    }


}
