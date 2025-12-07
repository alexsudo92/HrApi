create table AspNetUserClaims
(
    Id         INTEGER not null
        constraint PK_AspNetUserClaims
            primary key autoincrement,
    UserId     TEXT    not null
        constraint FK_AspNetUserClaims_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    ClaimType  TEXT,
    ClaimValue TEXT
);

create index IX_AspNetUserClaims_UserId
    on AspNetUserClaims (UserId);

