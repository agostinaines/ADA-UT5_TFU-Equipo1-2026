# ADA-UT5_TFU-Equipo1-2026

## Instalación

Instalar la dependencia:

```bash
dotnet add package Newtonsoft.Json
```

## Correr la aplicación
Moverse al directorio de la API y ejecutarla:

```bash
cd MyWebApiApp
dotnet run
```

## Probar la API
Con dos terminales corriendo en simultáneo:

```bash
cd MyWebApiApp
dotnet run
```

```bash
newman run postmanCollection/apiCollection.json -r htmlextra
```