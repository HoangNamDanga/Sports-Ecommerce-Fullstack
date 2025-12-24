package com.example.clear_all.repository;

import com.example.clear_all.model.Articles;
import com.example.clear_all.model.Categories;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.List;
import java.util.Optional;

@Repository
public interface ArticlesRepository  extends JpaRepository<Articles, BigDecimal> {
    //lấy bài viết mới nhất
    @Query(
            value = "SELECT * FROM ARTICLES WHERE PUBLISHED_AT <= SYSDATE ORDER BY PUBLISHED_AT DESC, ID DESC FETCH FIRST 1 ROWS ONLY",
            nativeQuery = true
    )
    Optional<Articles> findLatestArticle();

    // --- Phương thức để lấy 8 bài viết mới nhất sử dụng Native SQL (như bạn đã làm) ---
    // Cần đảm bảo cú pháp FETCH FIRST X ROWS ONLY/LIMIT X phù hợp với CSDL của bạn (Oracle/MySQL/PostgreSQL)
    @Query(
            value = "SELECT * " +
                    "FROM ARTICLES " +
                    "WHERE PUBLISHED_AT IS NOT NULL " +
                    "AND TO_DATE(PUBLISHED_AT, 'DD-MON-RR') <= SYSDATE " +  // chuyển PUBLISHED_AT sang DATE để so sánh chính xác
                    "ORDER BY TO_DATE(PUBLISHED_AT, 'DD-MON-RR') DESC, ID DESC " +  // sort theo ngày thực, rồi id để phòng trường hợp cùng ngày đăng , vì id tự tăng ...
                    "FETCH FIRST 8 ROWS ONLY",
            nativeQuery = true
    )
    List<Articles> findEightLatestArticlesNative();



}
