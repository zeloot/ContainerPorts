FROM pull mcr.microsoft.com/dotnet/sdk
WORKDIR /App
# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out
WORKDIR /App/out
ENTRYPOINT ["dotnet", "ContainerPorts.dll"]
CMD ["--server"]
