# Exercise 1
## **A simple web API**

In this exercise you will create a Docker image for a simple Dotnet Core web API application.  It is not necessary to be fluent in Dotnet Core to complete this exercise.  Determine the correct base image to use and create a Docker file & Compose file to test the service in the swarm.


## Build the application 

```
docker build -t exercice-1:1.0 .
```


## Run application 
By default it exposes service on port 80
```
docker run -d -p 3000:80 --name cnt1  exercice-1:1.0
```

Check containers logs 
```
$docker logs -f cnt1
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {52eea1bc-294f-4eaf-aece-66a20a6b38ab} may be persisted to storage in unencrypted form.
Hosting environment: Production
Content root path: /target
Now listening on: http://[::]:80
Application started. Press Ctrl+C to shut down.
```
* Check how to expose service on 8080 for e.g *

## Test the running application 

````
$ http localhost:3000/api/values
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Mon, 19 Aug 2019 07:55:14 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
    "DotNet Core",
    "Linux",
    "Docker"
]

````
