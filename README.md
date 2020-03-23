# PokemonApiService
## Description
Translate pokemon description to Shakespeare-style English

---

## How to use
### In Windows 10
1. Install git.  
2. Clone the project to a local folder: 
```
git clone https://github.com/chiyanYang/PokemonApiService.git
```

3. Install Docker [here](https://hub.docker.com/editions/community/docker-ce-desktop-windows) and run Docker.    
4. Open command line and do the following in command line.  
5. Switch to the project folder where Dockerfile is located, e.g.
```
cd C:\git\PokemonApiService\PokemonApiService
```

6. Build docker by the following command 
```
docker build -f Dockerfile ..
```  
7. After the build, you can find this line 
```
Successfully built XXXXXXXXXXX
```  
8. Run 
```
docker run -d -p 8080:80 XXXXXXXXXXX
```
Note: `XXXXXXXXXXX` is from step (7).  
9. Test on the browser [localhost:8080/pokemon/weedle](http://localhost:8080/pokemon/weedle), the result should be shown.  
  
### Alternatively,  
1. Follow the step (1)(2)(3) above.  
2. Install Visaul Studio 2019.  
3. Run `PokemonApiService.sln` in porject folder `PokemonApiService` with Visaul Studio 2019.  
4. Click `Debug-> Start Debugging` or click `Debug` icon namedDocker to start the service.  

---

## Folder Structure
####  [`Clients`](./PokemonApiService/Clients)
- Access other endpoints or external services.
- [`ShakespeareClient`](./PokemonApiService/Clients/ShakespeareClient.cs): Get result from Shakespeare API.
####  [`Controller`](./PokemonApiService/Controllers/)
- Handle request to the endpoints.
- [`PokemonDetailsController`](./PokemonApiService/Controllers/PokemonDetailsController.cs): Handle request to the /pokemon/{pokemon name}.
####  [`Models`](./PokemonApiService/Models)
All Models.

---
## Flows in `PokemonApiService`
1. Get pokemon details from pokemon API.
2. Translate pokemon description by Shakespeare API
3. Return the reuslt