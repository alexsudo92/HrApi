create table Interactions
(
    Id          TEXT    not null
        constraint PK_Interactions
            primary key,
    Date        TEXT    not null,
    Type        INTEGER not null,
    Message     TEXT    not null,
    CandidateId TEXT
        constraint FK_Interactions_Candidates_CandidateId
            references Candidates
);

create index IX_Interactions_CandidateId
    on Interactions (CandidateId);

INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e33-bf5f-48d1a0fb6c39', '2024-01-16T10:00:00', 2, 'Кандидат откликнулся на вакансию Frontend Developer', '018e32d3-7e69-7e29-15bf-ae3df08b2c6f');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e34-c06f-59e2b1fc7d4a', '2024-01-17T14:30:00', 3, 'Первичный скрининг, обсуждение опыта работы с React и TypeScript', '018e32d3-7e69-7e29-15bf-ae3df08b2c6f');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e35-d17f-6af3c2fd8e5b', '2024-01-19T11:00:00', 6, 'Техническое собеседование с командой разработки', '018e32d3-7e69-7e29-15bf-ae3df08b2c6f');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e36-e28f-7b04d3fe9f6c', '2024-01-22T09:15:00', 2, 'Отклик на вакансию Backend Developer', '018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e37-f39f-8c15e4ffa07d', '2024-01-23T16:45:00', 4, 'Назначено техническое задание по Node.js и PostgreSQL', '018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e38-04af-9d26f500b18e', '2024-01-25T13:00:00', 6, 'Собеседование с тимлидом backend-отдела', '018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e39-15bf-ae37f601c29f', '2024-02-02T08:30:00', 2, 'Новый отклик на вакансию менеджера по продажам', '018e32d3-7e69-7e2b-37df-c05f2ad4e8b1');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3a-26cf-bf48f702d3a0', '2024-02-03T11:20:00', 3, 'Знакомство, обсуждение опыта в Сбермаркете', '018e32d3-7e69-7e2b-37df-c05f2ad4e8b1');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3b-37df-c05ff803e4b1', '2024-01-12T14:00:00', 2, 'Отклик на вакансию DevOps инженера', '018e32d3-7e69-7e2c-48ef-d16a3be5f9c2');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3c-48ef-d16bf904f5c2', '2024-01-15T10:00:00', 6, 'Техническое собеседование по Kubernetes и AWS', '018e32d3-7e69-7e2c-48ef-d16a3be5f9c2');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3d-59ff-e27cfa05f6d3', '2024-01-18T17:30:00', 7, 'Выставлено офферное предложение на 200000 руб.', '018e32d3-7e69-7e2c-48ef-d16a3be5f9c2');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3e-6a0f-f38dfb06f7e4', '2024-02-11T12:15:00', 2, 'Отклик на вакансию UX/UI дизайнера', '018e32d3-7e69-7e2d-59ff-e27b4cf60ad3');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e3f-7b1f-049efc07f8f5', '2024-02-12T15:45:00', 6, 'Просмотр портфолио, обсуждение опыта в СберДизайне', '018e32d3-7e69-7e2d-59ff-e27b4cf60ad3');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e40-8c2f-15affd08f906', '2024-02-14T11:00:00', 8, 'Кандидат принят на работу на условиях part-time', '018e32d3-7e69-7e2d-59ff-e27b4cf60ad3');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e41-9d3f-26b0fe09fa17', '2024-02-06T13:20:00', 2, 'Студент 4 курса НГУ откликнулся на стажировку', '018e32d3-7e69-7e2e-6a0f-f38c5da71be4');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e42-ae4f-37c1ff0afb28', '2024-02-07T10:30:00', 3, 'Собеседование с ментором, оценка базовых навыков', '018e32d3-7e69-7e2e-6a0f-f38c5da71be4');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e43-bf5f-48d2000bfc39', '2024-01-26T16:00:00', 2, 'Отклик на вакансию аналитика данных', '018e32d3-7e69-7e2f-7b1f-049d6eb82cf5');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e44-c06f-59e3010cfd4a', '2024-01-29T14:00:00', 6, 'Кейс-интервью по аналитике и SQL', '018e32d3-7e69-7e2f-7b1f-049d6eb82cf5');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e45-d17f-6af4020dfe5b', '2024-02-16T09:45:00', 2, 'Отклик на вакансию маркетолога', '018e32d3-7e69-7e30-8c2f-15ae7fc93d06');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e46-e28f-7b05030eff6c', '2024-02-19T11:30:00', 6, 'Собеседование с руководителем маркетингового отдела', '018e32d3-7e69-7e30-8c2f-15ae7fc93d06');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e47-f39f-8c16040fa07d', '2024-02-21T16:15:00', 9, 'Кандидат не подошел по требованиям к опыту работы', '018e32d3-7e69-7e30-8c2f-15ae7fc93d06');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e48-04af-9d27050fb18e', '2024-02-01T15:10:00', 2, 'Новый отклик на вакансию системного администратора', '018e32d3-7e69-7e31-9d3f-26bf8eda4e17');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e49-15bf-ae380610c29f', '2024-02-02T12:00:00', 4, 'Отправлено приглашение на техническое собеседование', '018e32d3-7e69-7e31-9d3f-26bf8eda4e17');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e4a-26cf-bf490711d3a0', '2024-02-13T10:30:00', 2, 'Отклик на вакансию менеджера по продукту', '018e32d3-7e69-7e32-ae4f-37c09feb5f28');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e4b-37df-c05a0812e4b1', '2024-02-14T15:00:00', 6, 'Собеседование с продукт-директором', '018e32d3-7e69-7e32-ae4f-37c09feb5f28');
INSERT INTO Interactions (Id, Date, Type, Message, CandidateId) VALUES ('018e32d3-7e69-7e4c-48ef-d16b0913f5c2', '2024-02-16T18:00:00', 7, 'Выставлен оффер с зарплатой 190000 руб.', '018e32d3-7e69-7e32-ae4f-37c09feb5f28');
