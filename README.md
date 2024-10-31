# BookingProject
Para ejecución del proyecto backend.
1. Ejecute en la consola el siguiente comando ```git clone https://github.com/PaoM21/BookingProject.git```.
2. Abra el proyecto en el entorno de desarollo de preferencia.
3. Abra la aplicación de docker desktop.
4. Ejecute en la consola el siguiente comando ```sed -i 's/\r$//' BookingProject.API/Db/run-initialization.sh```.
5. En la consola ejecute el siguiente comando ```docker-compose up --build``` para crear la imagen, container y volume en docker de la base de datos y el api del proyecto.
6. Ingrese desde el navegador web de su preferencia a la ruta _http://localhost:8080/swagger/index.html_ donde encontrará los endpoint del proyecto backend.
Para ejecución del proyecto frontend.
1. Ejecute en la consola el comando ```npm install```.
2. Ejecute en la consola el comando ```npm run dev```.
3. Abra el link de ejecución que le muestra en consola y pruebe la funcionalidad.
