using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaTénica01 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Entry;
            int MainOptions = 0;
            bool valid;
            bool End = false;
            float saldoinicial;
            float monto;
            int numerocuenta;
            int elementos;
            List<Cuenta> ListaCuentas = new List<Cuenta>();
            List<Transaccion> ListaTransaccion = new List<Transaccion>();



            while (End == false)
            {
                Console.WriteLine("Gestión de cuentas Bancarias \nIntroduzca su accion \n1-Crear cuenta \n2-Consultar Saldo \n3-Realizar un deposito \n4-Realizar un retiro\n5-Consultar Saldo Final \n6-Salir");
                Entry = Console.ReadLine();
                valid = Regex.IsMatch(Entry, "([0-9]+)");
                if (valid == true)
                {
                    MainOptions = Convert.ToInt32(Entry);
                    switch (MainOptions)
                    {
                        case 1:
                            Console.WriteLine("************************************\nIntroduzca el Saldo Inicial de la Cuenta");
                            saldoinicial = ValidacionFloat();
                            if  (saldoinicial > -1){
                                ListaCuentas = CrearCuenta(saldoinicial, ListaCuentas);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                Console.ReadKey();
                                Console.Clear();
                            }

                                break;
                        case 2:
                            elementos = ListaCuentas.Count;
                            if (elementos == 0)
                            {
                                Console.WriteLine("************************************");
                                Console.WriteLine("No hay Cuentas");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("************************************\nIntroduzca el Numero de la Cuenta");
                            numerocuenta = ValidacionInt();
                            if (numerocuenta > -1)
                            {
                                ConsultarSaldo(numerocuenta, ListaCuentas);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                Console.ReadKey();
                                Console.Clear();
                            }

                                break;
                        case 3:
                            elementos = ListaCuentas.Count;
                            if (elementos == 0)
                            {
                                Console.WriteLine("************************************");
                                Console.WriteLine("No hay Cuentas");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("************************************\nIntroduzca el Numero de la Cuenta");
                            numerocuenta = ValidacionInt();
                            if(numerocuenta > -1)
                            {
                                for (int i = 0; i < elementos + 1; i++) {
                                    if (i < elementos)
                                    {
                                        if (numerocuenta == ListaCuentas[i].Numero)
                                        {

                                            Console.WriteLine("************************************\nIntroduzca el Monto a Depositar");
                                            monto = ValidacionFloat();
                                            if (monto > -1)
                                            {
                                                ListaCuentas = DepositoRetiro(numerocuenta, monto, ListaCuentas, 0);
                                                ListaTransaccion = RegistrarTransaccion(ListaTransaccion, numerocuenta, monto, ListaCuentas, 0);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                    }
                                    else if (i >= elementos)
                                    {
                                        Console.WriteLine("************************************");
                                        Console.WriteLine("Cuenta no existe");
                                        Console.WriteLine("************************************");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            break;
                        case 4:
                            elementos = ListaCuentas.Count;
                            if (elementos == 0)
                            {
                                Console.WriteLine("************************************");
                                Console.WriteLine("No hay Cuentas");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("************************************\nIntroduzca el Numero de la Cuenta");
                            numerocuenta = ValidacionInt();
                            if (numerocuenta > -1)
                            {
                                for (int i = 0; i < elementos + 1; i++)
                                {
                                    if (i < elementos)
                                    {
                                        if (numerocuenta == ListaCuentas[i].Numero)
                                        {

                                            Console.WriteLine("************************************\nIntroduzca el Monto a Retirar");
                                            monto = ValidacionFloat();
                                            if (monto > -1)
                                            {
                                                if(monto <= ListaCuentas[i].Saldo)
                                                {
                                                    ListaCuentas = DepositoRetiro(numerocuenta, monto, ListaCuentas, 1);
                                                    ListaTransaccion = RegistrarTransaccion(ListaTransaccion, numerocuenta, monto, ListaCuentas, 1);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("************************************");
                                                    Console.WriteLine("Retiro Rechazado");
                                                    Console.WriteLine("Saldo insuficiente");
                                                    Console.WriteLine("************************************");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                    }
                                    else if (i >= elementos)
                                    {
                                        Console.WriteLine("************************************");
                                        Console.WriteLine("Cuenta no existe");
                                        Console.WriteLine("************************************");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:

                            if(ListaCuentas.Count == 0)
                            {
                                Console.WriteLine("************************************");
                                Console.WriteLine("No hay Cuentas");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            if(ListaTransaccion.Count == 0)
                            {
                                Console.WriteLine("************************************");
                                Console.WriteLine("No hay Transacciones");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Console.WriteLine("************************************\nIntroduzca el Numero de la Cuenta");
                            numerocuenta = ValidacionInt();
                            if (numerocuenta > -1)
                            {
                                for (int i = 0; i < ListaCuentas.Count+1; i++)
                                {
                                    if (i < ListaCuentas.Count)
                                    {
                                        if(numerocuenta == ListaCuentas[i].Numero)
                                        {
                                            SaldoFinal(numerocuenta, ListaCuentas, ListaTransaccion);
                                            break;
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("************************************");
                                        Console.WriteLine("Cuenta no existe");
                                        Console.WriteLine("************************************");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                                Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("************************************\nIntrodujo un termino no valido.");
                            Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("************************************\nIntroduzca solo numeros");
                    Console.WriteLine("Presiones cualquier tecla para continuar...\n************************************");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static public float ValidacionFloat(){
            string Entry;
            bool valid;
            float saldo;
            Entry = Console.ReadLine();
            valid = Regex.IsMatch(Entry, "([0-9.]+)");
            if (valid)
            {
                saldo = float.Parse(Entry);
            }
            else { saldo = -1; }
                return saldo;
        }

        static public int ValidacionInt()
        {
            string Entry;
            bool valid;
            int numero;
            Entry = Console.ReadLine();
            valid = Regex.IsMatch(Entry, "([0-9]+)");
            if (valid)
            {
                numero = Convert.ToInt32(Entry);
            }
            else { numero = -1; }
            return numero;
        }

        static public List<Cuenta> CrearCuenta(float saldo, List<Cuenta> Lista)
        {
            int numerocuenta;
            if (Lista.Count == 0)
            {
               numerocuenta = 1;
            }
            else { 
               Cuenta UltimaCuenta = Lista.Last();
                numerocuenta = UltimaCuenta.Numero + 1;
            }
            Lista.Add(new Cuenta(numerocuenta, saldo));
            Console.WriteLine("************************************");
            Console.WriteLine("Numero de Cuenta: " + numerocuenta);
            Console.WriteLine("Saldo inicial: " + saldo);

            return Lista;
        }

        static public void ConsultarSaldo(int NumeroCuenta, List<Cuenta> Lista)
        {
            float saldo;
            int elementos = Lista.Count;
            int numerocuentatemp;
            Cuenta cuenta;
                for (int i = 0; i < elementos+1; i++)
                {
                    if (i < elementos)
                    {
                        cuenta = Lista[i];
                        numerocuentatemp = cuenta.Numero;
                        if (numerocuentatemp == NumeroCuenta)
                        {
                            saldo = cuenta.Saldo;
                            Console.WriteLine("Saldo de la cuenta: " + saldo);
                            return;
                        }
                    }
                    else {
                        Console.WriteLine("************************************");
                        Console.WriteLine("Cuenta no existe");
                        Console.WriteLine("************************************");
                        return ;
                    }

                }
            return;
        }

        static public List<Cuenta> DepositoRetiro(int numerocuenta, float monto, List<Cuenta>Cuenta, int tipo)
        {
            float saldo;
            int elementos = Cuenta.Count;
            int numerocuentatemp;
            Cuenta cuenta;

                for (int i = 0; i < elementos + 1; i++)
                {
                        cuenta = Cuenta[i];
                        numerocuentatemp = cuenta.Numero;
                        if (numerocuentatemp == numerocuenta)
                        {
                            saldo = cuenta.Saldo;
                            if(tipo == 0)
                            {
                                saldo = saldo + monto;
                                Cuenta[i].Saldo = saldo;
                                Console.WriteLine("************************************");
                                Console.WriteLine("Deposito Realizado");
                                Console.WriteLine("************************************");
                                Console.ReadKey();
                                Console.Clear();
                                return Cuenta;
                            }
                            else if(tipo == 1)
                            {
                                    saldo = saldo - monto;
                                    Cuenta[i].Saldo = saldo;
                                    Console.WriteLine("************************************");
                                    Console.WriteLine("Retiro Realizado");
                                    Console.WriteLine("************************************");
                                    Console.ReadKey();
                                    Console.Clear();
                                    return Cuenta;
                            }

                            
                        }
                }
            return Cuenta;
        }

        public static List<Transaccion> RegistrarTransaccion (List<Transaccion> list, int NumeroCuenta, float monto, List<Cuenta>Cuentas, int tipo)
        {
            int elementos = Cuentas.Count;
            int elementosT = list.Count;
            float saldo;
            int lastident;
            for (int i = 0; i < elementos; i++)
            {
                if (NumeroCuenta == Cuentas[i].Numero)
                {
                    saldo = Cuentas [i].Saldo;
                    if (elementosT == 0)
                    {
                        if (tipo == 0){
                            list.Add(new Transaccion(1, NumeroCuenta, "Deposito", monto, saldo));
                        }
                        else if (tipo == 1)
                        {
                            list.Add(new Transaccion(1, NumeroCuenta, "Retiro", monto, saldo));
                        }
                        
                    }
                    else
                    {
                        lastident = list.Last().identificador;
                        if (tipo == 0)
                        {
                            list.Add(new Transaccion(lastident+1, NumeroCuenta, "Deposito", monto, saldo));
                        }
                        else if (tipo == 1)
                        {
                            list.Add(new Transaccion(lastident + 1, NumeroCuenta, "Retiro", monto, saldo));
                        }
                    }


                }
            }
                return list;
        }


        static public void SaldoFinal(int numerocuenta, List<Cuenta>Cuentas, List<Transaccion>Transacciones)
        {
            int elementos = Transacciones.Count;
            int elementosC = Cuentas.Count;
            float saldo;
            int contador = 0;
            Console.WriteLine("************************************");
            Console.WriteLine("Resumen de Transacciones");

            for (int i = 0; i < elementos; i++) { 
                if (numerocuenta == Transacciones[i].numerocuenta)
                {
                    Console.WriteLine("Identificador: " + Transacciones[i].identificador + " | Tipo de Transaccion: " + Transacciones[i].tipo + " | Monto: " + Transacciones[i].monto + " | Saldo final: " + Transacciones[i].saldofinal);
                    contador++;
                }
            
            }
            if (contador == 0) {

                Console.WriteLine("************************************");
                Console.WriteLine("Esta cuenta no ha hecho ninguna Transaccion.");

            }
            for (int i = 0; i < elementosC; i++)
            {
                if (numerocuenta == Cuentas[i].Numero)
                {
                    saldo = Cuentas[i].Saldo;
                    Console.WriteLine("Saldo final: " + saldo);
                }
            }
            Console.WriteLine("************************************");
            Console.ReadKey();
            Console.Clear();
            return;
        }

    }


    public class Cuenta (int nuevonumero, float nuevosaldo)
    {
        public int Numero = nuevonumero;
        public float Saldo = nuevosaldo;
    }

    public class Transaccion(int identificador, int numerocuenta, string tipo, float monto, float saldofinal)
    {
        public int identificador = identificador;
        public int numerocuenta = numerocuenta;
        public string tipo = tipo;
        public float monto = monto;
        public float saldofinal = saldofinal;
    }
}