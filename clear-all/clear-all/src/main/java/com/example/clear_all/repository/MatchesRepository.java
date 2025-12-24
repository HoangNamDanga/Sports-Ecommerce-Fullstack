package com.example.clear_all.repository;

import com.example.clear_all.model.Matches;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import javax.sql.DataSource;
import java.math.BigDecimal;

@Repository
public interface MatchesRepository extends JpaRepository<Matches, BigDecimal>,MatchesRepositoryCustom {

}
//Kế thừa JpaRepository để xử lý thao tác CRUD
// Kế thừa MatchesRepositoryCustom để thêm logic custom như gọi Stored Procedure
// Spring Boot sẽ tự động tìm và gắn MatchesRepositoryImp cho phần MatchesRepository