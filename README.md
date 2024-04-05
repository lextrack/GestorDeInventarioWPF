<p align="center">
  <img src="./InventarioDB/Resources/icon.ico">
</p>

<h2 align="center">Gestor de inventarios </h2>
<p align="left">

Este proyecto es un gestor de inventarios de escritorio que permite gestionar el inventario de productos y  registrar sus entradas y salidas de la bodega. Además, cuenta con una interfaz de usuario fácil de usar, un sistema básico de inicio de sesión y conexión a una base de datos (SQL Server) a través de Entity Framework.

<h2 align="center">Capturas</h2>
<p align="left">

<img src="./InventarioDB/Captures/1.png">
<img src="./InventarioDB/Captures/2.png">

<h2 align="center">Características</h2>
<p align="left">

* **Interfaz de Usuario**: El proyecto utiliza Windows Presentation Foundation (WPF) para crear una interfaz de usuario fácil de usar, moderna y atractiva.

* **Sistema de Inicio de Sesión**: Los usuarios deben iniciar sesión antes de acceder a las funcionalidades del gestor de inventarios. Esto garantiza la seguridad de los datos. Se usa un sistema simple en el que solo debes recordar una contraseña.

* **Base de Datos**: Utiliza SQL Server como sistema de gestión de base de datos para almacenar información sobre productos, entradas y salidas. Cuenta también con triggers para actualizar automáticamente las cantidades del stock de productos cuando se realizan transacciones de entrada o salida.

* **Entity Framework**: Entity Framework se utiliza como ORM para interactuar con la base de datos de SQL Server de manera eficiente y sencilla.

* **Registro de entradas y salidas**: No solo puedes registrar productos, también sus entradas y salidas.

<h2 align="center">Requisitos de Ejecución</h2>
<p align="left">

* Windows 10 o superior: La aplicación se desarrolló para sistemas Windows y se ha probado en Windows 10 y versiones posteriores (la compatibilidad con Windows 7 no esta garantizada).

* SQL Server: Debe tener instalado y configurado SQL Server para almacenar y administrar la base de datos. Se debe añadir la base de datos al gestor de base de datos. Hay un script de la base de datos en el código fuente y en la versión compilada en la sección de releases.

* Framework .NET: Asegúrese de tener instalado .NET 8 para poder ejecutar la aplicación (en la sección de releases hay una versión compilada que permite la ejecución sin instalar el framework).

<h2 align="center">Uso</h2>
<p align="left">

Inicie sesión con la contraseña por defecto, que es "1234". Obviamente, esta contraseña puede ser cambiada.
Eso es todo. Ya puedes usar la app para gestionar un inventario con stock y sus entradas y salida.

<h2 align="center">Licencia</h2>
<p align="left">

Este proyecto está bajo la Licencia MIT. Consulte el archivo LICENSE para obtener más detalles.

<h2 align="center">Agradecimientos</h2>
<p align="left">

Gracias a Falticon por los iconos usados en esta aplicación.

Recuerda que puedes realizar donaciones a través de Paypal o Ko-fi.

¡Gracias por usar InventarioDB!

