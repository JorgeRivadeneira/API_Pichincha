DETALLE DE LA APLICACIÓN:

La aplicacion creada usa ASP.NET CORE v6, Enity Framework 6.

BASES DE DATOS: Toda la Data se encuentra creada con SQL Server, y el archivo de la Base de datos, se encuentra en el mismo directorio con el nombre:

BaseDatos.sql

Para el manejo de cáclculos cuando se hace un movimiento de débito o crédito, se creó un trigger (insert, update) sobre la tabla de movimientos para calcular los saldos, para ello se uso transaccionalidad y el manejo de errores en dicho trigger, además también para el registro de la data 
en la tabla del cupo diario y del cálculo para validar el cupo diario máximo permitido (Parámetro en la BDD).

CADENA CONEXION BDD: La cadena de conexion se encuentra en la raíz de éste directorio en el archivo:

appsettings.json "ConnectionStrings": { "DefaultConnection": "server=(LocalDb)\\MSSQLLocalDB;database=ApiTransactions;trusted_connection=true"
