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
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

/**
 *
 * @author admin
 */
@Entity
@Table(name = "MATCHES")
public class Matches implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @Column(name = "ID")
    private BigDecimal id;
    @Column(name = "HOME_TEAM_ID")
    private BigInteger homeTeamId;
    @Column(name = "AWAY_TEAM_ID")
    private BigInteger awayTeamId;
    @Column(name = "LEAGUE_ID")
    private BigInteger leagueId;
    @Column(name = "MATCH_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    private Date matchDate;
    @Column(name = "STADIUM")
    private String stadium;
    @Column(name = "FIRST_HALF_SCORE_HOME")
    private Short firstHalfScoreHome;
    @Column(name = "FIRST_HALF_SCORE_AWAY")
    private Short firstHalfScoreAway;
    @Column(name = "FULL_TIME_SCORE_HOME")
    private Short fullTimeScoreHome;
    @Column(name = "FULL_TIME_SCORE_AWAY")
    private Short fullTimeScoreAway;
    @Column(name = "STATUS")
    private String status;
    @Column(name = "REFEREE")
    private String referee;
    @Column(name = "ATTENDANCE")
    private BigInteger attendance;
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

    public Matches() {
    }

    public Matches(BigDecimal id) {
        this.id = id;
    }

    public Matches(BigDecimal id, BigInteger createBy, Date createDate, Date lastUpdateDate) {
        this.id = id;
        this.createBy = createBy;
        this.createDate = createDate;
        this.lastUpdateDate = lastUpdateDate;
    }

    public BigDecimal getId() {
        return id;
    }

    public void setId(BigDecimal id) {
        this.id = id;
    }

    public BigInteger getHomeTeamId() {
        return homeTeamId;
    }

    public void setHomeTeamId(BigInteger homeTeamId) {
        this.homeTeamId = homeTeamId;
    }

    public BigInteger getAwayTeamId() {
        return awayTeamId;
    }

    public void setAwayTeamId(BigInteger awayTeamId) {
        this.awayTeamId = awayTeamId;
    }

    public BigInteger getLeagueId() {
        return leagueId;
    }

    public void setLeagueId(BigInteger leagueId) {
        this.leagueId = leagueId;
    }

    public Date getMatchDate() {
        return matchDate;
    }

    public void setMatchDate(Date matchDate) {
        this.matchDate = matchDate;
    }

    public String getStadium() {
        return stadium;
    }

    public void setStadium(String stadium) {
        this.stadium = stadium;
    }

    public Short getFirstHalfScoreHome() {
        return firstHalfScoreHome;
    }

    public void setFirstHalfScoreHome(Short firstHalfScoreHome) {
        this.firstHalfScoreHome = firstHalfScoreHome;
    }

    public Short getFirstHalfScoreAway() {
        return firstHalfScoreAway;
    }

    public void setFirstHalfScoreAway(Short firstHalfScoreAway) {
        this.firstHalfScoreAway = firstHalfScoreAway;
    }

    public Short getFullTimeScoreHome() {
        return fullTimeScoreHome;
    }

    public void setFullTimeScoreHome(Short fullTimeScoreHome) {
        this.fullTimeScoreHome = fullTimeScoreHome;
    }

    public Short getFullTimeScoreAway() {
        return fullTimeScoreAway;
    }

    public void setFullTimeScoreAway(Short fullTimeScoreAway) {
        this.fullTimeScoreAway = fullTimeScoreAway;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getReferee() {
        return referee;
    }

    public void setReferee(String referee) {
        this.referee = referee;
    }

    public BigInteger getAttendance() {
        return attendance;
    }

    public void setAttendance(BigInteger attendance) {
        this.attendance = attendance;
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
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Matches)) {
            return false;
        }
        Matches other = (Matches) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.Matches[ id=" + id + " ]";
    }
    
}
