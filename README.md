# dotnet-server
[![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)](https://github.com/Naereen/StrapDown.js/blob/master/LICENSE)
![](https://img.shields.io/github/last-commit/joro550/dotnet-server.svg) 
[![](https://img.shields.io/nuget/v/DotNetSimpleServer.svg)](https://www.nuget.org/packages/DotNetSimpleServer/) 
[![](https://img.shields.io/nuget/dt/DotNetSimpleServer.svg)](https://www.nuget.org/packages/DotNetSimpleServer/)

A dot net global tool to spin up a quick server, that sets up a url and response contract. For example you can ask the server to respond to a sepcific request on `/hello` with `{"Hello":"world"}`, you can setup the server to respond to all of your favourite Http methods like get, post, put, delete. 

## Why does this exist?
In the modern developer world we are working with interconnected systems service A calls service B calls service C, now when you are working on service A what do you do when it calls service B? 

* Do you spin up a fake service B? 
* Do you create an API collection in postman? 

Let me introduce you to a third option, dot net server - a configurable http server that you configure with a text file (written in json) that will only answer requests on the url's that you have specified with the response code and body that you have specified.

Now you don't have to write/alter code to return a bad request or a specfic response body, just simply put it into the dotnet server configuration file and run this global tool and then allow your service to call.

I believe this will be a great tool for testing SPA applications or any application that has one or many downstream services that it relies on to do it's thing.

## Is this only for dot net?
Nope it's just written in dotnet, it's just a simple http server that listens on a port to a specfied list of urls and returns a body when that url is hit, nothing intrinsically linking it with dotnet what so ever, this is just the language I know and love and with the recent asp net core changes to add endpoints really cheaply and the dot net global tools I believe this is almost the *perfect* toolchain for what I wanted to achieve.

Feel free to implement this in a different language though, just don't send me the pull-request ;)

## How do I configure the server?
There is a good example in the repository called `file-example.txt` have a look in there for now, hopefully I can add some good documentation soon.

### Simple configuration
```
{
    "server" : {
        "ports": [ // The ports in which the server will listen to
            {
                "isSecure" : true, // Is this a secure port? (https)
                "portNumber" : 5000 // the number of the port
            }
        ]
    },
    "interactions": [ // array of urls to listen to
        {
            "description": "A GET request to retrieve a thing", // not used, just for humans
            "request": {
                "method": "get", // the method in which the server is looking for
                "path": "/things/1234" // the url after the port i.e. localhost:5000/things/1234
            },
            "response": { // the response given to the user 
                "status": 200, // the response code (in this case 200: Ok)
                "headers": [], // the headers that it will return 
                "body": { // The reponse body
                    "Hello" : "World"
                }
            }
        }
}
```

### Response from a file
Use case: you want to have an editable response model or just have a long response body then put it into a file and we'll load it into the response body

```
{
  "interactions": [
    {
      "description": "A GET request to retrieve a thing",
      "request": {
        "method": "get",
        "path": "/things/1234"
      },
      "response": {
        "type": "fromFile",
        "status": 200,
        "headers": [],
        "contentType": "application/json",
        "fileName": "c:\users\joro550\response.txt"
      }
    }
}
```

### From string
Use case: You don't nessasarily want an object, maybe you just want a some words

```
{
  "interactions": [
    {
      "description": "A GET request to retrieve a thing",
      "request": {
        "method": "get",
        "path": "/things/1234"
      },
      "response": {
        "type": "fromString",
        "status": 200,
        "headers": [],
        "contentType": "text/plain",
        "content": "Hello World"
      }
    }
}
```

### Incremental from list

Use case: You want to test a series of responses, just add them to the list, these will be returned on after another

```
{
  "interactions": [
    {
      "description": "A GET request to retrieve a thing",
      "request": {
        "method": "get",
        "path": "/things/1234"
      },
      "response": {
        "type": "incrementalList",
        "values": [
          {
            "headers": [],
            "status": 200,
            "contentType": "application/json",
            "content": {
              "Key1": "Value1"
            }
          },
          {
            "headers": [],
            "status": 200,
            "contentType": "",
            "content": {
              "Key2": "Value2"
            }
          }
        ]
      }
    }
}
```


### Incremental from list

Use case: You want to test a series of responses, just add them to the list, these will be returned randomly

```
{
  "interactions": [
    {
      "description": "A GET request to retrieve a thing",
      "request": {
        "method": "get",
        "path": "/things/1234"
      },
      "response": {
        "type": "randomList",
        "status": 200,
        "values": [
          {
            "headers": [],
            "contentType": "",
            "content": ""
          },
          {
            "headers": [],
            "contentType": "",
            "content": ""
          }
        ]
      }
    }
  ]
}
```

## Future development?
- Random failures?
- Conditional logic on result?
- Random body content?
- File watcher to watch file changes so the server doesn't need restarted after a change?
 - {Your idea here}

## How do I install this thing?
If you follow the nuget link up top you will be sent to the nuget feed where it will tell you how to install this tool:

`dotnet tool install --global DotNetSimpleServer --version {currentVersion}`

You can also update via the upgrade command

`dotnet tool update DotNetSimpleServer -g`

## Contributing
If you want to contribute, that's great, please dive into the code!

If you add anything please have supporting tests and issue and a pull-request that is against the develop branch. 