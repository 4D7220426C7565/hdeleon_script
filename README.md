# hdeleon_script
*El script desarrollado por **hdeleon.net**, explora "recursivamente" un sitio web dado, comenzando desde una URL base. Utiliza **PuppeteerSharp**, una biblioteca para controlar navegadores web automatizados en C#.*

*Tienes el video completo.*
[Youtube](https://www.youtube.com/watch?v=nwPCmrkSKqE)

*El script básicamente cumple con la función de explorar un sitio web y extraer los enlaces válidos de **status 200 OK**. Ten en cuenta que si no obtienes respuesta puede que la web emplee: **rate limiting** o también llamado: **throttling**, tenga cuidado con el tipo de web que se este atacando.*

*Ejemplo al emplear el ataque a https://www.poloniex.com*

![poloniex](https://github.com/4D7220426C7565/hdeleon_script/assets/171493198/9856b5ea-fd2b-42b0-9820-ff07121dcff4)

*Atacando a https://www.google.com*

![test](https://github.com/4D7220426C7565/hdeleon_script/assets/171493198/6a969599-4c6f-44b9-80a1-9f39fb0d2429)

*❗Nota: Es un script muy básico, puede perzonalizarlo a sus gustos. Por otro, ```string Chrome = @"./../../../../../bin/chromium";``` dependerá si usa linux o windows, en mi caso uso chromium: **/bin/chromium***

*Instalar(Linux) Chromium.*
```sh
sudo apt install chromium
```

*Instalar dotnet "Debian".*
[Microsoft => Debian](https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian)

*Para ejecutar el code de C#:*

```sh
dotnet new console --framework net6.0 --output <Filename>
cd <Filename>
dotnet new sln
dotnet add package PuppeteerSharp --version 18.0.1
```
- *net6.0 / net8.0 Dependerá que versión de ```dotnet``` quiere trabajar.*
- *add package PuppeteerSharp --version 18.0.1 Instalar el paquete **PuppeteerSharp*** 

*Clonar repositorio o simplemente copie el code. Así de fresco ;)*

```sh
git clone https://github.com/4D7220426C7565/hdeleon_script.git && cd hdeleon_script
dotnet run Program.cs
```
