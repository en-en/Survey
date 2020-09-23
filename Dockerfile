FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/01-Presentation/Cyg.Application.Api/Cyg.Application.Api.csproj", "Cyg.Application.Api/"]
RUN dotnet restore "Cyg.Application.Api/Cyg.Application.Api.csproj"
COPY . .
WORKDIR "/src/Cyg.Application.Api"
RUN dotnet build "Cyg.Application.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cyg.Application.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cyg.Application.Api.dll"]
