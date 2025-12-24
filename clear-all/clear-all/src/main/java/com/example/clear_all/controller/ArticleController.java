package com.example.clear_all.controller;

import com.example.clear_all.HoangNam.Infrastructure.MessageResponse;
import com.example.clear_all.model.Categories;
import com.example.clear_all.service.ArticleService;
import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.model.Articles;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.*;

@RestController
@RequestMapping("/api/articles")
public class ArticleController {

    @Autowired
    private ArticleService articleService;


    //Chưa test
    @GetMapping
    public ResponseEntity<List<ArticleCommand>> getAllArticle(){
        return ResponseEntity.ok(articleService.getAllArticle());
    }

    @GetMapping("/latest-eight") // <-- Thay đổi đường dẫn API cho rõ ràng
    public ResponseEntity<List<ArticleCommand>> getLatestEightArticles(){ // <-- Thay đổi tên phương thức
        return ResponseEntity.ok(articleService.getEightLatestArticles()); // <-- Gọi phương thức service mới
    }




    @GetMapping("/latest-article")
    public ResponseEntity<ArticleCommand> getLatestArticle() {
        Optional<ArticleCommand> latestArticleCommand = articleService.getLatestArticle();

        return latestArticleCommand
                .map(ResponseEntity::ok)  // Trả về ResponseEntity với dữ liệu ArticleCommand
                .orElseGet(() -> ResponseEntity.notFound().build());  // Nếu không có bài viết, trả về 404
    }

    @PostMapping("/create-bai-viet")
    public ResponseEntity<MessageResponse> createArticle(@Valid @RequestBody ArticleCommand command) {
        MessageResponse response = new MessageResponse();

        try {
            Long userId = 1L;
            Articles article = articleService.createArticle(command, userId);

            boolean isCreated = article != null;

            response.setSuccess(isCreated);
            response.setHttpStatusCode(HttpStatus.OK.value());
            response.setMessage(isCreated ? "Thêm mới thành công!" : "Thêm mới thất bại!");
            response.setData(article);

            return ResponseEntity.ok(response);

        } catch (Exception ex) {
            response.setSuccess(false);
            response.setHttpStatusCode(HttpStatus.BAD_REQUEST.value());
            response.setMessage("Lỗi xảy ra khi tạo bài viết.");

            Map<String, List<String>> errors = new HashMap<>();
            errors.put("exception", Collections.singletonList(ex.getMessage()));
            response.setErrors(errors);

            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(response);
        }
    }
}
