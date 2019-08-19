## Docker Compose instruction 
Check the `docker-compose.yml` file content 

```
version: '3.7'
services:
  frontend:
    build: ../exercise-2
    ports:
    - "4000:80"
    environment:
    - EX1_URL=http://api
    links:
    - api
    networks: 
      - frontend_ovl
      - backend_ovl
  api:
    build: ../exercise-1
    networks:
      - backend_ovl
networks: 
  frontend_ovl:
    driver: overlay 
  backend_ovl:  
    driver: overlay 
```


```
$ docker-compose up
WARNING: The Docker Engine you're using is running in swarm mode.

Compose does not use swarm mode to deploy services to multiple nodes in a swarm. All containers will be scheduled on the current node.

To deploy your application across the swarm, use `docker stack deploy`.

Creating network "docker_backend_ovl" with driver "overlay"
Creating network "docker_frontend_ovl" with driver "overlay"
Creating docker_api_1 ... done
Creating docker_frontend_1 ... done
Attaching to docker_api_1, docker_frontend_1
api_1       | warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
api_1       |       No XML encryptor configured. Key {10993f6f-a2b6-469b-b068-df5aca0cf829} may be persisted to storage in unencrypted form.
api_1       | Hosting environment: Production
api_1       | Content root path: /target
api_1       | Now listening on: http://[::]:80
api_1       | Application started. Press Ctrl+C to shut down.
frontend_1  | warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
frontend_1  |       No XML encryptor configured. Key {9af710f5-44b7-41fc-a68b-2363a3437ba1} may be persisted to storage in unencrypted form.
frontend_1  | Hosting environment: Production
frontend_1  | Content root path: /target
frontend_1  | Now listening on: http://[::]:80
frontend_1  | Application started. Press Ctrl+C to shut down.
``` 


```
frontend_1  | Using Back end Url EX1_URL=http://api
```