/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.example.clear_all.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import jakarta.persistence.Basic;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.NamedQueries;
import jakarta.persistence.NamedQuery;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

/**
 *
 * @author admin
 */
@Entity
@Table(name = "PREMIER_LEAGUE_STANDINGS")

public class PremierLeagueStandings implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "TEAM_ID")
    private BigDecimal teamId;
    @Basic(optional = false)
    @Column(name = "LEAGUE_ID")
    private BigInteger leagueId;
    @Column(name = "RANK_POSITION")
    private Short rankPosition;
    @Basic(optional = false)
    @Column(name = "TEAM_NAME")
    private String teamName;
    @Column(name = "MATCHES_PLAYED")
    private Short matchesPlayed;
    @Column(name = "WINS")
    private Short wins;
    @Column(name = "DRAWS")
    private Short draws;
    @Column(name = "LOSSES")
    private Short losses;
    @Column(name = "GOALS_FOR")
    private Short goalsFor;
    @Column(name = "GOALS_AGAINST")
    private Short goalsAgainst;
    @Column(name = "GOAL_DIFFERENCE")
    private Short goalDifference;
    @Column(name = "POINTS")
    private Short points;
    @Basic(optional = false)
    @Column(name = "CREATE_BY")
    private BigInteger createBy;
    @Basic(optional = false)
    @Column(name = "CREATE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date createDate;
    @Column(name = "LAST_UPDATE_BY")
    private BigInteger lastUpdateBy;
    @Basic(optional = false)
    @Column(name = "LAST_UPDATE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date lastUpdateDate;

    public PremierLeagueStandings() {
    }

    public PremierLeagueStandings(BigDecimal teamId) {
        this.teamId = teamId;
    }

    public PremierLeagueStandings(BigDecimal teamId, BigInteger leagueId, String teamName, BigInteger createBy, Date createDate, Date lastUpdateDate) {
        this.teamId = teamId;
        this.leagueId = leagueId;
        this.teamName = teamName;
        this.createBy = createBy;
        this.createDate = createDate;
        this.lastUpdateDate = lastUpdateDate;
    }

    public BigDecimal getTeamId() {
        return teamId;
    }

    public void setTeamId(BigDecimal teamId) {
        this.teamId = teamId;
    }

    public BigInteger getLeagueId() {
        return leagueId;
    }

    public void setLeagueId(BigInteger leagueId) {
        this.leagueId = leagueId;
    }

    public Short getRankPosition() {
        return rankPosition;
    }

    public void setRankPosition(Short rankPosition) {
        this.rankPosition = rankPosition;
    }

    public String getTeamName() {
        return teamName;
    }

    public void setTeamName(String teamName) {
        this.teamName = teamName;
    }

    public Short getMatchesPlayed() {
        return matchesPlayed;
    }

    public void setMatchesPlayed(Short matchesPlayed) {
        this.matchesPlayed = matchesPlayed;
    }

    public Short getWins() {
        return wins;
    }

    public void setWins(Short wins) {
        this.wins = wins;
    }

    public Short getDraws() {
        return draws;
    }

    public void setDraws(Short draws) {
        this.draws = draws;
    }

    public Short getLosses() {
        return losses;
    }

    public void setLosses(Short losses) {
        this.losses = losses;
    }

    public Short getGoalsFor() {
        return goalsFor;
    }

    public void setGoalsFor(Short goalsFor) {
        this.goalsFor = goalsFor;
    }

    public Short getGoalsAgainst() {
        return goalsAgainst;
    }

    public void setGoalsAgainst(Short goalsAgainst) {
        this.goalsAgainst = goalsAgainst;
    }

    public Short getGoalDifference() {
        return goalDifference;
    }

    public void setGoalDifference(Short goalDifference) {
        this.goalDifference = goalDifference;
    }

    public Short getPoints() {
        return points;
    }

    public void setPoints(Short points) {
        this.points = points;
    }

    public BigInteger getCreateBy() {
        return createBy;
    }

    public void setCreateBy(BigInteger createBy) {
        this.createBy = createBy;
    }

    public Date getCreateDate() {
        return createDate;
    }

    public void setCreateDate(Date createDate) {
        this.createDate = createDate;
    }

    public BigInteger getLastUpdateBy() {
        return lastUpdateBy;
    }

    public void setLastUpdateBy(BigInteger lastUpdateBy) {
        this.lastUpdateBy = lastUpdateBy;
    }

    public Date getLastUpdateDate() {
        return lastUpdateDate;
    }

    public void setLastUpdateDate(Date lastUpdateDate) {
        this.lastUpdateDate = lastUpdateDate;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (teamId != null ? teamId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof PremierLeagueStandings)) {
            return false;
        }
        PremierLeagueStandings other = (PremierLeagueStandings) object;
        if ((this.teamId == null && other.teamId != null) || (this.teamId != null && !this.teamId.equals(other.teamId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.mycompany.laydatabasebyrencode.PremierLeagueStandings[ teamId=" + teamId + " ]";
    }
    
}
