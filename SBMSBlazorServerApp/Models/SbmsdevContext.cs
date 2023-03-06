using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace SBMSBlazorServerApp.Models;

public partial class SbmsdevContext : DbContext
{
    public SbmsdevContext()
    {
    }

    public SbmsdevContext(DbContextOptions<SbmsdevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdnPlanDtl> PdnPlanDtls { get; set; }

    public virtual DbSet<PdnPlanHdr> PdnPlanHdrs { get; set; }

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Get ConnectionString from appsettings.json
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("ERPConnection"));
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //optionsBuilder.UseSqlServer("Data Source=192.168.27.247;Initial Catalog=SBMSDEV;TrustServerCertificate=True;User Id=uds;Password=uds1q2w3e4r!@");
    }
    //        => optionsBuilder.UseSqlServer("Data Source=192.168.27.247;Initial Catalog=SBMSDEV;TrustServerCertificate=True;User Id=uds;Password=uds1q2w3e4r!@");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdnPlanDtl>(entity =>
        {
            entity.HasKey(e => new { e.WoNo, e.TbCd, e.PpVer, e.ProcSeq });

            entity.ToTable("PDN_PLAN_DTL");

            entity.Property(e => e.WoNo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasComment("EQ 번호")
                .HasColumnName("WO_NO");
            entity.Property(e => e.TbCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("EQ 버전")
                .HasColumnName("TB_CD");
            entity.Property(e => e.PpVer)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PP_VER");
            entity.Property(e => e.ProcSeq)
                .HasComment("공정 순서")
                .HasColumnName("PROC_SEQ");
            entity.Property(e => e.CrtnDt)
                .HasComment("등록일자")
                .HasColumnType("datetime")
                .HasColumnName("CRTN_DT");
            entity.Property(e => e.CrtrEmpno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("등록자 사번")
                .HasColumnName("CRTR_EMPNO");
            entity.Property(e => e.ProcCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("공정 코드")
                .HasColumnName("PROC_CD");
            entity.Property(e => e.SatWorkYn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("토요일 근무 여부")
                .HasColumnName("SAT_WORK_YN");
            entity.Property(e => e.UpdrEmpno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("수정자 사번")
                .HasColumnName("UPDR_EMPNO");
            entity.Property(e => e.UpdtDt)
                .HasComment("수정일자")
                .HasColumnType("datetime")
                .HasColumnName("UPDT_DT");
            entity.Property(e => e.WorkDdayDcnt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("작업일차일수")
                .HasColumnName("WORK_DDAY_DCNT");
            entity.Property(e => e.WorkDdays)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("작업 일자")
                .HasColumnName("WORK_DDAYS");
            entity.Property(e => e.WorkFrmDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("작업 시작일")
                .HasColumnName("WORK_FRM_DT");
            entity.Property(e => e.WorkToDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("작업 종료일")
                .HasColumnName("WORK_TO_DT");

            entity.HasOne(d => d.PdnPlanHdr).WithMany(p => p.PdnPlanDtls)
                .HasForeignKey(d => new { d.WoNo, d.TbCd, d.PpVer })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK01_PDN_PLAN_DTL");
        });

        modelBuilder.Entity<PdnPlanHdr>(entity =>
        {
            entity.HasKey(e => new { e.WoNo, e.TbCd, e.PpVer });

            entity.ToTable("PDN_PLAN_HDR");

            entity.Property(e => e.WoNo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasComment("WO 번호")
                .HasColumnName("WO_NO");
            entity.Property(e => e.TbCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("생산 구분")
                .HasColumnName("TB_CD");
            entity.Property(e => e.PpVer)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("생산계획 버전")
                .HasColumnName("PP_VER");
            entity.Property(e => e.BlockCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("블럭업체 드")
                .HasColumnName("BLOCK_CMPY_CD");
            entity.Property(e => e.CrtnDt)
                .HasDefaultValueSql("(getdate())")
                .HasComment("등록일자")
                .HasColumnType("datetime")
                .HasColumnName("CRTN_DT");
            entity.Property(e => e.CrtrEmpno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("등록자 사번")
                .HasColumnName("CRTR_EMPNO");
            entity.Property(e => e.CustCd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("고객 코드")
                .HasColumnName("CUST_CD");
            entity.Property(e => e.DueDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("출하 요청일")
                .HasColumnName("DUE_DT");
            entity.Property(e => e.ElecMtrlRcptDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("전장 자재 입고일자")
                .HasColumnName("ELEC_MTRL_RCPT_DT");
            entity.Property(e => e.ElecMtrlReqDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("전장 자재 불출 요청일")
                .HasColumnName("ELEC_MTRL_REQ_DT");
            entity.Property(e => e.ElecOdrCmplDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("전장 발주 완료일")
                .HasColumnName("ELEC_ODR_CMPL_DT");
            entity.Property(e => e.ElecPdnCmplDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("전장 생산 완료일자")
                .HasColumnName("ELEC_PDN_CMPL_DT");
            entity.Property(e => e.ElectricCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("전장업체 코드")
                .HasColumnName("ELECTRIC_CMPY_CD");
            entity.Property(e => e.EndUser)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasComment("최종  User")
                .HasColumnName("END_USER");
            entity.Property(e => e.EqNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasComment("EQ 번호")
                .HasColumnName("EQ_NO");
            entity.Property(e => e.ErpTransSttsCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("ERP 전송상태 코드")
                .HasColumnName("ERP_TRANS_STTS_CD");
            entity.Property(e => e.FittingCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("FITTING 업체 코드")
                .HasColumnName("FITTING_CMPY_CD");
            entity.Property(e => e.FrameCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("프레임 업체 코드")
                .HasColumnName("FRAME_CMPY_CD");
            entity.Property(e => e.FscCd)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasComment("FSC 코드")
                .HasColumnName("FSC_CD");
            entity.Property(e => e.HpCertifiCmplYn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("고압인증 완료 여부")
                .HasColumnName("HP_CERTIFI_CMPL_YN");
            entity.Property(e => e.HpCertifiDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("고압인증 일자")
                .HasColumnName("HP_CERTIFI_DT");
            entity.Property(e => e.LastPlanYn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("최종 계획 여부")
                .HasColumnName("LAST_PLAN_YN");
            entity.Property(e => e.LineCd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("라인 코드")
                .HasColumnName("LINE_CD");
            entity.Property(e => e.MailTrnsYn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("메일 전송 여부")
                .HasColumnName("MAIL_TRNS_YN");
            entity.Property(e => e.MechMtrlRcptDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("기구 자재 입고일자")
                .HasColumnName("MECH_MTRL_RCPT_DT");
            entity.Property(e => e.MechMtrlReqDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("기구 자재 불출 요청일")
                .HasColumnName("MECH_MTRL_REQ_DT");
            entity.Property(e => e.MechOdrCmplDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("기구 발주 완료일")
                .HasColumnName("MECH_ODR_CMPL_DT");
            entity.Property(e => e.MechPdnCmplDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("기구 생산 완료일자")
                .HasColumnName("MECH_PDN_CMPL_DT");
            entity.Property(e => e.MechanicCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("기구업체 코드")
                .HasColumnName("MECHANIC_CMPY_CD");
            entity.Property(e => e.PdnCmplDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("생산완료 일자")
                .HasColumnName("PDN_CMPL_DT");
            entity.Property(e => e.PdnFrmDt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("생산 시작일")
                .HasColumnName("PDN_FRM_DT");
            entity.Property(e => e.PdnPlanDesc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("생산계획 설명")
                .HasColumnName("PDN_PLAN_DESC");
            entity.Property(e => e.PdnSchedCnfmYn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComment("생산계획 확정 여부")
                .HasColumnName("PDN_SCHED_CNFM_YN");
            entity.Property(e => e.ProcTypeCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("공정타입 코드")
                .HasColumnName("PROC_TYPE_CD");
            entity.Property(e => e.ReservoirCmpyCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("RESERVOIR 업체 코드")
                .HasColumnName("RESERVOIR_CMPY_CD");
            entity.Property(e => e.SaleChgrEmpno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("담장자 사번")
                .HasColumnName("SALE_CHGR_EMPNO");
            entity.Property(e => e.UpdrEmpno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("수정자 사")
                .HasColumnName("UPDR_EMPNO");
            entity.Property(e => e.UpdtDt)
                .HasDefaultValueSql("(getdate())")
                .HasComment("수정일자")
                .HasColumnType("datetime")
                .HasColumnName("UPDT_DT");
            entity.Property(e => e.WoClsYn)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("W/O 취소여부")
                .HasColumnName("WO_CLS_YN");
        });
        modelBuilder.HasSequence<decimal>("AS_PARTSTRBYEQ_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("DCL_MNG_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("EOCUSTSTREPIT_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("EQ_MODULE_WORKSHOP_HDR_SEQ")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("FAQ_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("INFO_CHNG_HIST_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("MAIL_M_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("MRP_EXECUTE_LOG_SEQ")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("NOTICE_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("OCN_CHNG_DTL_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("OCN_CHNG_FSC_DTL_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("OCN_CHNG_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("PROC_H_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();
        modelBuilder.HasSequence<decimal>("STD_FUCT_TBL_HIST_SEQ_01")
            .HasMin(1L)
            .HasMax(9223372036854775807L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
