package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.RelatedArticlesExtension;
import com.example.clear_all.model.RelatedArticles;

import java.util.ArrayList;
import java.util.List;

public class RelatedArticleQueryExtensionMapper {
    public static RelatedArticlesExtension toDto(RelatedArticles entity) {
        RelatedArticlesExtension dto = new RelatedArticlesExtension();
        dto.setPrimaryArticleId(entity.getRelatedArticlesPK().getPrimaryArticleId());
        dto.setRelatedArticleId(entity.getRelatedArticlesPK().getRelatedArticleId());
        dto.setRelationType(entity.getRelationType());
        dto.setCreatedAt(entity.getCreatedAt());

        //dto tạo thêm 3 field để hứng giá trị string từ entity
        if (entity.getArticles() != null) {
            dto.setRelatedTitle(entity.getArticles().getTitle());
            dto.setRelatedSlug(entity.getArticles().getSlug());
            dto.setRelatedFeaturedImage(entity.getArticles().getFeaturedImage());
        }

        /*
        * @JoinColumn(name = "RELATED_ARTICLE_ID", referencedColumnName = "ID", insertable = false, updatable = false)
        @ManyToOne(optional = false)
        private Articles articles
        * entity.getArticles() sẽ truy xuất được bài viết liên quan, từ đó lấy được title, slug, featuredImage.;
        * */

        return dto;
    }

    public static List<RelatedArticlesExtension> toDtoList(List<RelatedArticles> entities) {
        List<RelatedArticlesExtension> dtoList = new ArrayList<>();
        for (RelatedArticles entity : entities) {
            dtoList.add(toDto(entity));
        }
        return dtoList;
    }
}
