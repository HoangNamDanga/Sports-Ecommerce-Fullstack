package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.CategoriesQuery;
import com.example.clear_all.model.Categories;

public class CategoriesMapper {
    public static CategoriesQuery toDto(Categories entity) {
        CategoriesQuery query = new CategoriesQuery();
        query.setId(entity.getId());
        query.setCategoryName(entity.getCategoryName());
        query.setSlug(entity.getSlug());
        query.setParentId(entity.getParentId());
        query.setDisplayOrder(entity.getDisplayOrder());
        query.setCreateBy(entity.getCreateBy());
        query.setCreateDate(entity.getCreateDate());
        query.setLastUpdateBy(entity.getLastUpdateBy());
        query.setLastUpdateDate(entity.getLastUpdateDate());
        return query;
    }
}
