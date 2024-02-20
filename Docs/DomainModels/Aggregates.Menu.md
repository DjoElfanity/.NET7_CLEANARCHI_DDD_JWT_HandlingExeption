# Domain Models

## Menu 

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection (MenuSection section);
    
}
```

```json
{
    "id" : "00000000-000000-0000-0000" , 
    "name" : "Some name",
    "description" : "Some descriptions", 
    "averageRating" : 4.5  ,
    "sections" : 
    [
        {
            "id"  :"00000000-000000-0000-0000",
            "name" : "Appetizes" ,
            "description" : "Starters",
            "items" :
            [
                {
                "id" : "00000000-000000-0000-0000",
                "name" : "Fried",
                "description" : "some description" , 
                "price" : 6.00
                }

            ]

        }
       
    ],
    "createdDateTime" : "2020",
    "updatedDateTime" :"2021" , 
    "hostId": "00000000-000000-0000-0000" , 
    "dinnerIds"  : 
    [
        "00000000-000000-0000-0000",
    ],

    "menuReviewIds":
     [
        "00000000-000000-0000-0000",
     ]
}
```