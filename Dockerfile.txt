FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build

CMD ["dotnet","--info"]