FROM mcr.microsoft.com/dotnet/sdk
WORKDIR /app
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o out

WORKDIR /app/out

EXPOSE 2000
EXPOSE 3000
EXPOSE 4000

ENTRYPOINT ["dotnet", "ContainerPorts.dll"]

CMD ["--server"]