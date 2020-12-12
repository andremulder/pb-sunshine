CREATE TABLE [pbsunshi].[contact] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [naam]      VARCHAR (255) NULL,
    [email]     VARCHAR (255) NULL,
    [telefoon]  VARCHAR (50)  NULL,
    [onderwerp] VARCHAR (255) NULL,
    [bericht]   TEXT          NULL,
    [ip]        VARCHAR (50)  NULL,
    [host]      VARCHAR (50)  NULL,
    CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED ([id] ASC)
);

