package com.example.clear_all.controller;


import com.example.clear_all.dto.response.CategoriesQuery;
import com.example.clear_all.model.Categories;
import com.example.clear_all.service.CategoriesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/categories")
public class CategoriesController {

    @Autowired
    private CategoriesService categoriesService;



    @GetMapping
    public ResponseEntity<List<CategoriesQuery>> getAllCategories(){
        return ResponseEntity.ok(categoriesService.getAllCategories());
    }

    // Lấy thể loại theo ID
    @GetMapping("/{categoryId}")
    public ResponseEntity<Categories> getCategoryById(@PathVariable Long categoryId) {
        Categories category = categoriesService.getCategoryById(categoryId);
        if (category != null) {
            return ResponseEntity.ok(category);
        }
        return ResponseEntity.notFound().build();
    }
}
