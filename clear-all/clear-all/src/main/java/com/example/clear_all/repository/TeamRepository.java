package com.example.clear_all.repository;


import com.example.clear_all.model.Teams;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.math.BigDecimal;

@Repository
public interface TeamRepository extends JpaRepository<Teams, BigDecimal> {
}
