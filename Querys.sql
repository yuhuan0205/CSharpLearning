/* 1 */
CREATE TABLE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
(
	[CTIME] datetime DEFAULT GETDATE(),
	[MTIME] int,
	[RecordID] bigint,
	[���] nvarchar(8),
	[�Ѳ��N��] nvarchar(10),
	[�Ѳ��W��] nvarchar(20),
	[�}�L��] decimal(9,2),
	[�̰���] decimal(9,2),
	[�̧C��] decimal(9,2),
	[���L��] decimal(9,2),
	[���^] decimal(9,2),
	PRIMARY KEY(��� DESC, �Ѳ��N�� ASC)
);

CREATE 
NONCLUSTERED INDEX MTIME_INDEX
ON [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A](MTIME DESC)
/* DELETE FROM [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]; */

/* 12 */
INSERT INTO [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A](���, �Ѳ��N��, �Ѳ��W��, �}�L��)
 VALUES(N'20181218', N'0000', N'����', 0);

/* 13 */
UPDATE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
SET �}�L�� = 1
WHERE �Ѳ��W�� LIKE N'����';

/* 14 */
DELETE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
WHERE �}�L�� = 1;

/* 15 */
INSERT INTO [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
SELECT [CTIME], [MTIME], [RecordID], [���], [�Ѳ��N��], [�Ѳ��W��], [�}�L��], [�̰���], [�̧C��], [���L��], [���^] FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE N'20181214';

/* 16 */
DELETE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A];

TRUNCATE TABLE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A];

/* 17 */
DROP TABLE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]

/* 19 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE N'20181206';

/* 20 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE (��� BETWEEN N'20181201' AND N'20181206') AND �Ѳ��N�� IN (N'0050', N'006201', N'00721B');

/* 21 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE (��� BETWEEN N'20181201' AND N'20181206');

/* 22 */
SELECT ���, COUNT(*) AS ��Ƶ��� FROM [StockDB].[dbo].[�馬�L]
GROUP BY ���
HAVING ��� LIKE N'2018%'

/* 23 */
SELECT �Ѳ��N��, SUM(�}�L��) AS �}�L���`�M, MIN(�̰���) AS �̤p�̰���, MAX(�̧C��) AS �̤j�̧C��, AVG(���L��) AS �������L�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN N'20181201' AND N'20181206'
GROUP BY �Ѳ��N��;

/* 24 */
SELECT DISTINCT �Ѳ��W��, SUBSTRING(�Ѳ��W��,0,3) AS �Y�g FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN N'20181201' AND N'20181206'

/* 25 */
SELECT DISTINCT RTRIM (LTRIM(�Ѳ��W��)) AS �Y���h�ť� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN N'20181201' AND N'20181206'

/* 26 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN N'20181201' AND N'20181206'
ORDER BY �Ѳ��N�� DESC, ��� ASC

/* 27 */
SELECT �Ѳ��N��, AVG(���L��) AS �������L�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN N'20181201' AND N'20181206'
GROUP BY �Ѳ��N��
HAVING AVG(���L��) < 80

/* 28 */
SELECT COUNT(*) AS �`��Ƶ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%'

/* 29 */
/* solution 1 */
SELECT COUNT(*) AS �`��Ƶ���
FROM ( (SELECT �Ѳ��N��, ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%' )
EXCEPT
(SELECT �Ѳ��N��, ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%' AND ���L�� IS NULL
)) AS �D�Ŧ��L��

/* solution 2 */
SELECT COUNT(*) AS �`��Ƶ���
FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%' AND (���L�� >=0 OR ���L�� < 0)

/* solution3 */
SELECT COUNT(���L��) AS �`��Ƶ���
FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%'


/* 30 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%' AND LEN(�Ѳ��N��) > 4

/* 31 */
SELECT DISTINCT REPLACE(�Ѳ��W��, N'����', N'__') AS �W�٥]�t���Ƥ��Ѳ� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'2018%' AND �Ѳ��W�� LIKE N'%����%'

/* 32 */
SELECT * from [StockDB].[DBO].[�馬�L] 
WHERE DATEDIFF(dd, CAST(��� AS DATE), GETDATE()) = 0

/* solution 2 */
DECLARE @TODAY NVARCHAR(8) = CONVERT(NVARCHAR(8), GETDATE(), 112)
SELECT * from [StockDB].[DBO].[�馬�L] 
WHERE ��� LIKE @TODAY

/* 33 */
SELECT * FROM (SELECT *,  ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ���) AS [Rank] FROM [StockDB].[dbo].[�馬�L] WHERE �Ѳ��N�� LIKE N'1%' AND ��� LIKE N'2018%') AS ����
WHERE ����.[Rank] = 6

/* 34 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE N'20181206'
EXCEPT
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE N'20181205'

/* 35 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE N'20181206'
INTERSECT 
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE N'20181205'

/* 36 */
SELECT �馬�L.* , �W���d.�^��W��  
FROM [StockDB].[dbo].[�馬�L] AS �馬�L JOIN [StockDB].[dbo].[�W���d�򥻸�ƪ�] AS �W���d ON �馬�L.�Ѳ��N�� = �W���d.�Ѳ��N�� AND SUBSTRING(�馬�L.���, 0, 5) LIKE  �W���d.�~��
WHERE �馬�L.��� LIKE N'2018%'

/* 37 */
SELECT �馬�L.���, �馬�L.�Ѳ��W��, ETF.�~��, ETF.�W�� 
FROM (SELECT * FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE N'20181214' ) AS �馬�L 
JOIN 
(SELECT �~��, �W��, �N�� FROM [StockDB].[dbo].[ETF�򥻸�ƪ�] WHERE �~�� LIKE N'2018') AS ETF
ON �馬�L.�Ѳ��N�� = ETF.�N��
WHERE �馬�L.�Ѳ��W�� NOT LIKE ETF.�W��

/* 38 */
SELECT �W���d = 
CASE �W���d
	WHEN 1 THEN N'�W��'
	WHEN 2 THEN N'�W�d'
	WHEN 3 THEN N'���d'
	WHEN 4 THEN N'���o'
	ELSE N'��L'
END,
[CTIME], [MTIME], [RecordID], [���], [�Ѳ��N��], [�Ѳ��W��], [�Ѧһ�], [�}�L��], [�̰���], [�̧C��], [���L��], [���^], [���~�N��], [������], [�^����], [���^���p], [�̫�e�R��], [�̫�e���], [���T(%)], [���T(%)], [����q], [����q(��)], [���浧��], [������B(�d)], [����Ȥ�(%)], [����q�ܰ�(%)], [�ѥ�(�ʸU)2], [���i�ܰ�(%)], [���i], [�`����(��)], [���Ȥ�(%)], [���ѥ��q��], [���Ѫѻ��b�Ȥ�], [���Ѫѻ��b�Ȥ�2], [���q��], [���q��(��|�u)], [�ѪF�v�q(�ʸU)], [�ѻ��b�Ȥ�], [�ѻ��b�Ȥ�2], [�ªѥ�(�ʸU)], [�e�R�i��], [�e��i��], [����Ѧһ�], [������B_��], [����], [�ѥ�(�ʸU)], [�g��v], [���^��]
FROM [StockDB].[dbo].[�馬�L] AS �馬�L
WHERE ��� BETWEEN N'20181201' AND N'20181206'

/* 39 */
SELECT [Range] = 
CASE 
	WHEN ���L��<10 THEN N'Under_10'
	WHEN ���L�� >= 10 AND ���L�� < 50 THEN N'Under_50'
	WHEN ���L�� >= 50 AND ���L�� < 100 THEN N'Under_100'
	WHEN ���L��>=100 THEN N'Over_100'
END, *
FROM [StockDB].[dbo].[�馬�L] AS �馬�L
WHERE ��� BETWEEN N'20181201' AND N'20181206'

/* 40 */

/* SOLUTION 1 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'20181206'
ORDER BY 
CASE
	WHEN ���L�� > 5 THEN ���L��
	WHEN ���L�� <=5 THEN ���L��*-1
	END
DESC 

/* SOLUTION 2 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE N'20181206'
ORDER BY 
CASE WHEN ���L�� > 5 THEN ���L�� END DESC,
CASE WHEN ���L�� <=5 THEN ���L�� END ASC


/* 41 */
SELECT * FROM
(
	SELECT *, ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS ���� 
	FROM [StockDB].[dbo].[�馬�L]
	WHERE �Ѳ��N�� IN (SELECT DISTINCT TOP 1000 �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L])
) AS �Y1000�ɪѲ�
WHERE �Y1000�ɪѲ�.���� = 1


SELECT ��l.* FROM 
(SELECT * FROM [StockDB].[dbo].[�馬�L]) AS ��l, (SELECT TOP 1000 �Ѳ��N��, MAX(���) AS �̤j��� FROM [StockDB].[dbo].[�馬�L] GROUP BY �Ѳ��N��) AS ����
WHERE ��l.�Ѳ��N�� LIKE ����.�Ѳ��N�� AND ��l.��� LIKE ����.�̤j���


/* 45 */
DECLARE @�W���̷s�~�� char(4)
DECLARE @���d�̷s�~�� char(4)
DECLARE @���o�̷s�~�� char(4)

SELECT @�W���̷s�~�� = MAX(�~��) FROM [StockDB].[dbo].[�W���d�򥻸�ƪ�]
SELECT @���d�̷s�~�� = MAX(�~��) FROM [StockDB].[dbo].[���d�򥻸�ƪ�]
SELECT @���o�̷s�~�� = MAX(�~��) FROM [StockDB].[dbo].[���}�o��򥻸�ƪ�]

SELECT �Ѳ��W��, �Ѳ��N��, �W���W�d AS �����O, �W���W�d AS �H�������O, ���q�W��, �Τ@�s�� FROM [StockDB].[dbo].[�W���d�򥻸�ƪ�]
WHERE �~�� LIKE @�W���̷s�~�� AND ���P����� = 1
UNION
SELECT �W�� AS �Ѳ��W��, �N�� AS �Ѳ��N��, �W���W�d AS �����O, �W���W�d AS �H�������O, ���q�W��, �Τ@�s�� FROM [StockDB].[dbo].[���d�򥻸�ƪ�]
WHERE �~�� LIKE @���d�̷s�~�� AND �ҥ� = 1
UNION
SELECT �W�� AS �Ѳ��W��, �N�� AS �Ѳ��N��, �W���W�d AS �����O, �W���W�d AS �H�������O, ���q�W��, �Τ@�s�� FROM [StockDB].[dbo].[���}�o��򥻸�ƪ�]
WHERE �~�� LIKE @���o�̷s�~�� AND �ҥ� = 1 AND �N�� NOT LIKE N'6536'


/* 46 */

SELECT * 
FROM (
	SELECT *,  ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS [Rank] 
	FROM [StockDB].[dbo].[�馬�L] 
	WHERE �Ѳ��N�� IN 
		(
		SELECT �Ѳ��N�� 
		FROM [StockDB].[dbo].[�W���d�򥻸�ƪ�] 
		WHERE �~�� LIKE N'2018' AND ���P����� = 1
		)
	AND ��� LIKE N'2018%'
	) AS ����
WHERE ����.[Rank] = 1

/* SOLUTION2 */

SELECT * FROM [StockDB].[dbo].[�馬�L] AS �Ѳ����
INNER JOIN
(SELECT �Ѳ��N��, MAX(���) AS �̤j���
FROM [StockDB].[dbo].[�馬�L] 
GROUP BY �Ѳ��N��)
AS �Ѳ����
ON �Ѳ����.�̤j��� = �Ѳ����.��� AND �Ѳ����.�Ѳ��N�� = �Ѳ����.�Ѳ��N��
WHERE �Ѳ����.�Ѳ��N�� IN 
	(
	SELECT �Ѳ��N�� 
	FROM [StockDB].[dbo].[�W���d�򥻸�ƪ�] 
	WHERE �~�� LIKE N'2018' AND ���P����� = 1
	)


/* 47 */
SELECT ��ɶU�e.���,��ɶU��.�Ѳ��N��, ��ɶU�e.��Ӥ����γ~�ɶU�l�B, ��ɶU��.���, ��ɶU��.�Ѳ��N��, ��ɶU��.��Ӥ����γ~�ɶU�e��l�B
FROM 
(SELECT ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS [���RANK], * FROM [StockDB].[dbo].[��ɶU�ڶ���O�~�l�B��]) AS ��ɶU�� 
JOIN 
(SELECT ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS [���RANK], * FROM [StockDB].[dbo].[��ɶU�ڶ���O�~�l�B��]) AS ��ɶU�e 
ON ��ɶU��.�Ѳ��N�� = ��ɶU�e.�Ѳ��N�� AND ��ɶU��.���RANK = ��ɶU�e.���RANK-1
WHERE ��ɶU��.��Ӥ����γ~�ɶU�e��l�B != ��ɶU�e.��Ӥ����γ~�ɶU�l�B

/* 48 */
SELECT �s�V.�Ѳ��N�� , �s�V.���L�� AS �s�V���L, �馬�L.�Ѳ��N��, �馬�L.���L�� AS �馬�L FROM 
(SELECT * FROM [StockDB].[dbo].[�馬�L_�s�H�V�m_2016] WHERE ��� LIKE N'20161212' ) AS �s�V
JOIN 
(SELECT * FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE N'20161212' ) AS �馬�L
ON �馬�L.�Ѳ��N�� = �s�V.�Ѳ��N��
WHERE �馬�L.���L�� != �s�V.���L��

/* OR THIS*/
SELECT �s�V.�Ѳ��N�� , �s�V.���L�� AS �s�V���L, �馬�L.�Ѳ��N��, �馬�L.���L�� AS �馬�L FROM 
[StockDB].[dbo].[�馬�L_�s�H�V�m_2016] AS �s�V
JOIN 
[StockDB].[dbo].[�馬�L] AS �馬�L
ON �馬�L.��� LIKE N'20161212' AND �s�V.��� LIKE N'20161212' AND �馬�L.�Ѳ��N�� = �s�V.�Ѳ��N��
WHERE �馬�L.���L�� != �s�V.���L��

/* 49 */
/* ANS SHOULD BE 14895 */

WITH 
���q�̤j�~�� AS(
SELECT ���.�~��, ���.���q�Τ@�s��, MAX(SHGSTUDTLCOM.�̤jCHADATE) AS �̤jCHADATE
FROM
[StockDB].[dbo].[��ѤW�����q�򥻸�ƪ�] AS ���
JOIN
(SELECT HK.COMUNIC, �̤j���.�̤jCHADATE, HK.NUMPUSH 
FROM
(SELECT * FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM])AS HK
JOIN 
(SELECT COMUNIC, MAX(CHDATE) AS �̤jCHADATE 
FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM]
WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1
GROUP BY COMUNIC, SUBSTRING(CONVERT(nvarchar, CHDATE, 112),0, 5)) AS �̤j���
ON HK.COMUNIC = �̤j���.COMUNIC AND HK.CHDATE = �̤j���.�̤jCHADATE ) AS SHGSTUDTLCOM
ON ���.���q�Τ@�s�� = SHGSTUDTLCOM.COMUNIC AND ���.�~�� >= SUBSTRING(CONVERT(nvarchar, SHGSTUDTLCOM.�̤jCHADATE, 112),0, 5)
GROUP BY ���.���q�Τ@�s��, ���.�~��
)


UPDATE [StockDB].[dbo].[��ѤW�����q�򥻸�ƪ�]
SET [StockDB].[dbo].[��ѤW�����q�򥻸�ƪ�].[���q�ѵo��Ѽ�(�ʸU��)] = CAST(�~�׹���.NUMPUSH/1000000 AS DECIMAL(10,3))
FROM 
(SELECT ���q�̤j�~��.�̤jCHADATE, ���q�̤j�~��.���q�Τ@�s��, ���q�̤j�~��.�~��, ���.[���q�ѵo��Ѽ�(�ʸU��)], HK.NUMPUSH FROM 
���q�̤j�~��
JOIN
[StockDB].[dbo].[��ѤW�����q�򥻸�ƪ�] AS ���
ON ���q�̤j�~��.�~�� = ���.�~�� AND ���q�̤j�~��.���q�Τ@�s�� = ���.���q�Τ@�s��
JOIN 
((SELECT * FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM] WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1)AS HK
JOIN 
(SELECT COMUNIC, MAX(CHDATE) AS �̤jCHADATE 
FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM] WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1
GROUP BY COMUNIC, SUBSTRING(CONVERT(nvarchar, CHDATE, 112),0, 5)) AS �̤j���
ON HK.COMUNIC = �̤j���.COMUNIC AND HK.CHDATE = �̤j���.�̤jCHADATE)
ON ���q�̤j�~��.�̤jCHADATE = HK.CHDATE AND ���q�̤j�~��.���q�Τ@�s�� = HK.COMUNIC) AS �~�׹���

WHERE [StockDB].[dbo].[��ѤW�����q�򥻸�ƪ�].���q�Τ@�s�� = �~�׹���.���q�Τ@�s�� 





/* 51 */
GO;
CREATE PROC TWORETURN 
AS
	RETURN 2
GO;

/* 52 */
ALTER PROC TWORETURN
AS 
	RETURN '2'
GO;

DROP PROC TWORETURN


/* 53 */
GO;
CREATE PROC TWORETURN 
AS
	RETURN 2
GO;

DECLARE @two INT
EXEC @two = TWORETURN 

GO
DROP PROC TWORETURN
GO;

CREATE PROC TWORETURN @TWO INT OUTPUT
AS
	SELECT @TWO = 2

GO

DECLARE @two INT
EXEC TWORETURN @two OUTPUT
GO;


/* 55 */
CREATE FUNCTION Get�馬�LBy���
(@��� nvarchar(8))
RETURNS TABLE

RETURN (SELECT * FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE @��� )

GO

SELECT * FROM Get�馬�LBy���('20181214')
GO

/* 56 */
CREATE FUNCTION Get�馬�L�̤j���
()
RETURNS nvarchar(8)
BEGIN
DECLARE @�̤j��� nvarchar(8)
 SELECT @�̤j��� = MAX(���) FROM [StockDB].[dbo].[�馬�L]

RETURN @�̤j���
END

GO
SELECT dbo.Get�馬�L�̤j���()

/* 60 */
USE StockDB
GO
CREATE TRIGGER �馬�L����
ON [�馬�L]
AFTER INSERT, UPDATE, DELETE
AS
SELECT MTIME = 0
GO

/* 61 */
ENABLE TRIGGER �馬�L���� ON [�馬�L]
GO
DISABLE TRIGGER �馬�L���� ON [�馬�L]
GO
DROP TRIGGER �馬�L����
GO

/* 63 */
WITH 
TESTCTE AS
(
	SELECT * FROM [StockDB].[dbo].[�馬�L]
	WHERE ��� LIKE N'20181214'
)
SELECT * FROM TESTCTE






