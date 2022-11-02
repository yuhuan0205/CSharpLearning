/* 1 */
CREATE TABLE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
(
	[CTIME] datetime,
	[MTIME] int,
	[RecordID] bigint,
	[���] nvarchar(8),
	[�Ѳ��N�X] nvarchar(10),
	[�Ѳ��W��] nvarchar(20),
	[�}�L��] decimal(9,2),
	[�̰���] decimal(9,2),
	[�̧C��] decimal(9,2),
	[���L��] decimal(9,2),
	[���^] decimal(9,2),
);
/* DELETE FROM [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]; */

/* 12 */
INSERT INTO [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A](���, �Ѳ��N�X, �Ѳ��W��, �}�L��)
 VALUES('20181218', '0000', '����', 0);

/* 13 */
UPDATE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
SET �}�L�� = 1
WHERE �Ѳ��W�� LIKE '����';

/* 14 */
DELETE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A]
WHERE �}�L�� = 1;

/* 15 */
INSERT INTO [StockDB].[DBO].[�馬�L_�s�H�V�m_���������-���A]
SELECT [CTIME], [MTIME], [RecordID], [���], [�Ѳ��N��], [�Ѳ��W��], [�}�L��], [�̰���], [�̧C��], [���L��], [���^] FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE '20181214';

/* 16 */
DELETE [StockDB].[dbo].[�馬�L_�s�H�V�m_���������-���A];

/* 19 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE '20181206';

/* 20 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE (��� BETWEEN '20181201' AND '20181206') AND �Ѳ��N�� IN ('0050', '006201', '00721B');

/* 21 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE (��� BETWEEN '20181201' AND '20181206');

/* 22 */
SELECT ���, COUNT(*) AS ��Ƶ��� FROM [StockDB].[dbo].[�馬�L]
GROUP BY ���
HAVING ��� LIKE '2018%'

/* 23 */
SELECT �Ѳ��N��, SUM(�}�L��) AS �}�L���`�M, MIN(�̰���) AS �̤p�̰���, MAX(�̧C��) AS �̤j�̧C��, AVG(���L��) AS �������L�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN '20181201' AND '20181206'
GROUP BY �Ѳ��N��;

/* 24 */
SELECT DISTINCT �Ѳ��W��, SUBSTRING(�Ѳ��W��,0,3) AS �Y�g FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN '20181201' AND '20181206'

/* 25 */
SELECT DISTINCT RTRIM (LTRIM(�Ѳ��W��)) AS �Y���h�ť� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN '20181201' AND '20181206'

/* 26 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN '20181201' AND '20181206'
ORDER BY �Ѳ��N�� DESC, ��� ASC

/* 27 */
SELECT �Ѳ��N��, AVG(���L��) AS �������L�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� BETWEEN '20181201' AND '20181206'
GROUP BY �Ѳ��N��
HAVING AVG(���L��) < 80

/* 28 */
SELECT COUNT(*) AS �`��Ƶ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%'

/* 29 */
/* solution 1 */
SELECT COUNT(*) AS �`��Ƶ���
FROM ( (SELECT �Ѳ��N��, ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%' )
EXCEPT
(SELECT �Ѳ��N��, ��� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%' AND ���L�� IS NULL
)) AS �D�Ŧ��L��

/* solution 2 */
SELECT COUNT(*) AS �`��Ƶ���
FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%' AND (���L�� >=0 OR ���L�� < 0)


/* 30 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%' AND LEN(�Ѳ��N��) > 4

/* 31 */
SELECT DISTINCT REPLACE(�Ѳ��W��, '����', '__') AS �W�٥]�t���Ƥ��Ѳ� FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '2018%' AND �Ѳ��W�� LIKE '%����%'

/* 32 */
SELECT * from [StockDB].[DBO].[�馬�L] 
WHERE DATEDIFF(dd, CAST(��� AS DATE), GETDATE()) = 0

/* 33 */
SELECT * FROM (SELECT *,  ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ���) AS [Rank] FROM [StockDB].[dbo].[�馬�L] WHERE �Ѳ��N�� LIKE '1%' AND ��� LIKE '2018%') AS ����
WHERE ����.[Rank] = 6

/* 34 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE '20181206'
EXCEPT
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE '20181205'

/* 35 */
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE '20181206'
INTERSECT 
SELECT DISTINCT �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L]
WHERE [���] LIKE '20181205'

/* 36 */
SELECT �馬�L.* , �W���d.�^��W��  
FROM [StockDB].[dbo].[�馬�L] AS �馬�L JOIN [StockDB].[dbo].[�W���d�򥻸�ƪ�] AS �W���d ON �馬�L.�Ѳ��N�� = �W���d.�Ѳ��N�� AND SUBSTRING(�馬�L.���, 0, 5) LIKE  �W���d.�~��
WHERE �馬�L.��� LIKE '2018%'

/* 37 */
SELECT �馬�L.���, �馬�L.�Ѳ��W��, ETF.�~��, ETF.�W�� 
FROM (SELECT * FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE '20181214' ) AS �馬�L 
JOIN 
(SELECT �~��, �W��, �N�� FROM [StockDB].[dbo].[ETF�򥻸�ƪ�] WHERE �~�� LIKE '2018') AS ETF
ON �馬�L.�Ѳ��N�� = ETF.�N�� AND SUBSTRING(�馬�L.���, 0, 5) LIKE  ETF.�~��

/* 38 */
SELECT �W���d = 
CASE �W���d
	WHEN 1 THEN '�W��'
	WHEN 2 THEN '�W�d'
	WHEN 3 THEN '���d'
	WHEN 4 THEN '���o'
	ELSE '��L'
END,
[CTIME], [MTIME], [RecordID], [���], [�Ѳ��N��], [�Ѳ��W��], [�Ѧһ�], [�}�L��], [�̰���], [�̧C��], [���L��], [���^], [���~�N��], [������], [�^����], [���^���p], [�̫�e�R��], [�̫�e���], [���T(%)], [���T(%)], [����q], [����q(��)], [���浧��], [������B(�d)], [����Ȥ�(%)], [����q�ܰ�(%)], [�ѥ�(�ʸU)2], [���i�ܰ�(%)], [���i], [�`����(��)], [���Ȥ�(%)], [���ѥ��q��], [���Ѫѻ��b�Ȥ�], [���Ѫѻ��b�Ȥ�2], [���q��], [���q��(��|�u)], [�ѪF�v�q(�ʸU)], [�ѻ��b�Ȥ�], [�ѻ��b�Ȥ�2], [�ªѥ�(�ʸU)], [�e�R�i��], [�e��i��], [����Ѧһ�], [������B_��], [����], [�ѥ�(�ʸU)], [�g��v], [���^��]
FROM [StockDB].[dbo].[�馬�L] AS �馬�L
WHERE ��� BETWEEN '20181201' AND '20181206'

/* 39 */
SELECT [Range] = 
CASE 
	WHEN ���L��<10 THEN 'Under_10'
	WHEN ���L�� >= 10 AND ���L�� < 50 THEN 'Under_50'
	WHEN ���L�� >= 50 AND ���L�� < 100 THEN 'Under_100'
	WHEN ���L��>=100 THEN 'Over_100'
END, *
FROM [StockDB].[dbo].[�馬�L] AS �馬�L
WHERE ��� BETWEEN '20181201' AND '20181206'

/* 40 */
SELECT * FROM [StockDB].[dbo].[�馬�L]
WHERE ��� LIKE '20181206'
ORDER BY 
CASE
	WHEN ���L�� > 5 THEN ���L��
	WHEN ���L�� <=5 THEN ���L��*-1
	END
DESC 

/* 41 */
SELECT * FROM
(
	SELECT *, ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS ���� 
	FROM [StockDB].[dbo].[�馬�L]
	WHERE �Ѳ��N�� IN (SELECT DISTINCT TOP 1000 �Ѳ��N�� FROM [StockDB].[dbo].[�馬�L])
) AS �Y1000�ɪѲ�
WHERE �Y1000�ɪѲ�.���� = 1


/* 46 */

SELECT * 
FROM (
	SELECT *,  ROW_NUMBER() OVER(PARTITION BY �Ѳ��N�� ORDER BY ��� DESC) AS [Rank] 
	FROM [StockDB].[dbo].[�馬�L] 
	WHERE �Ѳ��N�� IN 
		(
		SELECT �Ѳ��N�� 
		FROM [StockDB].[dbo].[�W���d�򥻸�ƪ�] 
		WHERE �~�� LIKE '2018' AND ���P����� = 1
		)
	AND ��� LIKE '2018%'
	) AS ����
WHERE ����.[Rank] = 1

/* 47 */
SELECT ��ɶU�e.���,��ɶU��.�Ѳ��N��, ��ɶU�e.��Ӥ����γ~�ɶU�l�B, ��ɶU��.���, ��ɶU��.�Ѳ��N��, ��ɶU��.��Ӥ����γ~�ɶU�e��l�B
FROM [StockDB].[dbo].[��ɶU�ڶ���O�~�l�B��] AS ��ɶU�� JOIN [StockDB].[dbo].[��ɶU�ڶ���O�~�l�B��] AS ��ɶU�e 
ON ��ɶU��.�Ѳ��N�� = ��ɶU�e.�Ѳ��N�� AND DATEDIFF(dd, CAST(��ɶU�e.��� AS DATE), CAST(��ɶU��.��� AS DATE)) = 1
WHERE ��ɶU��.��Ӥ����γ~�ɶU�e��l�B != ��ɶU�e.��Ӥ����γ~�ɶU�l�B

/* 48 */
SELECT �s�V.�Ѳ��N�� , �s�V.���L�� AS �s�V���L, �馬�L.�Ѳ��N��, �馬�L.���L�� AS �馬�L FROM 
(SELECT * FROM [StockDB].[dbo].[�馬�L_�s�H�V�m_2016] WHERE ��� LIKE '20161212' ) AS �s�V
JOIN 
(SELECT * FROM [StockDB].[dbo].[�馬�L] WHERE ��� LIKE '20161212' ) AS �馬�L
ON �馬�L.�Ѳ��N�� = �s�V.�Ѳ��N��
WHERE �馬�L.���L�� != �s�V.���L��

/* OR THIS*/
SELECT �s�V.�Ѳ��N�� , �s�V.���L�� AS �s�V���L, �馬�L.�Ѳ��N��, �馬�L.���L�� AS �馬�L FROM 
[StockDB].[dbo].[�馬�L_�s�H�V�m_2016] AS �s�V
JOIN 
[StockDB].[dbo].[�馬�L] AS �馬�L
ON �馬�L.��� LIKE '20161212' AND �s�V.��� LIKE '20161212' AND �馬�L.�Ѳ��N�� = �s�V.�Ѳ��N��
WHERE �馬�L.���L�� != �s�V.���L��


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
	WHERE ��� LIKE '20181214'
)
SELECT * FROM TESTCTE