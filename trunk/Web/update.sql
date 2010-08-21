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