package com.example.clear_all.repository;

import com.example.clear_all.model.RelatedArticles;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.List;

@Repository
public interface RelatedArticlesRepository extends JpaRepository<RelatedArticles, BigDecimal> {
    /*
    * lấy danh sách các bài viết liên quan đ một bài chính (theo PRIMARY_ARTICLE_ID) như bên .NET
    * @Query("SELECT r FROM RelatedArticles r WHERE r.relatedArticlesPK.primaryArticleId = :articleId")
    List<RelatedArticles> findRelatedByPrimaryId(@Param("articleId") BigInteger articleId); */

    @Query("SELECT r FROM RelatedArticles r WHERE r.relatedArticlesPK.primaryArticleId = :articleId")
    List<RelatedArticles> findRelatedByPrimaryId(@Param("articleId") BigInteger articleId);


}
