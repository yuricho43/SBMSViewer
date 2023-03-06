using System;
using System.Collections.Generic;

namespace SBMSBlazorServerApp.Models;

public partial class PdnPlanDtl
{
    /// <summary>
    /// EQ 번호
    /// </summary>
    public string WoNo { get; set; } = null!;

    /// <summary>
    /// EQ 버전
    /// </summary>
    public string TbCd { get; set; } = null!;

    public string PpVer { get; set; } = null!;

    /// <summary>
    /// 공정 순서
    /// </summary>
    public int ProcSeq { get; set; }

    /// <summary>
    /// 공정 코드
    /// </summary>
    public string ProcCd { get; set; } = null!;

    /// <summary>
    /// 작업일차일수
    /// </summary>
    public string? WorkDdayDcnt { get; set; }

    /// <summary>
    /// 작업 시작일
    /// </summary>
    public string? WorkFrmDt { get; set; }

    /// <summary>
    /// 작업 종료일
    /// </summary>
    public string? WorkToDt { get; set; }

    /// <summary>
    /// 토요일 근무 여부
    /// </summary>
    public string? SatWorkYn { get; set; }

    /// <summary>
    /// 작업 일자
    /// </summary>
    public string? WorkDdays { get; set; }

    /// <summary>
    /// 등록자 사번
    /// </summary>
    public string CrtrEmpno { get; set; } = null!;

    /// <summary>
    /// 등록일자
    /// </summary>
    public DateTime CrtnDt { get; set; }

    /// <summary>
    /// 수정자 사번
    /// </summary>
    public string? UpdrEmpno { get; set; }

    /// <summary>
    /// 수정일자
    /// </summary>
    public DateTime? UpdtDt { get; set; }

    public virtual PdnPlanHdr PdnPlanHdr { get; set; } = null!;
}
