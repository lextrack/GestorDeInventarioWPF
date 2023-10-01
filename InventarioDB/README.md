# Gestor de Inventarios (InventarioDB)

Este proyecto es un gestor de inventarios desarrollado en WPF que permite gestionar el inventario de productos y  registrar sus entradas y salidas de la bodega. Además, cuenta con animaciones de interfaz de usuario, un sistema básico de inicio de sesión y conexión a una base de datos (SQL Server) a través de Entity Framework.

## Capturas

<img src="./Captures/gifUI.gif">

## Características

    Interfaz de Usuario: El proyecto utiliza Windows Presentation Foundation (WPF) para crear una interfaz de usuario fácil de usar, moderna y atractiva.

    Animaciones: La aplicación incluye animaciones para mejorar la experiencia del usuario y hacerla más atractiva.

    Sistema de Inicio de Sesión: Los usuarios deben iniciar sesión antes de acceder a las funcionalidades del gestor de inventarios. Esto garantiza la seguridad de los datos.

    Base de Datos SQL Server: Utiliza SQL Server como sistema de gestión de base de datos para almacenar información sobre productos, entradas y salidas.

    Entity Framework: Entity Framework se utiliza como ORM para interactuar con la base de datos de SQL Server de manera eficiente y sencilla.

    Registro de Entradas y Salidas: No solo puedes registrar productos, también sus entradas y salidas.

    Triggers: Se han implementado desencadenadores (triggers) en la base de datos para actualizar automáticamente las cantidades del stock de productos cuando se realizan entradas o salidas.

## Requisitos de Ejecución

    Windows 10 o superior: La aplicación se desarrolló para sistemas Windows y se ha probado en Windows 10 y versiones posteriores (la compatibilidad con Windows 7 no esta garantizada).

    SQL Server: Debe tener instalado y configurado SQL Server para almacenar y administrar la base de datos. Se debe añadir la base de datos al gestor de base de datos. Hay un script de la base de datos en el código fuente y en la versión compilada en la sección de releases.

    Framework .NET: Asegúrese de tener instalado .NET 7 para poder ejecutar la aplicación.

## Uso

    Inicie sesión con la contraseña por defecto, que es "1234". Obviamente, esta contraseña puede ser cambiada.

    Es es todo. Ya puedes usar la app para gestionar un inventario con stock, entradas y salida.


## Licencia

    Este proyecto está bajo la Licencia MIT. Consulte el archivo LICENSE para obtener más detalles.

## Agradecimientos

    Gracias a Falticon por los iconos usados en esta aplicación.

    Recuerda que puedes realizar donaciones a través de Paypal o Ko-fi.

    ¡Gracias por usar InventarioDB!

