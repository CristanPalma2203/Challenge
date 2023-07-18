# Establece la imagen base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos del proyecto y compila la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Establece el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "out/Prueba.dll"]