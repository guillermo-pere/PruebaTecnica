# PruebaTécnicaProgramación01
A continuación se presenta un sencillo programa que se ejecuta en el cmd.
Recomiendo abrirse através de Visual Studio 2022.
Se usan listas en memorias para simular la persistencia de datos.
El codigo se encuentra en el archivo Program.cs en la Carpeta PruebaTécnicaProgramación01

Instrucciones:
Se presentan 6 opciones:
1-Crear cuenta
2-Consultar Saldo
3-Realizar un deposito
4-Realizar un retiro
5-Consultar Saldo Final
6-Salir

Solo se aceptan el ingreso de los 6 números enteros. De otra forma mandará un mensaje.

1. La primera opción te pedirá introducir el saldo inicial de una nueva cuenta, asigna el número de cuenta automáticamente y finalmente imprime el número de cuenta y el saldo inicial.
   Se pueden añadir cuentas de forma indefinida.
     *Introducir un saldo que no sea un numero float imprimira un mensaje y te regresara a las opciones iniciales.
2. Consultar el saldo te pedirá introducir el numero de cuenta a la que quieres consultar el saldo. Posteriormente imprimirá el saldo actual de la cuenta.
     *Introducir un numero de cuenta que no sea un numero int imprimira un mensaje y te regresara a las opciones iniciales.
     *Si no hay cuentas en el sistema imprimira un mensaje de error y te regresara a las opciones iniciales.
     *Si la cuenta a la que quieres consultar no existe imprimira un mensaje de error y te regresara a las opciones iniciales.
3. Realizar un deposito te pedira el numero de cuenta a la cual realizar un deposito
     *Introducir un numero que no sea int imprimira un mensaje y te regresara a las opciones iniciales.
     *Si no hay cuentas en el sistema imprimira un mensaje de error y te regresara a las opciones iniciales.
     *Si la cuenta a la que quieres consultar no existe imprimira un mensaje de error y te regresara a las opciones iniciales.
   Posteriormente te pedira introducir el monto a depositar.
     *Introducir un numero que no sea float imprimira un mensaje de error y te regresara a las opciones iniciales.
   Imprimirá un mensaje al completarse.
4. Realizar un retiro te pedira ingresar el numero de cuenta a la cual realizar un retiro.
     *Introducir un numero que no sea int imprimira un mensaje y te regresara a las opciones iniciales.
     *Si no hay cuentas en el sistema imprimira un mensaje de error y te regresara a las opciones iniciales.
     *Si la cuenta a la que quieres consultar no existe imprimira un mensaje de error y te regresara a las opciones iniciales.
   Posteriormente te pedira introducir el monto a depositar.
     *Introducir un numero que no sea float imprimira un mensaje de error y te regresara a las opciones iniciales.
     *Si la cantidad a retirar excede el saldo de la cuenta la transaccion será rechazada, imprimirá un mensaje y te regresará a las opciones iniciales.
5. Consultar saldo final imprimirá el historial de transacciones junto al saldo final.
   *Si no hay cuentas en el sistema imprimira un mensaje de error y te regresara a las opciones iniciales.
   *Si no hay transacciones en el sistemas imprimira un mensaje de error y te regresara a las opciones iniciales.
   Te pedirá el número de cuenta al que quieres consultar las transacciones realizadas.
     *Introducir un numero que no sea int imprimira un mensaje y te regresara a las opciones iniciales.
     *Si la cuenta a la que quieres consultar no existe imprimira un mensaje de error y te regresara a las opciones iniciales.
     *Si la cuenta a la quieres consultar no ha hecho transacciones te mandará un mensaje junto al saldo actual y te regresara a las opciones iniciales.
6. Terminará la ejecución del programa.

Pruebas:
1. Intente ingresar letras o numeros no enteros para observar que todos los campos son seguros.
2. Cree una cuenta de saldo 1000 y una cuenta de saldo 2000
3. Haga un deposito de 700 en la primera y un retiro de 700 en la otra.
4. Haga una consulta de transacciones de cada cuenta.
   
   
