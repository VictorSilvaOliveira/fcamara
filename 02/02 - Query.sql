SELECT 
	p.ReportsTo, 
	COUNT(p.ID) AS `Num of Members`, 
	AVG(p.Age)  AS `Average of Members`
FROM db.person p
WHERE p.ReportsTo IS NOT NULL
GROUP BY p.ReportsTo
ORDER BY p.ReportsTo;