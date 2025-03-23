User Management
===============

This application is a simple REST API:

- [Create A User Record](#create-a-user-record)
- [Get All User Records](#get-all-user-records)
- [Get A User Record by ID](#get-a-user-record-by-id)
- [Update A User Record by ID](#update-a-user-record-by-id)
- [Delete A User Record by ID](#delete-a-user-record-by-id)

Create A User Record
--------------------

```http
POST api/users
Content-Type: application/json

{
    "firstName": "string",
    "lastName": "string",
    "contact": {
        "address": {
            "country": "string",
            "city": "string",
            "postCode": "string"
            "street": "string"
        },
        "email": "string",
        "phone": {
            "countryCode": 0033,
            "number": 666666666
        }
    }
}

###
```

Get All User Records
--------------------

```http
GET api/users
```

Get A User Record by ID
-----------------------

```http
GET api/users/{userId}
```

Update A User Record by ID
--------------------------

```http
PUT api/users/{userId}
Content-Type: application/json

{
    "contact": {
        "address": {
            "country": "string",
            "city": "string",
            "postCode": "string"
            "street": "string"
        },
        "email": "string",
        "phone": {
            "countryCode": 0033,
            "number": 666666666
        }
    }
}

###
```

Delete A User Record by ID
--------------------------

```http
DELETE api/users/{userId}
```
