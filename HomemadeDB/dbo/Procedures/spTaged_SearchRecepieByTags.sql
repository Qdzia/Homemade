CREATE PROCEDURE [dbo].[spTaged_SearchRecepieByTags]
	@Tags nvarchar(256)
AS
BEGIN
	
SELECT r.RecepieId, COUNT(*) as NumOfTags
INTO #taged_recepies
FROM Taged t

JOIN Recepies r ON t.RecepieId = r.RecepieId
JOIN Tags h ON t.TagId = h.TagId

WHERE h.Tag IN 
(
	SELECT value FROM STRING_SPLIT(@Tags,'|')
)
GROUP BY r.RecepieId ORDER BY COUNT(*) DESC;

SELECT rr.* FROM Recepies rr
JOIN #taged_recepies tg ON rr.RecepieId = tg.RecepieId
ORDER BY tg.NumOfTags DESC;

END
