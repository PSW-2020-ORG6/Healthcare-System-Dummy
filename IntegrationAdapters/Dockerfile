FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
WORKDIR /app
COPY . .
EXPOSE 60998
EXPOSE 5000
EXPOSE 44372
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IntegrationAdapters.dll
