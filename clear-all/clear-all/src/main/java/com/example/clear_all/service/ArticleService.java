package com.example.clear_all.service;

import com.example.clear_all.dto.response.CategoriesQuery;
import com.example.clear_all.mapper.CategoriesMapper;
import com.example.clear_all.model.Categories;
import com.example.clear_all.repository.ArticlesRepository;
import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.mapper.ArticleMapper;
import com.example.clear_all.model.Articles;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class ArticleService {

    @Autowired
    private ArticlesRepository articlesRepository;

    @Autowired
    private ArticleMapper articleMapper;

    public Articles createArticle(ArticleCommand command, long userId) throws IOException {
        //1. Thiết lập mặc định
        command.prepareForCreate(BigInteger.valueOf(userId));

        //2. Upload ảnh nếu có
        articleMapper.processImageUpload(command);

        //3. Map sang Entity
        Articles article = articleMapper.toEntity(command);
        // Chuyển đổi LocalDateTime sang Date
        Date createDate = Date.from(LocalDateTime.now().atZone(ZoneId.systemDefault()).toInstant());
        article.setCreateDate(createDate);

        //4. Lưu vào DB
        return articlesRepository.save(article);
    }

    public List<ArticleCommand> getAllArticle(){
        List<Articles> entities = articlesRepository.findAll();
        return entities.stream()
                .map(ArticleMapper::toCommand)
                .collect(Collectors.toList());
    }

    // Phương thức để lấy bài viết mới nhất
    public Optional<ArticleCommand> getLatestArticle() {
        // Lấy bài viết mới nhất
        Optional<Articles> latestArticle = articlesRepository.findLatestArticle();

        // Nếu bài viết tồn tại, chuyển sang ArticleCommand
        return latestArticle.map(ArticleMapper::toCommand);
    }

    public List<ArticleCommand> getEightLatestArticles() {
        // 1. Gọi Repository để lấy danh sách Articles entity (8 bài mới nhất)
        List<Articles> latestEightArticles = articlesRepository.findEightLatestArticlesNative();

        // 2. Sử dụng Stream API và ArticleMapper.toCommand để map từng entity sang command
        return latestEightArticles.stream()
                .map(ArticleMapper::toCommand)
                .collect(Collectors.toList());
    }


}
