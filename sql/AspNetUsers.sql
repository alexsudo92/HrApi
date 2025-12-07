create table AspNetUsers
(
    Id                   TEXT    not null
        constraint PK_AspNetUsers
            primary key,
    Avatar               TEXT    not null,
    UserName             TEXT,
    NormalizedUserName   TEXT,
    Email                TEXT,
    NormalizedEmail      TEXT,
    EmailConfirmed       INTEGER not null,
    PasswordHash         TEXT,
    SecurityStamp        TEXT,
    ConcurrencyStamp     TEXT,
    PhoneNumber          TEXT,
    PhoneNumberConfirmed INTEGER not null,
    TwoFactorEnabled     INTEGER not null,
    LockoutEnd           TEXT,
    LockoutEnabled       INTEGER not null,
    AccessFailedCount    INTEGER not null
);

create index EmailIndex
    on AspNetUsers (NormalizedEmail);

create unique index UserNameIndex
    on AspNetUsers (NormalizedUserName);

INSERT INTO AspNetUsers (Id, Avatar, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES ('AB9E43F7-9E1A-4061-A8A3-40580D7359A1', '00000000-0000-0000-0000-000000000000', 'Admin', 'ADMIN', 'admin@admin.com', 'ADMIN@ADMIN.COM', 0, 'AQAAAAIAAYagAAAAEJsS7kMxfCDXiUOJIXdFlxqxt7M5WueTJT4JccAcc20gYkUii8fGhcQ/WJgT4/xqbQ==', 'TYMQ7XF7YKKKT6R7XDW4PC6F2JQATOY2', '47e3cfad-c366-497e-bf04-7cb29f5f5877', null, 0, 0, null, 1, 0);
