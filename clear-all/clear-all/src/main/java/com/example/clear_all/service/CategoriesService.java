package com.example.clear_all.service;

import com.example.clear_all.dto.response.CategoriesQuery;
import com.example.clear_all.mapper.CategoriesMapper;
import com.example.clear_all.model.Categories;
import com.example.clear_all.repository.CategoriesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CategoriesService {

    @Autowired
    private CategoriesRepository categoriesRepository;

    public List<CategoriesQuery> getAllCategories(){
        List<Categories> entities = categoriesRepository.findAll();
        return entities.stream()
                .map(CategoriesMapper::toDto)
                .collect(Collectors.toList());
    }

    // Sử dụng phương thức findByIdNative để tìm thể loại theo ID
    public Categories getCategoryById(Long categoryId) {
        return categoriesRepository.findByIdNative(categoryId);
    }
}
