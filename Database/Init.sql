-- User Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL, -- Hashed password storage
    Email NVARCHAR(100) NOT NULL,
    RoleID INT,
    IsActive BIT,
    CONSTRAINT FK_User_Role FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- Role Table
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);

-- Task Table
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Status NVARCHAR(20),
    Priority NVARCHAR(20),
    DueDate DATETIME,
    CreatorID INT,
    AssigneeID INT,
    ProjectID INT,
    CONSTRAINT FK_Task_Creator FOREIGN KEY (CreatorID) REFERENCES Users(UserID),
    CONSTRAINT FK_Task_Assignee FOREIGN KEY (AssigneeID) REFERENCES Users(UserID),
    CONSTRAINT FK_Task_Project FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);

-- Project Table
CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    StartDate DATETIME,
    EndDate DATETIME,
    ManagerID INT,
    CONSTRAINT FK_Project_Manager FOREIGN KEY (ManagerID) REFERENCES Users(UserID)
);

-- Comment Table
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY,
    TaskID INT,
    UserID INT,
    CommentText NVARCHAR(500),
    CreatedAt DATETIME,
    CONSTRAINT FK_Comment_Task FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    CONSTRAINT FK_Comment_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- File Table
CREATE TABLE Files (
    FileID INT PRIMARY KEY,
    TaskID INT,
    FileName NVARCHAR(100),
    FilePath NVARCHAR(255),
    UploadedBy INT,
    UploadedAt DATETIME,
    CONSTRAINT FK_File_Task FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    CONSTRAINT FK_File_User FOREIGN KEY (UploadedBy) REFERENCES Users(UserID)
);

-- Notification Table
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY,
    UserID INT,
    NotificationText NVARCHAR(500),
    IsRead BIT,
    CreatedAt DATETIME,
    CONSTRAINT FK_Notification_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


-- Inserting seed data for Users
INSERT INTO Users (UserID, Username, Password, Email, RoleID, IsActive)
VALUES
    (1, 'JohnDoe', 'hashed_password_123', 'john@example.com', 1, 1),
    (2, 'JaneSmith', 'hashed_password_456', 'jane@example.com', 2, 1),
    -- Add more users as needed
    (3, 'AliceJohnson', 'hashed_password_789', 'alice@example.com', 1, 1);

    -- Inserting seed data for Roles
INSERT INTO Roles (RoleID, RoleName, Description)
VALUES
    (1, 'Admin', 'Administrator role with full access'),
    (2, 'User', 'Standard user role with limited access'),
    -- Add more roles as needed
    (3, 'Manager', 'Manager role with specific access');
    -- Inserting seed data for Projects
INSERT INTO Projects (ProjectID, Title, Description, StartDate, EndDate, ManagerID)
VALUES
    (1, 'Project X', 'Description of Project X', '2023-01-01', '2023-12-31', 1),
    (2, 'Project Y', 'Description of Project Y', '2023-02-15', '2023-11-30', 2),
    -- Add more projects as needed
    (3, 'Project Z', 'Description of Project Z', '2023-03-10', '2023-10-15', 3);
    -- Inserting seed data for Tasks
INSERT INTO Tasks (TaskID, Title, Description, Status, Priority, DueDate, CreatorID, AssigneeID, ProjectID)
VALUES
    (1, 'Task 1', 'Description of Task 1', 'In Progress', 'High', '2023-05-15', 1, 2, 1),
    (2, 'Task 2', 'Description of Task 2', 'To-do', 'Medium', '2023-06-30', 2, 1, 2),
    -- Add more tasks as needed
    (3, 'Task 3', 'Description of Task 3', 'Done', 'Low', '2023-07-20', 3, 3, 3);
    -- Inserting seed data for Comments
INSERT INTO Comments (CommentID, TaskID, UserID, CommentText, CreatedAt)
VALUES
    (1, 1, 2, 'This is a comment on Task 1', '2023-05-20'),
    (2, 2, 1, 'Comment on Task 2', '2023-06-25'),
    -- Add more comments as needed
    (3, 3, 3, 'Another comment on Task 3', '2023-07-25');
    -- Inserting seed data for Files
INSERT INTO Files (FileID, TaskID, FileName, FilePath, UploadedBy, UploadedAt)
VALUES
    (1, 1, 'file1.pdf', '/path/to/file1.pdf', 1, '2023-05-22'),
    (2, 2, 'document.docx', '/path/to/document.docx', 2, '2023-06-28'),
    -- Add more files as needed
    (3, 3, 'presentation.pptx', '/path/to/presentation.pptx', 3, '2023-07-30');
    -- Inserting seed data for Notifications
INSERT INTO Notifications (NotificationID, UserID, NotificationText, IsRead, CreatedAt)
VALUES
    (1, 1, 'You have a new task assigned', 0, '2023-05-21'),
    (2, 2, 'New comment on Task 2', 1, '2023-06-26'),
    -- Add more notifications as needed
    (3, 3, 'Task 3 deadline approaching', 0, '2023-07-28');
