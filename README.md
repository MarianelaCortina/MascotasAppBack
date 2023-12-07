Este código pertenece al back end  de la app Mascotas, que realicé con .Net Core 8 utilizando Entity framework
El front end lo encontrarán en el siguiente link: https://github.com/MarianelaCortina/MascotasAppFront

La app web consiste en un ABM de una Veterinaria, en cuya home se listan automáticamente las mascotas.

En el back, realicé:
+ Capa Models:
  - La clase Mascota, con los atributos para crear instancias del objeto mascota (Id, Nombre, Raza, Color, Edad, Peso, Fecha de creación del registro)
  - Mascota DTO: para que no todos los atributos sean visibles para desde el lado del Cliente, como por ejemplo: fecha de creación.
  - Interface Repository y Mascota Repository donde están los métodos que luego son utilizados en el Controller.
+ Capa Migration:
  - Realicé el archivo AplicationDbContextModelSnapshot, que contiene los atributos del objeto Mascota, para migrar esta tabla a la
    base de datos SQL Server.  
+ Capa Controller:
  - Aquí están las apis con los métodos para realizar el ABM, que son llamados desde el service del front end.
