--select r.*, d.DateCreated from AnalysisData d 
--				inner join AnalysisResults r
--				on d.AnalysisResultsId = r.Id
--order by d.DateCreated desc


select * from AnalysisData
select * from AnalysisResults
