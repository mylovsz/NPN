/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      hg
 * Project :      Model1.DM1
 * Author :       HUAGO
 *
 * Date Created : Wednesday, October 12, 2016 15:30:04
 * Target DBMS : Microsoft SQL Server 2008
 */

USE SSY
go
/* 
 * TABLE: tHostSet 
 */

CREATE TABLE tHostSet(
    sGUID          char(36)        NOT NULL,
    sKey           varchar(20)     NULL,
    sValue         varchar(50)     NULL,
    sHostGUID      char(36)        NULL,
    sDesc          varchar(100)    NULL,
    dCreateDate    datetime        NULL,
    dUpdateDate    datetime        NULL,
    CONSTRAINT PK37 PRIMARY KEY NONCLUSTERED (sGUID)
)
go



IF OBJECT_ID('tHostSet') IS NOT NULL
    PRINT '<<< CREATED TABLE tHostSet >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE tHostSet >>>'
go

/* 
 * PROCEDURE: tHostSetInsProc 
 */

CREATE PROCEDURE tHostSetInsProc
(
    @sGUID           char(36),
    @sKey            varchar(20)             = NULL,
    @sValue          varchar(50)             = NULL,
    @sHostGUID       char(36)                = NULL,
    @sDesc           varchar(100)            = NULL,
    @dCreateDate     datetime                = NULL,
    @dUpdateDate     datetime                = NULL)
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
    @sKey            varchar(20)             = NULL,
    @sValue          varchar(50)             = NULL,
    @sHostGUID       char(36)                = NULL,
    @sDesc           varchar(100)            = NULL,
    @dCreateDate     datetime                = NULL,
    @dUpdateDate     datetime                = NULL)
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


