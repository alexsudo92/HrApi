create table AspNetUserRoles
(
    UserId TEXT not null
        constraint FK_AspNetUserRoles_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    RoleId TEXT not null
        constraint FK_AspNetUserRoles_AspNetRoles_RoleId
            references AspNetRoles
            on delete cascade,
    constraint PK_AspNetUserRoles
        primary key (UserId, RoleId)
);

create index IX_AspNetUserRoles_RoleId
    on AspNetUserRoles (RoleId);

INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('AB9E43F7-9E1A-4061-A8A3-40580D7359A1', '4922550F-282E-4409-B9D6-13AF1A3C6737');
