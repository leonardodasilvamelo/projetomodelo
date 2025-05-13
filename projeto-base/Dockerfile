FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /build

COPY ["src/Projeto.Base.Api/Projeto.Base.Api.csproj", "src/Projeto.Base.Api/"]
COPY ["src/Projeto.Base.Application/Projeto.Base.Application.csproj", "src/Projeto.Base.Application/"]
COPY ["src/Projeto.Base.Domain/Projeto.Base.Domain.csproj", "src/Projeto.Base.Domain/"]
COPY ["src/Projeto.Base.Infra.ExternalService/Projeto.Base.Infra.ExternalService.csproj", "src/Projeto.Base.Infra.ExternalService/"]
COPY ["src/Projeto.Base.Infra.IoC/Projeto.Base.Infra.IoC.csproj", "src/Projeto.Base.Infra.IoC/"]
COPY ["src/Projeto.Base.Infra.Security/Projeto.Base.Infra.Security.csproj", "src/Projeto.Base.Infra.Security/"]

RUN dotnet restore "src/Projeto.Base.Api/Projeto.Base.Api.csproj"
COPY . .
WORKDIR /build/src/Projeto.Base.Api

FROM build AS publish
RUN dotnet publish "Projeto.Base.Api.csproj" -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 as app
RUN apt-get update
RUN apt-get install tzdata -y

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ=America/Sao_Paulo
ENV LANG pt-BR
ENV LANGUAGE pt-BR
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /publish .

EXPOSE 80
EXPOSE 443

RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

ENTRYPOINT ["dotnet", "Projeto.Base.Api.dll", "--urls", "http://+:80"]