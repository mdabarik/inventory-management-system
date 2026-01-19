CREATE TABLE Supplier (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL UNIQUE,
    Country VARCHAR(100),
    ContactInfo VARCHAR(100)
)

insert into Supplier (Name, Country, ContactInfo)
Values ('Supplier 1', 'USA', 'Test Contact 1, USA');

select * from Supplier;
