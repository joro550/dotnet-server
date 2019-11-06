# dotnet-server
[![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)](https://github.com/Naereen/StrapDown.js/blob/master/LICENSE)
![](https://img.shields.io/github/last-commit/joro550/dotnet-server.svg) 
[![](https://img.shields.io/nuget/v/DotNetSimpleServer.svg)](https://www.nuget.org/packages/DotNetSimpleServer/) 
[![](https://img.shields.io/nuget/dt/DotNetSimpleServer.svg)](https://www.nuget.org/packages/DotNetSimpleServer/)

A dot net global tool to spin up a quick server, that sets up a url and response contract. For example you can ask the server to respond to a sepcific request on `/hello` with `{"Hello":"world"}`, you can setup the server to respond to all of your favourite Http methods like get, post, put, delete. 

## Why does this exist?
I don't know about you but when I'm working on modern systems that depend on down stream services I find that people are not very good at making a fake version of the dependency, so when I boot up a local version of the service I either have to have the real thing running along what I'm all ready running or spin up a fake service that returns a specfic contract.

I'm getting sick of writing boiler plate, so I thought I'd have a global tool that would load a file that describes the requests I'm going to send and what responses I want it to return.

## How do I configure the server?
There is a good example in the repository called `file-example.txt` have a look in there for now, hopefully I can add some good documentation soon.

## Future development?
- Random failures?
- Conditional logic on result?
 - {Your idea here}

## How do I install this thing?
Yeah.. Right now you'll have to download the project and run `dotnet pack` on the solution, once that is complete you can run this command: `dotnet tool install --global --add-source ./nupkg GlobalServer`, I'll make this easier once I know how! 

Thanks for now!