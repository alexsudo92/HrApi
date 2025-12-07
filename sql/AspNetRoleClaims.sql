create table AspNetRoleClaims
(
    Id         INTEGER not null
        constraint PK_AspNetRoleClaims
            primary key autoincrement,
    RoleId     TEXT    not null
        constraint FK_AspNetRoleClaims_AspNetRoles_RoleId
            references AspNetRoles
            on delete cascade,
    ClaimType  TEXT,
    ClaimValue TEXT
);

create index IX_AspNetRoleClaims_RoleId
    on AspNetRoleClaims (RoleId);

