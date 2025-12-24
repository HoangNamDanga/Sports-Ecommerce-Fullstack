using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

public partial class HoangNamWebContext : DbContext
{
    public HoangNamWebContext()
    {
    }

    public HoangNamWebContext(DbContextOptions<HoangNamWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApproveLoginUser> ApproveLoginUsers { get; set; }

    public virtual DbSet<ApproveLoginUser24h> ApproveLoginUser24hs { get; set; }

    public virtual DbSet<AqInternetAgent> AqInternetAgents { get; set; }

    public virtual DbSet<AqInternetAgentPriv> AqInternetAgentPrivs { get; set; }

    public virtual DbSet<AqKeyShardMap> AqKeyShardMaps { get; set; }

    public virtual DbSet<AqQueue> AqQueues { get; set; }

    public virtual DbSet<AqQueueTable> AqQueueTables { get; set; }

    public virtual DbSet<AqSchedule> AqSchedules { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<BomDetail> BomDetails { get; set; }

    public virtual DbSet<BomHeader> BomHeaders { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<DhnCart> DhnCarts { get; set; }

    public virtual DbSet<DhnCartItem> DhnCartItems { get; set; }

    public virtual DbSet<DhnCategory> DhnCategories { get; set; }

    public virtual DbSet<DhnCompesationPromotion> DhnCompesationPromotions { get; set; }

    public virtual DbSet<DhnCompesationPromotionDetail> DhnCompesationPromotionDetails { get; set; }

    public virtual DbSet<DhnImportWarrantyDatum> DhnImportWarrantyData { get; set; }

    public virtual DbSet<DhnNewsArticle> DhnNewsArticles { get; set; }

    public virtual DbSet<DhnOrder> DhnOrders { get; set; }

    public virtual DbSet<DhnOrderItem> DhnOrderItems { get; set; }

    public virtual DbSet<DhnProduct> DhnProducts { get; set; }

    public virtual DbSet<DhnProductImage> DhnProductImages { get; set; }

    public virtual DbSet<DhnProductVariant> DhnProductVariants { get; set; }

    public virtual DbSet<DhnPromotion> DhnPromotions { get; set; }

    public virtual DbSet<DhnStore> DhnStores { get; set; }

    public virtual DbSet<FaAddition> FaAdditions { get; set; }

    public virtual DbSet<FaAssigment> FaAssigments { get; set; }

    public virtual DbSet<FaBook> FaBooks { get; set; }

    public virtual DbSet<FeedbackSubmission> FeedbackSubmissions { get; set; }

    public virtual DbSet<Help> Helps { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<LiveScore> LiveScores { get; set; }

    public virtual DbSet<LogmnrAgeSpill> LogmnrAgeSpills { get; set; }

    public virtual DbSet<LogmnrAttrcol> LogmnrAttrcols { get; set; }

    public virtual DbSet<LogmnrAttribute> LogmnrAttributes { get; set; }

    public virtual DbSet<LogmnrCcol> LogmnrCcols { get; set; }

    public virtual DbSet<LogmnrCdef> LogmnrCdefs { get; set; }

    public virtual DbSet<LogmnrCol> LogmnrCols { get; set; }

    public virtual DbSet<LogmnrColtype> LogmnrColtypes { get; set; }

    public virtual DbSet<LogmnrCon> LogmnrCons { get; set; }

    public virtual DbSet<LogmnrContainer> LogmnrContainers { get; set; }

    public virtual DbSet<LogmnrDictionary> LogmnrDictionaries { get; set; }

    public virtual DbSet<LogmnrDictstate> LogmnrDictstates { get; set; }

    public virtual DbSet<LogmnrDid> LogmnrDids { get; set; }

    public virtual DbSet<LogmnrEnc> LogmnrEncs { get; set; }

    public virtual DbSet<LogmnrError> LogmnrErrors { get; set; }

    public virtual DbSet<LogmnrFilter> LogmnrFilters { get; set; }

    public virtual DbSet<LogmnrGlobal> LogmnrGlobals { get; set; }

    public virtual DbSet<LogmnrGtTabInclude> LogmnrGtTabIncludes { get; set; }

    public virtual DbSet<LogmnrGtUserInclude> LogmnrGtUserIncludes { get; set; }

    public virtual DbSet<LogmnrGtXidInclude> LogmnrGtXidIncludes { get; set; }

    public virtual DbSet<LogmnrIcol> LogmnrIcols { get; set; }

    public virtual DbSet<LogmnrIdnseq> LogmnrIdnseqs { get; set; }

    public virtual DbSet<LogmnrInd> LogmnrInds { get; set; }

    public virtual DbSet<LogmnrIndcompart> LogmnrIndcomparts { get; set; }

    public virtual DbSet<LogmnrIndpart> LogmnrIndparts { get; set; }

    public virtual DbSet<LogmnrIndsubpart> LogmnrIndsubparts { get; set; }

    public virtual DbSet<LogmnrKopm> LogmnrKopms { get; set; }

    public virtual DbSet<LogmnrLob> LogmnrLobs { get; set; }

    public virtual DbSet<LogmnrLobfrag> LogmnrLobfrags { get; set; }

    public virtual DbSet<LogmnrLog> LogmnrLogs { get; set; }

    public virtual DbSet<LogmnrLogmnrBuildlog> LogmnrLogmnrBuildlogs { get; set; }

    public virtual DbSet<LogmnrNtab> LogmnrNtabs { get; set; }

    public virtual DbSet<LogmnrObj> LogmnrObjs { get; set; }

    public virtual DbSet<LogmnrOpqtype> LogmnrOpqtypes { get; set; }

    public virtual DbSet<LogmnrParameter> LogmnrParameters { get; set; }

    public virtual DbSet<LogmnrPartobj> LogmnrPartobjs { get; set; }

    public virtual DbSet<LogmnrPdbInfo> LogmnrPdbInfos { get; set; }

    public virtual DbSet<LogmnrProcessedLog> LogmnrProcessedLogs { get; set; }

    public virtual DbSet<LogmnrProfilePlsqlStat> LogmnrProfilePlsqlStats { get; set; }

    public virtual DbSet<LogmnrProfileTableStat> LogmnrProfileTableStats { get; set; }

    public virtual DbSet<LogmnrProp> LogmnrProps { get; set; }

    public virtual DbSet<LogmnrRefcon> LogmnrRefcons { get; set; }

    public virtual DbSet<LogmnrRestartCkpt> LogmnrRestartCkpts { get; set; }

    public virtual DbSet<LogmnrRestartCkptTxinfo> LogmnrRestartCkptTxinfos { get; set; }

    public virtual DbSet<LogmnrSeed> LogmnrSeeds { get; set; }

    public virtual DbSet<LogmnrSession> LogmnrSessions { get; set; }

    public virtual DbSet<LogmnrSessionAction> LogmnrSessionActions { get; set; }

    public virtual DbSet<LogmnrSessionEvolve> LogmnrSessionEvolves { get; set; }

    public virtual DbSet<LogmnrShardT> LogmnrShardTs { get; set; }

    public virtual DbSet<LogmnrSpill> LogmnrSpills { get; set; }

    public virtual DbSet<LogmnrSubcoltype> LogmnrSubcoltypes { get; set; }

    public virtual DbSet<LogmnrT> LogmnrTs { get; set; }

    public virtual DbSet<LogmnrTab> LogmnrTabs { get; set; }

    public virtual DbSet<LogmnrTabcompart> LogmnrTabcomparts { get; set; }

    public virtual DbSet<LogmnrTabpart> LogmnrTabparts { get; set; }

    public virtual DbSet<LogmnrTabsubpart> LogmnrTabsubparts { get; set; }

    public virtual DbSet<LogmnrType> LogmnrTypes { get; set; }

    public virtual DbSet<LogmnrUid> LogmnrUids { get; set; }

    public virtual DbSet<LogmnrUser> LogmnrUsers { get; set; }

    public virtual DbSet<LogmnrcConGg> LogmnrcConGgs { get; set; }

    public virtual DbSet<LogmnrcConcolGg> LogmnrcConcolGgs { get; set; }

    public virtual DbSet<LogmnrcDbnameUidMap> LogmnrcDbnameUidMaps { get; set; }

    public virtual DbSet<LogmnrcGsba> LogmnrcGsbas { get; set; }

    public virtual DbSet<LogmnrcGsii> LogmnrcGsiis { get; set; }

    public virtual DbSet<LogmnrcGtc> LogmnrcGtcs { get; set; }

    public virtual DbSet<LogmnrcGtlo> LogmnrcGtlos { get; set; }

    public virtual DbSet<LogmnrcIndGg> LogmnrcIndGgs { get; set; }

    public virtual DbSet<LogmnrcIndcolGg> LogmnrcIndcolGgs { get; set; }

    public virtual DbSet<LogmnrcSeqGg> LogmnrcSeqGgs { get; set; }

    public virtual DbSet<LogmnrcShardT> LogmnrcShardTs { get; set; }

    public virtual DbSet<LogmnrcT> LogmnrcTs { get; set; }

    public virtual DbSet<LogmnrcTspart> LogmnrcTsparts { get; set; }

    public virtual DbSet<LogmnrcUser> LogmnrcUsers { get; set; }

    public virtual DbSet<LogmnrggcGtc> LogmnrggcGtcs { get; set; }

    public virtual DbSet<LogmnrggcGtlo> LogmnrggcGtlos { get; set; }

    public virtual DbSet<LogmnrpCtasPartMap> LogmnrpCtasPartMaps { get; set; }

    public virtual DbSet<LogmnrtMddl> LogmnrtMddls { get; set; }

    public virtual DbSet<LogstdbyApplyMilestone> LogstdbyApplyMilestones { get; set; }

    public virtual DbSet<LogstdbyApplyProgress> LogstdbyApplyProgresses { get; set; }

    public virtual DbSet<LogstdbyEdsTable> LogstdbyEdsTables { get; set; }

    public virtual DbSet<LogstdbyEvent> LogstdbyEvents { get; set; }

    public virtual DbSet<LogstdbyFlashbackScn> LogstdbyFlashbackScns { get; set; }

    public virtual DbSet<LogstdbyHistory> LogstdbyHistories { get; set; }

    public virtual DbSet<LogstdbyParameter> LogstdbyParameters { get; set; }

    public virtual DbSet<LogstdbyPlsql> LogstdbyPlsqls { get; set; }

    public virtual DbSet<LogstdbyScn> LogstdbyScns { get; set; }

    public virtual DbSet<LogstdbySkip> LogstdbySkips { get; set; }

    public virtual DbSet<LogstdbySkipSupport> LogstdbySkipSupports { get; set; }

    public virtual DbSet<LogstdbySkipTransaction> LogstdbySkipTransactions { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchEvent> MatchEvents { get; set; }

    public virtual DbSet<MatchLineup> MatchLineups { get; set; }

    public virtual DbSet<MfgDetail> MfgDetails { get; set; }

    public virtual DbSet<MfgHeader> MfgHeaders { get; set; }

    public virtual DbSet<MfgRouting> MfgRoutings { get; set; }

    public virtual DbSet<MviewAdvAjg> MviewAdvAjgs { get; set; }

    public virtual DbSet<MviewAdvBasetable> MviewAdvBasetables { get; set; }

    public virtual DbSet<MviewAdvClique> MviewAdvCliques { get; set; }

    public virtual DbSet<MviewAdvEligible> MviewAdvEligibles { get; set; }

    public virtual DbSet<MviewAdvException> MviewAdvExceptions { get; set; }

    public virtual DbSet<MviewAdvFilter> MviewAdvFilters { get; set; }

    public virtual DbSet<MviewAdvFilterinstance> MviewAdvFilterinstances { get; set; }

    public virtual DbSet<MviewAdvFjg> MviewAdvFjgs { get; set; }

    public virtual DbSet<MviewAdvGc> MviewAdvGcs { get; set; }

    public virtual DbSet<MviewAdvInfo> MviewAdvInfos { get; set; }

    public virtual DbSet<MviewAdvJournal> MviewAdvJournals { get; set; }

    public virtual DbSet<MviewAdvLevel> MviewAdvLevels { get; set; }

    public virtual DbSet<MviewAdvLog> MviewAdvLogs { get; set; }

    public virtual DbSet<MviewAdvOutput> MviewAdvOutputs { get; set; }

    public virtual DbSet<MviewAdvParameter> MviewAdvParameters { get; set; }

    public virtual DbSet<MviewAdvPlan> MviewAdvPlans { get; set; }

    public virtual DbSet<MviewAdvPretty> MviewAdvPretties { get; set; }

    public virtual DbSet<MviewAdvRollup> MviewAdvRollups { get; set; }

    public virtual DbSet<MviewAdvSqldepend> MviewAdvSqldepends { get; set; }

    public virtual DbSet<MviewAdvTemp> MviewAdvTemps { get; set; }

    public virtual DbSet<MviewAdvWorkload> MviewAdvWorkloads { get; set; }

    public virtual DbSet<MviewEvaluation> MviewEvaluations { get; set; }

    public virtual DbSet<MviewException> MviewExceptions { get; set; }

    public virtual DbSet<MviewFilter> MviewFilters { get; set; }

    public virtual DbSet<MviewFilterinstance> MviewFilterinstances { get; set; }

    public virtual DbSet<MviewLog> MviewLogs { get; set; }

    public virtual DbSet<MviewRecommendation> MviewRecommendations { get; set; }

    public virtual DbSet<MviewWorkload> MviewWorkloads { get; set; }

    public virtual DbSet<Ol> Ols { get; set; }

    public virtual DbSet<OlHint> OlHints { get; set; }

    public virtual DbSet<OlNode> OlNodes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerMatchStat> PlayerMatchStats { get; set; }

    public virtual DbSet<PremierLeagueStanding> PremierLeagueStandings { get; set; }

    public virtual DbSet<ProductPriv> ProductPrivs { get; set; }

    public virtual DbSet<RedoDb> RedoDbs { get; set; }

    public virtual DbSet<RedoLog> RedoLogs { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<RelatedArticle> RelatedArticles { get; set; }

    public virtual DbSet<ReplSupportMatrix> ReplSupportMatrices { get; set; }

    public virtual DbSet<ReplValidCompat> ReplValidCompats { get; set; }

    public virtual DbSet<RollingConnection> RollingConnections { get; set; }

    public virtual DbSet<RollingDatabase> RollingDatabases { get; set; }

    public virtual DbSet<RollingDirective> RollingDirectives { get; set; }

    public virtual DbSet<RollingEvent> RollingEvents { get; set; }

    public virtual DbSet<RollingParameter> RollingParameters { get; set; }

    public virtual DbSet<RollingPlan> RollingPlans { get; set; }

    public virtual DbSet<RollingStatistic> RollingStatistics { get; set; }

    public virtual DbSet<RollingStatus> RollingStatuses { get; set; }

    public virtual DbSet<SchedulerJobArg> SchedulerJobArgs { get; set; }

    public virtual DbSet<SchedulerJobArgsTbl> SchedulerJobArgsTbls { get; set; }

    public virtual DbSet<SchedulerProgramArg> SchedulerProgramArgs { get; set; }

    public virtual DbSet<SchedulerProgramArgsTbl> SchedulerProgramArgsTbls { get; set; }

    public virtual DbSet<SqlplusProductProfile> SqlplusProductProfiles { get; set; }

    public virtual DbSet<TblEmployeeCheckInApp> TblEmployeeCheckInApps { get; set; }

    public virtual DbSet<TblEmployeeCheckOut> TblEmployeeCheckOuts { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<User24h> User24hs { get; set; }

    public virtual DbSet<UserAuditlog24h> UserAuditlog24hs { get; set; }

    public virtual DbSet<UserDepartment> UserDepartments { get; set; }

    public virtual DbSet<UserInventory> UserInventories { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=system;Password=123456;Data Source=//localhost:1521/orcl21pdb1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<ApproveLoginUser>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Islogin).HasDefaultValueSql("0");
            entity.Property(e => e.Islogout).HasDefaultValueSql("0");

            entity.HasOne(d => d.User).WithMany(p => p.ApproveLoginUsers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_APPROVE_LOGIN_USERS_USER");
        });

        modelBuilder.Entity<ApproveLoginUser24h>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008310");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<AqInternetAgent>(entity =>
        {
            entity.HasKey(e => e.AgentName).HasName("SYS_C002559");
        });

        modelBuilder.Entity<AqInternetAgentPriv>(entity =>
        {
            entity.HasOne(d => d.AgentNameNavigation).WithMany().HasConstraintName("AGENT_MUST_BE_CREATED");
        });

        modelBuilder.Entity<AqQueue>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("AQ$_QUEUES_PRIMARY");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.BaseQueue).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<AqQueueTable>(entity =>
        {
            entity.HasKey(e => e.Objno).HasName("AQ$_QUEUE_TABLES_PRIMARY");
        });

        modelBuilder.Entity<AqSchedule>(entity =>
        {
            entity.HasKey(e => new { e.Oid, e.Destination }).HasName("AQ$_SCHEDULES_PRIMARY");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008351");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<BomDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BOM_DETAILS_PK");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<BomHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008254");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008356");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008371");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008461");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Status).HasDefaultValueSql("'ACTIVE'");
            entity.Property(e => e.TotalAmount).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<DhnCartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008468");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Quantity).HasDefaultValueSql("1");

            entity.HasOne(d => d.Cart).WithMany(p => p.DhnCartItems).HasConstraintName("FK_CART_ITEMS_CART");

            entity.HasOne(d => d.Product).WithMany(p => p.DhnCartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CART_ITEMS_PRODUCT");
        });

        modelBuilder.Entity<DhnCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008426");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnCompesationPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008306");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnCompesationPromotionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008301");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnImportWarrantyDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008296");
        });

        modelBuilder.Entity<DhnNewsArticle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008445");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Views).HasDefaultValueSql("0");

            entity.HasOne(d => d.Product).WithMany(p => p.DhnNewsArticles).HasConstraintName("FK_NEWS_PRODUCT");
        });

        modelBuilder.Entity<DhnOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008433");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.OrderStatus).HasDefaultValueSql("'Pending'");
        });

        modelBuilder.Entity<DhnOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008441");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008416");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.StockQuantity).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<DhnProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008421");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.IsThumbnail).HasDefaultValueSql("'N'");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");

            entity.HasOne(d => d.Product).WithMany(p => p.DhnProductImages).HasConstraintName("FK_IMAGES_PRODUCT");
        });

        modelBuilder.Entity<DhnProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008429");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AdditionalPrice).HasDefaultValueSql("0");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE -- Ngày cập nhật cuối\n");

            entity.HasOne(d => d.Product).WithMany(p => p.DhnProductVariants).HasConstraintName("FK_VARIANTS_PRODUCT");
        });

        modelBuilder.Entity<DhnPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008453");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<DhnStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008449");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<FaAddition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008284");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<FaAssigment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008294");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.TransferDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<FaBook>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("SYS_C008273");

            entity.Property(e => e.AssetId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<FeedbackSubmission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008411");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Status).HasDefaultValueSql("'New'");
        });

        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => new { e.Topic, e.Seq }).HasName("HELP_TOPIC_SEQ");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008336");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<LiveScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008376");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AwayScore).HasDefaultValueSql("0");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.HomeScore).HasDefaultValueSql("0");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<LogmnrAgeSpill>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.Pdbid, e.Xidusn, e.Xidslt, e.Xidsqn, e.Chunk, e.Sequence }).HasName("LOGMNR_AGE_SPILL$_PK");
        });

        modelBuilder.Entity<LogmnrAttrcol>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_ATTRCOL$_PK");
        });

        modelBuilder.Entity<LogmnrAttribute>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Toid, e.Version, e.Attribute }).HasName("LOGMNR_ATTRIBUTE$_PK");
        });

        modelBuilder.Entity<LogmnrCcol>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Con, e.Intcol }).HasName("LOGMNR_CCOL$_PK");
        });

        modelBuilder.Entity<LogmnrCdef>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Con }).HasName("LOGMNR_CDEF$_PK");
        });

        modelBuilder.Entity<LogmnrCol>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_COL$_PK");
        });

        modelBuilder.Entity<LogmnrColtype>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_COLTYPE$_PK");
        });

        modelBuilder.Entity<LogmnrCon>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Con }).HasName("LOGMNR_CON$_PK");
        });

        modelBuilder.Entity<LogmnrContainer>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_CONTAINER$_PK");
        });

        modelBuilder.Entity<LogmnrDictionary>(entity =>
        {
            entity.HasKey(e => e.LogmnrUid).HasName("LOGMNR_DICTIONARY$_PK");
        });

        modelBuilder.Entity<LogmnrDictstate>(entity =>
        {
            entity.HasKey(e => e.LogmnrUid).HasName("LOGMNR_DICTSTATE$_PK");
        });

        modelBuilder.Entity<LogmnrDid>(entity =>
        {
            entity.HasKey(e => e.Session).HasName("LOGMNR_DID$_PK");

            entity.Property(e => e.Flags).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<LogmnrEnc>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Owner }).HasName("LOGMNR_ENC$_PK");
        });

        modelBuilder.Entity<LogmnrIcol>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_ICOL$_PK");
        });

        modelBuilder.Entity<LogmnrIdnseq>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_IDNSEQ$_PK");
        });

        modelBuilder.Entity<LogmnrInd>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_IND$_PK");
        });

        modelBuilder.Entity<LogmnrIndcompart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_INDCOMPART$_PK");
        });

        modelBuilder.Entity<LogmnrIndpart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Bo }).HasName("LOGMNR_INDPART$_PK");
        });

        modelBuilder.Entity<LogmnrIndsubpart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Pobj }).HasName("LOGMNR_INDSUBPART$_PK");
        });

        modelBuilder.Entity<LogmnrKopm>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Name }).HasName("LOGMNR_KOPM$_PK");
        });

        modelBuilder.Entity<LogmnrLob>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_LOB$_PK");
        });

        modelBuilder.Entity<LogmnrLobfrag>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Fragobj }).HasName("LOGMNR_LOBFRAG$_PK");
        });

        modelBuilder.Entity<LogmnrLog>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.Thread, e.Sequence, e.FirstChange, e.DbId, e.ResetlogsChange, e.ResetTimestamp }).HasName("LOGMNR_LOG$_PK");
        });

        modelBuilder.Entity<LogmnrLogmnrBuildlog>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.InitialXid }).HasName("LOGMNR_LOGMNR_BUILDLOG_PK");
        });

        modelBuilder.Entity<LogmnrNtab>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_NTAB$_PK");
        });

        modelBuilder.Entity<LogmnrObj>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_OBJ$_PK");
        });

        modelBuilder.Entity<LogmnrOpqtype>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_OPQTYPE$_PK");
        });

        modelBuilder.Entity<LogmnrPartobj>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_PARTOBJ$_PK");
        });

        modelBuilder.Entity<LogmnrPdbInfo>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrDid, e.LogmnrMdh, e.PluginScn }).HasName("LOGMNR_PDB_INFO$_PK");
        });

        modelBuilder.Entity<LogmnrProcessedLog>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.Thread }).HasName("LOGMNR_PROCESSED_LOG$_PK");
        });

        modelBuilder.Entity<LogmnrProfilePlsqlStat>(entity =>
        {
            entity.HasKey(e => new { e.Pkgowner, e.Pkgname, e.Name }).HasName("LOGMNR_PROFILE_PLSQL$_PK");
        });

        modelBuilder.Entity<LogmnrProfileTableStat>(entity =>
        {
            entity.HasKey(e => e.Objid).HasName("LOGMNR_PROFILE_TABLE$_PK");
        });

        modelBuilder.Entity<LogmnrProp>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Name }).HasName("LOGMNR_PROPS$_PK");
        });

        modelBuilder.Entity<LogmnrRefcon>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_REFCON$_PK");
        });

        modelBuilder.Entity<LogmnrRestartCkpt>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.CkptScn, e.Xidusn, e.Xidslt, e.Xidsqn, e.Pdbid, e.SessionNum, e.SerialNum }).HasName("LOGMNR_RESTART_CKPT$_PK");
        });

        modelBuilder.Entity<LogmnrRestartCkptTxinfo>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.Xidusn, e.Xidslt, e.Xidsqn, e.SessionNum, e.SerialNum, e.EffectiveScn }).HasName("LOGMNR_RESTART_CKPT_TXINFO$_PK");
        });

        modelBuilder.Entity<LogmnrSeed>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol }).HasName("LOGMNR_SEED$_PK");
        });

        modelBuilder.Entity<LogmnrSession>(entity =>
        {
            entity.HasKey(e => e.Session).HasName("LOGMNR_SESSION_PK");

            entity.Property(e => e.GlobalDbName).HasDefaultValueSql("null");
        });

        modelBuilder.Entity<LogmnrSessionAction>(entity =>
        {
            entity.HasKey(e => new { e.Logmnrsession, e.Actionname }).HasName("LOGMNR_SESSION_ACTION$_PK");

            entity.Property(e => e.Flagsruntime).HasDefaultValueSql("0");
            entity.Property(e => e.Lcrcount).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<LogmnrSessionEvolve>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.DbId, e.ResetScn, e.ResetTimestamp }).HasName("LOGMNR_SESSION_EVOLVE$_PK");
        });

        modelBuilder.Entity<LogmnrShardT>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.TablespaceName }).HasName("LOGMNR_SHARD_TS_PK");
        });

        modelBuilder.Entity<LogmnrSpill>(entity =>
        {
            entity.HasKey(e => new { e.Session, e.Pdbid, e.Xidusn, e.Xidslt, e.Xidsqn, e.Chunk, e.Startidx, e.Endidx, e.Flag, e.Sequence }).HasName("LOGMNR_SPILL$_PK");
        });

        modelBuilder.Entity<LogmnrSubcoltype>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Intcol, e.Toid }).HasName("LOGMNR_SUBCOLTYPE$_PK");
        });

        modelBuilder.Entity<LogmnrT>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Ts }).HasName("LOGMNR_TS$_PK");
        });

        modelBuilder.Entity<LogmnrTab>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_TAB$_PK");
        });

        modelBuilder.Entity<LogmnrTabcompart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNR_TABCOMPART$_PK");
        });

        modelBuilder.Entity<LogmnrTabpart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Bo }).HasName("LOGMNR_TABPART$_PK");
        });

        modelBuilder.Entity<LogmnrTabsubpart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Pobj }).HasName("LOGMNR_TABSUBPART$_PK");
        });

        modelBuilder.Entity<LogmnrType>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Toid, e.Version }).HasName("LOGMNR_TYPE$_PK");
        });

        modelBuilder.Entity<LogmnrUid>(entity =>
        {
            entity.HasKey(e => e.LogmnrUid1).HasName("LOGMNR_UID$_PK");
        });

        modelBuilder.Entity<LogmnrUser>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.User }).HasName("LOGMNR_USER$_PK");
        });

        modelBuilder.Entity<LogmnrcConGg>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Con, e.CommitScn }).HasName("LOGMNRC_CON_GG_PK");
        });

        modelBuilder.Entity<LogmnrcConcolGg>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Con, e.CommitScn, e.Intcol }).HasName("LOGMNRC_CONCOL_GG_PK");
        });

        modelBuilder.Entity<LogmnrcDbnameUidMap>(entity =>
        {
            entity.HasKey(e => new { e.GlobalName, e.LogmnrMdh }).HasName("LOGMNRC_DBNAME_UID_MAP_PK");
        });

        modelBuilder.Entity<LogmnrcGsba>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.AsOfScn }).HasName("LOGMNRC_GSBA_PK");
        });

        modelBuilder.Entity<LogmnrcGsii>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj }).HasName("LOGMNRC_GSII_PK");
        });

        modelBuilder.Entity<LogmnrcGtc>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Objv, e.Intcol }).HasName("LOGMNRC_GTCS_PK");
        });

        modelBuilder.Entity<LogmnrcGtlo>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Keyobj, e.Baseobjv }).HasName("LOGMNRC_GTLO_PK");
        });

        modelBuilder.Entity<LogmnrcIndGg>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.CommitScn }).HasName("LOGMNRC_IND_GG_PK");
        });

        modelBuilder.Entity<LogmnrcIndcolGg>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.CommitScn, e.Intcol }).HasName("LOGMNRC_INDCOL_GG_PK");
        });

        modelBuilder.Entity<LogmnrcSeqGg>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.CommitScn }).HasName("LOGMNRC_SEQ_GG_PK");
        });

        modelBuilder.Entity<LogmnrcShardT>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.TablespaceName, e.StartScn }).HasName("LOGMNRC_SHARD_TS_PK");
        });

        modelBuilder.Entity<LogmnrcT>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Ts, e.StartScn }).HasName("LOGMNRC_TS_PK");
        });

        modelBuilder.Entity<LogmnrcTspart>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.StartScn }).HasName("LOGMNRC_TSPART_PK");
        });

        modelBuilder.Entity<LogmnrcUser>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.User, e.StartScn }).HasName("LOGMNRC_USER_PK");
        });

        modelBuilder.Entity<LogmnrggcGtc>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Obj, e.Objv, e.Intcol }).HasName("LOGMNRGGC_GTCS_PK");
        });

        modelBuilder.Entity<LogmnrggcGtlo>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Keyobj, e.Baseobjv }).HasName("LOGMNRGGC_GTLO_PK");
        });

        modelBuilder.Entity<LogmnrpCtasPartMap>(entity =>
        {
            entity.HasKey(e => new { e.LogmnrUid, e.Baseobjv, e.Keyobj }).HasName("LOGMNRP_CTAS_PART_MAP_PK");
        });

        modelBuilder.Entity<LogmnrtMddl>(entity =>
        {
            entity.HasKey(e => new { e.SourceObj, e.SourceRowid }).HasName("LOGMNRT_MDDL$_PK");
        });

        modelBuilder.Entity<LogstdbyApplyMilestone>(entity =>
        {
            entity.Property(e => e.FetchlwmScn).HasDefaultValueSql("(0) ");
        });

        modelBuilder.Entity<LogstdbyEdsTable>(entity =>
        {
            entity.HasKey(e => new { e.Owner, e.TableName }).HasName("LOGSTDBY$EDS_TABLES_PKEY");
        });

        modelBuilder.Entity<LogstdbyFlashbackScn>(entity =>
        {
            entity.HasKey(e => e.PrimaryScn).HasName("SYS_C005845");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008341");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<MatchEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008346");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<MatchLineup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008406");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<MfgDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008229");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MfgHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008224");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MfgRouting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008245");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.StartTime).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<MviewAdvAjg>(entity =>
        {
            entity.HasKey(e => e.Ajgid).HasName("MVIEW$_ADV_AJG_PK");

            entity.ToTable("MVIEW$_ADV_AJG", tb => tb.HasComment("Anchor-join graph representation"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvAjgs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_AJG_FK");
        });

        modelBuilder.Entity<MviewAdvBasetable>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_BASETABLE", tb => tb.HasComment("Base tables refered by a query"));

            entity.HasOne(d => d.Query).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_BASETABLE_FK");
        });

        modelBuilder.Entity<MviewAdvClique>(entity =>
        {
            entity.HasKey(e => e.Cliqueid).HasName("MVIEW$_ADV_CLIQUE_PK");

            entity.ToTable("MVIEW$_ADV_CLIQUE", tb => tb.HasComment("Table for storing canonical form of Clique queries"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvCliques)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_CLIQUE_FK");
        });

        modelBuilder.Entity<MviewAdvEligible>(entity =>
        {
            entity.HasKey(e => new { e.Sumobjn, e.Runid }).HasName("MVIEW$_ADV_ELIGIBLE_PK");

            entity.ToTable("MVIEW$_ADV_ELIGIBLE", tb => tb.HasComment("Summary management rewrite eligibility information"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvEligibles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_ELIGIBLE_FK");
        });

        modelBuilder.Entity<MviewAdvException>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_EXCEPTIONS", tb => tb.HasComment("Output table for dimension validations"));

            entity.HasOne(d => d.Run).WithMany().HasConstraintName("MVIEW$_ADV_EXCEPTION_FK");
        });

        modelBuilder.Entity<MviewAdvFilter>(entity =>
        {
            entity.HasKey(e => new { e.Filterid, e.Subfilternum }).HasName("MVIEW$_ADV_FILTER_PK");

            entity.ToTable("MVIEW$_ADV_FILTER", tb => tb.HasComment("Table for workload filter definition"));
        });

        modelBuilder.Entity<MviewAdvFilterinstance>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_FILTERINSTANCE", tb => tb.HasComment("Table for workload filter instance definition"));

            entity.HasOne(d => d.Run).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_FILTERINSTANCE_FK");
        });

        modelBuilder.Entity<MviewAdvFjg>(entity =>
        {
            entity.HasKey(e => e.Fjgid).HasName("MVIEW$_ADV_FJG_PK");

            entity.ToTable("MVIEW$_ADV_FJG", tb => tb.HasComment("Representation for query join sub-graph not in AJG "));

            entity.HasOne(d => d.Ajg).WithMany(p => p.MviewAdvFjgs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_FJG_FK");
        });

        modelBuilder.Entity<MviewAdvGc>(entity =>
        {
            entity.HasKey(e => e.Gcid).HasName("MVIEW$_ADV_GC_PK");

            entity.ToTable("MVIEW$_ADV_GC", tb => tb.HasComment("Group-by columns of a query"));

            entity.HasOne(d => d.Fjg).WithMany(p => p.MviewAdvGcs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_GC_FK");
        });

        modelBuilder.Entity<MviewAdvInfo>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.Seq }).HasName("MVIEW$_ADV_INFO_PK");

            entity.ToTable("MVIEW$_ADV_INFO", tb => tb.HasComment("Internal table for passing information from the SQL analyzer"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_INFO_FK");
        });

        modelBuilder.Entity<MviewAdvJournal>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.Seq }).HasName("MVIEW$_ADV_JOURNAL_PK");

            entity.ToTable("MVIEW$_ADV_JOURNAL", tb => tb.HasComment("Summary advisor journal table for debugging and information"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvJournals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_JOURNAL_FK");
        });

        modelBuilder.Entity<MviewAdvLevel>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.Levelid }).HasName("MVIEW$_ADV_LEVEL_PK");

            entity.ToTable("MVIEW$_ADV_LEVEL", tb => tb.HasComment("Level definition"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvLevels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_LEVEL_FK");
        });

        modelBuilder.Entity<MviewAdvLog>(entity =>
        {
            entity.HasKey(e => e.Runid).HasName("MVIEW$_ADV_LOG_PK");

            entity.ToTable("MVIEW$_ADV_LOG", tb => tb.HasComment("Log all calls to summary advisory functions"));
        });

        modelBuilder.Entity<MviewAdvOutput>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.Rank }).HasName("MVIEW$_ADV_OUTPUT_PK");

            entity.ToTable("MVIEW$_ADV_OUTPUT", tb => tb.HasComment("Output table for summary recommendations and evaluations"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvOutputs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_OUTPUT_FK");
        });

        modelBuilder.Entity<MviewAdvParameter>(entity =>
        {
            entity.HasKey(e => e.ParameterName).HasName("MVIEW$_ADV_PARAMETERS_PK");

            entity.ToTable("MVIEW$_ADV_PARAMETERS", tb => tb.HasComment("Summary advisor tuning parameters"));
        });

        modelBuilder.Entity<MviewAdvPlan>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_PLAN", tb => tb.HasComment("Private plan table for estimate_mview_size operations"));
        });

        modelBuilder.Entity<MviewAdvPretty>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_PRETTY", tb => tb.HasComment("Table for sql parsing"));
        });

        modelBuilder.Entity<MviewAdvRollup>(entity =>
        {
            entity.HasKey(e => new { e.Runid, e.Clevelid, e.Plevelid }).HasName("MVIEW$_ADV_ROLLUP_PK");

            entity.ToTable("MVIEW$_ADV_ROLLUP", tb => tb.HasComment("Each row repesents either a functional dependency or join-key relationship"));

            entity.HasOne(d => d.Run).WithMany(p => p.MviewAdvRollups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_ROLLUP_FK");

            entity.HasOne(d => d.MviewAdvLevel).WithMany(p => p.MviewAdvRollupMviewAdvLevels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_ROLLUP_CFK");

            entity.HasOne(d => d.MviewAdvLevelNavigation).WithMany(p => p.MviewAdvRollupMviewAdvLevelNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MVIEW$_ADV_ROLLUP_PFK");
        });

        modelBuilder.Entity<MviewAdvSqldepend>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_SQLDEPEND", tb => tb.HasComment("Temporary table for workload collections"));
        });

        modelBuilder.Entity<MviewAdvTemp>(entity =>
        {
            entity.ToTable("MVIEW$_ADV_TEMP", tb => tb.HasComment("Table for temporary data"));
        });

        modelBuilder.Entity<MviewAdvWorkload>(entity =>
        {
            entity.HasKey(e => e.Queryid).HasName("MVIEW$_ADV_WORKLOAD_PK");

            entity.ToTable("MVIEW$_ADV_WORKLOAD", tb => tb.HasComment("Shared workload repository for DBA users of summary advisor"));
        });

        modelBuilder.Entity<MviewEvaluation>(entity =>
        {
            entity.ToView("MVIEW_EVALUATIONS");
        });

        modelBuilder.Entity<MviewException>(entity =>
        {
            entity.ToView("MVIEW_EXCEPTIONS");
        });

        modelBuilder.Entity<MviewFilter>(entity =>
        {
            entity.ToView("MVIEW_FILTER");
        });

        modelBuilder.Entity<MviewFilterinstance>(entity =>
        {
            entity.ToView("MVIEW_FILTERINSTANCE");
        });

        modelBuilder.Entity<MviewLog>(entity =>
        {
            entity.ToView("MVIEW_LOG");
        });

        modelBuilder.Entity<MviewRecommendation>(entity =>
        {
            entity.ToView("MVIEW_RECOMMENDATIONS");
        });

        modelBuilder.Entity<MviewWorkload>(entity =>
        {
            entity.ToView("MVIEW_WORKLOAD");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008331");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<PlayerMatchStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008399");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Assists).HasDefaultValueSql("0");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Goals).HasDefaultValueSql("0");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.MinutesPlayed).HasDefaultValueSql("0");
            entity.Property(e => e.RedCards).HasDefaultValueSql("0");
            entity.Property(e => e.YellowCards).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<PremierLeagueStanding>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("SYS_C008393");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Draws).HasDefaultValueSql("0");
            entity.Property(e => e.GoalDifference).HasDefaultValueSql("0");
            entity.Property(e => e.GoalsAgainst).HasDefaultValueSql("0");
            entity.Property(e => e.GoalsFor).HasDefaultValueSql("0");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.Losses).HasDefaultValueSql("0");
            entity.Property(e => e.MatchesPlayed).HasDefaultValueSql("0");
            entity.Property(e => e.Points).HasDefaultValueSql("0");
            entity.Property(e => e.Wins).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<ProductPriv>(entity =>
        {
            entity.ToView("PRODUCT_PRIVS");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008319");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.ExpiryDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<RelatedArticle>(entity =>
        {
            entity.HasKey(e => new { e.PrimaryArticleId, e.RelatedArticleId }).HasName("SYS_C008357");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.PrimaryArticle).WithMany(p => p.RelatedArticlePrimaryArticles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008358");

            entity.HasOne(d => d.RelatedArticleNavigation).WithMany(p => p.RelatedArticleRelatedArticleNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008359");
        });

        modelBuilder.Entity<ReplSupportMatrix>(entity =>
        {
            entity.HasKey(e => new { e.Bmap1, e.Bmap2, e.ReplProduct, e.SupportMode }).HasName("REPL_SUPPORT_MATRIX_PK");
        });

        modelBuilder.Entity<SchedulerJobArg>(entity =>
        {
            entity.ToView("SCHEDULER_JOB_ARGS");
        });

        modelBuilder.Entity<SchedulerProgramArg>(entity =>
        {
            entity.ToView("SCHEDULER_PROGRAM_ARGS");
        });

        modelBuilder.Entity<TblEmployeeCheckInApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008387");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CheckInTime).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<TblEmployeeCheckOut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008381");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008326");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Addgoogle).HasDefaultValueSql("0");
            entity.Property(e => e.Inactive).HasDefaultValueSql("0");
            entity.Property(e => e.Ondelete).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<User24h>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008308");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<UserAuditlog24h>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008313");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateBy).HasDefaultValueSql("'System'");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
        });

        modelBuilder.Entity<UserDepartment>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.UserDepartments).HasConstraintName("FK_USER_DEPARTMENTS_USER");
        });

        modelBuilder.Entity<UserInventory>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.UserInventories).HasConstraintName("FK_USER_INVENTORIES_USER");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008365");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.LastUpdateDate).HasDefaultValueSql("SYSDATE ");
            entity.Property(e => e.ViewCount).HasDefaultValueSql("0");
        });
        modelBuilder.HasSequence("AP_MFG_ROUTINGS_SEQ");
        modelBuilder.HasSequence("APPROVE_LOGIN_USER24H_SEQ");
        modelBuilder.HasSequence("ARTICLES_SEQ");
        modelBuilder.HasSequence("BOM_DETAILS_SEQ");
        modelBuilder.HasSequence("BOM_HEADERS_SEQ");
        modelBuilder.HasSequence("CATEGORIES_SEQ");
        modelBuilder.HasSequence("COMMENTS_SEQ");
        modelBuilder.HasSequence("DHN_CART_ITEMS_SEQ");
        modelBuilder.HasSequence("DHN_CARTS_SEQ");
        modelBuilder.HasSequence("DHN_CATEGORIES_SEQ");
        modelBuilder.HasSequence("DHN_COMPESATION_PROMOTION_DETAIL_SEQ");
        modelBuilder.HasSequence("DHN_COMPESATION_PROMOTION_SEQ");
        modelBuilder.HasSequence("DHN_IMPORT_WARRANTY_DATUM_SEQ");
        modelBuilder.HasSequence("DHN_NEWS_ARTICLES_SEQ");
        modelBuilder.HasSequence("DHN_ORDER_ITEMS_SEQ");
        modelBuilder.HasSequence("DHN_ORDERS_SEQ");
        modelBuilder.HasSequence("DHN_PRODUCT_IMAGE_SEQ");
        modelBuilder.HasSequence("DHN_PRODUCT_VARIANTS_SEQ");
        modelBuilder.HasSequence("DHN_PRODUCTS_SEQ");
        modelBuilder.HasSequence("DHN_PROMOTIONS_SEQ");
        modelBuilder.HasSequence("DHN_STORES_SEQ");
        modelBuilder.HasSequence("FA_ADDITIONS_SEQ");
        modelBuilder.HasSequence("FA_ASSIGMENTS_SEQ");
        modelBuilder.HasSequence("FA_BOOKS_SEQ");
        modelBuilder.HasSequence("FEEDBACK_SUBMISSIONS_SEQ");
        modelBuilder.HasSequence("LEAGUES_SEQ");
        modelBuilder.HasSequence("LIVE_SCORES_SEQ");
        modelBuilder.HasSequence("LOGMNR_DIDS$");
        modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");
        modelBuilder.HasSequence("LOGMNR_SEQ$");
        modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();
        modelBuilder.HasSequence("MATCH_EVENTS_SEQ");
        modelBuilder.HasSequence("MATCH_LINEUPS_SEQ");
        modelBuilder.HasSequence("MATCHES_DETAILS_SEQ");
        modelBuilder.HasSequence("MFG_DETAILS_SEQ");
        modelBuilder.HasSequence("MFG_HEADERS_SEQ");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");
        modelBuilder.HasSequence("PLAYER_MATCH_STATS_SEQ");
        modelBuilder.HasSequence("PLAYERS_SEQ");
        modelBuilder.HasSequence("PREMIER_LEAGUE_STANDINGS_SEQ");
        modelBuilder.HasSequence("REFRESH_TOKEN_SEQ");
        modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");
        modelBuilder.HasSequence("SEQ_APPROVE_LOGIN_USERS_ID");
        modelBuilder.HasSequence("SEQ_USERS_ID");
        modelBuilder.HasSequence("TBL_EMPLOYEE_CHECK_IN_APP_SEQ");
        modelBuilder.HasSequence("TBL_EMPLOYEE_CHECK_OUT_SEQ");
        modelBuilder.HasSequence("TEAMS_SEQ");
        modelBuilder.HasSequence("USER_AUDITLOG_24H_SEQ");
        modelBuilder.HasSequence("USER24H_SEQ");
        modelBuilder.HasSequence("VIDEOS_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
