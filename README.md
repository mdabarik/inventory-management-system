# Inventory Management System (.NET C# MVC)

# Data Model

```csharp
BaseEntity {
    Id: Guid,
    CreatedAt: DateTime
}

BaseModel : BaseEntity {
    Name: string
}

Product : BaseEntity {
    Name: string,
    Price: decimal,
    Quantity: int,
    CategoryId: Guid,
    Description: string
}

Category : BaseEntity {
    Name: string
}

Supplier : BaseEntity {
    Name: string,
    Country: string,
    ContactInfo: string
}

User : BaseEntity {
    Name: string,
    Email: string,
    Phone: string,
    Address: string
}

StockTransaction : BaseEntity {
    Quantity: int,
    TransactionType: StockTransactionType
}

enum StockTransactionType {
    StockIn = 1,
    StockOut = 2
}
```
