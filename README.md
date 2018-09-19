# Base64-validation API

* A .Net Core based application, used for making based64 enconded Json comparison.

## Assignment

* Provide 2 http endpoints that accepts JSON base64 encoded binary data on both
endpoints
  * _host_/v1/diff/_ID_/left 
  * _host_/v1/diff/_ID_/right
* The provided data needs to be diff-ed and the results shall be available on a third end
point
  * _host_/v1/diff/_ID_

* The results shall provide the following info in JSON format
  * If equal return that
  * If not of equal size just return that
  * If of same size provide insight in where the diffs are, actual diffs are not needed.

* Make assumptions in the implementation explicit, choices are good but need to be

## Built with

* [.Net Core](SDK) - The .Net framework used
* [Visual Studio 2018](IDE) - Development Environement

* [Microsoft.AspNetCore.All](Package)  - A set of .NET API's that are included in the default .NET Core application model.
* [Swashbuckle.AspNetCore](Package) - Swagger tools for documenting APIs built on ASP.NET Core
* [Microsoft.EntityFrameworkCore.InMemory](Package) - In-memory database provider for Entity Framework Core (used for testing purposes).


## Installation

* It requires [.Net Core SDK 2.0] to run.

  https://www.microsoft.com/net/download/thank-you/dotnet-runtime-2.1.4-windows-hosting-bundle-installer


## Running

* 1- Clone Repository into a folder

* 2- Open Solution in Visual Studio and Run in Release Mode (on IIS Express or Browser)

* 3- You will see on browser Swagger UI 

* 4- You can use POSTMAN for calling API

* 5- Execute POST on <server:port>/v1/diff/<id>/left passing the Base64 Encoded JSON String as the Request Body (no headers) and make sure you set the media type to be application/json (http://localhost:5080/v1/diff/1/left)
  
* 6-Execute POST on <server:port>/v1/diff/<id>/right passing the Base64 Encoded JSON String as the Request Body (no headers) and make sure you set the media type to be application/json (http://localhost:5080/v1/diff/1/right)
  
* 7-Execute GET on <server:port>/v1/diff/<id> to get the JSON response describing the DIFF according to the Requirements.(http://localhost:5080/v1/diff/1)


## Rest API

There are three main endpoints you can call. Instructions on how to use them in your own application are linked below.

| Title | URL | Method | Params | Data Params
| ------ | ------ | ------ | ------ | ------ |
| Left Json save | **host**:**port**/v1/diff/**ID**/left | POST |Required: id=[integer] | { "data": "[string]"} |
| Right Json save |**host**:**port**/v1/diff/**ID**/right | POST | Required: id=[integer] |{ "data": "[string]"} |
| Diff Result |**host**:**port**/v1/diff/**ID** | GET | Required: id=[integer] | 

Example:
```sh
method: POST
url: http://localhost:5080/v1/diff/1/left
message body: 
{
  "data": "aHR0cDovL296bWVobWV0LmNvbQ=="
}
result:
Status: 200 OK
{
  "message": "OK"
}
```

## Improvements

 - Improve Rest errors codes and verbs usage.
 - Improve exception
 - Populate more Integration and Unit Test
 
## Author

* **Mehmet Oz** - [Profile](https://www.linkedin.com/in/mehmetozz/en)
