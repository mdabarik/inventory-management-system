CREATE TABLE Category (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL UNIQUE
)

insert into Category (Name) 
Values ('Mechanical');

select * from Category;