USE [FremontCricket]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPlayerInfo]    Script Date: 3/2/2025 5:51:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetAllPlayerInfo] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	ROW_NUMBER() OVER(ORDER BY ui.first_name),
	ui.first_name, 
	ui.last_name, 
	0,
	0,
	0,
	0
	from  user_info ui 
END