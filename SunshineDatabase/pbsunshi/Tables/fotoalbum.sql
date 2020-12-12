CREATE TABLE [pbsunshi].[fotoalbum] (
    [album_id] INT           IDENTITY (1, 1) NOT NULL,
    [naam]     VARCHAR (255) NULL,
    [datum]    DATE          NULL,
    [fotomap]  VARCHAR (255) NULL,
    [soort]    VARCHAR (50)  NULL,
    CONSTRAINT [PK_fotoalbum] PRIMARY KEY CLUSTERED ([album_id] ASC)
);

