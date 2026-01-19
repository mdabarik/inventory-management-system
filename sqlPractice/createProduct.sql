Create table Product (
	Id INT Primary Key AUTO_INCREMENT,
    Name Varchar(150) NOT NULL,
    Price Decimal(20,2) NOT NULL Check(Price>=0), -- check is a constraint
    Quantity INT NOT NULL check(Quantity>=0),
    CategoryId Int Not null,
    SupplierId INT NOt null,
    Description Text,
    
    -- categoryid table er foreign key
    constraint fk_product_category 
		foreign key (CategoryId)
        references Category(Id)
        on delete  restrict -- category delete kora jabe na oi cat id er product thakle
        on update cascade, -- category id change hole, joto product ase same category thakle product er category id o change hobe
	
    constraint fk_product_supplier
		foreign key (SupplierId)
        references Supplier(Id)
        on delete  restrict -- category delete kora jabe na oi cat id er product thakle
        on update cascade -- category id change hole, joto product ase same category thakle product er category id o change hobe
        
)


