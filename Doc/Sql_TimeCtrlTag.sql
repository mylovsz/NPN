/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      hg
 * Project :      Model1.DM1
 * Author :       HUAGO
 *
 * Date Created : Wednesday, November 23, 2016 13:53:40
 * Target DBMS : Microsoft SQL Server 2008
 */

USE SSY
go
/* 
 * TABLE: tCtrlTagInfoes 
 */

CREATE TABLE tCtrlTagInfoes(
    sGUID               char(36)         NOT NULL,
    iType               int              NULL,
    sLightGroupGUID     char(36)         NULL,
    sLightGroupState    nvarchar(50)     NULL,
    sRelayInfoGUID      char(36)         NULL,
    sRelayState         nvarchar(50)     NULL,
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
 * PROCEDURE: tCtrlTagInfoesInsProc 
 */

CREATE PROCEDURE tCtrlTagInfoesInsProc
(
    @sGUID                char(36),
    @iType                int                      = NULL,
    @sLightGroupGUID      char(36)                 = NULL,
    @sLightGroupState     nvarchar(50)             = NULL,
    @sRelayInfoGUID       char(36)                 = NULL,
    @sRelayState          nvarchar(50)             = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    INSERT INTO tCtrlTagInfoes(sGUID,
                               iType,
                               sLightGroupGUID,
                               sLightGroupState,
                               sRelayInfoGUID,
                               sRelayState,
                               sDesc)
    VALUES(@sGUID,
           @iType,
           @sLightGroupGUID,
           @sLightGroupState,
           @sRelayInfoGUID,
           @sRelayState,
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
    @sLightGroupGUID      char(36)                 = NULL,
    @sLightGroupState     nvarchar(50)             = NULL,
    @sRelayInfoGUID       char(36)                 = NULL,
    @sRelayState          nvarchar(50)             = NULL,
    @sDesc                nvarchar(500)            = NULL)
AS
BEGIN
    BEGIN TRAN

    UPDATE tCtrlTagInfoes
       SET iType                 = @iType,
           sLightGroupGUID       = @sLightGroupGUID,
           sLightGroupState      = @sLightGroupState,
           sRelayInfoGUID        = @sRelayInfoGUID,
           sRelayState           = @sRelayState,
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
           sLightGroupGUID,
           sLightGroupState,
           sRelayInfoGUID,
           sRelayState,
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


