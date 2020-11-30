FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
LABEL maintainer="vladimir.budjen@uns.ac.rs"
COPY . .
EXPOSE 49900
ENV ASPNETCORE_URLS= http://*:49900
ENTRYPOINT ["dotnet", "WebApplication.dll"]