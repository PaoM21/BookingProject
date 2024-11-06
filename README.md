# BookingProject
Para ejecución del proyecto backend (_BookingProject/_).
1. Ejecute en la consola el siguiente comando ```git clone https://github.com/PaoM21/BookingProject.git```.
2. Abra el proyecto en el entorno de desarollo de preferencia.
3. Abra la aplicación de docker desktop.
4. En la consola de comandos Git Bash, cambie a la raiz del proyecto.
5. Ejecute en la consola bash el siguiente comando ```sed -i 's/\r$//' BookingProject.API/Db/run-initialization.sh```.
6. En la consola del entorno de desarrollo ejecute el siguiente comando ```docker-compose up --build``` para crear la imagen, container y volume en docker de la base de datos y el api del proyecto.
7. Ingrese desde el navegador web de su preferencia a la ruta _http://localhost:8080/swagger/index.html_ donde encontrará los endpoint del proyecto backend.
   
Para ejecución del proyecto frontend.
1. En la consola bash cambie a la ruta _/BookingProject/BookingProject_ .
2. Ejecute en la consola bash el comando ```npm install```.
3. Ejecute en la consola el comando ```npm run dev```.
4. Abra el link de ejecución que le muestra en consola y pruebe la funcionalidad.
