--Triggers and Transactions
--Lab
--TRANSACTIONS
CREATE PROC usp_TransferFunds(@FromAccountId INT, @ToAccountId INT, @Amount MONEY)
AS
BEGIN TRANSACTION
	IF (SELECT [Balance] FROM [Accounts] WHERE [Id] = @FromAccountId) < @Amount
	BEGIN
		ROLLBACK;
		THROW 50001, 'Insufficient funds', 1;
	END

	IF (SELECT COUNT(*) FROM [Accounts] WHERE [Id] IN (@FromAccountId, @ToAccountId)) < 2
	BEGIN
		ROLLBACK;
		THROW 50002, 'InvalidIdAccount', 1;
	END

	UPDATE [Accounts]
		SET [Balance] = [Balance] - @Amount
		WHERE [Id] = @FromAccountId;
	
	UPDATE [Accounts]
		SET [Balance] = [Balance] + @Amount
		WHERE [Id] = @ToAccountId;
COMMIT

--TRIGGER ON UPDATE ACCOUNT => INSERT LOGS
CREATE TRIGGER tr_OnAccountChangeAddLogRecord
ON [Accounts] FOR UPDATE
AS
	INSERT [AccountChanges]([AccountId], [OldBalance], [NewBalance], [DateOfChange])
	SELECT i.[Id], d.[Balance], i.[Balance], GETDATE()
		FROM [inserted] i
		JOIN [deleted] d ON d.[Id] = i.[Id]
		WHERE i.[Balance] != d.[Balance]
GO
--TRIGGER ON DELETE ACCOUNTHOLDER => NO DELETE => UPDATE IsDeleted
CREATE TRIGGER tr_OnDeleteAccountHoldersSetIsDeleted
ON [AccountHolders] INSTEAD OF DELETE
AS
	UPDATE [AccountHolders]
		SET [IsDeleted] = 1
		WHERE [Id] IN (SELECT [Id] FROM [deleted])
GO

--Exercises
--PROBLEM 01 - Create Table Logs
CREATE TRIGGER tr_OnAccountChangeAddLogRecord
ON [Accounts] FOR UPDATE
AS
	INSERT [Logs]([AccountId], [OldSum], [NewSum])
	SELECT i.[Id], d.[Balance], i.[Balance]
		FROM [inserted] i
		JOIN [deleted] d ON d.[Id] = i.[Id]
		WHERE i.[Balance] != d.[Balance]

--PROBLEM 02 - Create Table Emails
CREATE TRIGGER tr_Logs_NotificationEmails
ON Logs FOR INSERT
AS
	INSERT INTO [NotificationEmails]
	VALUES
	(
	(
	    SELECT [AccountId]
	    FROM [inserted]
	),
	CONCAT('Balance change for account: ',
	      (
	          SELECT [AccountId]
	          FROM [inserted]
	      )),
	CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ',
	      (
	          SELECT [OldSum]
	          FROM [Logs]
	      ), ' to ',
	      (
	          SELECT [NewSum]
				FROM [Logs]), '.'))