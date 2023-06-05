# Book API

Book API is a REST API sample that implements the GET, POST, PUT, DELETE and PATCH methods.

The PATCH method updates only properties of an entity that are provided in the body. For example the following request updates only the title and keeps unchanged other properties of the book entity.

`PATCH /api/book/{bookId}`
```JSON
{
  "title": "a new title"
}
```