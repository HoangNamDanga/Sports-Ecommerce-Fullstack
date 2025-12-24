package com.example.clear_all.repository;

import com.example.clear_all.dto.response.FixtureMatchQueryRaw;
import com.example.clear_all.mapper.FixtureMatchRowMapper;
import org.hibernate.dialect.OracleTypes;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.SqlOutParameter;
import org.springframework.jdbc.core.simple.SimpleJdbcCall;
import org.springframework.stereotype.Repository;

import javax.sql.DataSource;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Repository
public class MatchesRepositoryImpl implements MatchesRepositoryCustom{

    private final JdbcTemplate jdbcTemplate;
    private final DataSource dataSource;


    @Autowired
    public MatchesRepositoryImpl(JdbcTemplate jdbcTemplate, DataSource dataSource) {
        this.jdbcTemplate = jdbcTemplate;
        this.dataSource = dataSource;
    }

    @Override
    public List<FixtureMatchQueryRaw> getAllFixturesFromStoredProcedure() {
        SimpleJdbcCall jdbcCall = new SimpleJdbcCall(dataSource)
                .withProcedureName("GET_ALL_FIXTURES_PROC")
                .declareParameters(
                        new SqlOutParameter("p_fixtures_cursor", OracleTypes.CURSOR, new FixtureMatchRowMapper())
                );

        Map<String,Object> result = jdbcCall.execute(new HashMap<>()); // kiểu trả ra API, trong ví dụ này nghĩa là key là String nghãi là leagueName, object là value, value nghĩa là 1 đối tượng

        //Kiểu mong muốn trả về là p_fixtures_cursor (con trỏ) - trả về 1 List<FixtureMatchQueryRaw>, do java không tự động biết điều này nên mình phải ép kiểu để java hiểu
        return (List<FixtureMatchQueryRaw>) result.get("p_fixtures_cursor");
    }
}
