CREATE TABLE [dbo].[TrainingDetails] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [TrainingName] VARCHAR (500) NULL,
    [StartDate]    DATETIME      NULL,
    [EndDate]      DATETIME      NULL,
    [CreatedBy]    VARCHAR (100) NULL,
    [IsActive]     BIT           NULL,
    [CreatedOn]    DATETIME      NULL,
    [UpdatedBy]    VARCHAR (100) NULL,
    [UpdateOn]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

