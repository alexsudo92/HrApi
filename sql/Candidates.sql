create table Candidates
(
    Id          TEXT    not null
        constraint PK_Candidates
            primary key,
    Name        TEXT    not null,
    Phone       TEXT    not null,
    Mail        TEXT    not null,
    Salary      REAL    not null,
    Status      INTEGER not null,
    Skills      TEXT    not null,
    Education   TEXT    not null,
    Experience  INTEGER not null,
    Employment  INTEGER not null,
    WorkHours   INTEGER not null,
    RespondDate TEXT    not null
);

INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e29-15bf-ae3df08b2c6f', 'Иванов Алексей Петрович', '+7 (915) 123-45-67', 'alexey.ivanov@mail.ru', 160000, 1, '["React","TypeScript","Redux","Webpack","Jest"]', 'МГТУ им. Баумана, Факультет информатики', 5, 0, 40, '2024-01-16');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2a-26cf-bf4e19c3d7a0', 'Петрова Мария Сергеевна', '+7 (916) 234-56-78', 'petrova.m@yandex.ru', 180000, 1, '["Node.js","PostgreSQL","Docker","AWS","Redis"]', 'СПбГУ, Математико-механический факультет', 4, 1, 35, '2024-01-22');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2b-37df-c05f2ad4e8b1', 'Сидоров Дмитрий Владимирович', '+7 (917) 345-67-89', 'sidorov.dmitry@gmail.com', 120000, 0, '["Холодные звонки","CRM","Переговоры","Презентации"]', 'РЭУ им. Плеханова, Факультет маркетинга', 2, 0, 40, '2024-02-02');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2c-48ef-d16a3be5f9c2', 'Козлова Анна Игоревна', '+7 (918) 456-78-90', 'anna.koz@mail.ru', 200000, 2, '["Kubernetes","AWS","Terraform","Prometheus","GitLab CI"]', 'МФТИ, Факультет инноваций и высоких технологий', 6, 0, 40, '2024-01-12');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2d-59ff-e27b4cf60ad3', 'Федоров Артем Олегович', '+7 (919) 567-89-01', 'artem.fedorov@ya.ru', 140000, 3, '["Figma","Adobe XD","User Research","Prototyping","UI/UX"]', 'ВШЭ, Факультет дизайна', 3, 2, 30, '2024-02-11');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2e-6a0f-f38c5da71be4', 'Никитина Елена Валерьевна', '+7 (920) 678-90-12', 'nikitina.elena@mail.ru', 50000, 1, '["JavaScript","Python","HTML/CSS","Git","SQL"]', 'НГУ, Факультет информационных технологий (студент 4 курс)', 0, 3, 20, '2024-02-06');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e2f-7b1f-049d6eb82cf5', 'Волков Павел Александрович', '+7 (921) 789-01-23', 'volkov.pavel@gmail.com', 150000, 1, '["SQL","Python","Tableau","Statistics","Machine Learning"]', 'МГУ, ВМК', 3, 1, 40, '2024-01-26');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e30-8c2f-15ae7fc93d06', 'Григорьева Ольга Дмитриевна', '+7 (922) 890-12-34', 'olga.grig@yandex.ru', 130000, 4, '["SMM","Google Analytics","Content Marketing","SEO","Email marketing"]', 'МГИМО, Факультет международных экономических отношений', 3, 0, 40, '2024-02-16');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e31-9d3f-26bf8eda4e17', 'Белов Сергей Николаевич', '+7 (923) 901-23-45', 'belov.sergey@mail.ru', 110000, 0, '["Windows Server","Linux","Network","Active Directory","Virtualization"]', 'УрФУ, Радиофакультет', 3, 0, 40, '2024-02-01');
INSERT INTO Candidates (Id, Name, Phone, Mail, Salary, Status, Skills, Education, Experience, Employment, WorkHours, RespondDate) VALUES ('018e32d3-7e69-7e32-ae4f-37c09feb5f28', 'Смирнова Ирина Викторовна', '+7 (924) 012-34-56', 'smirnova.irina@gmail.com', 190000, 2, '["Product Management","Analytics","Roadmapping","A/B Testing","Jira"]', 'ВШЭ, Факультет бизнес-информатики', 6, 0, 40, '2024-02-13');
