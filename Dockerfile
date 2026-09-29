# ---- Étape 1 : build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restaurer les dépendances en premier pour profiter du cache Docker
COPY BoutiqueTech/BoutiqueTech.csproj BoutiqueTech/
RUN dotnet restore BoutiqueTech/BoutiqueTech.csproj

COPY BoutiqueTech/ BoutiqueTech/
RUN dotnet publish BoutiqueTech/BoutiqueTech.csproj -c Release -o /app/publish --no-restore /p:UseAppHost=false

# ---- Étape 2 : runtime (image minimale, sans SDK) ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# L'application écrit users.json dans son répertoire : on le rend accessible
# à l'utilisateur non-root fourni par l'image officielle (APP_UID)
RUN chown -R $APP_UID /app

# Ne jamais exécuter le conteneur en root
USER $APP_UID

ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

ENTRYPOINT ["dotnet", "BoutiqueTech.dll"]
