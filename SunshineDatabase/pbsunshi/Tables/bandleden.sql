CREATE TABLE [pbsunshi].[bandleden] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [biografie] TEXT         NOT NULL,
    [foto]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_bandleden] PRIMARY KEY CLUSTERED ([id] ASC)
);

