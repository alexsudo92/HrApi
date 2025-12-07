create table AspNetUserTokens
(
    UserId        TEXT not null
        constraint FK_AspNetUserTokens_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    LoginProvider TEXT not null,
    Name          TEXT not null,
    Value         TEXT,
    constraint PK_AspNetUserTokens
        primary key (UserId, LoginProvider, Name)
);

