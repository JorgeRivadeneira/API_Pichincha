FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

EXPOSE 80
EXPOSE 5024

#Copiar project file
COPY ./*.csproj ./
RUN dotnet restore 

#Copiar lo demás
COPY . .
RUN dotnet publish -c Release -o out

#Hacer un build de la imágen
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "API_PICHINCHA.dll"]