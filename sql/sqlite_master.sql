create table sqlite_master
(
    type     TEXT,
    name     TEXT,
    tbl_name TEXT,
    rootpage INT,
    sql      TEXT
);

INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetRoles', 'AspNetRoles', 2, 'CREATE TABLE "AspNetRoles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_AspNetRoles_1', 'AspNetRoles', 3, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetUsers', 'AspNetUsers', 4, 'CREATE TABLE "AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "Avatar" TEXT NOT NULL,
    "UserName" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "Email" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_AspNetUsers_1', 'AspNetUsers', 5, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'Candidates', 'Candidates', 6, 'CREATE TABLE "Candidates" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Candidates" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Phone" TEXT NOT NULL,
    "Mail" TEXT NOT NULL,
    "Salary" REAL NOT NULL,
    "Status" INTEGER NOT NULL,
    "Skills" TEXT NOT NULL,
    "Education" TEXT NOT NULL,
    "Experience" INTEGER NOT NULL,
    "Employment" INTEGER NOT NULL,
    "WorkHours" INTEGER NOT NULL,
    "RespondDate" TEXT NOT NULL
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_Candidates_1', 'Candidates', 7, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'Vacancies', 'Vacancies', 8, 'CREATE TABLE "Vacancies" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Vacancies" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "StartSalary" REAL NOT NULL,
    "EndSalary" REAL NOT NULL,
    "Description" TEXT NOT NULL,
    "Education" TEXT NOT NULL,
    "Experience" INTEGER NOT NULL,
    "Employment" INTEGER NOT NULL,
    "WorkHours" INTEGER NOT NULL,
    "Location" TEXT NOT NULL,
    "Branch" TEXT NOT NULL,
    "Tags" TEXT NOT NULL,
    "PostDate" TEXT NOT NULL,
    "EndDate" TEXT NOT NULL,
    "Status" INTEGER NOT NULL,
    "Requirements" TEXT NOT NULL,
    "Tasks" TEXT NOT NULL,
    "Features" TEXT NOT NULL
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_Vacancies_1', 'Vacancies', 9, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetRoleClaims', 'AspNetRoleClaims', 10, 'CREATE TABLE "AspNetRoleClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,
    "RoleId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'sqlite_sequence', 'sqlite_sequence', 11, 'CREATE TABLE sqlite_sequence(name,seq)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetUserClaims', 'AspNetUserClaims', 12, 'CREATE TABLE "AspNetUserClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,
    "UserId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetUserLogins', 'AspNetUserLogins', 13, 'CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_AspNetUserLogins_1', 'AspNetUserLogins', 14, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetUserRoles', 'AspNetUserRoles', 15, 'CREATE TABLE "AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_AspNetUserRoles_1', 'AspNetUserRoles', 16, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'AspNetUserTokens', 'AspNetUserTokens', 19, 'CREATE TABLE "AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_AspNetUserTokens_1', 'AspNetUserTokens', 20, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'Interactions', 'Interactions', 21, 'CREATE TABLE "Interactions" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Interactions" PRIMARY KEY,
    "Date" TEXT NOT NULL,
    "Type" INTEGER NOT NULL,
    "Message" TEXT NOT NULL,
    "CandidateId" TEXT NULL,
    CONSTRAINT "FK_Interactions_Candidates_CandidateId" FOREIGN KEY ("CandidateId") REFERENCES "Candidates" ("Id")
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_Interactions_1', 'Interactions', 22, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'Workplace', 'Workplace', 23, 'CREATE TABLE "Workplace" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Workplace" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "StartDate" TEXT NOT NULL,
    "EndDate" TEXT NOT NULL,
    "CandidateId" TEXT NULL,
    CONSTRAINT "FK_Workplace_Candidates_CandidateId" FOREIGN KEY ("CandidateId") REFERENCES "Candidates" ("Id")
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_Workplace_1', 'Workplace', 24, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('table', 'CandidateVacancy', 'CandidateVacancy', 25, 'CREATE TABLE "CandidateVacancy" (
    "CandidatesId" TEXT NOT NULL,
    "VacanciesId" TEXT NOT NULL,
    CONSTRAINT "PK_CandidateVacancy" PRIMARY KEY ("CandidatesId", "VacanciesId"),
    CONSTRAINT "FK_CandidateVacancy_Candidates_CandidatesId" FOREIGN KEY ("CandidatesId") REFERENCES "Candidates" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CandidateVacancy_Vacancies_VacanciesId" FOREIGN KEY ("VacanciesId") REFERENCES "Vacancies" ("Id") ON DELETE CASCADE
)');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'sqlite_autoindex_CandidateVacancy_1', 'CandidateVacancy', 26, null);
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_AspNetRoleClaims_RoleId', 'AspNetRoleClaims', 27, 'CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'RoleNameIndex', 'AspNetRoles', 28, 'CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_AspNetUserClaims_UserId', 'AspNetUserClaims', 29, 'CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_AspNetUserLogins_UserId', 'AspNetUserLogins', 30, 'CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_AspNetUserRoles_RoleId', 'AspNetUserRoles', 31, 'CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'EmailIndex', 'AspNetUsers', 32, 'CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'UserNameIndex', 'AspNetUsers', 33, 'CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_CandidateVacancy_VacanciesId', 'CandidateVacancy', 34, 'CREATE INDEX "IX_CandidateVacancy_VacanciesId" ON "CandidateVacancy" ("VacanciesId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_Interactions_CandidateId', 'Interactions', 35, 'CREATE INDEX "IX_Interactions_CandidateId" ON "Interactions" ("CandidateId")');
INSERT INTO sqlite_master (type, name, tbl_name, rootpage, sql) VALUES ('index', 'IX_Workplace_CandidateId', 'Workplace', 36, 'CREATE INDEX "IX_Workplace_CandidateId" ON "Workplace" ("CandidateId")');
