
CREATE DATABASE AEP

GO

USE AEP

GO

--Creating Image table
CREATE TABLE [dbo].[Image](
[Id] int IDENTITY(1,1) not null,
[Content] nvarchar(max) not null,
[Title] nvarchar(300) null,
[Description] nvarchar (500) null
)

GO

-- Creating primary key for Image table
ALTER TABLE [dbo].[Image]
ADD CONSTRAINT [PK_ImageId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

--------------------------------------------------------------------
--Creating Vocabulary table
CREATE TABLE [dbo].[Vocabulary](
[Id] int IDENTITY(1,1) not null,
[ImageId] int, 
[Word] nvarchar(200) not null,
[Synonym] nvarchar(1000) not null,
)

GO

-- Creating primary key for [Vocabulary] table
ALTER TABLE [dbo].[Vocabulary]
ADD CONSTRAINT [PK_VocabularyId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key for ImageId 
ALTER TABLE [dbo].[Vocabulary] WITH CHECK ADD CONSTRAINT 
[FK_Vocabulary_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO

--------------------------------------------------------------------
CREATE TABLE [dbo].[Accent](
[Id] int IDENTITY(1,1) not null,
[ImageId] int, 
[British] nvarchar(300) not null,
[American] nvarchar(300) not null
)

GO

-- Creating primary key for [Accent] table
ALTER TABLE [dbo].[Accent]
ADD CONSTRAINT [PK_AccentId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key for ImageId
ALTER TABLE [dbo].[Accent] WITH CHECK ADD CONSTRAINT 
[FK_Accent_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO
--------------------------------------------------------------------

CREATE TABLE [dbo].[ProseActivity](
[Id] int IDENTITY(1,1) not null,
[AccentId] int, 
[Question] nvarchar(300) null,
[Answer] nvarchar(300) null,
[Result] bit,
[Datetime] datetime,
[Identity] nvarchar(200) null,
)

GO

-- Creating primary key for [ProseActivity] table
ALTER TABLE [dbo].[ProseActivity]
ADD CONSTRAINT [PK_ProseActivityId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key for AccentId
ALTER TABLE [dbo].[ProseActivity] WITH CHECK ADD CONSTRAINT 
[FK_ProseActivity_Accent] FOREIGN KEY([AccentId])
REFERENCES [dbo].[Accent] ([Id])
GO

--------------------------------------------------------------------

CREATE TABLE [dbo].[Lesson](
[Id] int IDENTITY(1,1) not null,
[Name] nvarchar(300) not null, 
[Description] nvarchar(max) null,
)

GO

-- Creating primary key for [Lesson] table
ALTER TABLE [dbo].[Lesson]
ADD CONSTRAINT [PK_LessonId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

--------------------------------------------------------------------

CREATE TABLE [dbo].[Page](
[Id] int IDENTITY(1,1) not null,
[Content] nvarchar(max) null,
)

GO

-- Creating primary key for [Vocabulary] table
ALTER TABLE [dbo].[Page]
ADD CONSTRAINT [PK_PageId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO


--------------------------------------------------------------------

CREATE TABLE [dbo].[LessonPageMapping](
[Id] int IDENTITY(1,1) not null,
[LessonId] int,
[PageId] int,
)

GO

-- Creating primary key for [Vocabulary] table
ALTER TABLE [dbo].[LessonPageMapping]
ADD CONSTRAINT [PK_LessonPageMappingId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key for LessonId 
ALTER TABLE [dbo].[LessonPageMapping] WITH CHECK ADD CONSTRAINT 
[FK_LessonPageMapping_Lesson] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
GO

-- Creating foreign key for PageId 
ALTER TABLE [dbo].[LessonPageMapping] WITH CHECK ADD CONSTRAINT 
[FK_LessonPageMapping_Page] FOREIGN KEY([PageId])
REFERENCES [dbo].[Page] ([Id])
GO

-- Creating User table

CREATE TABLE [dbo].[User](
[Id] int IDENTITY(1,1) not null,
[FirstName] nvarchar(300) null,
[LastName] nvarchar(300) null,
[UserName] nvarchar(300) not null,
[Password] nvarchar(max) not null,
[Address] nvarchar(max) null,
[Email] nvarchar(300) null,
[Phone] nvarchar(50) null,
[IsActive] bit
)

GO

-- Creating primary key for Image table
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_UserId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating QuestionSet table

CREATE TABLE [dbo].[QuestionSet] (
[Id] int IDENTITY(1,1) not null,
[QuestionId] nvarchar(max) not null,
[UserId] int not null,
[DateCreated] datetime
)

-- Creating primary key for the QuestionSet table

ALTER TABLE [dbo].[QuestionSet]
ADD CONSTRAINT [PK_QuestionSetId]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key for UserId

ALTER TABLE [dbo].[QuestionSet] WITH CHECK ADD CONSTRAINT 
[FK_QuestionSet_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

sp_RENAME '[ProseActivity].[Identity]' , 'UserId', 'COLUMN'

ALTER TABLE dbo.ProseActivity
   ALTER COLUMN UserId int not null
