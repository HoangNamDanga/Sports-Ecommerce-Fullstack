package com.example.clear_all.controller;


import com.example.clear_all.dto.response.PremierLeagueStandingsQuery;
import com.example.clear_all.service.PremierLeaguesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.math.BigDecimal;
import java.util.List;

@RestController
@RequestMapping("/api/premier-leagues")
public class PremierLeaguesController {

    @Autowired
    private PremierLeaguesService premierLeaguesService;

    // API Endpoint để lấy bảng xếp hạng Ngoại Hạng Anh theo LEAGUE_ID
    @GetMapping
    public ResponseEntity<List<PremierLeagueStandingsQuery>> getPremierLeagueStandings(
            @RequestParam(value = "leagueId", required = false) BigDecimal leagueId) {

        // Kiểm tra nếu leagueId là null hoặc không hợp lệ, gán giá trị mặc định
        if (leagueId == null || leagueId.compareTo(BigDecimal.ZERO) <= 0) {
            leagueId = BigDecimal.valueOf(23); // Gán giá trị mặc định cho leagueId (ví dụ: Ngoại Hạng Anh)
        }

        List<PremierLeagueStandingsQuery> standings = premierLeaguesService.getPremierLeagueStandingsByLeagueId(leagueId);
        if (standings.isEmpty()) {
            return ResponseEntity.noContent().build(); // Nếu không có dữ liệu, trả về 204 No Content
        }
        return ResponseEntity.ok(standings); // Trả về danh sách standings với HTTP status 200
    }
}
