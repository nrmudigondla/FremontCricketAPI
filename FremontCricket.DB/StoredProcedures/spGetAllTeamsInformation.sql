USE [FremontCricket]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllTeamsInformation]    Script Date: 2/2/2025 6:30:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		NR
-- Create date: 2/2/2025
-- Description:	This SP used to get all the teams information along with thier match information.
-- =============================================
ALTER PROCEDURE [dbo].[spGetAllTeamsInformation]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	t.id,
    t.team_name, 
    COUNT(m.id) AS MatchesPlayed,
    SUM(CASE WHEN m.match_won_by = t.id THEN 1 ELSE 0 END) AS MatchesWon,
    SUM(CASE WHEN m.match_lost_by = t.id THEN 1 ELSE 0 END) AS MatchesLost
	FROM 
		team_info t
	JOIN 
		match_info m ON m.host_team = t.id OR m.guest_team = t.id
	GROUP BY 
		t.team_name, t.id
	ORDER BY 
		t.team_name;

END