CREATE TABLE YouPlay.user (
    Id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    ExternalId VARCHAR(100) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    CreatedBy INTEGER NOT NULL,
    CreatedOn TIMESTAMP WITH TIME ZONE NOT NULL,
    ModifiedBy INTEGER NOT NULL,
    ModifiedOn TIMESTAMP WITH TIME ZONE NOT NULL
);

INSERT INTO YouPlay.user (
    ExternalId, Name, Email, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn
) VALUES (
    'system', 'System', 'system@admin.com', 1, now(), 1, now() at time zone 'utc'
);

ALTER TABLE YouPlay.user
ADD CONSTRAINT FK_CreatedBy_User FOREIGN KEY (CreatedBy) REFERENCES YouPlay.User (id);

ALTER TABLE YouPlay.user
ADD CONSTRAINT FK_ModifiedBy_User FOREIGN KEY (ModifiedBy) REFERENCES YouPlay.User (id);