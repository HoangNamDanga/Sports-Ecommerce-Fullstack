package com.example.clear_all.service;

import com.example.clear_all.dto.response.User24hQuery;
import com.example.clear_all.mapper.User24hMapper;
import com.example.clear_all.model.User24h;
import com.example.clear_all.repository.User24hRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class User24hService {
    @Autowired
    private User24hRepository user24hRepository;

    public List<User24hQuery> getAllUsers() {
        List<User24h> users = user24hRepository.findAll();
        return users.stream()
                .map(User24hMapper::toDto)
                .collect(Collectors.toList());
    }
}
