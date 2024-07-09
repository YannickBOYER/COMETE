# Étape 1 : Utiliser l'image SDK de .NET 7.0 comme base pour la construction de l'application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Étape 2 : Copier les fichiers de solution et de projet, puis restaurer les dépendances
COPY CometeAPI/CometeAPI.sln .
COPY CometeAPI/CometeAPI/CometeAPI.csproj CometeAPI/
RUN dotnet restore CometeAPI/CometeAPI.csproj

# Étape 3 : Copier tous les fichiers de l'application et compiler
COPY CometeAPI/ CometeAPI/
WORKDIR /app/CometeAPI
RUN dotnet publish -c Release -o out

# Étape 4 : Utiliser l'image runtime de .NET 7.0 pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/CometeAPI/out .

EXPOSE 7176

# Étape 5 : Configurer le point d'entrée
ENTRYPOINT ["dotnet", "CometeAPI.dll"]
