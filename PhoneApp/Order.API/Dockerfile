#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat
FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG source
# ENV ASPNETCORE_URLS http://+:8080
WORKDIR /app
EXPOSE 8080
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Order.API.dll","--server.urls", "http://127.0.0.1:8080"]
