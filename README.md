# contacts-manager
Gestor de contactos CRUD

📘 Manual del Usuario: Gestor de Contactos

💾 Este manual explica cómo utilizar la aplicación de consola del Gestor de Contactos, que permite administrar una lista de personas almacenadas en una base de datos MySQL.

🚀 Cómo Empezar
Inicio de la Aplicación: Al ejecutar el programa, verá un mensaje de bienvenida. La aplicación le pedirá que presione una tecla para acceder al menú principal.

Menú Principal: Una vez dentro, se mostrará el menú con las 5 opciones disponibles:
1) Crear nuevo contacto
2) Ver todos los contactos
3) Actualizar contacto (por ID)
4) Eliminar contacto (por ID)
5) Salir de la aplicación

📝 Funciones del Sistema (CRUD)
1. Crear Nuevo Contacto (Opción 1)
   Esta función le permite agregar un nuevo registro a la lista.
   Seleccione la opción 1.
   El sistema le pedirá que ingrese el Nombre del contacto y luego el Teléfono.
   Presione Enter después de cada entrada.
   Recibirá un mensaje de confirmación ("Contacto creado exitosamente.")

2. Ver Todos los Contactos (Opción 2)
   Esta función muestra la lista completa de todos los contactos guardados en la base de datos.
   Seleccione la opción 2.
   El sistema listará todos los registros, mostrando el ID único, el Nombre y el Teléfono de cada persona.
   Nota importante: El ID es el número clave que usará para actualizar o eliminar un contacto.

3. Actualizar Contacto (Opción 3)
   Esta función permite modificar el nombre y/o el teléfono de un contacto existente.
   Seleccione la opción 3.
   El sistema le mostrará primero la lista de contactos (Opción 2) para que pueda identificar el ID del contacto a modificar.
   Ingrese el ID del contacto que desea actualizar.
   Luego, ingrese el Nuevo Nombre y el Nuevo Teléfono (aunque no quiera cambiar uno de los campos, debe ingresarlo con el valor que desea mantener).
   Recibirá un mensaje de confirmación si el ID existe.

4. Eliminar Contacto (Opción 4)
   Esta función permite borrar un registro de la base de datos de forma permanente.
   Seleccione la opción 4.
   El sistema le mostrará la lista de contactos para que pueda identificar el ID del contacto a eliminar.
   Ingrese el ID del contacto que desea borrar.
   Recibirá un mensaje de confirmación de la eliminación ("Contacto con ID X eliminado exitosamente.").
   Advertencia: Esta acción no se puede deshacer.

5. Finalizar la Aplicación
   Seleccione la opción 5 en el menú.
   Verá un mensaje de despedida ("¡Gracias por usar la aplicación!").
   Presione cualquier tecla para cerrar la ventana de la consola.

Sugerencia: Si encuentra algún error (indicado por un mensaje que comienza con Error), asegúrese de que el ID ingresado sea correcto, o informe el mensaje de error completo al administrador del sistema.
