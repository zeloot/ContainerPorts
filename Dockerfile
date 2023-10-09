FROM mcr.microsoft.com/dotnet/sdk
WORKDIR /app
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o out

WORKDIR /app/out

EXPOSE 2000/tcp
EXPOSE 3000/tcp
EXPOSE 4000/udp

ENTRYPOINT ["dotnet", "ContainerPorts.dll"]

CMD ["--server"]
