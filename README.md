# XNerd Ecommerce API
---

#### Configuracion de Servidor SMTP Local
Pasos para la instalacion de un servidor Smtp Local, ten encuenta que este hace uso de tecnologias .Net y si intentas instalarlo en un proyecto con configuracion para utilizar una version obligatoria de .Net, podria fallar la instalacion.
Lo recomendable es que abras tu terminal aparte y asi no tendras problemas de choques de versiones. Al momento de instalar este servidor sin senialar una version especifica, este hace uso de .Net 10 (12 de Febrero de 2026).

```bash
>  dotnet tool install --global Rnwood.Smtp4dev
>  smtp4dev
# El puerto por defecto es el 5000 y al ejecutar veras una url como la siguiente: http://localhost:5000
```

Si tienes la necesidad de cambiar el puerto, al ejecutar el servidor te mostrara una ruta como la siguiente (Segun el momento puede que algunas cosas que cambien)
> C:\Users\{ tu usuario }\.dotnet\tools\.store\rnwood.smtp4dev\3.14.0\rnwood.smtp4dev\3.14.0\tools\net8.0\any

En esta ruta deberas buscar un archivo llamado `appsettings.json`, una vez lo encuentres lo abres con notepad o vscode y buscar lo siguiente `"Urls": "http://localhost:5000"`, aqui es donde podras configurar el puerto que mejor te convenga.

Autor: Elmer Marquez `leomarqz` `::crack::night::` `xnerd`
