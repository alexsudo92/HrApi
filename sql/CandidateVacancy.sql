create table CandidateVacancy
(
    CandidatesId TEXT not null
        constraint FK_CandidateVacancy_Candidates_CandidatesId
            references Candidates
            on delete cascade,
    VacanciesId  TEXT not null
        constraint FK_CandidateVacancy_Vacancies_VacanciesId
            references Vacancies
            on delete cascade,
    constraint PK_CandidateVacancy
        primary key (CandidatesId, VacanciesId)
);

create index IX_CandidateVacancy_VacanciesId
    on CandidateVacancy (VacanciesId);

INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e29-15bf-ae3df08b2c6f', '018e32d3-7e69-7e1f-9b1f-5a3e8f7d8a5b');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0', '018e32d3-7e69-7e20-8c2f-1b4a6d9e3f7c');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2b-37df-c05f2ad4e8b1', '018e32d3-7e69-7e21-9d3f-2c5b7e0f4a8d');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2c-48ef-d16a3be5f9c2', '018e32d3-7e69-7e22-ae4f-3d6c8f1a5b9e');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2d-59ff-e27b4cf60ad3', '018e32d3-7e69-7e23-bf5f-4e7d9a2b6c0f');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2e-6a0f-f38c5da71be4', '018e32d3-7e69-7e24-c06f-5f8eab3c7d1a');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e2f-7b1f-049d6eb82cf5', '018e32d3-7e69-7e25-d17f-6a9fbc4d8e2b');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e30-8c2f-15ae7fc93d06', '018e32d3-7e69-7e26-e28f-7b0acd5e9f3c');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e31-9d3f-26bf8eda4e17', '018e32d3-7e69-7e27-f39f-8c1bde6f0a4d');
INSERT INTO CandidateVacancy (CandidatesId, VacanciesId) VALUES ('018e32d3-7e69-7e32-ae4f-37c09feb5f28', '018e32d3-7e69-7e28-04af-9d2cef7a1b5e');
