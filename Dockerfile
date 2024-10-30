# Usar una imagen base de .NET SDK para la compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo de solución y los archivos de proyecto
COPY *.sln .
COPY BookingProject.API/*.csproj ./BookingProject.API/
COPY BookingProject.Application/*.csproj ./BookingProject.Application/
COPY BookingProject.Domain/*.csproj ./BookingProject.Domain/
COPY BookingProject.Infrastructure/*.csproj ./BookingProject.Infrastructure/
COPY BookingProject.Tests/*.csproj ./BookingProject.Tests/

# Restaurar las dependencias
RUN dotnet restore

# Copiar el resto de los archivos del proyecto
COPY . .

# Compilar el proyecto
WORKDIR /app/BookingProject.API
RUN dotnet publish -c Release -o out

# Usar una imagen base de .NET para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos compilados del contenedor de build
COPY --from=build /app/BookingProject.API/out .

# Exponer el puerto que usará la aplicación
EXPOSE 80

# Establecer el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "BookingProject.API.dll"]
