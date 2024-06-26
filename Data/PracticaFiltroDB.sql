-- Active: 1719377435251@@bo1467ift0bokyubooa4-mysql.services.clever-cloud.com@3306@bo1467ift0bokyubooa4
CREATE TABLE students(
    id_student INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    Names VARCHAR(125) NOT NULL,
    BirthDate DATE NOT NULL,
    Address VARCHAR(125) NOT NULL,
    Email VARCHAR(155) NOT NULL
);

CREATE TABLE teachers(
    id_teacher INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    Names VARCHAR(155) NOT NULL,
    Specialty VARCHAR(125) NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Email VARCHAR(125) NOT NULL,
    YearsExperience INT NOT NULL
);

CREATE TABLE enrollments(
    id_enrrollment INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    Date_enrollment DATE NOT NULL,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Status ENUM("Pagada", "Pendiente de Pago", "Cancelada") NOT NULL,
    Foreign Key (StudentId) REFERENCES students(id_student),
    Foreign Key (CourseId) REFERENCES courses(id_course)
);

CREATE TABLE courses(
    id_course INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    Name VARCHAR(125) NOT NULL,
    Description TEXT NOT NULL,
    TeacherId INT NOT NULL,
    Schedule VARCHAR(125) NOT NULL,
    Duration VARCHAR (125) NOT NULL,
    Capacity INT NOT NULL,
    Foreign Key (TeacherId) REFERENCES teachers(id_teacher)
);

INSERT INTO teachers(`Names`, `Specialty`, `Phone`, `Email`, `YearsExperience`) VALUES
("Francisco", "Quimica", "31413213", "teacher@test.com", 2);DROP TABLE enrollments;

INSERT INTO courses(`Name`, `Description`, `TeacherId`, `Schedule`, `Duration`, `Capacity`) VALUES
("Matemáticas", "Son matemáticas avanzadas junto con calculo", 2, "Martes a Jueves", "2 horas en la tarde", 20);

INSERT INTO enrollments(`Date_enrollment`, `StudentId`, `CourseId`, `Status`) VALUES 
("2012-02-03", 2, 1, "Pagada");


SELECT * FROM enrollments;

SHOW TABLES;