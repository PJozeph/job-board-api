CREATE TABLE JobBoardSchema.jb_user
(
    UserId INT IDENTITY(1, 1) PRIMARY KEY
    , FirstName NVARCHAR(50)
    , LastName NVARCHAR(50)
    , Email NVARCHAR(50)
    , Gender NVARCHAR(50)
    , Active BIT
);

CREATE TABLE JobBoardSchema.job_post (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    UserId INT,
    title VARCHAR(255) NOT NULL,
    jobDescription TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES JobBoardSchema.jb_user(UserId) ON DELETE CASCADE
);