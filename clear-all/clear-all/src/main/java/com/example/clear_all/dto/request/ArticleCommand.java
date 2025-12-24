package com.example.clear_all.dto.request;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Data;
import org.springframework.web.multipart.MultipartFile;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

@Data
public class ArticleCommand {

    private BigDecimal id;


    @NotBlank(message = "Title is required")
    @Size(max = 200, message = "Title cannot exceed 200 characters")
    private String title;

    @NotBlank(message = "Content is required")
    private String content;

    @Size(max = 500, message = "Summary cannot exceed 500 characters")
    private String summary;

    @NotNull(message = "Author ID is required")
    private BigInteger authorId;


    @NotNull(message = "Category ID is required")
    private BigInteger categoryId;


    private BigInteger teamId;

    private Date publishedAt;

    @Size(max = 255, message = "Slug cannot exceed 255 characters")
    private String slug;


    private MultipartFile featuredImageFile;

    private String featuredImage;

    private BigInteger viewCount;

    private Boolean isFeatured;

    private BigInteger createBy;

    private Date createDate;

    private BigInteger lastUpdateBy;

    private Date lastUpdateDate;



    public void generateSlug(){
        if(title != null && !title.isEmpty()){
            //convert to Lower()
            String slugValue = title.toLowerCase();

            //Replay spaces with hyphens
            slugValue = slugValue.replaceAll("\\s+", "-");

            //Remove special characters
            slugValue = slugValue.replaceAll("[^a-z0-9-]", "");

            //Remove multiple consecutive hyphens
            slugValue = slugValue.replaceAll("-+", "-");

            //Remove leading and trailing hyphens
            slugValue = slugValue.replaceAll("^-|-$", "");

            this.slug = slugValue;

        }
    }

    // Method to set default values before creating a new article
    // param userId the ID of the user creating the article

    public void prepareForCreate(BigInteger userId){
        Date now = new Date();
        this.createBy = userId;
        this.createDate = now;
        this.lastUpdateBy = userId;
        this.lastUpdateDate = now;

        if(this.viewCount == null){
            this.viewCount = BigInteger.ZERO;
        }

        if (this.isFeatured == null) {
            this.isFeatured = false; // false nghĩa là không nổi bật
        }

        if(this.slug == null || this.slug.isEmpty()){
            generateSlug();
        }
    }

    //Method to set update information
    //Param userId the ID off the user updating articles

    public void prepareForUpdate(BigInteger userId){
        this.lastUpdateBy = userId;
        this.lastUpdateDate = new Date();

        if(this.slug == null || this.slug.isEmpty()){
            generateSlug();
        }
    }

}
