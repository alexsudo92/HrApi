create table Workplace
(
    Id          TEXT not null
        constraint PK_Workplace
            primary key,
    Name        TEXT not null,
    StartDate   TEXT not null,
    EndDate     TEXT not null,
    CandidateId TEXT
        constraint FK_Workplace_Candidates_CandidateId
            references Candidates
);

create index IX_Workplace_CandidateId
    on Workplace (CandidateId);

INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e4d-59ff-e27b4cf60ad4', 'Яндекс', '2020-03-01', '2023-12-31', '018e32d3-7e69-7e29-15bf-ae3df08b2c6f');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e4e-6a0f-f38c5da71be5', 'Тинькофф', '2018-06-01', '2020-02-28', '018e32d3-7e69-7e29-15bf-ae3df08b2c6f');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e4f-7b1f-049d6eb82cf6', 'Ozon', '2021-01-15', '2024-01-31', '018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e50-8c2f-15ae7fc93d07', 'Lamoda', '2019-09-01', '2020-12-31', '018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e51-9d3f-26bf8eda4e18', 'Сбермаркет', '2022-02-01', '2024-01-15', '018e32d3-7e69-7e2b-37df-c05f2ad4e8b1');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e52-ae4f-37c09feb5f29', 'Avito', '2019-04-01', '2024-01-20', '018e32d3-7e69-7e2c-48ef-d16a3be5f9c2');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e53-bf5f-48d1a0fb6c40', 'Mail.ru Group', '2017-09-01', '2019-03-31', '018e32d3-7e69-7e2c-48ef-d16a3be5f9c2');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e54-c06f-59e2b1fc7d4b', 'СберДизайн', '2021-07-01', '2024-01-25', '018e32d3-7e69-7e2d-59ff-e27b4cf60ad3');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e55-d17f-6af3c2fd8e5c', 'Тинькофф Аналитика', '2021-03-01', '2024-01-18', '018e32d3-7e69-7e2f-7b1f-049d6eb82cf5');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e56-e28f-7b04d3fe9f6d', 'Wildberries', '2021-01-10', '2024-01-30', '018e32d3-7e69-7e30-8c2f-15ae7fc93d06');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e57-f39f-8c15e4ffa07e', 'Уралсиб', '2020-11-01', '2024-01-10', '018e32d3-7e69-7e31-9d3f-26bf8eda4e17');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e58-04af-9d26f500b18f', 'VK', '2019-08-01', '2024-01-28', '018e32d3-7e69-7e32-ae4f-37c09feb5f28');
INSERT INTO Workplace (Id, Name, StartDate, EndDate, CandidateId) VALUES ('018e32d3-7e69-7e59-15bf-ae37f601c2a0', 'Рамблер', '2017-05-01', '2019-07-31', '018e32d3-7e69-7e32-ae4f-37c09feb5f28');
