package com.example.clear_all.dto.response;


import lombok.Data;
import lombok.Getter;
import lombok.Setter;

import java.math.BigInteger;
import java.util.Date;

@Getter
@Setter
@Data
public class RelatedArticlesExtension {
    private BigInteger primaryArticleId;
    private BigInteger relatedArticleId;
    private String relationType;
    private Date createdAt;

    // Thông tin từ bảng Articles (bài viết liên quan)
    private String relatedTitle;
    private String relatedSlug;
    private String relatedFeaturedImage;

}
