--添加友情链接
ALTER PROCEDURE [dbo].[AddLink]
	@LinkName VARCHAR(50),
	@CateID INT,
	@LinkUrl VARCHAR(200),
	@LinkOrder INT
AS
	INSERT INTO Link(LinkName, LinkCateID, LinkUrl, LinkOrder) 
	VALUES(@LinkName, @CateID, @LinkUrl, @LinkOrder)
GO

--添加图片
ALTER PROCEDURE [dbo].[AddPhoto]
	@PhotName VARCHAR(50),
	@CateID INT,
	@PhotUrl VARCHAR(200),
	@PhotPath VARCHAR(300),
	@PhotOrder INT,
	@PhotUploadAt DATETIME
AS
	INSERT INTO Photo(PhotName, PhotCateID, PhotUrl, PhotPath, PhotOrder, PhotUploadAt) 
	VALUES(@PhotName, @CateID, @PhotUrl, @PhotPath, @PhotOrder, @PhotUploadAt) 
GO

ALTER PROCEDURE [dbo].[GetLinkList]
	@CateID INT,
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		tid INT NOT NULL
	)

	INSERT INTO @TempTable(tid)
	SELECT LinkID FROM [Link]
	WHERE LinkCateID=@CateID
	ORDER BY LinkOrder DESC,LinkID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT LinkID,LinkName,LinkUrl,LinkOrder,LinkCateID
	FROM [Link],@TempTable 
	WHERE LinkID=tid AND AutoID BETWEEN @MinID AND @MaxID ORDER BY LinkOrder
GO

ALTER PROCEDURE [dbo].[GetPhotoList]
	@CateID INT,
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		tid INT NOT NULL
	)

	INSERT INTO @TempTable(tid)
	SELECT PhotID FROM [Photo]
	WHERE PhotCateID=@CateID
	ORDER BY PhotOrder DESC,PhotID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT PhotID,PhotName,PhotUrl,PhotPath,PhotOrder,PhotUploadAt,PhotCateID
	FROM [Photo],@TempTable 
	WHERE PhotID=tid AND AutoID BETWEEN @MinID AND @MaxID ORDER BY PhotOrder
GO

--修改友情链接
ALTER PROCEDURE [dbo].[UpdateLinkInfo]
	@LinkID INT,
	@LinkName VARCHAR(50),
	@CateID INT,
	@LinkUrl VARCHAR(200),
	@LinkOrder INT
AS
	Update Link 
	SET LinkName=@LinkName, LinkCateID=@CateID, LinkUrl=@LinkUrl, LinkOrder=@LinkOrder
	WHERE LinkID = @LinkID
GO

--修改图片信息
ALTER PROCEDURE [dbo].[UpdatePhotoInfo]
	@PhotID INT,
	@PhotName VARCHAR(50),
	@CateID INT,
	@PhotUrl VARCHAR(200),
	@PhotPath VARCHAR(300),
	@PhotOrder INT,
	@PhotUploadAt DATETIME
AS
	Update Photo
	SET PhotName=@PhotName, PhotCateID=@CateID, PhotUrl=@PhotUrl, PhotPath=@PhotPath, PhotOrder=@PhotOrder, PhotUploadAt=@PhotUploadAt
	WHERE PhotID = @PhotID
GO

ALTER PROCEDURE [dbo].[GetArticleListByColumn]
	@ArtiColumnID INT
AS
BEGIN
	SELECT TOP 5 ArtiID,ArtiTitle,ArtiCreateAt,ArtiColumnID,ArtiStatus,ArtiIsTop,ArtiClicks,ArtiOrder,ArtiUserID,ArtiUserName,ArtiPic
	FROM Article
	WHERE ArtiColumnID=@ArtiColumnID AND ArtiStatus=0
	ORDER BY ArtiOrder DESC,ArtiID DESC
END
GO

ALTER PROCEDURE [dbo].[GetPhotoListByWeb]
AS
BEGIN
	SELECT * FROM Photo ORDER BY PhotOrder DESC,PhotID DESC
END
GO

CREATE PROCEDURE [dbo].[GetLinkListByCate]
	@CateID INT,
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
BEGIN
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		LinkID INT NOT NULL
	)

	INSERT INTO @TempTable(LinkID)
	SELECT LinkID FROM Link
	WHERE LinkCateID=@CateID 
	ORDER BY LinkOrder DESC,LinkID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT LinkName,LinkUrl
	FROM Link l,@TempTable t
	WHERE l.LinkID=t.LinkID AND AutoID BETWEEN @MinID AND @MaxID ORDER BY AutoID
END
GO

ALTER PROCEDURE [dbo].[GetAllLinkList]
AS
BEGIN
	SELECT * FROM Link
	ORDER BY LinkOrder DESC,LinkID DESC
END
GO

--获取文章内容
ALTER PROCEDURE [dbo].[GetArticleInfo]
	@ArtiID INT
AS
BEGIN
	SELECT ArtiID,ArtiTitle,ArtiContent,ArtiCreateAt,ArtiColumnID,ArtiStatus,ArtiIsTop,ArtiClicks,ArtiOrder,ArtiUserID,ArtiUserName,ArtiPic
	FROM Article
	WHERE ArtiID=@ArtiID AND ArtiStatus=0
END
GO

ALTER PROCEDURE [dbo].[GetNoticeList]
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
BEGIN
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		NoticeID BIGINT NOT NULL
	)

	INSERT INTO @TempTable(NoticeID)
	SELECT NotiID FROM Notice,Article
	WHERE ArtiStatus=0 AND NotiArtiID=ArtiID
	ORDER BY NotiOrder DESC,NotiID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT NotiID,NotiArtiID,NotiOrder,NotiCreateAt,ArtiTitle
	FROM Article,Notice,@TempTable
	WHERE NotiArtiID=ArtiID AND NotiID=NoticeID AND AutoID BETWEEN @MinID AND @MaxID
END
GO

ALTER PROCEDURE [dbo].[GetAllNoticeList]
AS
BEGIN
	SELECT NotiID,NotiArtiID,NotiOrder,NotiCreateAt,ArtiTitle 
	FROM Notice,Article
	WHERE ArtiStatus=0 AND NotiArtiID=ArtiID
	ORDER BY NotiOrder DESC,NotiID DESC
END
GO

--获取文章内容
CREATE PROCEDURE [dbo].[GetArticleInfoByAdmin]
	@ArtiID INT
AS
BEGIN
	SELECT ArtiID,ArtiTitle,ArtiContent,ArtiCreateAt,ArtiColumnID,ArtiStatus,ArtiIsTop,ArtiClicks,ArtiOrder,ArtiUserID,ArtiUserName,ArtiPic
	FROM Article
	WHERE ArtiID=@ArtiID
END
GO

INSERT INTO [Column]([ColuID],[ColuName],[ColuCreateAt],[ColuDesc])
VALUES (4,'杰信人力资源','2009-05-23 18:54:50.250','杰信人力资源')
GO

--添加图片
ALTER PROCEDURE [dbo].[AddPhoto]
	@PhotName VARCHAR(50),
	@CateID INT,
	@PhotUrl VARCHAR(200),
	@PhotPath VARCHAR(300),
	@PhotOrder INT,
	@PhotUploadAt DATETIME
AS
	INSERT INTO Photo(PhotName, PhotCateID, PhotUrl, PhotPath, PhotOrder, PhotUploadAt) 
	VALUES(@PhotName, @CateID, @PhotUrl, @PhotPath, @PhotOrder, @PhotUploadAt) 
	
	UPDATE Site SET SitePicCount=SitePicCount+1
GO

--添加友情链接
ALTER PROCEDURE [dbo].[AddLink]
	@LinkName VARCHAR(50),
	@CateID INT,
	@LinkUrl VARCHAR(200),
	@LinkOrder INT
AS
	INSERT INTO Link(LinkName, LinkCateID, LinkUrl, LinkOrder) 
	VALUES(@LinkName, @CateID, @LinkUrl, @LinkOrder)
	
	UPDATE Site SET SiteLinkCount=SiteLinkCount+1
GO

ALTER PROCEDURE [dbo].[GetPhotoList]
	@CateID INT,
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		tid INT NOT NULL
	)

	INSERT INTO @TempTable(tid)
	SELECT PhotID FROM [Photo]
	WHERE PhotCateID=@CateID
	ORDER BY PhotOrder DESC,PhotID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT PhotID,PhotName,PhotUrl,PhotPath,PhotOrder,PhotUploadAt,PhotCateID
	FROM [Photo],@TempTable 
	WHERE PhotID=tid AND AutoID BETWEEN @MinID AND @MaxID ORDER BY PhotOrder DESC,PhotID DESC
GO

ALTER PROCEDURE [dbo].[GetNoticeList]
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
BEGIN
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		NoticeID BIGINT NOT NULL
	)

	INSERT INTO @TempTable(NoticeID)
	SELECT NotiID FROM Notice,Article
	WHERE ArtiStatus=0 AND NotiArtiID=ArtiID
	ORDER BY NotiOrder DESC,NotiID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT NotiID,NotiArtiID,NotiOrder,NotiCreateAt,ArtiTitle
	FROM Article,Notice,@TempTable
	WHERE NotiArtiID=ArtiID AND NotiID=NoticeID AND AutoID BETWEEN @MinID AND @MaxID
	ORDER BY NotiOrder DESC,NotiID DESC
END
GO

ALTER PROCEDURE [dbo].[GetLinkList]
	@CateID INT,
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
AS
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		tid INT NOT NULL
	)

	INSERT INTO @TempTable(tid)
	SELECT LinkID FROM [Link]
	WHERE LinkCateID=@CateID
	ORDER BY LinkOrder DESC,LinkID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT LinkID,LinkName,LinkUrl,LinkOrder,LinkCateID
	FROM [Link],@TempTable 
	WHERE LinkID=tid AND AutoID BETWEEN @MinID AND @MaxID ORDER BY LinkOrder DESC,LinkID DESC
GO

/*手动操作*/
1、修改Article和Notice表的外键关系为级联删除。