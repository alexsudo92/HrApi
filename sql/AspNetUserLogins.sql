create table AspNetUserLogins
(
    LoginProvider       TEXT not null,
    ProviderKey         TEXT not null,
    ProviderDisplayName TEXT,
    UserId              TEXT not null
        constraint FK_AspNetUserLogins_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    constraint PK_AspNetUserLogins
        primary key (LoginProvider, ProviderKey)
);

create index IX_AspNetUserLogins_UserId
    on AspNetUserLogins (UserId);

