CREATE TABLE [pbsunshi].[fotos] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [album_id]     INT           NOT NULL,
    [bestandsnaam] VARCHAR (255) NULL,
    [bekeken]      INT           NULL,
    [host]         VARCHAR (255) NULL,
    CONSTRAINT [PK_fotos] PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([album_id]) REFERENCES [pbsunshi].[fotoalbum] ([album_id])
);

