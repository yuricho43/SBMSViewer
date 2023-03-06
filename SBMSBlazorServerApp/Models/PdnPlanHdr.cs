using System;
using System.Collections.Generic;

namespace SBMSBlazorServerApp.Models;

public partial class PdnPlanHdr
{
    /// <summary>
    /// WO 번호
    /// </summary>
    public string WoNo { get; set; } = null!;

    /// <summary>
    /// 생산 구분
    /// </summary>
    public string TbCd { get; set; } = null!;

    /// <summary>
    /// 생산계획 버전
    /// </summary>
    public string PpVer { get; set; } = null!;

    /// <summary>
    /// EQ 번호
    /// </summary>
    public string? EqNo { get; set; }

    /// <summary>
    /// 공정타입 코드
    /// </summary>
    public string? ProcTypeCd { get; set; }

    /// <summary>
    /// 생산 시작일
    /// </summary>
    public string? PdnFrmDt { get; set; }

    /// <summary>
    /// 기구업체 코드
    /// </summary>
    public string? MechanicCmpyCd { get; set; }

    /// <summary>
    /// 전장업체 코드
    /// </summary>
    public string? ElectricCmpyCd { get; set; }

    /// <summary>
    /// 프레임 업체 코드
    /// </summary>
    public string? FrameCmpyCd { get; set; }

    /// <summary>
    /// 블럭업체 드
    /// </summary>
    public string? BlockCmpyCd { get; set; }

    /// <summary>
    /// FITTING 업체 코드
    /// </summary>
    public string? FittingCmpyCd { get; set; }

    /// <summary>
    /// RESERVOIR 업체 코드
    /// </summary>
    public string? ReservoirCmpyCd { get; set; }

    /// <summary>
    /// 고압인증 일자
    /// </summary>
    public string? HpCertifiDt { get; set; }

    /// <summary>
    /// 전장 자재 입고일자
    /// </summary>
    public string? ElecMtrlRcptDt { get; set; }

    /// <summary>
    /// 기구 자재 입고일자
    /// </summary>
    public string? MechMtrlRcptDt { get; set; }

    /// <summary>
    /// 전장 생산 완료일자
    /// </summary>
    public string? ElecPdnCmplDt { get; set; }

    /// <summary>
    /// 기구 생산 완료일자
    /// </summary>
    public string? MechPdnCmplDt { get; set; }

    /// <summary>
    /// 전장 발주 완료일
    /// </summary>
    public string? ElecOdrCmplDt { get; set; }

    /// <summary>
    /// 기구 발주 완료일
    /// </summary>
    public string? MechOdrCmplDt { get; set; }

    /// <summary>
    /// 전장 자재 불출 요청일
    /// </summary>
    public string? ElecMtrlReqDt { get; set; }

    /// <summary>
    /// 기구 자재 불출 요청일
    /// </summary>
    public string? MechMtrlReqDt { get; set; }

    /// <summary>
    /// 생산완료 일자
    /// </summary>
    public string? PdnCmplDt { get; set; }

    /// <summary>
    /// 생산계획 확정 여부
    /// </summary>
    public string? PdnSchedCnfmYn { get; set; }

    /// <summary>
    /// FSC 코드
    /// </summary>
    public string? FscCd { get; set; }

    /// <summary>
    /// 출하 요청일
    /// </summary>
    public string? DueDt { get; set; }

    /// <summary>
    /// W/O 취소여부
    /// </summary>
    public string? WoClsYn { get; set; }

    /// <summary>
    /// 고객 코드
    /// </summary>
    public string? CustCd { get; set; }

    /// <summary>
    /// 최종  User
    /// </summary>
    public string? EndUser { get; set; }

    /// <summary>
    /// 라인 코드
    /// </summary>
    public string? LineCd { get; set; }

    /// <summary>
    /// 담장자 사번
    /// </summary>
    public string? SaleChgrEmpno { get; set; }

    /// <summary>
    /// 고압인증 완료 여부
    /// </summary>
    public string? HpCertifiCmplYn { get; set; }

    /// <summary>
    /// 최종 계획 여부
    /// </summary>
    public string? LastPlanYn { get; set; }

    /// <summary>
    /// 메일 전송 여부
    /// </summary>
    public string? MailTrnsYn { get; set; }

    /// <summary>
    /// ERP 전송상태 코드
    /// </summary>
    public string? ErpTransSttsCd { get; set; }

    /// <summary>
    /// 생산계획 설명
    /// </summary>
    public string? PdnPlanDesc { get; set; }

    /// <summary>
    /// 등록자 사번
    /// </summary>
    public string CrtrEmpno { get; set; } = null!;

    /// <summary>
    /// 등록일자
    /// </summary>
    public DateTime CrtnDt { get; set; }

    /// <summary>
    /// 수정자 사
    /// </summary>
    public string? UpdrEmpno { get; set; }

    /// <summary>
    /// 수정일자
    /// </summary>
    public DateTime? UpdtDt { get; set; }

    public virtual ICollection<PdnPlanDtl> PdnPlanDtls { get; } = new List<PdnPlanDtl>();
}
