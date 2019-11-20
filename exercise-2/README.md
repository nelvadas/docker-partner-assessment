# Exercise 2
## **Web sites and data**

In this exercise you will create a Docker image for a simple Dotnet Core MVC web site.  It is not necessary to be fluent in Dotnet Core to complete this exercise.  Determine the correct base image to use and create a Docker file & Compose file to test the services in the swarm.  

This site uses the API created in **exercise 1** to load a set of values and display a bulleted list.  Create a Compose file with both services and enable networking between them.

Use an overlay network to leverage the Docker internal DNS so the data traffic from the API does not need to leave the swarm to be consumed by the site.

Update `Api.cs` File to rely on Environment variable 

Build the exercise2 with the following command 
```
docker build -t exercice-2:1.0 .
```

```
docker run -it -p 5000:80 --name cnt1 exercice-1:1.0
docker run -it -p 3000:80 -e EX1_URL=http://localhost:5000  --name cnt2 exercice-2:1.0
```
