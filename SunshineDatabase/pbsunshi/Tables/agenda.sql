CREATE TABLE [pbsunshi].[agenda] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [datum]               DATE          NOT NULL,
    [adres]               VARCHAR (255) NULL,
    [omschrijving]        VARCHAR (255) NOT NULL,
    [openbaar]            BIT           NULL,
    [van]                 TIME (7)      NULL,
    [tot]                 TIME (7)      NULL,
    [googleAgendaSynchId] VARCHAR (255) NULL,
    CONSTRAINT [PK_agenda] PRIMARY KEY CLUSTERED ([id] ASC)
);

