/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      hg
 * Project :      Model1.DM1
 * Author :       HUAGO
 *
 * Date Created : Friday, December 09, 2016 14:10:54
 * Target DBMS : Microsoft SQL Server 2008
 */

USE SSY
go
/* 
 * TABLE: tBranchConfigs 
 */

CREATE TABLE tBranchConfigs(
    sGUID                 char(36)         NOT NULL,
    iID                   int              NULL,
    sName                 nvarchar(100)    NULL,
    fCurrentHI            float            NULL,
    fCurrentLO            float            NULL,
    fCurrentZO            float            NULL,
    iCurrentSD            float            NULL,
    iVoltType             int              NULL,
    fRatio                float            NULL,
    iEnable               int              NULL,
    iState_Command        int              NULL,
    sMeasureConfigGUID    char(36)         NULL,
    sRelayInfoGUID        char(36)         NULL,
    sSwitchConfigGUID     char(36)         NULL,
    dCreateTime           datetime         NULL,
    dUpdateTime           datetime         NULL,
    sDesc                 nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_1_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tBranchConfigs') IS NOT NULL
    PRINT '<<< CREATED TABLE tBranchConfigs >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tBranchConfigs >>>'
go

/* 
 * TABLE: tCMDRevs 
 */

CREATE TABLE tCMDRevs(
    sGUID           char(36)         NOT NULL,
    iContentType    int              NULL,
    sContent        nvarchar(500)    NULL,
    iState          int              NULL,
    dCreateDate     datetime         NULL,
    dUpdateTime     datetime         NULL,
    iHostIDType     int              NULL,
    sHostIDAddr     nvarchar(100)    NULL,
    sHostIDID       nvarchar(100)    NULL,
    sHostIDSIM      nvarchar(100)    NULL,
    sHostIDIP       nvarchar(100)    NULL,
    sHostIDMAC      nvarchar(100)    NULL,
    CONSTRAINT PK4_2_1_2_1_1_2_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tCMDRevs') IS NOT NULL
    PRINT '<<< CREATED TABLE tCMDRevs >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tCMDRevs >>>'
go

/* 
 * TABLE: tCMDSends 
 */

CREATE TABLE tCMDSends(
    sGUID           char(36)         NOT NULL,
    iContentType    int              NULL,
    sContent        nvarchar(500)    NULL,
    iState          int              NULL,
    dCreateDate     datetime         NULL,
    dUpdateTime     datetime         NULL,
    iHostIDType     int              NULL,
    sHostIDAddr     nvarchar(100)    NULL,
    sHostIDID       nvarchar(100)    NULL,
    sHostIDSIM      nvarchar(100)    NULL,
    sHostIDIP       nvarchar(100)    NULL,
    sHostIDMAC      nvarchar(100)    NULL,
    CONSTRAINT PK4_2_1_2_1_1_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tCMDSends') IS NOT NULL
    PRINT '<<< CREATED TABLE tCMDSends >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tCMDSends >>>'
go

/* 
 * TABLE: tCtrlTagInfoes 
 */

CREATE TABLE tCtrlTagInfoes(
    sGUID               char(36)         NOT NULL,
    iType               int              NULL,
    sRelayState         nvarchar(50)     NULL,
    sRelayInfo_GUID     char(36)         NULL,
    sLightGroupState    nvarchar(50)     NULL,
    sLightGroupGUID     char(36)         NULL,
    sDesc               nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_1_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tCtrlTagInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tCtrlTagInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tCtrlTagInfoes >>>'
go

/* 
 * TABLE: tGroupInfoes 
 */

CREATE TABLE tGroupInfoes(
    sGUID               char(36)         NOT NULL,
    sProjectInfoGUID    char(36)         NULL,
    sName               nvarchar(100)    NULL,
    sID                 varchar(10)      NULL,
    dCreateDate         datetime         NULL,
    dUpdateTime         datetime         NULL,
    sRemark             nvarchar(500)    NULL,
    CONSTRAINT PK4_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tGroupInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tGroupInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tGroupInfoes >>>'
go

/* 
 * TABLE: tHolidayInfoes 
 */

CREATE TABLE tHolidayInfoes(
    sGUID             char(36)         NOT NULL,
    iID               int              NULL,
    dStartTime        datetime         NULL,
    dEndTime          datetime         NULL,
    sName             nvarchar(100)    NULL,
    dCreateDate       datetime         NULL,
    dUpdateTime       datetime         NULL,
    iEnable           int              NULL,
    sHHostInfoGUID    char(36)         NULL,
    sDesc             nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1_1_1_1_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHolidayInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tHolidayInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHolidayInfoes >>>'
go

/* 
 * TABLE: tHolidayTimeCtrlInfoes 
 */

CREATE TABLE tHolidayTimeCtrlInfoes(
    sGUID               char(36)         NOT NULL,
    iID                 int              NULL,
    iEnable             int              NULL,
    dTime               datetime         NULL,
    iState_Command      int              NULL,
    dCreateDate         datetime         NULL,
    dUpdateTime         datetime         NULL,
    sHolidayInfoGUID    char(36)         NULL,
    sTagGUID            char(36)         NULL,
    sDesc               nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1_1_1_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHolidayTimeCtrlInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tHolidayTimeCtrlInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHolidayTimeCtrlInfoes >>>'
go

/* 
 * TABLE: tHostInfo 
 */

CREATE TABLE tHostInfo(
    sGUID                 char(36)         NOT NULL,
    sName                 nvarchar(100)    NULL,
    fLng                  float            NULL,
    fLat                  float            NULL,
    iIDType               int              NULL,
    sID_ID                varchar(20)      NULL,
    sID_Addr              nvarchar(100)    NULL,
    sID_IP                nvarchar(100)    NULL,
    sID_MAC               nvarchar(100)    NULL,
    sID_SIM               nvarchar(100)    NULL,
    sHardware_Version     nvarchar(100)    NULL,
    iHardware_Type        int              NULL,
    iState_Online         int              NULL,
    iState_Alarm          int              NULL,
    iState_Enable         int              NULL,
    iState_Command        int              NULL,
    sGroupInfoGUID        char(36)         NULL,
    sProjectInfoGUID      char(36)         NULL,
    dCreateDate           datetime         NULL,
    dUpdateTime           datetime         NULL,
    sRemark               nvarchar(500)    NULL,
    sHostInfoStateGUID    char(36)         NULL,
    CONSTRAINT PK4_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHostInfo') IS NOT NULL
    PRINT '<<< CREATED TABLE tHostInfo >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHostInfo >>>'
go

/* 
 * TABLE: tHostInfoState 
 */

CREATE TABLE tHostInfoState(
    sGUID               char(36)         NOT NULL,
    sHostInfoGUID       char(36)         NULL,
    iState_Online       int              NULL,
    iFlag               int              NULL,
    sState_Alarm        nvarchar(100)    NULL,
    sMeasureInfoGUID    nvarchar(200)    NULL,
    sSwitchInfoGUID     char(36)         NULL,
    dCreateDate         datetime         NULL,
    dUpdateTime         datetime         NULL,
    CONSTRAINT PK4_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHostInfoState') IS NOT NULL
    PRINT '<<< CREATED TABLE tHostInfoState >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHostInfoState >>>'
go

/* 
 * TABLE: tHostSet 
 */

CREATE TABLE tHostSet(
    sGUID          char(36)         NOT NULL,
    sKey           nvarchar(50)     NULL,
    sValue         nvarchar(50)     NULL,
    sHostGUID      char(36)         NULL,
    sDesc          nvarchar(100)    NULL,
    dCreateDate    datetime         NULL,
    dUpdateDate    datetime         NULL,
    CONSTRAINT PK37 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHostSet') IS NOT NULL
    PRINT '<<< CREATED TABLE tHostSet >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHostSet >>>'
go

/* 
 * TABLE: tJurisdiction 
 */

CREATE TABLE tJurisdiction(
    sGUID                   char(36)         NOT NULL,
    sJurisdictionType       int              NULL,
    sJurisdictionContent    nvarchar(100)    NULL,
    sPrjectGUID             char(36)         NULL,
    sDesc                   nvarchar(500)    NULL,
    dCreateTime             datetime         NULL,
    dUpdateTime             datetime         NULL,
    CONSTRAINT PK32_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tJurisdiction') IS NOT NULL
    PRINT '<<< CREATED TABLE tJurisdiction >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tJurisdiction >>>'
go

/* 
 * TABLE: tLatLngTimeCtrlInfoes 
 */

CREATE TABLE tLatLngTimeCtrlInfoes(
    sGUID             char(36)         NOT NULL,
    iID               int              NULL,
    iTimeType         int              NULL,
    iOffset           int              NULL,
    iEnable           int              NULL,
    iState_Command    float            NULL,
    dCreateDate       datetime         NULL,
    dUpdateTime       datetime         NULL,
    sTagGUID          char(36)         NULL,
    sDesc             nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tLatLngTimeCtrlInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tLatLngTimeCtrlInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tLatLngTimeCtrlInfoes >>>'
go

/* 
 * TABLE: tLightGroupInfoes 
 */

CREATE TABLE tLightGroupInfoes(
    sGUID            char(36)         NOT NULL,
    sName            nvarchar(100)    NULL,
    sHostInfoGUID    char(36)         NULL,
    sID              varchar(10)      NULL,
    dCreateTime      datetime         NULL,
    dUpdateTime      datetime         NULL,
    sRemark          nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tLightGroupInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tLightGroupInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tLightGroupInfoes >>>'
go

/* 
 * TABLE: tLightInfoes 
 */

CREATE TABLE tLightInfoes(
    sGUID                            char(36)         NOT NULL,
    sName                            nvarchar(100)    NULL,
    sLightID                         nvarchar(100)    NULL,
    sLightPhyID                      nvarchar(50)     NULL,
    fLng                             float            NULL,
    fLat                             float            NULL,
    sAddr                            nvarchar(100)    NULL,
    iState_Command                   int              NULL,
    iAlarmConfig_Config              int              NULL,
    dAlarmConfig_Start               datetime         NULL,
    dAlarmConfig_End                 datetime         NULL,
    sAlarmConfig_Remark              nvarchar(500)    NULL,
    iRealTimeAlarm_FaultState        int              NULL,
    iRealTimeAlarm_Fault             int              NULL,
    iRealTimeAlarm_CreateDateTime    datetime         NULL,
    sHostInfoGUID                    char(36)         NULL,
    sStateGUID                       char(36)         NULL,
    dCreateTime                      datetime         NULL,
    dUpdateTime                      datetime         NULL,
    sRemark                          nvarchar(500)    NULL,
    sHardware_Version                nvarchar(200)    NULL,
    iHardware_Type                   int              NULL,
    iEnable                          int              NULL,
    CONSTRAINT PK4_3 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tLightInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tLightInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tLightInfoes >>>'
go

/* 
 * TABLE: tLightInfoLightGroupInfoes 
 */

CREATE TABLE tLightInfoLightGroupInfoes(
    sGUID                  char(36)    NOT NULL,
    sLightInfoGUID         char(36)    NOT NULL,
    sLightGroupInfoGUID    char(36)    NOT NULL,
    dCreateTime            datetime    NULL,
    dUpdateTime            datetime    NULL,
    CONSTRAINT PK4_2_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tLightInfoLightGroupInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tLightInfoLightGroupInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tLightInfoLightGroupInfoes >>>'
go

/* 
 * TABLE: tLightStateInfoes 
 */

CREATE TABLE tLightStateInfoes(
    sGUID             char(36)        NOT NULL,
    fVoltage          float           NULL,
    fCurrent          float           NULL,
    fPower            float           NULL,
    iFault            int             NULL,
    dCreateDate       datetime        NULL,
    dUpdateTime       datetime        NULL,
    sLightInfoGUID    char(36)        NULL,
    sSpareField1      nvarchar(50)    NULL,
    sSpareField2      nvarchar(50)    NULL,
    sSpareField3      nvarchar(50)    NULL,
    sSpareField4      nvarchar(50)    NULL,
    sSpareField5      nvarchar(50)    NULL,
    sSpareField6      nvarchar(50)    NULL,
    sSpareField7      nvarchar(50)    NULL,
    sSpareField8      nvarchar(50)    NULL,
    sSpareField9      nvarchar(50)    NULL,
    sSpareField10     nvarchar(50)    NULL,
    CONSTRAINT PK4_2_1_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tLightStateInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tLightStateInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tLightStateInfoes >>>'
go

/* 
 * TABLE: tMeasureConfigs 
 */

CREATE TABLE tMeasureConfigs(
    sGUID              char(36)         NOT NULL,
    fVoltHI            float            NULL,
    fVoltLO            float            NULL,
    iAlarmDelayTime    int              NULL,
    iMeasureNumber     int              NULL,
    iBranchNumber      char(10)         NULL,
    iState_Command     int              NULL,
    dCreateDate        datetime         NULL,
    dUpdateTime        datetime         NULL,
    sHostInfoGUID      char(36)         NULL,
    sDesc              nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tMeasureConfigs') IS NOT NULL
    PRINT '<<< CREATED TABLE tMeasureConfigs >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tMeasureConfigs >>>'
go

/* 
 * TABLE: tMeasureCurrentInfoes 
 */

CREATE TABLE tMeasureCurrentInfoes(
    sGUID               char(36)         NOT NULL,
    iID                 int              NULL,
    fValue              float            NULL,
    iAlarm              float            NULL,
    sMeasureInfoGUID    char(36)         NULL,
    dCreateTime         datetime         NULL,
    dUpdateTime         datetime         NULL,
    sDesc               nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tMeasureCurrentInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tMeasureCurrentInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tMeasureCurrentInfoes >>>'
go

/* 
 * TABLE: tMeasureInfoes 
 */

CREATE TABLE tMeasureInfoes(
    sGUID            char(36)         NOT NULL,
    iID              int              NULL,
    fVlotA           float            NULL,
    fVlotB           float            NULL,
    fVlotC           float            NULL,
    iAlarmVlotA      int              NULL,
    iAlarmVlotB      int              NULL,
    iAlarmVlotC      int              NULL,
    dCreateDate      datetime         NULL,
    dUpdateTime      datetime         NULL,
    sHostInfoGUID    char(36)         NULL,
    sDesc            nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tMeasureInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tMeasureInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tMeasureInfoes >>>'
go

/* 
 * TABLE: tMeasurePowerInfoes 
 */

CREATE TABLE tMeasurePowerInfoes(
    sGUID               char(36)         NOT NULL,
    iID                 int              NULL,
    fValue              float            NULL,
    sMeasureInfoGUID    char(36)         NULL,
    sDesc               nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tMeasurePowerInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tMeasurePowerInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tMeasurePowerInfoes >>>'
go

/* 
 * TABLE: tPrjectInfo 
 */

CREATE TABLE tPrjectInfo(
    sGUID          char(36)         NOT NULL,
    sID            nvarchar(100)    NULL,
    sName          nvarchar(100)    NULL,
    sAuthor        nvarchar(100)    NULL,
    fLng           float            NULL,
    fLat           float            NULL,
    dCreateDate    datetime         NULL,
    dUpdateTime    datetime         NULL,
    sRemark        nvarchar(500)    NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tPrjectInfo') IS NOT NULL
    PRINT '<<< CREATED TABLE tPrjectInfo >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tPrjectInfo >>>'
go

/* 
 * TABLE: tPrjectSet 
 */

CREATE TABLE tPrjectSet(
    sGUID          char(36)         NOT NULL,
    sKey           nvarchar(50)     NULL,
    sValue         nvarchar(50)     NULL,
    sPrjectGUID    char(36)         NULL,
    sDesc          nvarchar(500)    NULL,
    dCreateTime    datetime         NULL,
    dUpdateTime    datetime         NULL,
    CONSTRAINT PK32 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tPrjectSet') IS NOT NULL
    PRINT '<<< CREATED TABLE tPrjectSet >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tPrjectSet >>>'
go

/* 
 * TABLE: tRelayInfoes 
 */

CREATE TABLE tRelayInfoes(
    sGUID            char(36)         NOT NULL,
    iID              int              NULL,
    sName            nvarchar(100)    NULL,
    sHostInfoGUID    char(36)         NULL,
    dCreateDate      datetime         NULL,
    dUpdateTime      datetime         NULL,
    sRemark          nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tRelayInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tRelayInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tRelayInfoes >>>'
go

/* 
 * TABLE: tSwitchConfigs 
 */

CREATE TABLE tSwitchConfigs(
    sGUID            char(36)         NOT NULL,
    iID              int              NULL,
    sName            nvarchar(100)    NULL,
    iStateCommand    int              NULL,
    iAlarmEnable     int              NULL,
    sHostInfoGUID    char(36)         NOT NULL,
    dCreateDate      datetime         NULL,
    dUpdateTime      datetime         NULL,
    sRemark          nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tSwitchConfigs') IS NOT NULL
    PRINT '<<< CREATED TABLE tSwitchConfigs >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tSwitchConfigs >>>'
go

/* 
 * TABLE: tSwitchInfoes 
 */

CREATE TABLE tSwitchInfoes(
    sGUID             char(36)         NOT NULL,
    iAlarmState       int              NULL,
    iState_Command    int              NULL,
    sHostInfo_GUID    char(36)         NULL,
    dCreateDate       datetime         NULL,
    sSwitch_GUID      char(36)         NULL,
    dUpdateTiime      datetime         NULL,
    sDesc             nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_2_2_1_1_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tSwitchInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tSwitchInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tSwitchInfoes >>>'
go

/* 
 * TABLE: tTimeCtrlInfoes 
 */

CREATE TABLE tTimeCtrlInfoes(
    sGUID             char(36)         NOT NULL,
    iID               int              NULL,
    dTime             datetime         NULL,
    iEnable           int              NULL,
    iState_Command    float            NULL,
    dCreateDate       datetime         NULL,
    dUpdateTime       datetime         NULL,
    sHostInfoGUID     char(36)         NULL,
    sTagGUID          char(36)         NOT NULL,
    sDesc             nvarchar(500)    NULL,
    CONSTRAINT PK4_2_1_2_1_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tTimeCtrlInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tTimeCtrlInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tTimeCtrlInfoes >>>'
go

/* 
 * TABLE: tUserInfoes 
 */

CREATE TABLE tUserInfoes(
    sGUID              char(36)         NOT NULL,
    sID                nvarchar(100)    NULL,
    sUserName          nvarchar(100)    NOT NULL,
    sPassWord          nvarchar(200)    NOT NULL,
    iAuthorityGUID     char(36)         NULL,
    sAlias             nvarchar(100)    NULL,
    sPhone             nvarchar(100)    NULL,
    sEmail             nvarchar(100)    NULL,
    dCreateDate        datetime         NULL,
    dUpdateTime        datetime         NULL,
    sRemark            nvarchar(500)    NULL,
    sPrjectInfoGUID    char(36)         NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tUserInfoes') IS NOT NULL
    PRINT '<<< CREATED TABLE tUserInfoes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tUserInfoes >>>'
go

/* 
 * TABLE: tUserSet 
 */

CREATE TABLE tUserSet(
    sGUID          char(36)         NOT NULL,
    sKey           nvarchar(50)     NULL,
    sValue         nvarchar(50)     NULL,
    sUserGUID      char(36)         NULL,
    sDesc          nvarchar(500)    NULL,
    dCreateTime    datetime         NULL,
    dUpdateTime    datetime         NULL,
    CONSTRAINT PK32_1 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tUserSet') IS NOT NULL
    PRINT '<<< CREATED TABLE tUserSet >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tUserSet >>>'
go

/* 
 * PROCEDURE: tBranchConfigsInsProc 
 */

CREATE PROCEDURE tBranchConfigsInsProc
(
    @sGUID                  char(36),
    @iID                    int                      = NULL,
    @sName                  nvarchar(100)            = NULL,
    @fCurrentHI             float                    = NULL,
    @fCurrentLO             float                    = NULL,
    @fCurrentZO             float                    = NULL,
    @iCurrentSD             float                    = NULL,
    @iVoltType              int                      = NULL,
    @fRatio                 float                    = NULL,
    @iEnable                int                      = NULL,
    @iState_Command         int                      = NULL,
    @sMeasureConfigGUID     char(36)                 = NULL,
    @sRelayInfoGUID         char(36)                 = NULL,
    @sSwitchConfigGUID      char(36)                 = NULL,
    @dCreateTime            datetime                 = NULL,
    @dUpdateTime            datetime                 = NULL,
    @sDesc                  nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tBranchConfigs(sGUID,
                               iID,
                               sName,
                               fCurrentHI,
                               fCurrentLO,
                               fCurrentZO,
                               iCurrentSD,
                               iVoltType,
                               fRatio,
                               iEnable,
                               iState_Command,
                               sMeasureConfigGUID,
                               sRelayInfoGUID,
                               sSwitchConfigGUID,
                               dCreateTime,
                               dUpdateTime,
                               sDesc)
    VALUES(@sGUID,
           @iID,
           @sName,
           @fCurrentHI,
           @fCurrentLO,
           @fCurrentZO,
           @iCurrentSD,
           @iVoltType,
           @fRatio,
           @iEnable,
           @iState_Command,
           @sMeasureConfigGUID,
           @sRelayInfoGUID,
           @sSwitchConfigGUID,
           @dCreateTime,
           @dUpdateTime,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tBranchConfigsInsProc: Cannot insert because primary key value not found in tBranchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tBranchConfigsInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tBranchConfigsInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tBranchConfigsInsProc >>>'
go


/* 
 * PROCEDURE: tBranchConfigsUpdProc 
 */

CREATE PROCEDURE tBranchConfigsUpdProc
(
    @sGUID                  char(36),
    @iID                    int                      = NULL,
    @sName                  nvarchar(100)            = NULL,
    @fCurrentHI             float                    = NULL,
    @fCurrentLO             float                    = NULL,
    @fCurrentZO             float                    = NULL,
    @iCurrentSD             float                    = NULL,
    @iVoltType              int                      = NULL,
    @fRatio                 float                    = NULL,
    @iEnable                int                      = NULL,
    @iState_Command         int                      = NULL,
    @sMeasureConfigGUID     char(36)                 = NULL,
    @sRelayInfoGUID         char(36)                 = NULL,
    @sSwitchConfigGUID      char(36)                 = NULL,
    @dCreateTime            datetime                 = NULL,
    @dUpdateTime            datetime                 = NULL,
    @sDesc                  nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tBranchConfigs
       SET iID                     = @iID,
           sName                   = @sName,
           fCurrentHI              = @fCurrentHI,
           fCurrentLO              = @fCurrentLO,
           fCurrentZO              = @fCurrentZO,
           iCurrentSD              = @iCurrentSD,
           iVoltType               = @iVoltType,
           fRatio                  = @fRatio,
           iEnable                 = @iEnable,
           iState_Command          = @iState_Command,
           sMeasureConfigGUID      = @sMeasureConfigGUID,
           sRelayInfoGUID          = @sRelayInfoGUID,
           sSwitchConfigGUID       = @sSwitchConfigGUID,
           dCreateTime             = @dCreateTime,
           dUpdateTime             = @dUpdateTime,
           sDesc                   = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tBranchConfigsUpdProc: Cannot update  in tBranchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tBranchConfigsUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tBranchConfigsUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tBranchConfigsUpdProc >>>'
go


/* 
 * PROCEDURE: tBranchConfigsDelProc 
 */

CREATE PROCEDURE tBranchConfigsDelProc
(
    @sGUID                  char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tBranchConfigs
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tBranchConfigsDelProc: Cannot delete because foreign keys still exist in tBranchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tBranchConfigsDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tBranchConfigsDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tBranchConfigsDelProc >>>'
go


/* 
 * PROCEDURE: tBranchConfigsSelProc 
 */

CREATE PROCEDURE tBranchConfigsSelProc
(
    @sGUID                  char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           sName,
           fCurrentHI,
           fCurrentLO,
           fCurrentZO,
           iCurrentSD,
           iVoltType,
           fRatio,
           iEnable,
           iState_Command,
           sMeasureConfigGUID,
           sRelayInfoGUID,
           sSwitchConfigGUID,
           dCreateTime,
           dUpdateTime,
           sDesc
      FROM tBranchConfigs
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tBranchConfigsSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tBranchConfigsSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tBranchConfigsSelProc >>>'
go


/* 
 * PROCEDURE: tCMDRevsInsProc 
 */

CREATE PROCEDURE tCMDRevsInsProc
(
    @sGUID            char(36),
    @iContentType     int                      = NULL,
    @sContent         nvarchar(500)            = NULL,
    @iState           int                      = NULL,
    @dCreateDate      datetime                 = NULL,
    @dUpdateTime      datetime                 = NULL,
    @iHostIDType      int                      = NULL,
    @sHostIDAddr      nvarchar(100)            = NULL,
    @sHostIDID        nvarchar(100)            = NULL,
    @sHostIDSIM       nvarchar(100)            = NULL,
    @sHostIDIP        nvarchar(100)            = NULL,
    @sHostIDMAC       nvarchar(100)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tCMDRevs(sGUID,
                         iContentType,
                         sContent,
                         iState,
                         dCreateDate,
                         dUpdateTime,
                         iHostIDType,
                         sHostIDAddr,
                         sHostIDID,
                         sHostIDSIM,
                         sHostIDIP,
                         sHostIDMAC)
    VALUES(@sGUID,
           @iContentType,
           @sContent,
           @iState,
           @dCreateDate,
           @dUpdateTime,
           @iHostIDType,
           @sHostIDAddr,
           @sHostIDID,
           @sHostIDSIM,
           @sHostIDIP,
           @sHostIDMAC)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tCMDRevsInsProc: Cannot insert because primary key value not found in tCMDRevs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tCMDRevsInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDRevsInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDRevsInsProc >>>'
go


/* 
 * PROCEDURE: tCMDRevsUpdProc 
 */

CREATE PROCEDURE tCMDRevsUpdProc
(
    @sGUID            char(36),
    @iContentType     int                      = NULL,
    @sContent         nvarchar(500)            = NULL,
    @iState           int                      = NULL,
    @dCreateDate      datetime                 = NULL,
    @dUpdateTime      datetime                 = NULL,
    @iHostIDType      int                      = NULL,
    @sHostIDAddr      nvarchar(100)            = NULL,
    @sHostIDID        nvarchar(100)            = NULL,
    @sHostIDSIM       nvarchar(100)            = NULL,
    @sHostIDIP        nvarchar(100)            = NULL,
    @sHostIDMAC       nvarchar(100)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tCMDRevs
       SET iContentType      = @iContentType,
           sContent          = @sContent,
           iState            = @iState,
           dCreateDate       = @dCreateDate,
           dUpdateTime       = @dUpdateTime,
           iHostIDType       = @iHostIDType,
           sHostIDAddr       = @sHostIDAddr,
           sHostIDID         = @sHostIDID,
           sHostIDSIM        = @sHostIDSIM,
           sHostIDIP         = @sHostIDIP,
           sHostIDMAC        = @sHostIDMAC
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tCMDRevsUpdProc: Cannot update  in tCMDRevs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCMDRevsUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDRevsUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDRevsUpdProc >>>'
go


/* 
 * PROCEDURE: tCMDRevsDelProc 
 */

CREATE PROCEDURE tCMDRevsDelProc
(
    @sGUID            char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tCMDRevs
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tCMDRevsDelProc: Cannot delete because foreign keys still exist in tCMDRevs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCMDRevsDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDRevsDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDRevsDelProc >>>'
go


/* 
 * PROCEDURE: tCMDRevsSelProc 
 */

CREATE PROCEDURE tCMDRevsSelProc
(
    @sGUID            char(36))
AS
BEGIN
    SELECT sGUID,
           iContentType,
           sContent,
           iState,
           dCreateDate,
           dUpdateTime,
           iHostIDType,
           sHostIDAddr,
           sHostIDID,
           sHostIDSIM,
           sHostIDIP,
           sHostIDMAC
      FROM tCMDRevs
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tCMDRevsSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDRevsSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDRevsSelProc >>>'
go


/* 
 * PROCEDURE: tCMDSendsInsProc 
 */

CREATE PROCEDURE tCMDSendsInsProc
(
    @sGUID            char(36),
    @iContentType     int                      = NULL,
    @sContent         nvarchar(500)            = NULL,
    @iState           int                      = NULL,
    @dCreateDate      datetime                 = NULL,
    @dUpdateTime      datetime                 = NULL,
    @iHostIDType      int                      = NULL,
    @sHostIDAddr      nvarchar(100)            = NULL,
    @sHostIDID        nvarchar(100)            = NULL,
    @sHostIDSIM       nvarchar(100)            = NULL,
    @sHostIDIP        nvarchar(100)            = NULL,
    @sHostIDMAC       nvarchar(100)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tCMDSends(sGUID,
                          iContentType,
                          sContent,
                          iState,
                          dCreateDate,
                          dUpdateTime,
                          iHostIDType,
                          sHostIDAddr,
                          sHostIDID,
                          sHostIDSIM,
                          sHostIDIP,
                          sHostIDMAC)
    VALUES(@sGUID,
           @iContentType,
           @sContent,
           @iState,
           @dCreateDate,
           @dUpdateTime,
           @iHostIDType,
           @sHostIDAddr,
           @sHostIDID,
           @sHostIDSIM,
           @sHostIDIP,
           @sHostIDMAC)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tCMDSendsInsProc: Cannot insert because primary key value not found in tCMDSends '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tCMDSendsInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDSendsInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDSendsInsProc >>>'
go


/* 
 * PROCEDURE: tCMDSendsUpdProc 
 */

CREATE PROCEDURE tCMDSendsUpdProc
(
    @sGUID            char(36),
    @iContentType     int                      = NULL,
    @sContent         nvarchar(500)            = NULL,
    @iState           int                      = NULL,
    @dCreateDate      datetime                 = NULL,
    @dUpdateTime      datetime                 = NULL,
    @iHostIDType      int                      = NULL,
    @sHostIDAddr      nvarchar(100)            = NULL,
    @sHostIDID        nvarchar(100)            = NULL,
    @sHostIDSIM       nvarchar(100)            = NULL,
    @sHostIDIP        nvarchar(100)            = NULL,
    @sHostIDMAC       nvarchar(100)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tCMDSends
       SET iContentType      = @iContentType,
           sContent          = @sContent,
           iState            = @iState,
           dCreateDate       = @dCreateDate,
           dUpdateTime       = @dUpdateTime,
           iHostIDType       = @iHostIDType,
           sHostIDAddr       = @sHostIDAddr,
           sHostIDID         = @sHostIDID,
           sHostIDSIM        = @sHostIDSIM,
           sHostIDIP         = @sHostIDIP,
           sHostIDMAC        = @sHostIDMAC
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tCMDSendsUpdProc: Cannot update  in tCMDSends '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCMDSendsUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDSendsUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDSendsUpdProc >>>'
go


/* 
 * PROCEDURE: tCMDSendsDelProc 
 */

CREATE PROCEDURE tCMDSendsDelProc
(
    @sGUID            char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tCMDSends
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tCMDSendsDelProc: Cannot delete because foreign keys still exist in tCMDSends '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCMDSendsDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDSendsDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDSendsDelProc >>>'
go


/* 
 * PROCEDURE: tCMDSendsSelProc 
 */

CREATE PROCEDURE tCMDSendsSelProc
(
    @sGUID            char(36))
AS
BEGIN
    SELECT sGUID,
           iContentType,
           sContent,
           iState,
           dCreateDate,
           dUpdateTime,
           iHostIDType,
           sHostIDAddr,
           sHostIDID,
           sHostIDSIM,
           sHostIDIP,
           sHostIDMAC
      FROM tCMDSends
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tCMDSendsSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCMDSendsSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCMDSendsSelProc >>>'
go


/* 
 * PROCEDURE: tCtrlTagInfoesInsProc 
 */

CREATE PROCEDURE tCtrlTagInfoesInsProc
(
    @sGUID                char(36),
    @iType                int                      = NULL,
    @sRelayState          nvarchar(50)             = NULL,
    @sRelayInfo_GUID      char(36)                 = NULL,
    @sLightGroupState     nvarchar(50)             = NULL,
    @sLightGroupGUID      char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tCtrlTagInfoes(sGUID,
                               iType,
                               sRelayState,
                               sRelayInfo_GUID,
                               sLightGroupState,
                               sLightGroupGUID,
                               sDesc)
    VALUES(@sGUID,
           @iType,
           @sRelayState,
           @sRelayInfo_GUID,
           @sLightGroupState,
           @sLightGroupGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tCtrlTagInfoesInsProc: Cannot insert because primary key value not found in tCtrlTagInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tCtrlTagInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCtrlTagInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCtrlTagInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tCtrlTagInfoesUpdProc 
 */

CREATE PROCEDURE tCtrlTagInfoesUpdProc
(
    @sGUID                char(36),
    @iType                int                      = NULL,
    @sRelayState          nvarchar(50)             = NULL,
    @sRelayInfo_GUID      char(36)                 = NULL,
    @sLightGroupState     nvarchar(50)             = NULL,
    @sLightGroupGUID      char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tCtrlTagInfoes
       SET iType                 = @iType,
           sRelayState           = @sRelayState,
           sRelayInfo_GUID       = @sRelayInfo_GUID,
           sLightGroupState      = @sLightGroupState,
           sLightGroupGUID       = @sLightGroupGUID,
           sDesc                 = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tCtrlTagInfoesUpdProc: Cannot update  in tCtrlTagInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCtrlTagInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCtrlTagInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCtrlTagInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tCtrlTagInfoesDelProc 
 */

CREATE PROCEDURE tCtrlTagInfoesDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tCtrlTagInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tCtrlTagInfoesDelProc: Cannot delete because foreign keys still exist in tCtrlTagInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tCtrlTagInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCtrlTagInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCtrlTagInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tCtrlTagInfoesSelProc 
 */

CREATE PROCEDURE tCtrlTagInfoesSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           iType,
           sRelayState,
           sRelayInfo_GUID,
           sLightGroupState,
           sLightGroupGUID,
           sDesc
      FROM tCtrlTagInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tCtrlTagInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tCtrlTagInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tCtrlTagInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tGroupInfoesInsProc 
 */

CREATE PROCEDURE tGroupInfoesInsProc
(
    @sGUID                char(36),
    @sProjectInfoGUID     char(36)                 = NULL,
    @sName                nvarchar(100)            = NULL,
    @sID                  varchar(10)              = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sRemark              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tGroupInfoes(sGUID,
                             sProjectInfoGUID,
                             sName,
                             sID,
                             dCreateDate,
                             dUpdateTime,
                             sRemark)
    VALUES(@sGUID,
           @sProjectInfoGUID,
           @sName,
           @sID,
           @dCreateDate,
           @dUpdateTime,
           @sRemark)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tGroupInfoesInsProc: Cannot insert because primary key value not found in tGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tGroupInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tGroupInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tGroupInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tGroupInfoesUpdProc 
 */

CREATE PROCEDURE tGroupInfoesUpdProc
(
    @sGUID                char(36),
    @sProjectInfoGUID     char(36)                 = NULL,
    @sName                nvarchar(100)            = NULL,
    @sID                  varchar(10)              = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sRemark              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tGroupInfoes
       SET sProjectInfoGUID      = @sProjectInfoGUID,
           sName                 = @sName,
           sID                   = @sID,
           dCreateDate           = @dCreateDate,
           dUpdateTime           = @dUpdateTime,
           sRemark               = @sRemark
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tGroupInfoesUpdProc: Cannot update  in tGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tGroupInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tGroupInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tGroupInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tGroupInfoesDelProc 
 */

CREATE PROCEDURE tGroupInfoesDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tGroupInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tGroupInfoesDelProc: Cannot delete because foreign keys still exist in tGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tGroupInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tGroupInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tGroupInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tGroupInfoesSelProc 
 */

CREATE PROCEDURE tGroupInfoesSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           sProjectInfoGUID,
           sName,
           sID,
           dCreateDate,
           dUpdateTime,
           sRemark
      FROM tGroupInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tGroupInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tGroupInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tGroupInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tHolidayInfoesInsProc 
 */

CREATE PROCEDURE tHolidayInfoesInsProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @dStartTime         datetime                 = NULL,
    @dEndTime           datetime                 = NULL,
    @sName              nvarchar(100)            = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @iEnable            int                      = NULL,
    @sHHostInfoGUID     char(36)                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tHolidayInfoes(sGUID,
                               iID,
                               dStartTime,
                               dEndTime,
                               sName,
                               dCreateDate,
                               dUpdateTime,
                               iEnable,
                               sHHostInfoGUID,
                               sDesc)
    VALUES(@sGUID,
           @iID,
           @dStartTime,
           @dEndTime,
           @sName,
           @dCreateDate,
           @dUpdateTime,
           @iEnable,
           @sHHostInfoGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tHolidayInfoesInsProc: Cannot insert because primary key value not found in tHolidayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tHolidayInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tHolidayInfoesUpdProc 
 */

CREATE PROCEDURE tHolidayInfoesUpdProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @dStartTime         datetime                 = NULL,
    @dEndTime           datetime                 = NULL,
    @sName              nvarchar(100)            = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @iEnable            int                      = NULL,
    @sHHostInfoGUID     char(36)                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tHolidayInfoes
       SET iID                 = @iID,
           dStartTime          = @dStartTime,
           dEndTime            = @dEndTime,
           sName               = @sName,
           dCreateDate         = @dCreateDate,
           dUpdateTime         = @dUpdateTime,
           iEnable             = @iEnable,
           sHHostInfoGUID      = @sHHostInfoGUID,
           sDesc               = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tHolidayInfoesUpdProc: Cannot update  in tHolidayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tHolidayInfoesDelProc 
 */

CREATE PROCEDURE tHolidayInfoesDelProc
(
    @sGUID              char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tHolidayInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tHolidayInfoesDelProc: Cannot delete because foreign keys still exist in tHolidayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tHolidayInfoesSelProc 
 */

CREATE PROCEDURE tHolidayInfoesSelProc
(
    @sGUID              char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           dStartTime,
           dEndTime,
           sName,
           dCreateDate,
           dUpdateTime,
           iEnable,
           sHHostInfoGUID,
           sDesc
      FROM tHolidayInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tHolidayTimeCtrlInfoesInsProc 
 */

CREATE PROCEDURE tHolidayTimeCtrlInfoesInsProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @iEnable              int                      = NULL,
    @dTime                datetime                 = NULL,
    @iState_Command       int                      = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sHolidayInfoGUID     char(36)                 = NULL,
    @sTagGUID             char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tHolidayTimeCtrlInfoes(sGUID,
                                       iID,
                                       iEnable,
                                       dTime,
                                       iState_Command,
                                       dCreateDate,
                                       dUpdateTime,
                                       sHolidayInfoGUID,
                                       sTagGUID,
                                       sDesc)
    VALUES(@sGUID,
           @iID,
           @iEnable,
           @dTime,
           @iState_Command,
           @dCreateDate,
           @dUpdateTime,
           @sHolidayInfoGUID,
           @sTagGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tHolidayTimeCtrlInfoesInsProc: Cannot insert because primary key value not found in tHolidayTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tHolidayTimeCtrlInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayTimeCtrlInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayTimeCtrlInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tHolidayTimeCtrlInfoesUpdProc 
 */

CREATE PROCEDURE tHolidayTimeCtrlInfoesUpdProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @iEnable              int                      = NULL,
    @dTime                datetime                 = NULL,
    @iState_Command       int                      = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sHolidayInfoGUID     char(36)                 = NULL,
    @sTagGUID             char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tHolidayTimeCtrlInfoes
       SET iID                   = @iID,
           iEnable               = @iEnable,
           dTime                 = @dTime,
           iState_Command        = @iState_Command,
           dCreateDate           = @dCreateDate,
           dUpdateTime           = @dUpdateTime,
           sHolidayInfoGUID      = @sHolidayInfoGUID,
           sTagGUID              = @sTagGUID,
           sDesc                 = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tHolidayTimeCtrlInfoesUpdProc: Cannot update  in tHolidayTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayTimeCtrlInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayTimeCtrlInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayTimeCtrlInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tHolidayTimeCtrlInfoesDelProc 
 */

CREATE PROCEDURE tHolidayTimeCtrlInfoesDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tHolidayTimeCtrlInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tHolidayTimeCtrlInfoesDelProc: Cannot delete because foreign keys still exist in tHolidayTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayTimeCtrlInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayTimeCtrlInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayTimeCtrlInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tHolidayTimeCtrlInfoesSelProc 
 */

CREATE PROCEDURE tHolidayTimeCtrlInfoesSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           iEnable,
           dTime,
           iState_Command,
           dCreateDate,
           dUpdateTime,
           sHolidayInfoGUID,
           sTagGUID,
           sDesc
      FROM tHolidayTimeCtrlInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tHolidayTimeCtrlInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHolidayTimeCtrlInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHolidayTimeCtrlInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tHostInfoInsProc 
 */

CREATE PROCEDURE tHostInfoInsProc
(
    @sGUID                  char(36),
    @sName                  nvarchar(100)            = NULL,
    @fLng                   float                    = NULL,
    @fLat                   float                    = NULL,
    @iIDType                int                      = NULL,
    @sID_ID                 varchar(20)              = NULL,
    @sID_Addr               nvarchar(100)            = NULL,
    @sID_IP                 nvarchar(100)            = NULL,
    @sID_MAC                nvarchar(100)            = NULL,
    @sID_SIM                nvarchar(100)            = NULL,
    @sHardware_Version      nvarchar(100)            = NULL,
    @iHardware_Type         int                      = NULL,
    @iState_Online          int                      = NULL,
    @iState_Alarm           int                      = NULL,
    @iState_Enable          int                      = NULL,
    @iState_Command         int                      = NULL,
    @sGroupInfoGUID         char(36)                 = NULL,
    @sProjectInfoGUID       char(36)                 = NULL,
    @dCreateDate            datetime                 = NULL,
    @dUpdateTime            datetime                 = NULL,
    @sRemark                nvarchar(500)            = NULL,
    @sHostInfoStateGUID     char(36)                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tHostInfo(sGUID,
                          sName,
                          fLng,
                          fLat,
                          iIDType,
                          sID_ID,
                          sID_Addr,
                          sID_IP,
                          sID_MAC,
                          sID_SIM,
                          sHardware_Version,
                          iHardware_Type,
                          iState_Online,
                          iState_Alarm,
                          iState_Enable,
                          iState_Command,
                          sGroupInfoGUID,
                          sProjectInfoGUID,
                          dCreateDate,
                          dUpdateTime,
                          sRemark,
                          sHostInfoStateGUID)
    VALUES(@sGUID,
           @sName,
           @fLng,
           @fLat,
           @iIDType,
           @sID_ID,
           @sID_Addr,
           @sID_IP,
           @sID_MAC,
           @sID_SIM,
           @sHardware_Version,
           @iHardware_Type,
           @iState_Online,
           @iState_Alarm,
           @iState_Enable,
           @iState_Command,
           @sGroupInfoGUID,
           @sProjectInfoGUID,
           @dCreateDate,
           @dUpdateTime,
           @sRemark,
           @sHostInfoStateGUID)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tHostInfoInsProc: Cannot insert because primary key value not found in tHostInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tHostInfoInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoInsProc >>>'
go


/* 
 * PROCEDURE: tHostInfoUpdProc 
 */

CREATE PROCEDURE tHostInfoUpdProc
(
    @sGUID                  char(36),
    @sName                  nvarchar(100)            = NULL,
    @fLng                   float                    = NULL,
    @fLat                   float                    = NULL,
    @iIDType                int                      = NULL,
    @sID_ID                 varchar(20)              = NULL,
    @sID_Addr               nvarchar(100)            = NULL,
    @sID_IP                 nvarchar(100)            = NULL,
    @sID_MAC                nvarchar(100)            = NULL,
    @sID_SIM                nvarchar(100)            = NULL,
    @sHardware_Version      nvarchar(100)            = NULL,
    @iHardware_Type         int                      = NULL,
    @iState_Online          int                      = NULL,
    @iState_Alarm           int                      = NULL,
    @iState_Enable          int                      = NULL,
    @iState_Command         int                      = NULL,
    @sGroupInfoGUID         char(36)                 = NULL,
    @sProjectInfoGUID       char(36)                 = NULL,
    @dCreateDate            datetime                 = NULL,
    @dUpdateTime            datetime                 = NULL,
    @sRemark                nvarchar(500)            = NULL,
    @sHostInfoStateGUID     char(36)                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tHostInfo
       SET sName                   = @sName,
           fLng                    = @fLng,
           fLat                    = @fLat,
           iIDType                 = @iIDType,
           sID_ID                  = @sID_ID,
           sID_Addr                = @sID_Addr,
           sID_IP                  = @sID_IP,
           sID_MAC                 = @sID_MAC,
           sID_SIM                 = @sID_SIM,
           sHardware_Version       = @sHardware_Version,
           iHardware_Type          = @iHardware_Type,
           iState_Online           = @iState_Online,
           iState_Alarm            = @iState_Alarm,
           iState_Enable           = @iState_Enable,
           iState_Command          = @iState_Command,
           sGroupInfoGUID          = @sGroupInfoGUID,
           sProjectInfoGUID        = @sProjectInfoGUID,
           dCreateDate             = @dCreateDate,
           dUpdateTime             = @dUpdateTime,
           sRemark                 = @sRemark,
           sHostInfoStateGUID      = @sHostInfoStateGUID
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tHostInfoUpdProc: Cannot update  in tHostInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoUpdProc >>>'
go


/* 
 * PROCEDURE: tHostInfoDelProc 
 */

CREATE PROCEDURE tHostInfoDelProc
(
    @sGUID                  char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tHostInfo
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tHostInfoDelProc: Cannot delete because foreign keys still exist in tHostInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoDelProc >>>'
go


/* 
 * PROCEDURE: tHostInfoSelProc 
 */

CREATE PROCEDURE tHostInfoSelProc
(
    @sGUID                  char(36))
AS
BEGIN
    SELECT sGUID,
           sName,
           fLng,
           fLat,
           iIDType,
           sID_ID,
           sID_Addr,
           sID_IP,
           sID_MAC,
           sID_SIM,
           sHardware_Version,
           iHardware_Type,
           iState_Online,
           iState_Alarm,
           iState_Enable,
           iState_Command,
           sGroupInfoGUID,
           sProjectInfoGUID,
           dCreateDate,
           dUpdateTime,
           sRemark,
           sHostInfoStateGUID
      FROM tHostInfo
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoSelProc >>>'
go


/* 
 * PROCEDURE: tHostInfoStateInsProc 
 */

CREATE PROCEDURE tHostInfoStateInsProc
(
    @sGUID                char(36),
    @sHostInfoGUID        char(36)                 = NULL,
    @iState_Online        int                      = NULL,
    @iFlag                int                      = NULL,
    @sState_Alarm         nvarchar(100)            = NULL,
    @sMeasureInfoGUID     nvarchar(200)            = NULL,
    @sSwitchInfoGUID      char(36)                 = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tHostInfoState(sGUID,
                               sHostInfoGUID,
                               iState_Online,
                               iFlag,
                               sState_Alarm,
                               sMeasureInfoGUID,
                               sSwitchInfoGUID,
                               dCreateDate,
                               dUpdateTime)
    VALUES(@sGUID,
           @sHostInfoGUID,
           @iState_Online,
           @iFlag,
           @sState_Alarm,
           @sMeasureInfoGUID,
           @sSwitchInfoGUID,
           @dCreateDate,
           @dUpdateTime)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tHostInfoStateInsProc: Cannot insert because primary key value not found in tHostInfoState '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tHostInfoStateInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoStateInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoStateInsProc >>>'
go


/* 
 * PROCEDURE: tHostInfoStateUpdProc 
 */

CREATE PROCEDURE tHostInfoStateUpdProc
(
    @sGUID                char(36),
    @sHostInfoGUID        char(36)                 = NULL,
    @iState_Online        int                      = NULL,
    @iFlag                int                      = NULL,
    @sState_Alarm         nvarchar(100)            = NULL,
    @sMeasureInfoGUID     nvarchar(200)            = NULL,
    @sSwitchInfoGUID      char(36)                 = NULL,
    @dCreateDate          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tHostInfoState
       SET sHostInfoGUID         = @sHostInfoGUID,
           iState_Online         = @iState_Online,
           iFlag                 = @iFlag,
           sState_Alarm          = @sState_Alarm,
           sMeasureInfoGUID      = @sMeasureInfoGUID,
           sSwitchInfoGUID       = @sSwitchInfoGUID,
           dCreateDate           = @dCreateDate,
           dUpdateTime           = @dUpdateTime
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tHostInfoStateUpdProc: Cannot update  in tHostInfoState '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoStateUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoStateUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoStateUpdProc >>>'
go


/* 
 * PROCEDURE: tHostInfoStateDelProc 
 */

CREATE PROCEDURE tHostInfoStateDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tHostInfoState
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tHostInfoStateDelProc: Cannot delete because foreign keys still exist in tHostInfoState '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoStateDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoStateDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoStateDelProc >>>'
go


/* 
 * PROCEDURE: tHostInfoStateSelProc 
 */

CREATE PROCEDURE tHostInfoStateSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           sHostInfoGUID,
           iState_Online,
           iFlag,
           sState_Alarm,
           sMeasureInfoGUID,
           sSwitchInfoGUID,
           dCreateDate,
           dUpdateTime
      FROM tHostInfoState
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tHostInfoStateSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostInfoStateSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostInfoStateSelProc >>>'
go


/* 
 * PROCEDURE: tHostSetInsProc 
 */

CREATE PROCEDURE tHostSetInsProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sHostGUID       char(36)                 = NULL,
    @sDesc           nvarchar(100)            = NULL,
    @dCreateDate     datetime                 = NULL,
    @dUpdateDate     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tHostSet(sGUID,
                         sKey,
                         sValue,
                         sHostGUID,
                         sDesc,
                         dCreateDate,
                         dUpdateDate)
    VALUES(@sGUID,
           @sKey,
           @sValue,
           @sHostGUID,
           @sDesc,
           @dCreateDate,
           @dUpdateDate)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tHostSetInsProc: Cannot insert because primary key value not found in tHostSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tHostSetInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostSetInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostSetInsProc >>>'
go


/* 
 * PROCEDURE: tHostSetUpdProc 
 */

CREATE PROCEDURE tHostSetUpdProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sHostGUID       char(36)                 = NULL,
    @sDesc           nvarchar(100)            = NULL,
    @dCreateDate     datetime                 = NULL,
    @dUpdateDate     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tHostSet
       SET sKey             = @sKey,
           sValue           = @sValue,
           sHostGUID        = @sHostGUID,
           sDesc            = @sDesc,
           dCreateDate      = @dCreateDate,
           dUpdateDate      = @dUpdateDate
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tHostSetUpdProc: Cannot update  in tHostSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostSetUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostSetUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostSetUpdProc >>>'
go


/* 
 * PROCEDURE: tHostSetDelProc 
 */

CREATE PROCEDURE tHostSetDelProc
(
    @sGUID           char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tHostSet
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tHostSetDelProc: Cannot delete because foreign keys still exist in tHostSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tHostSetDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostSetDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostSetDelProc >>>'
go


/* 
 * PROCEDURE: tHostSetSelProc 
 */

CREATE PROCEDURE tHostSetSelProc
(
    @sGUID           char(36))
AS
BEGIN
    SELECT sGUID,
           sKey,
           sValue,
           sHostGUID,
           sDesc,
           dCreateDate,
           dUpdateDate
      FROM tHostSet
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tHostSetSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tHostSetSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tHostSetSelProc >>>'
go


/* 
 * PROCEDURE: tJurisdictionInsProc 
 */

CREATE PROCEDURE tJurisdictionInsProc
(
    @sGUID                    char(36),
    @sJurisdictionType        int                      = NULL,
    @sJurisdictionContent     nvarchar(100)            = NULL,
    @sPrjectGUID              char(36)                 = NULL,
    @sDesc                    nvarchar(500)            = NULL,
    @dCreateTime              datetime                 = NULL,
    @dUpdateTime              datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tJurisdiction(sGUID,
                              sJurisdictionType,
                              sJurisdictionContent,
                              sPrjectGUID,
                              sDesc,
                              dCreateTime,
                              dUpdateTime)
    VALUES(@sGUID,
           @sJurisdictionType,
           @sJurisdictionContent,
           @sPrjectGUID,
           @sDesc,
           @dCreateTime,
           @dUpdateTime)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tJurisdictionInsProc: Cannot insert because primary key value not found in tJurisdiction '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tJurisdictionInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tJurisdictionInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tJurisdictionInsProc >>>'
go


/* 
 * PROCEDURE: tJurisdictionUpdProc 
 */

CREATE PROCEDURE tJurisdictionUpdProc
(
    @sGUID                    char(36),
    @sJurisdictionType        int                      = NULL,
    @sJurisdictionContent     nvarchar(100)            = NULL,
    @sPrjectGUID              char(36)                 = NULL,
    @sDesc                    nvarchar(500)            = NULL,
    @dCreateTime              datetime                 = NULL,
    @dUpdateTime              datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tJurisdiction
       SET sJurisdictionType         = @sJurisdictionType,
           sJurisdictionContent      = @sJurisdictionContent,
           sPrjectGUID               = @sPrjectGUID,
           sDesc                     = @sDesc,
           dCreateTime               = @dCreateTime,
           dUpdateTime               = @dUpdateTime
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tJurisdictionUpdProc: Cannot update  in tJurisdiction '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tJurisdictionUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tJurisdictionUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tJurisdictionUpdProc >>>'
go


/* 
 * PROCEDURE: tJurisdictionDelProc 
 */

CREATE PROCEDURE tJurisdictionDelProc
(
    @sGUID                    char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tJurisdiction
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tJurisdictionDelProc: Cannot delete because foreign keys still exist in tJurisdiction '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tJurisdictionDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tJurisdictionDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tJurisdictionDelProc >>>'
go


/* 
 * PROCEDURE: tJurisdictionSelProc 
 */

CREATE PROCEDURE tJurisdictionSelProc
(
    @sGUID                    char(36))
AS
BEGIN
    SELECT sGUID,
           sJurisdictionType,
           sJurisdictionContent,
           sPrjectGUID,
           sDesc,
           dCreateTime,
           dUpdateTime
      FROM tJurisdiction
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tJurisdictionSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tJurisdictionSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tJurisdictionSelProc >>>'
go


/* 
 * PROCEDURE: tLatLngTimeCtrlInfoesInsProc 
 */

CREATE PROCEDURE tLatLngTimeCtrlInfoesInsProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @iTimeType          int                      = NULL,
    @iOffset            int                      = NULL,
    @iEnable            int                      = NULL,
    @iState_Command     float                    = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @sTagGUID           char(36)                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tLatLngTimeCtrlInfoes(sGUID,
                                      iID,
                                      iTimeType,
                                      iOffset,
                                      iEnable,
                                      iState_Command,
                                      dCreateDate,
                                      dUpdateTime,
                                      sTagGUID,
                                      sDesc)
    VALUES(@sGUID,
           @iID,
           @iTimeType,
           @iOffset,
           @iEnable,
           @iState_Command,
           @dCreateDate,
           @dUpdateTime,
           @sTagGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tLatLngTimeCtrlInfoesInsProc: Cannot insert because primary key value not found in tLatLngTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tLatLngTimeCtrlInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLatLngTimeCtrlInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLatLngTimeCtrlInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tLatLngTimeCtrlInfoesUpdProc 
 */

CREATE PROCEDURE tLatLngTimeCtrlInfoesUpdProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @iTimeType          int                      = NULL,
    @iOffset            int                      = NULL,
    @iEnable            int                      = NULL,
    @iState_Command     float                    = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @sTagGUID           char(36)                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tLatLngTimeCtrlInfoes
       SET iID                 = @iID,
           iTimeType           = @iTimeType,
           iOffset             = @iOffset,
           iEnable             = @iEnable,
           iState_Command      = @iState_Command,
           dCreateDate         = @dCreateDate,
           dUpdateTime         = @dUpdateTime,
           sTagGUID            = @sTagGUID,
           sDesc               = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tLatLngTimeCtrlInfoesUpdProc: Cannot update  in tLatLngTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLatLngTimeCtrlInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLatLngTimeCtrlInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLatLngTimeCtrlInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tLatLngTimeCtrlInfoesDelProc 
 */

CREATE PROCEDURE tLatLngTimeCtrlInfoesDelProc
(
    @sGUID              char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tLatLngTimeCtrlInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tLatLngTimeCtrlInfoesDelProc: Cannot delete because foreign keys still exist in tLatLngTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLatLngTimeCtrlInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLatLngTimeCtrlInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLatLngTimeCtrlInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tLatLngTimeCtrlInfoesSelProc 
 */

CREATE PROCEDURE tLatLngTimeCtrlInfoesSelProc
(
    @sGUID              char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           iTimeType,
           iOffset,
           iEnable,
           iState_Command,
           dCreateDate,
           dUpdateTime,
           sTagGUID,
           sDesc
      FROM tLatLngTimeCtrlInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tLatLngTimeCtrlInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLatLngTimeCtrlInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLatLngTimeCtrlInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tLightGroupInfoesInsProc 
 */

CREATE PROCEDURE tLightGroupInfoesInsProc
(
    @sGUID             char(36),
    @sName             nvarchar(100)            = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @sID               varchar(10)              = NULL,
    @dCreateTime       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tLightGroupInfoes(sGUID,
                                  sName,
                                  sHostInfoGUID,
                                  sID,
                                  dCreateTime,
                                  dUpdateTime,
                                  sRemark)
    VALUES(@sGUID,
           @sName,
           @sHostInfoGUID,
           @sID,
           @dCreateTime,
           @dUpdateTime,
           @sRemark)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tLightGroupInfoesInsProc: Cannot insert because primary key value not found in tLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tLightGroupInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightGroupInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightGroupInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tLightGroupInfoesUpdProc 
 */

CREATE PROCEDURE tLightGroupInfoesUpdProc
(
    @sGUID             char(36),
    @sName             nvarchar(100)            = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @sID               varchar(10)              = NULL,
    @dCreateTime       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tLightGroupInfoes
       SET sName              = @sName,
           sHostInfoGUID      = @sHostInfoGUID,
           sID                = @sID,
           dCreateTime        = @dCreateTime,
           dUpdateTime        = @dUpdateTime,
           sRemark            = @sRemark
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tLightGroupInfoesUpdProc: Cannot update  in tLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightGroupInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightGroupInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightGroupInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tLightGroupInfoesDelProc 
 */

CREATE PROCEDURE tLightGroupInfoesDelProc
(
    @sGUID             char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tLightGroupInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tLightGroupInfoesDelProc: Cannot delete because foreign keys still exist in tLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightGroupInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightGroupInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightGroupInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tLightGroupInfoesSelProc 
 */

CREATE PROCEDURE tLightGroupInfoesSelProc
(
    @sGUID             char(36))
AS
BEGIN
    SELECT sGUID,
           sName,
           sHostInfoGUID,
           sID,
           dCreateTime,
           dUpdateTime,
           sRemark
      FROM tLightGroupInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tLightGroupInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightGroupInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightGroupInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tLightInfoesInsProc 
 */

CREATE PROCEDURE tLightInfoesInsProc
(
    @sGUID                             char(36),
    @sName                             nvarchar(100)            = NULL,
    @sLightID                          nvarchar(100)            = NULL,
    @sLightPhyID                       nvarchar(50)             = NULL,
    @fLng                              float                    = NULL,
    @fLat                              float                    = NULL,
    @sAddr                             nvarchar(100)            = NULL,
    @iState_Command                    int                      = NULL,
    @iAlarmConfig_Config               int                      = NULL,
    @dAlarmConfig_Start                datetime                 = NULL,
    @dAlarmConfig_End                  datetime                 = NULL,
    @sAlarmConfig_Remark               nvarchar(500)            = NULL,
    @iRealTimeAlarm_FaultState         int                      = NULL,
    @iRealTimeAlarm_Fault              int                      = NULL,
    @iRealTimeAlarm_CreateDateTime     datetime                 = NULL,
    @sHostInfoGUID                     char(36)                 = NULL,
    @sStateGUID                        char(36)                 = NULL,
    @dCreateTime                       datetime                 = NULL,
    @dUpdateTime                       datetime                 = NULL,
    @sRemark                           nvarchar(500)            = NULL,
    @sHardware_Version                 nvarchar(200)            = NULL,
    @iHardware_Type                    int                      = NULL,
    @iEnable                           int                      = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tLightInfoes(sGUID,
                             sName,
                             sLightID,
                             sLightPhyID,
                             fLng,
                             fLat,
                             sAddr,
                             iState_Command,
                             iAlarmConfig_Config,
                             dAlarmConfig_Start,
                             dAlarmConfig_End,
                             sAlarmConfig_Remark,
                             iRealTimeAlarm_FaultState,
                             iRealTimeAlarm_Fault,
                             iRealTimeAlarm_CreateDateTime,
                             sHostInfoGUID,
                             sStateGUID,
                             dCreateTime,
                             dUpdateTime,
                             sRemark,
                             sHardware_Version,
                             iHardware_Type,
                             iEnable)
    VALUES(@sGUID,
           @sName,
           @sLightID,
           @sLightPhyID,
           @fLng,
           @fLat,
           @sAddr,
           @iState_Command,
           @iAlarmConfig_Config,
           @dAlarmConfig_Start,
           @dAlarmConfig_End,
           @sAlarmConfig_Remark,
           @iRealTimeAlarm_FaultState,
           @iRealTimeAlarm_Fault,
           @iRealTimeAlarm_CreateDateTime,
           @sHostInfoGUID,
           @sStateGUID,
           @dCreateTime,
           @dUpdateTime,
           @sRemark,
           @sHardware_Version,
           @iHardware_Type,
           @iEnable)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tLightInfoesInsProc: Cannot insert because primary key value not found in tLightInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tLightInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tLightInfoesUpdProc 
 */

CREATE PROCEDURE tLightInfoesUpdProc
(
    @sGUID                             char(36),
    @sName                             nvarchar(100)            = NULL,
    @sLightID                          nvarchar(100)            = NULL,
    @sLightPhyID                       nvarchar(50)             = NULL,
    @fLng                              float                    = NULL,
    @fLat                              float                    = NULL,
    @sAddr                             nvarchar(100)            = NULL,
    @iState_Command                    int                      = NULL,
    @iAlarmConfig_Config               int                      = NULL,
    @dAlarmConfig_Start                datetime                 = NULL,
    @dAlarmConfig_End                  datetime                 = NULL,
    @sAlarmConfig_Remark               nvarchar(500)            = NULL,
    @iRealTimeAlarm_FaultState         int                      = NULL,
    @iRealTimeAlarm_Fault              int                      = NULL,
    @iRealTimeAlarm_CreateDateTime     datetime                 = NULL,
    @sHostInfoGUID                     char(36)                 = NULL,
    @sStateGUID                        char(36)                 = NULL,
    @dCreateTime                       datetime                 = NULL,
    @dUpdateTime                       datetime                 = NULL,
    @sRemark                           nvarchar(500)            = NULL,
    @sHardware_Version                 nvarchar(200)            = NULL,
    @iHardware_Type                    int                      = NULL,
    @iEnable                           int                      = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tLightInfoes
       SET sName                              = @sName,
           sLightID                           = @sLightID,
           sLightPhyID                        = @sLightPhyID,
           fLng                               = @fLng,
           fLat                               = @fLat,
           sAddr                              = @sAddr,
           iState_Command                     = @iState_Command,
           iAlarmConfig_Config                = @iAlarmConfig_Config,
           dAlarmConfig_Start                 = @dAlarmConfig_Start,
           dAlarmConfig_End                   = @dAlarmConfig_End,
           sAlarmConfig_Remark                = @sAlarmConfig_Remark,
           iRealTimeAlarm_FaultState          = @iRealTimeAlarm_FaultState,
           iRealTimeAlarm_Fault               = @iRealTimeAlarm_Fault,
           iRealTimeAlarm_CreateDateTime      = @iRealTimeAlarm_CreateDateTime,
           sHostInfoGUID                      = @sHostInfoGUID,
           sStateGUID                         = @sStateGUID,
           dCreateTime                        = @dCreateTime,
           dUpdateTime                        = @dUpdateTime,
           sRemark                            = @sRemark,
           sHardware_Version                  = @sHardware_Version,
           iHardware_Type                     = @iHardware_Type,
           iEnable                            = @iEnable
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tLightInfoesUpdProc: Cannot update  in tLightInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tLightInfoesDelProc 
 */

CREATE PROCEDURE tLightInfoesDelProc
(
    @sGUID                             char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tLightInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tLightInfoesDelProc: Cannot delete because foreign keys still exist in tLightInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tLightInfoesSelProc 
 */

CREATE PROCEDURE tLightInfoesSelProc
(
    @sGUID                             char(36))
AS
BEGIN
    SELECT sGUID,
           sName,
           sLightID,
           sLightPhyID,
           fLng,
           fLat,
           sAddr,
           iState_Command,
           iAlarmConfig_Config,
           dAlarmConfig_Start,
           dAlarmConfig_End,
           sAlarmConfig_Remark,
           iRealTimeAlarm_FaultState,
           iRealTimeAlarm_Fault,
           iRealTimeAlarm_CreateDateTime,
           sHostInfoGUID,
           sStateGUID,
           dCreateTime,
           dUpdateTime,
           sRemark,
           sHardware_Version,
           iHardware_Type,
           iEnable
      FROM tLightInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tLightInfoLightGroupInfoesInsProc 
 */

CREATE PROCEDURE tLightInfoLightGroupInfoesInsProc
(
    @sGUID                   char(36),
    @sLightInfoGUID          char(36),
    @sLightGroupInfoGUID     char(36),
    @dCreateTime             datetime            = NULL,
    @dUpdateTime             datetime            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tLightInfoLightGroupInfoes(sGUID,
                                           sLightInfoGUID,
                                           sLightGroupInfoGUID,
                                           dCreateTime,
                                           dUpdateTime)
    VALUES(@sGUID,
           @sLightInfoGUID,
           @sLightGroupInfoGUID,
           @dCreateTime,
           @dUpdateTime)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tLightInfoLightGroupInfoesInsProc: Cannot insert because primary key value not found in tLightInfoLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tLightInfoLightGroupInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoLightGroupInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoLightGroupInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tLightInfoLightGroupInfoesUpdProc 
 */

CREATE PROCEDURE tLightInfoLightGroupInfoesUpdProc
(
    @sGUID                   char(36),
    @sLightInfoGUID          char(36),
    @sLightGroupInfoGUID     char(36),
    @dCreateTime             datetime            = NULL,
    @dUpdateTime             datetime            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tLightInfoLightGroupInfoes
       SET sLightInfoGUID           = @sLightInfoGUID,
           sLightGroupInfoGUID      = @sLightGroupInfoGUID,
           dCreateTime              = @dCreateTime,
           dUpdateTime              = @dUpdateTime
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tLightInfoLightGroupInfoesUpdProc: Cannot update  in tLightInfoLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoLightGroupInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoLightGroupInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoLightGroupInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tLightInfoLightGroupInfoesDelProc 
 */

CREATE PROCEDURE tLightInfoLightGroupInfoesDelProc
(
    @sGUID                   char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tLightInfoLightGroupInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tLightInfoLightGroupInfoesDelProc: Cannot delete because foreign keys still exist in tLightInfoLightGroupInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoLightGroupInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoLightGroupInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoLightGroupInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tLightInfoLightGroupInfoesSelProc 
 */

CREATE PROCEDURE tLightInfoLightGroupInfoesSelProc
(
    @sGUID                   char(36))
AS
BEGIN
    SELECT sGUID,
           sLightInfoGUID,
           sLightGroupInfoGUID,
           dCreateTime,
           dUpdateTime
      FROM tLightInfoLightGroupInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tLightInfoLightGroupInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightInfoLightGroupInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightInfoLightGroupInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tLightStateInfoesInsProc 
 */

CREATE PROCEDURE tLightStateInfoesInsProc
(
    @sGUID              char(36),
    @fVoltage           float                   = NULL,
    @fCurrent           float                   = NULL,
    @fPower             float                   = NULL,
    @iFault             int                     = NULL,
    @dCreateDate        datetime                = NULL,
    @dUpdateTime        datetime                = NULL,
    @sLightInfoGUID     char(36)                = NULL,
    @sSpareField1       nvarchar(50)            = NULL,
    @sSpareField2       nvarchar(50)            = NULL,
    @sSpareField3       nvarchar(50)            = NULL,
    @sSpareField4       nvarchar(50)            = NULL,
    @sSpareField5       nvarchar(50)            = NULL,
    @sSpareField6       nvarchar(50)            = NULL,
    @sSpareField7       nvarchar(50)            = NULL,
    @sSpareField8       nvarchar(50)            = NULL,
    @sSpareField9       nvarchar(50)            = NULL,
    @sSpareField10      nvarchar(50)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tLightStateInfoes(sGUID,
                                  fVoltage,
                                  fCurrent,
                                  fPower,
                                  iFault,
                                  dCreateDate,
                                  dUpdateTime,
                                  sLightInfoGUID,
                                  sSpareField1,
                                  sSpareField2,
                                  sSpareField3,
                                  sSpareField4,
                                  sSpareField5,
                                  sSpareField6,
                                  sSpareField7,
                                  sSpareField8,
                                  sSpareField9,
                                  sSpareField10)
    VALUES(@sGUID,
           @fVoltage,
           @fCurrent,
           @fPower,
           @iFault,
           @dCreateDate,
           @dUpdateTime,
           @sLightInfoGUID,
           @sSpareField1,
           @sSpareField2,
           @sSpareField3,
           @sSpareField4,
           @sSpareField5,
           @sSpareField6,
           @sSpareField7,
           @sSpareField8,
           @sSpareField9,
           @sSpareField10)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tLightStateInfoesInsProc: Cannot insert because primary key value not found in tLightStateInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tLightStateInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightStateInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightStateInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tLightStateInfoesUpdProc 
 */

CREATE PROCEDURE tLightStateInfoesUpdProc
(
    @sGUID              char(36),
    @fVoltage           float                   = NULL,
    @fCurrent           float                   = NULL,
    @fPower             float                   = NULL,
    @iFault             int                     = NULL,
    @dCreateDate        datetime                = NULL,
    @dUpdateTime        datetime                = NULL,
    @sLightInfoGUID     char(36)                = NULL,
    @sSpareField1       nvarchar(50)            = NULL,
    @sSpareField2       nvarchar(50)            = NULL,
    @sSpareField3       nvarchar(50)            = NULL,
    @sSpareField4       nvarchar(50)            = NULL,
    @sSpareField5       nvarchar(50)            = NULL,
    @sSpareField6       nvarchar(50)            = NULL,
    @sSpareField7       nvarchar(50)            = NULL,
    @sSpareField8       nvarchar(50)            = NULL,
    @sSpareField9       nvarchar(50)            = NULL,
    @sSpareField10      nvarchar(50)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tLightStateInfoes
       SET fVoltage            = @fVoltage,
           fCurrent            = @fCurrent,
           fPower              = @fPower,
           iFault              = @iFault,
           dCreateDate         = @dCreateDate,
           dUpdateTime         = @dUpdateTime,
           sLightInfoGUID      = @sLightInfoGUID,
           sSpareField1        = @sSpareField1,
           sSpareField2        = @sSpareField2,
           sSpareField3        = @sSpareField3,
           sSpareField4        = @sSpareField4,
           sSpareField5        = @sSpareField5,
           sSpareField6        = @sSpareField6,
           sSpareField7        = @sSpareField7,
           sSpareField8        = @sSpareField8,
           sSpareField9        = @sSpareField9,
           sSpareField10       = @sSpareField10
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tLightStateInfoesUpdProc: Cannot update  in tLightStateInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightStateInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightStateInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightStateInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tLightStateInfoesDelProc 
 */

CREATE PROCEDURE tLightStateInfoesDelProc
(
    @sGUID              char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tLightStateInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tLightStateInfoesDelProc: Cannot delete because foreign keys still exist in tLightStateInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tLightStateInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightStateInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightStateInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tLightStateInfoesSelProc 
 */

CREATE PROCEDURE tLightStateInfoesSelProc
(
    @sGUID              char(36))
AS
BEGIN
    SELECT sGUID,
           fVoltage,
           fCurrent,
           fPower,
           iFault,
           dCreateDate,
           dUpdateTime,
           sLightInfoGUID,
           sSpareField1,
           sSpareField2,
           sSpareField3,
           sSpareField4,
           sSpareField5,
           sSpareField6,
           sSpareField7,
           sSpareField8,
           sSpareField9,
           sSpareField10
      FROM tLightStateInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tLightStateInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tLightStateInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tLightStateInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tMeasureConfigsInsProc 
 */

CREATE PROCEDURE tMeasureConfigsInsProc
(
    @sGUID               char(36),
    @fVoltHI             float                    = NULL,
    @fVoltLO             float                    = NULL,
    @iAlarmDelayTime     int                      = NULL,
    @iMeasureNumber      int                      = NULL,
    @iBranchNumber       char(10)                 = NULL,
    @iState_Command      int                      = NULL,
    @dCreateDate         datetime                 = NULL,
    @dUpdateTime         datetime                 = NULL,
    @sHostInfoGUID       char(36)                 = NULL,
    @sDesc               nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tMeasureConfigs(sGUID,
                                fVoltHI,
                                fVoltLO,
                                iAlarmDelayTime,
                                iMeasureNumber,
                                iBranchNumber,
                                iState_Command,
                                dCreateDate,
                                dUpdateTime,
                                sHostInfoGUID,
                                sDesc)
    VALUES(@sGUID,
           @fVoltHI,
           @fVoltLO,
           @iAlarmDelayTime,
           @iMeasureNumber,
           @iBranchNumber,
           @iState_Command,
           @dCreateDate,
           @dUpdateTime,
           @sHostInfoGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tMeasureConfigsInsProc: Cannot insert because primary key value not found in tMeasureConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tMeasureConfigsInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureConfigsInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureConfigsInsProc >>>'
go


/* 
 * PROCEDURE: tMeasureConfigsUpdProc 
 */

CREATE PROCEDURE tMeasureConfigsUpdProc
(
    @sGUID               char(36),
    @fVoltHI             float                    = NULL,
    @fVoltLO             float                    = NULL,
    @iAlarmDelayTime     int                      = NULL,
    @iMeasureNumber      int                      = NULL,
    @iBranchNumber       char(10)                 = NULL,
    @iState_Command      int                      = NULL,
    @dCreateDate         datetime                 = NULL,
    @dUpdateTime         datetime                 = NULL,
    @sHostInfoGUID       char(36)                 = NULL,
    @sDesc               nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tMeasureConfigs
       SET fVoltHI              = @fVoltHI,
           fVoltLO              = @fVoltLO,
           iAlarmDelayTime      = @iAlarmDelayTime,
           iMeasureNumber       = @iMeasureNumber,
           iBranchNumber        = @iBranchNumber,
           iState_Command       = @iState_Command,
           dCreateDate          = @dCreateDate,
           dUpdateTime          = @dUpdateTime,
           sHostInfoGUID        = @sHostInfoGUID,
           sDesc                = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tMeasureConfigsUpdProc: Cannot update  in tMeasureConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureConfigsUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureConfigsUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureConfigsUpdProc >>>'
go


/* 
 * PROCEDURE: tMeasureConfigsDelProc 
 */

CREATE PROCEDURE tMeasureConfigsDelProc
(
    @sGUID               char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tMeasureConfigs
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tMeasureConfigsDelProc: Cannot delete because foreign keys still exist in tMeasureConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureConfigsDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureConfigsDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureConfigsDelProc >>>'
go


/* 
 * PROCEDURE: tMeasureConfigsSelProc 
 */

CREATE PROCEDURE tMeasureConfigsSelProc
(
    @sGUID               char(36))
AS
BEGIN
    SELECT sGUID,
           fVoltHI,
           fVoltLO,
           iAlarmDelayTime,
           iMeasureNumber,
           iBranchNumber,
           iState_Command,
           dCreateDate,
           dUpdateTime,
           sHostInfoGUID,
           sDesc
      FROM tMeasureConfigs
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureConfigsSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureConfigsSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureConfigsSelProc >>>'
go


/* 
 * PROCEDURE: tMeasureCurrentInfoesInsProc 
 */

CREATE PROCEDURE tMeasureCurrentInfoesInsProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @fValue               float                    = NULL,
    @iAlarm               float                    = NULL,
    @sMeasureInfoGUID     char(36)                 = NULL,
    @dCreateTime          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tMeasureCurrentInfoes(sGUID,
                                      iID,
                                      fValue,
                                      iAlarm,
                                      sMeasureInfoGUID,
                                      dCreateTime,
                                      dUpdateTime,
                                      sDesc)
    VALUES(@sGUID,
           @iID,
           @fValue,
           @iAlarm,
           @sMeasureInfoGUID,
           @dCreateTime,
           @dUpdateTime,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tMeasureCurrentInfoesInsProc: Cannot insert because primary key value not found in tMeasureCurrentInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tMeasureCurrentInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureCurrentInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureCurrentInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tMeasureCurrentInfoesUpdProc 
 */

CREATE PROCEDURE tMeasureCurrentInfoesUpdProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @fValue               float                    = NULL,
    @iAlarm               float                    = NULL,
    @sMeasureInfoGUID     char(36)                 = NULL,
    @dCreateTime          datetime                 = NULL,
    @dUpdateTime          datetime                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tMeasureCurrentInfoes
       SET iID                   = @iID,
           fValue                = @fValue,
           iAlarm                = @iAlarm,
           sMeasureInfoGUID      = @sMeasureInfoGUID,
           dCreateTime           = @dCreateTime,
           dUpdateTime           = @dUpdateTime,
           sDesc                 = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tMeasureCurrentInfoesUpdProc: Cannot update  in tMeasureCurrentInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureCurrentInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureCurrentInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureCurrentInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tMeasureCurrentInfoesDelProc 
 */

CREATE PROCEDURE tMeasureCurrentInfoesDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tMeasureCurrentInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tMeasureCurrentInfoesDelProc: Cannot delete because foreign keys still exist in tMeasureCurrentInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureCurrentInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureCurrentInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureCurrentInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tMeasureCurrentInfoesSelProc 
 */

CREATE PROCEDURE tMeasureCurrentInfoesSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           fValue,
           iAlarm,
           sMeasureInfoGUID,
           dCreateTime,
           dUpdateTime,
           sDesc
      FROM tMeasureCurrentInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureCurrentInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureCurrentInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureCurrentInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tMeasureInfoesInsProc 
 */

CREATE PROCEDURE tMeasureInfoesInsProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @fVlotA            float                    = NULL,
    @fVlotB            float                    = NULL,
    @fVlotC            float                    = NULL,
    @iAlarmVlotA       int                      = NULL,
    @iAlarmVlotB       int                      = NULL,
    @iAlarmVlotC       int                      = NULL,
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @sDesc             nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tMeasureInfoes(sGUID,
                               iID,
                               fVlotA,
                               fVlotB,
                               fVlotC,
                               iAlarmVlotA,
                               iAlarmVlotB,
                               iAlarmVlotC,
                               dCreateDate,
                               dUpdateTime,
                               sHostInfoGUID,
                               sDesc)
    VALUES(@sGUID,
           @iID,
           @fVlotA,
           @fVlotB,
           @fVlotC,
           @iAlarmVlotA,
           @iAlarmVlotB,
           @iAlarmVlotC,
           @dCreateDate,
           @dUpdateTime,
           @sHostInfoGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tMeasureInfoesInsProc: Cannot insert because primary key value not found in tMeasureInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tMeasureInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tMeasureInfoesUpdProc 
 */

CREATE PROCEDURE tMeasureInfoesUpdProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @fVlotA            float                    = NULL,
    @fVlotB            float                    = NULL,
    @fVlotC            float                    = NULL,
    @iAlarmVlotA       int                      = NULL,
    @iAlarmVlotB       int                      = NULL,
    @iAlarmVlotC       int                      = NULL,
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @sDesc             nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tMeasureInfoes
       SET iID                = @iID,
           fVlotA             = @fVlotA,
           fVlotB             = @fVlotB,
           fVlotC             = @fVlotC,
           iAlarmVlotA        = @iAlarmVlotA,
           iAlarmVlotB        = @iAlarmVlotB,
           iAlarmVlotC        = @iAlarmVlotC,
           dCreateDate        = @dCreateDate,
           dUpdateTime        = @dUpdateTime,
           sHostInfoGUID      = @sHostInfoGUID,
           sDesc              = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tMeasureInfoesUpdProc: Cannot update  in tMeasureInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tMeasureInfoesDelProc 
 */

CREATE PROCEDURE tMeasureInfoesDelProc
(
    @sGUID             char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tMeasureInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tMeasureInfoesDelProc: Cannot delete because foreign keys still exist in tMeasureInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tMeasureInfoesSelProc 
 */

CREATE PROCEDURE tMeasureInfoesSelProc
(
    @sGUID             char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           fVlotA,
           fVlotB,
           fVlotC,
           iAlarmVlotA,
           iAlarmVlotB,
           iAlarmVlotC,
           dCreateDate,
           dUpdateTime,
           sHostInfoGUID,
           sDesc
      FROM tMeasureInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tMeasureInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasureInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasureInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tMeasurePowerInfoesInsProc 
 */

CREATE PROCEDURE tMeasurePowerInfoesInsProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @fValue               float                    = NULL,
    @sMeasureInfoGUID     char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tMeasurePowerInfoes(sGUID,
                                    iID,
                                    fValue,
                                    sMeasureInfoGUID,
                                    sDesc)
    VALUES(@sGUID,
           @iID,
           @fValue,
           @sMeasureInfoGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tMeasurePowerInfoesInsProc: Cannot insert because primary key value not found in tMeasurePowerInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tMeasurePowerInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasurePowerInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasurePowerInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tMeasurePowerInfoesUpdProc 
 */

CREATE PROCEDURE tMeasurePowerInfoesUpdProc
(
    @sGUID                char(36),
    @iID                  int                      = NULL,
    @fValue               float                    = NULL,
    @sMeasureInfoGUID     char(36)                 = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tMeasurePowerInfoes
       SET iID                   = @iID,
           fValue                = @fValue,
           sMeasureInfoGUID      = @sMeasureInfoGUID,
           sDesc                 = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tMeasurePowerInfoesUpdProc: Cannot update  in tMeasurePowerInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasurePowerInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasurePowerInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasurePowerInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tMeasurePowerInfoesDelProc 
 */

CREATE PROCEDURE tMeasurePowerInfoesDelProc
(
    @sGUID                char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tMeasurePowerInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tMeasurePowerInfoesDelProc: Cannot delete because foreign keys still exist in tMeasurePowerInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tMeasurePowerInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasurePowerInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasurePowerInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tMeasurePowerInfoesSelProc 
 */

CREATE PROCEDURE tMeasurePowerInfoesSelProc
(
    @sGUID                char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           fValue,
           sMeasureInfoGUID,
           sDesc
      FROM tMeasurePowerInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tMeasurePowerInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tMeasurePowerInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tMeasurePowerInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tPrjectInfoInsProc 
 */

CREATE PROCEDURE tPrjectInfoInsProc
(
    @sGUID           char(36),
    @sID             nvarchar(100)            = NULL,
    @sName           nvarchar(100)            = NULL,
    @sAuthor         nvarchar(100)            = NULL,
    @fLng            float                    = NULL,
    @fLat            float                    = NULL,
    @dCreateDate     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL,
    @sRemark         nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tPrjectInfo(sGUID,
                            sID,
                            sName,
                            sAuthor,
                            fLng,
                            fLat,
                            dCreateDate,
                            dUpdateTime,
                            sRemark)
    VALUES(@sGUID,
           @sID,
           @sName,
           @sAuthor,
           @fLng,
           @fLat,
           @dCreateDate,
           @dUpdateTime,
           @sRemark)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tPrjectInfoInsProc: Cannot insert because primary key value not found in tPrjectInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tPrjectInfoInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectInfoInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectInfoInsProc >>>'
go


/* 
 * PROCEDURE: tPrjectInfoUpdProc 
 */

CREATE PROCEDURE tPrjectInfoUpdProc
(
    @sGUID           char(36),
    @sID             nvarchar(100)            = NULL,
    @sName           nvarchar(100)            = NULL,
    @sAuthor         nvarchar(100)            = NULL,
    @fLng            float                    = NULL,
    @fLat            float                    = NULL,
    @dCreateDate     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL,
    @sRemark         nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tPrjectInfo
       SET sID              = @sID,
           sName            = @sName,
           sAuthor          = @sAuthor,
           fLng             = @fLng,
           fLat             = @fLat,
           dCreateDate      = @dCreateDate,
           dUpdateTime      = @dUpdateTime,
           sRemark          = @sRemark
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tPrjectInfoUpdProc: Cannot update  in tPrjectInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectInfoUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectInfoUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectInfoUpdProc >>>'
go


/* 
 * PROCEDURE: tPrjectInfoDelProc 
 */

CREATE PROCEDURE tPrjectInfoDelProc
(
    @sGUID           char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tPrjectInfo
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tPrjectInfoDelProc: Cannot delete because foreign keys still exist in tPrjectInfo '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectInfoDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectInfoDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectInfoDelProc >>>'
go


/* 
 * PROCEDURE: tPrjectInfoSelProc 
 */

CREATE PROCEDURE tPrjectInfoSelProc
(
    @sGUID           char(36))
AS
BEGIN
    SELECT sGUID,
           sID,
           sName,
           sAuthor,
           fLng,
           fLat,
           dCreateDate,
           dUpdateTime,
           sRemark
      FROM tPrjectInfo
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectInfoSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectInfoSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectInfoSelProc >>>'
go


/* 
 * PROCEDURE: tPrjectSetInsProc 
 */

CREATE PROCEDURE tPrjectSetInsProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sPrjectGUID     char(36)                 = NULL,
    @sDesc           nvarchar(500)            = NULL,
    @dCreateTime     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tPrjectSet(sGUID,
                           sKey,
                           sValue,
                           sPrjectGUID,
                           sDesc,
                           dCreateTime,
                           dUpdateTime)
    VALUES(@sGUID,
           @sKey,
           @sValue,
           @sPrjectGUID,
           @sDesc,
           @dCreateTime,
           @dUpdateTime)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tPrjectSetInsProc: Cannot insert because primary key value not found in tPrjectSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tPrjectSetInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectSetInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectSetInsProc >>>'
go


/* 
 * PROCEDURE: tPrjectSetUpdProc 
 */

CREATE PROCEDURE tPrjectSetUpdProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sPrjectGUID     char(36)                 = NULL,
    @sDesc           nvarchar(500)            = NULL,
    @dCreateTime     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tPrjectSet
       SET sKey             = @sKey,
           sValue           = @sValue,
           sPrjectGUID      = @sPrjectGUID,
           sDesc            = @sDesc,
           dCreateTime      = @dCreateTime,
           dUpdateTime      = @dUpdateTime
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tPrjectSetUpdProc: Cannot update  in tPrjectSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectSetUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectSetUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectSetUpdProc >>>'
go


/* 
 * PROCEDURE: tPrjectSetDelProc 
 */

CREATE PROCEDURE tPrjectSetDelProc
(
    @sGUID           char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tPrjectSet
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tPrjectSetDelProc: Cannot delete because foreign keys still exist in tPrjectSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectSetDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectSetDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectSetDelProc >>>'
go


/* 
 * PROCEDURE: tPrjectSetSelProc 
 */

CREATE PROCEDURE tPrjectSetSelProc
(
    @sGUID           char(36))
AS
BEGIN
    SELECT sGUID,
           sKey,
           sValue,
           sPrjectGUID,
           sDesc,
           dCreateTime,
           dUpdateTime
      FROM tPrjectSet
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tPrjectSetSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tPrjectSetSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tPrjectSetSelProc >>>'
go


/* 
 * PROCEDURE: tRelayInfoesInsProc 
 */

CREATE PROCEDURE tRelayInfoesInsProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @sName             nvarchar(100)            = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tRelayInfoes(sGUID,
                             iID,
                             sName,
                             sHostInfoGUID,
                             dCreateDate,
                             dUpdateTime,
                             sRemark)
    VALUES(@sGUID,
           @iID,
           @sName,
           @sHostInfoGUID,
           @dCreateDate,
           @dUpdateTime,
           @sRemark)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tRelayInfoesInsProc: Cannot insert because primary key value not found in tRelayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tRelayInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tRelayInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tRelayInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tRelayInfoesUpdProc 
 */

CREATE PROCEDURE tRelayInfoesUpdProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @sName             nvarchar(100)            = NULL,
    @sHostInfoGUID     char(36)                 = NULL,
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tRelayInfoes
       SET iID                = @iID,
           sName              = @sName,
           sHostInfoGUID      = @sHostInfoGUID,
           dCreateDate        = @dCreateDate,
           dUpdateTime        = @dUpdateTime,
           sRemark            = @sRemark
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tRelayInfoesUpdProc: Cannot update  in tRelayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tRelayInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tRelayInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tRelayInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tRelayInfoesDelProc 
 */

CREATE PROCEDURE tRelayInfoesDelProc
(
    @sGUID             char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tRelayInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tRelayInfoesDelProc: Cannot delete because foreign keys still exist in tRelayInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tRelayInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tRelayInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tRelayInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tRelayInfoesSelProc 
 */

CREATE PROCEDURE tRelayInfoesSelProc
(
    @sGUID             char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           sName,
           sHostInfoGUID,
           dCreateDate,
           dUpdateTime,
           sRemark
      FROM tRelayInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tRelayInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tRelayInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tRelayInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tSwitchConfigsInsProc 
 */

CREATE PROCEDURE tSwitchConfigsInsProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @sName             nvarchar(100)            = NULL,
    @iStateCommand     int                      = NULL,
    @iAlarmEnable      int                      = NULL,
    @sHostInfoGUID     char(36),
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tSwitchConfigs(sGUID,
                               iID,
                               sName,
                               iStateCommand,
                               iAlarmEnable,
                               sHostInfoGUID,
                               dCreateDate,
                               dUpdateTime,
                               sRemark)
    VALUES(@sGUID,
           @iID,
           @sName,
           @iStateCommand,
           @iAlarmEnable,
           @sHostInfoGUID,
           @dCreateDate,
           @dUpdateTime,
           @sRemark)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tSwitchConfigsInsProc: Cannot insert because primary key value not found in tSwitchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tSwitchConfigsInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchConfigsInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchConfigsInsProc >>>'
go


/* 
 * PROCEDURE: tSwitchConfigsUpdProc 
 */

CREATE PROCEDURE tSwitchConfigsUpdProc
(
    @sGUID             char(36),
    @iID               int                      = NULL,
    @sName             nvarchar(100)            = NULL,
    @iStateCommand     int                      = NULL,
    @iAlarmEnable      int                      = NULL,
    @sHostInfoGUID     char(36),
    @dCreateDate       datetime                 = NULL,
    @dUpdateTime       datetime                 = NULL,
    @sRemark           nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tSwitchConfigs
       SET iID                = @iID,
           sName              = @sName,
           iStateCommand      = @iStateCommand,
           iAlarmEnable       = @iAlarmEnable,
           sHostInfoGUID      = @sHostInfoGUID,
           dCreateDate        = @dCreateDate,
           dUpdateTime        = @dUpdateTime,
           sRemark            = @sRemark
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tSwitchConfigsUpdProc: Cannot update  in tSwitchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchConfigsUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchConfigsUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchConfigsUpdProc >>>'
go


/* 
 * PROCEDURE: tSwitchConfigsDelProc 
 */

CREATE PROCEDURE tSwitchConfigsDelProc
(
    @sGUID             char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tSwitchConfigs
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tSwitchConfigsDelProc: Cannot delete because foreign keys still exist in tSwitchConfigs '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchConfigsDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchConfigsDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchConfigsDelProc >>>'
go


/* 
 * PROCEDURE: tSwitchConfigsSelProc 
 */

CREATE PROCEDURE tSwitchConfigsSelProc
(
    @sGUID             char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           sName,
           iStateCommand,
           iAlarmEnable,
           sHostInfoGUID,
           dCreateDate,
           dUpdateTime,
           sRemark
      FROM tSwitchConfigs
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchConfigsSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchConfigsSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchConfigsSelProc >>>'
go


/* 
 * PROCEDURE: tSwitchInfoesInsProc 
 */

CREATE PROCEDURE tSwitchInfoesInsProc
(
    @sGUID              char(36),
    @iAlarmState        int                      = NULL,
    @iState_Command     int                      = NULL,
    @sHostInfo_GUID     char(36)                 = NULL,
    @dCreateDate        datetime                 = NULL,
    @sSwitch_GUID       char(36)                 = NULL,
    @dUpdateTiime       datetime                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tSwitchInfoes(sGUID,
                              iAlarmState,
                              iState_Command,
                              sHostInfo_GUID,
                              dCreateDate,
                              sSwitch_GUID,
                              dUpdateTiime,
                              sDesc)
    VALUES(@sGUID,
           @iAlarmState,
           @iState_Command,
           @sHostInfo_GUID,
           @dCreateDate,
           @sSwitch_GUID,
           @dUpdateTiime,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tSwitchInfoesInsProc: Cannot insert because primary key value not found in tSwitchInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tSwitchInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tSwitchInfoesUpdProc 
 */

CREATE PROCEDURE tSwitchInfoesUpdProc
(
    @sGUID              char(36),
    @iAlarmState        int                      = NULL,
    @iState_Command     int                      = NULL,
    @sHostInfo_GUID     char(36)                 = NULL,
    @dCreateDate        datetime                 = NULL,
    @sSwitch_GUID       char(36)                 = NULL,
    @dUpdateTiime       datetime                 = NULL,
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tSwitchInfoes
       SET iAlarmState         = @iAlarmState,
           iState_Command      = @iState_Command,
           sHostInfo_GUID      = @sHostInfo_GUID,
           dCreateDate         = @dCreateDate,
           sSwitch_GUID        = @sSwitch_GUID,
           dUpdateTiime        = @dUpdateTiime,
           sDesc               = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tSwitchInfoesUpdProc: Cannot update  in tSwitchInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tSwitchInfoesDelProc 
 */

CREATE PROCEDURE tSwitchInfoesDelProc
(
    @sGUID              char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tSwitchInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tSwitchInfoesDelProc: Cannot delete because foreign keys still exist in tSwitchInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tSwitchInfoesSelProc 
 */

CREATE PROCEDURE tSwitchInfoesSelProc
(
    @sGUID              char(36))
AS
BEGIN
    SELECT sGUID,
           iAlarmState,
           iState_Command,
           sHostInfo_GUID,
           dCreateDate,
           sSwitch_GUID,
           dUpdateTiime,
           sDesc
      FROM tSwitchInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tSwitchInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tSwitchInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tSwitchInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tTimeCtrlInfoesInsProc 
 */

CREATE PROCEDURE tTimeCtrlInfoesInsProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @dTime              datetime                 = NULL,
    @iEnable            int                      = NULL,
    @iState_Command     float                    = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @sHostInfoGUID      char(36)                 = NULL,
    @sTagGUID           char(36),
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tTimeCtrlInfoes(sGUID,
                                iID,
                                dTime,
                                iEnable,
                                iState_Command,
                                dCreateDate,
                                dUpdateTime,
                                sHostInfoGUID,
                                sTagGUID,
                                sDesc)
    VALUES(@sGUID,
           @iID,
           @dTime,
           @iEnable,
           @iState_Command,
           @dCreateDate,
           @dUpdateTime,
           @sHostInfoGUID,
           @sTagGUID,
           @sDesc)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tTimeCtrlInfoesInsProc: Cannot insert because primary key value not found in tTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tTimeCtrlInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tTimeCtrlInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tTimeCtrlInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tTimeCtrlInfoesUpdProc 
 */

CREATE PROCEDURE tTimeCtrlInfoesUpdProc
(
    @sGUID              char(36),
    @iID                int                      = NULL,
    @dTime              datetime                 = NULL,
    @iEnable            int                      = NULL,
    @iState_Command     float                    = NULL,
    @dCreateDate        datetime                 = NULL,
    @dUpdateTime        datetime                 = NULL,
    @sHostInfoGUID      char(36)                 = NULL,
    @sTagGUID           char(36),
    @sDesc              nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tTimeCtrlInfoes
       SET iID                 = @iID,
           dTime               = @dTime,
           iEnable             = @iEnable,
           iState_Command      = @iState_Command,
           dCreateDate         = @dCreateDate,
           dUpdateTime         = @dUpdateTime,
           sHostInfoGUID       = @sHostInfoGUID,
           sTagGUID            = @sTagGUID,
           sDesc               = @sDesc
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tTimeCtrlInfoesUpdProc: Cannot update  in tTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tTimeCtrlInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tTimeCtrlInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tTimeCtrlInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tTimeCtrlInfoesDelProc 
 */

CREATE PROCEDURE tTimeCtrlInfoesDelProc
(
    @sGUID              char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tTimeCtrlInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tTimeCtrlInfoesDelProc: Cannot delete because foreign keys still exist in tTimeCtrlInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tTimeCtrlInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tTimeCtrlInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tTimeCtrlInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tTimeCtrlInfoesSelProc 
 */

CREATE PROCEDURE tTimeCtrlInfoesSelProc
(
    @sGUID              char(36))
AS
BEGIN
    SELECT sGUID,
           iID,
           dTime,
           iEnable,
           iState_Command,
           dCreateDate,
           dUpdateTime,
           sHostInfoGUID,
           sTagGUID,
           sDesc
      FROM tTimeCtrlInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tTimeCtrlInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tTimeCtrlInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tTimeCtrlInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tUserInfoesInsProc 
 */

CREATE PROCEDURE tUserInfoesInsProc
(
    @sGUID               char(36),
    @sID                 nvarchar(100)            = NULL,
    @sUserName           nvarchar(100),
    @sPassWord           nvarchar(200),
    @iAuthorityGUID      char(36)                 = NULL,
    @sAlias              nvarchar(100)            = NULL,
    @sPhone              nvarchar(100)            = NULL,
    @sEmail              nvarchar(100)            = NULL,
    @dCreateDate         datetime                 = NULL,
    @dUpdateTime         datetime                 = NULL,
    @sRemark             nvarchar(500)            = NULL,
    @sPrjectInfoGUID     char(36)                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tUserInfoes(sGUID,
                            sID,
                            sUserName,
                            sPassWord,
                            iAuthorityGUID,
                            sAlias,
                            sPhone,
                            sEmail,
                            dCreateDate,
                            dUpdateTime,
                            sRemark,
                            sPrjectInfoGUID)
    VALUES(@sGUID,
           @sID,
           @sUserName,
           @sPassWord,
           @iAuthorityGUID,
           @sAlias,
           @sPhone,
           @sEmail,
           @dCreateDate,
           @dUpdateTime,
           @sRemark,
           @sPrjectInfoGUID)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tUserInfoesInsProc: Cannot insert because primary key value not found in tUserInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tUserInfoesInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserInfoesInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserInfoesInsProc >>>'
go


/* 
 * PROCEDURE: tUserInfoesUpdProc 
 */

CREATE PROCEDURE tUserInfoesUpdProc
(
    @sGUID               char(36),
    @sID                 nvarchar(100)            = NULL,
    @sUserName           nvarchar(100),
    @sPassWord           nvarchar(200),
    @iAuthorityGUID      char(36)                 = NULL,
    @sAlias              nvarchar(100)            = NULL,
    @sPhone              nvarchar(100)            = NULL,
    @sEmail              nvarchar(100)            = NULL,
    @dCreateDate         datetime                 = NULL,
    @dUpdateTime         datetime                 = NULL,
    @sRemark             nvarchar(500)            = NULL,
    @sPrjectInfoGUID     char(36)                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tUserInfoes
       SET sID                  = @sID,
           sUserName            = @sUserName,
           sPassWord            = @sPassWord,
           iAuthorityGUID       = @iAuthorityGUID,
           sAlias               = @sAlias,
           sPhone               = @sPhone,
           sEmail               = @sEmail,
           dCreateDate          = @dCreateDate,
           dUpdateTime          = @dUpdateTime,
           sRemark              = @sRemark,
           sPrjectInfoGUID      = @sPrjectInfoGUID
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tUserInfoesUpdProc: Cannot update  in tUserInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tUserInfoesUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserInfoesUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserInfoesUpdProc >>>'
go


/* 
 * PROCEDURE: tUserInfoesDelProc 
 */

CREATE PROCEDURE tUserInfoesDelProc
(
    @sGUID               char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tUserInfoes
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tUserInfoesDelProc: Cannot delete because foreign keys still exist in tUserInfoes '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tUserInfoesDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserInfoesDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserInfoesDelProc >>>'
go


/* 
 * PROCEDURE: tUserInfoesSelProc 
 */

CREATE PROCEDURE tUserInfoesSelProc
(
    @sGUID               char(36))
AS
BEGIN
    SELECT sGUID,
           sID,
           sUserName,
           sPassWord,
           iAuthorityGUID,
           sAlias,
           sPhone,
           sEmail,
           dCreateDate,
           dUpdateTime,
           sRemark,
           sPrjectInfoGUID
      FROM tUserInfoes
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tUserInfoesSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserInfoesSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserInfoesSelProc >>>'
go


/* 
 * PROCEDURE: tUserSetInsProc 
 */

CREATE PROCEDURE tUserSetInsProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sUserGUID       char(36)                 = NULL,
    @sDesc           nvarchar(500)            = NULL,
    @dCreateTime     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tUserSet(sGUID,
                         sKey,
                         sValue,
                         sUserGUID,
                         sDesc,
                         dCreateTime,
                         dUpdateTime)
    VALUES(@sGUID,
           @sKey,
           @sValue,
           @sUserGUID,
           @sDesc,
           @dCreateTime,
           @dUpdateTime)

    IF (@@error!=0)
    BEGIN
        RAISERROR  20000 'tUserSetInsProc: Cannot insert because primary key value not found in tUserSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

END
go
IF OBJECT_ID('tUserSetInsProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserSetInsProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserSetInsProc >>>'
go


/* 
 * PROCEDURE: tUserSetUpdProc 
 */

CREATE PROCEDURE tUserSetUpdProc
(
    @sGUID           char(36),
    @sKey            nvarchar(50)             = NULL,
    @sValue          nvarchar(50)             = NULL,
    @sUserGUID       char(36)                 = NULL,
    @sDesc           nvarchar(500)            = NULL,
    @dCreateTime     datetime                 = NULL,
    @dUpdateTime     datetime                 = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tUserSet
       SET sKey             = @sKey,
           sValue           = @sValue,
           sUserGUID        = @sUserGUID,
           sDesc            = @sDesc,
           dCreateTime      = @dCreateTime,
           dUpdateTime      = @dUpdateTime
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20001 'tUserSetUpdProc: Cannot update  in tUserSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tUserSetUpdProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserSetUpdProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserSetUpdProc >>>'
go


/* 
 * PROCEDURE: tUserSetDelProc 
 */

CREATE PROCEDURE tUserSetDelProc
(
    @sGUID           char(36))
AS
BEGIN
    BEGIN TRAN

    DELETE
      FROM tUserSet
     WHERE sGUID = @sGUID

    IF (@@error!=0)
    BEGIN
        RAISERROR  20002 'tUserSetDelProc: Cannot delete because foreign keys still exist in tUserSet '
        ROLLBACK TRAN
        RETURN(1)
    
    END

    COMMIT TRAN

    RETURN(0)
END
go
IF OBJECT_ID('tUserSetDelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserSetDelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserSetDelProc >>>'
go


/* 
 * PROCEDURE: tUserSetSelProc 
 */

CREATE PROCEDURE tUserSetSelProc
(
    @sGUID           char(36))
AS
BEGIN
    SELECT sGUID,
           sKey,
           sValue,
           sUserGUID,
           sDesc,
           dCreateTime,
           dUpdateTime
      FROM tUserSet
     WHERE sGUID = @sGUID

    RETURN(0)
END
go
IF OBJECT_ID('tUserSetSelProc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE tUserSetSelProc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE tUserSetSelProc >>>'
go


