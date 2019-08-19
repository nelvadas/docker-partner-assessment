FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY exercise-2.csproj .
RUN dotnet restore 
COPY . . 
RUN dotnet publish -c release -o /target 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /target 
COPY --from=build /target .
ENTRYPOINT [ "dotnet", "exercise-2.dll" ]