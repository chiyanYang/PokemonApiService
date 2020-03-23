# PokemonApiService
## Description
Translate pokemon description to Shakespeare description
## How to use
In Windows 10:
(1) Install git  
(2) Clone the project to a local folder: "git clone https://github.com/chiyanYang/PokemonApiService.git"   
(3) Install Docker (https://hub.docker.com/editions/community/docker-ce-desktop-windows)  
(4) Open command line and do the following in command line  
(5) Switch to the project folder where Dockerfile is located (e.g.: "cd C:\git\PokemonApiService\PokemonApiService")  
(6) Run "docker build -f Dockerfile .."  
(7) After the build, you can find this line "Successfully built XXXXXXXXXXX"  
(8) Run "docker run -d -p 8080:80 XXXXXXXXXXX". Note: XXXXXXXXXXX is from step (7)  
(9) Test on the browser "localhost:8080/pokemon/weedle", the result should be shown.  
## Structure
####  Clients folder
Access other endpoints or external services.
ShakespeareClient: Get result from Shakespeare API.
####  Controller folder
Handle request to the endpoints.
PokemonDetailsController: Handle request to the /pokemon/{pokemon name}.
####  Models folder
All Models.
## Flows in PokemonApiService
(1) Get pokemon details from pokemon API.
(2) Translate pokemon description by Shakespeare API
(3) Return the reuslt