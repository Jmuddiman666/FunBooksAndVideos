# FunBooksAndVideos
FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users 
can have memberships for the book club, the video club or for both clubs (premium).

## Getting Started
### Visual Studio
Load `FunBooksAndVideos.sln` solution
Set startup project to `FunBooksAndVideos.Api`
Start without debugging (Ctrl + F5)

### CLI
navigate to `FunBooksAndVideos.Api` directory `cd src/FunBooksAndVideos.Api`
Run the `FunBooksAndVideos.Api` project `dotnet run`


## Sample
``` bash
curl -X 'POST' \
  'https://localhost:7066/api/Order' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "customer": 4567890,
  "purchaseOrder": 3344656,
  "itemLines": [
    {
      "product": 2,
      "productName": "Book Club Membership"
    }
  ],
  "total": 48.50
}'
```
