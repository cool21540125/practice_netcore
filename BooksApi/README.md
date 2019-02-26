# 使用 ASP.NET Core 與 MongoDB 建立 Web API

- 2019/02/26
- [asp.net core -> mongodb](https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio-code)

## Asp.net Core -> MongoDb

1. MongoDB
2. Net core


### 1. MongoDB
```sh
### MongoDB
$ mongo

### use db
> use BookstoreDb
switched to db BookstoreDb

### create collection
> db.createCollection('Books')
{ "ok" : 1 }

### insert record
> db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, {'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}]);
{
        "acknowledged" : true,
        "insertedIds" : [
                ObjectId("5c755736e766a0da8509ba40"),
                ObjectId("5c755736e766a0da8509ba41")
        ]
}

### query
> db.Books.find({}).pretty();
{
        "_id" : ObjectId("5c755736e766a0da8509ba40"),
        "Name" : "Design Patterns",
        "Price" : 54.93,
        "Category" : "Computers",
        "Author" : "Ralph Johnson"
}
{
        "_id" : ObjectId("5c755736e766a0da8509ba41"),
        "Name" : "Clean Code",
        "Price" : 43.15,
        "Category" : "Computers",
        "Author" : "Robert C. Martin"
}

> 
```

### 2. Net core
```powershell
### new project
> dotnet new webapi -o BooksApi
> cd BooksApi

### 到這找最新版 https://www.nuget.org/packages/MongoDB.Driver/
# MongoDB 的 dotnet Driver
> dotnet add BooksApi.csproj package MongoDB.Driver -v 2.7.3

### new DB Dir
> mkdir Models
# 1. 新增 Models/Book.cs , 如下 --------------
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
### 如上 -----------------------------------------

### new Dir
> mkdir Services
# 1. 新增 Services/BookService.cs , 如下 --------------
using System.Collections.Generic;
using System.Linq;
using BooksApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var databases = client.GetDatabase("BookstoreDb");
            _books = databases.GetCollection<Book>("Books");
        }

        public List<Book> Get()
        {
            return _books.Find(book => true).ToList();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public Book Get(string id)
        {
            return _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        }

        public void Update(string id, Book bookIn)
        {
            _books.ReplaceOne(book => bookIn.Id == id, bookIn);
        }

        public void Remove(Book bookIn)
        {
            _books.DeleteOne(book => book.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}
### 如上 -----------------------------------------

### 修改 appsettings.json , 增加連線字串
"ConnectionStrings": {
      "BookstoreDb": "mongodb://localhost:27017"
  }

### 修改 Startup.cs
# 1. using BooksApi.Services;
# 2. Register the BookService class with the Dependency Injection system.

### 新增 Controllers/BooksController.cs
# 1. 
```

