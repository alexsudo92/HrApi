create table AspNetRoles
(
    Id               TEXT not null
        constraint PK_AspNetRoles
            primary key,
    Name             TEXT,
    NormalizedName   TEXT,
    ConcurrencyStamp TEXT
);

create unique index RoleNameIndex
    on AspNetRoles (NormalizedName);

INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('96819CA1-92AE-4A46-9F59-9670F5232211', 'User', 'USER', 'e9a39f26-85fd-49b0-b9a1-4a492ccd4cff');
INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('3AA72D20-FB46-4A27-9DFE-DE0D160D7248', 'Hr', 'HR', '9769bafc-591e-43be-8d31-aad9fd05a312');
INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('A414046D-ED08-47E1-9CE1-AAEDA744D6AE', 'BranchHead', 'BRANCHHEAD', '5efef764-cb4c-4d09-85ba-9fa7d99e5cb4');
INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('4922550F-282E-4409-B9D6-13AF1A3C6737', 'Admin', 'ADMIN', 'bf000e26-8310-4bbf-bd07-9df7b8a1a6e8');
