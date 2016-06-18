--select * from AnalysisResults


 
	SELECT        AnalysisData.Id, AnalysisData.Company, AnalysisData.JobTitle, AnalysisData.JobDescription, AnalysisData.AnalystName, AnalysisData.EmployeeName, 
                         AnalysisData.DateCreated, AnalysisData.DateEdited, AnalysisData.CreatedById, AnalysisData.AnalysisResultsId, AnalysisResults.Id AS 'AnalysisResults.Id', 
                         AnalysisResults.Neck, AnalysisResults.Shoulder1, AnalysisResults.Shoulder2, AnalysisResults.Back, AnalysisResults.Leg1, AnalysisResults.Leg2, 
                         AnalysisResults.Feet1, AnalysisResults.Feet2, AnalysisResults.Elbow1, AnalysisResults.Elbow2, AnalysisResults.Hand1, AnalysisResults.Hand2, 
                         AnalysisResults.Neck0, AnalysisResults.Back0, AnalysisResults.Shoulder0, AnalysisResults.Elbow0, AnalysisResults.Hand0, AnalysisResults.Leg0, 
                         AnalysisResults.Feet0
FROM            AnalysisData INNER JOIN
                         AnalysisResults ON AnalysisData.Id = AnalysisResults.Id
						 where AnalysisData.Id=14