package com.example.clear_all.mapper;

import com.example.clear_all.dto.response.User24hQuery;
import com.example.clear_all.model.User24h;

public class User24hMapper {
    public static User24hQuery toDto(User24h entity) {
        User24hQuery dto = new User24hQuery();
        dto.setId(entity.getId());
        dto.setUsername(entity.getUsername());
        dto.setFullname(entity.getFullname());
        dto.setPhone(entity.getPhone());
        dto.setRole(entity.getRole());
        dto.setInactive(entity.getInactive());
        dto.setCreatedate(entity.getCreatedate());
        dto.setCreateby(entity.getCreateby());
        dto.setModifydate(entity.getModifydate());
        dto.setModifyby(entity.getModifyby());
        dto.setTokenactive(entity.getTokenactive());
        dto.setDateactive(entity.getDateactive());
        dto.setCodeactive(entity.getCodeactive());
        dto.setDatecodeactive(entity.getDatecodeactive());
        dto.setCenter(entity.getCenter());
        dto.setAddgoogle(entity.getAddgoogle());
        dto.setEmpid(entity.getEmpid());
        return dto;
    }
}
