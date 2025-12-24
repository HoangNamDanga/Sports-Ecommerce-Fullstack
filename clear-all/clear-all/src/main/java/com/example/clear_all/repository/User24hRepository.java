package com.example.clear_all.repository;

import com.example.clear_all.model.User24h;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.math.BigDecimal;

@Repository
public interface User24hRepository extends JpaRepository<User24h, BigDecimal> {
}
