package com.example.clear_all.repository;

import com.example.clear_all.model.Categories;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.math.BigInteger;

@Repository
public interface CategoriesRepository  extends JpaRepository<Categories, BigInteger> {
    // Sử dụng Native SQL để tìm thể loại theo categoryId
    @Query(value = "SELECT * FROM CATEGORIES WHERE id = :categoryId", nativeQuery = true)
    Categories findByIdNative(@Param("categoryId") Long categoryId);
}
