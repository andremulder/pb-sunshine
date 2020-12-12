CREATE TABLE [pbsunshi].[gastenboek] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [naam]       VARCHAR (100) NULL,
    [email]      VARCHAR (100) NULL,
    [woonplaats] VARCHAR (255) NULL,
    [website]    VARCHAR (255) NULL,
    [bericht]    TEXT          NULL,
    [datum]      DATETIME      NULL,
    [ip]         VARCHAR (255) NULL,
    [host]       VARCHAR (255) NULL,
    [browser]    VARCHAR (255) NULL,
    CONSTRAINT [PK_gastenboek] PRIMARY KEY CLUSTERED ([id] ASC)
);

