FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN useradd -u 1234 nonrootuser
USER nonrootuser
LABEL maintainer="vladimir.budjen@uns.ac.rs"
COPY ./build .
EXPOSE 80
EXPOSE 5000
EXPOSE 5001
EXPOSE 8080
ENV ASPNETCORE_URLS="http://*:8080;http://*:5000;http://*:5001"
ENTRYPOINT ["dotnet", "WebApplication.dll"]
