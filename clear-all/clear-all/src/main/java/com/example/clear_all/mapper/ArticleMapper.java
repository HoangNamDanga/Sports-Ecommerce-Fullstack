package com.example.clear_all.mapper;

import com.example.clear_all.dto.request.ArticleCommand;
import com.example.clear_all.model.Articles;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.UUID;

@Component
public class ArticleMapper {
    private static final String UPLOAD_DIR = "upload/articles";

    //	Chuyển ArticleCommand → Articles. Dùng khi tạo mới hoặc cập nhật bài viết.
    public Articles toEntity(ArticleCommand command){
        Articles article = new Articles();

        //Only Set ID for existing articles (update)
        if(command.getId() != null){
            article.setId(command.getId());
        }

        article.setTitle(command.getTitle());
        article.setContent(command.getContent());
        article.setSummary(command.getSummary());
        article.setAuthorId(command.getAuthorId());
        article.setTeamId(command.getTeamId());
        article.setPublishedAt(command.getPublishedAt());
        article.setSlug(command.getSlug());
        article.setFeaturedImage(command.getFeaturedImage());
        article.setViewCount(command.getViewCount());
        article.setIsFeatured(command.getIsFeatured());
        article.setCreateBy(command.getCreateBy());
        article.setLastUpdateBy(command.getLastUpdateBy());
        article.setLastUpdateDate(command.getLastUpdateDate());
        article.setCategoryId(command.getCategoryId());

        return article;
    }


    //Chuyển Articles → ArticleCommand. Dùng khi load dữ liệu để trả về client.
    //chưa dùng, đây là query
    public static ArticleCommand toCommand(Articles article){
        ArticleCommand command = new ArticleCommand();
        command.setId(article.getId());
        command.setTitle(article.getTitle());
        command.setContent(article.getContent());
        command.setSummary(article.getSummary());
        command.setAuthorId(article.getAuthorId());
        command.setTeamId(article.getTeamId());
        command.setPublishedAt(article.getPublishedAt());
        command.setSlug(article.getSlug());
        command.setFeaturedImage(article.getFeaturedImage());
        command.setViewCount(article.getViewCount());
        command.setIsFeatured(article.getIsFeatured());
        command.setCreateBy(article.getCreateBy());
        command.setCreateDate(article.getCreateDate());
        command.setLastUpdateBy(article.getLastUpdateBy());
        command.setLastUpdateDate(article.getLastUpdateDate());
        command.setCategoryId(article.getCategoryId());
        return command;
    }

    /**
     * Process image upload from ArticleCommand and update the featuredImage path
     * @param command The ArticleCommand containing the uploaded file
     * @return The updated image path
     * @throws IOException If there's an error processing the file
     * Xử lý ảnh upload, tạo thư mục nếu chưa có, lưu ảnh và cập nhật đường dẫn ảnh.
     */

    public String processImageUpload(ArticleCommand command) throws IOException {
        MultipartFile imageFile = command.getFeaturedImageFile();

        if(imageFile == null || imageFile.isEmpty()){
            return  command.getFeaturedImage(); // trare về đường dẫn tồn tại nếu không có ảnh mới
        }

        //Create upload directory if it doesn't exist

        Path uploadPath = Paths.get(UPLOAD_DIR);
        if (!Files.exists(uploadPath)) {
            Files.createDirectories(uploadPath);
        }

        //Generate unique filename
        String fileName = UUID.randomUUID().toString() + "_" +
                StringUtils.cleanPath(imageFile.getOriginalFilename());

        //Save the file
        Path filePath = uploadPath.resolve(fileName);
        Files.copy(imageFile.getInputStream(), filePath, StandardCopyOption.REPLACE_EXISTING);

        //Update the featuredImage path
        String imagePath = UPLOAD_DIR + fileName;
        command.setFeaturedImage(imagePath);

        return imagePath;
    }
    /**
     * Update entity from command for updates
     * @param article The entity to update
     * @param command The command with updated values
     * Cập nhật một bài viết (Articles) từ DTO ArticleCommand. Dùng cho chỉnh sửa.
     */

    public void updateEntityFromCommand(Articles article, ArticleCommand command){
        article.setTitle(command.getTitle());
        article.setContent(command.getContent());
        article.setSummary(command.getSummary());
        article.setAuthorId(command.getAuthorId());
        article.setTeamId(command.getTeamId());
        article.setPublishedAt(command.getPublishedAt());
        article.setSlug(command.getSlug());

        // Only update featured image if a new one is provided
        if (command.getFeaturedImage() != null) {
            article.setFeaturedImage(command.getFeaturedImage());
        }

        article.setIsFeatured(command.getIsFeatured());
        article.setCategoryId(command.getCategoryId());
        article.setLastUpdateBy(command.getLastUpdateBy());
        article.setLastUpdateDate(command.getLastUpdateDate());
    }

    /**
     * Tạo ID mới thủ công (nếu không dùng auto increment).
     * Generate new ID for article - if your system requires manual ID generation
     */
    public BigDecimal generateNewId() {
        // Implementation depends on your system's ID generation strategy
        // This is just an example
        return new BigDecimal(System.currentTimeMillis());
    }
}
