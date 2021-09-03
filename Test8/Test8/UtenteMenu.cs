using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using Services;

namespace Presentation
{
    public static class UtenteMenu
    {
        public static void Access()
        {
            Utente utente = new Utente();
            Utente userAutenticato = new Utente();
            do
            {
                string nome = String.Empty;
                do
                {
                    Console.WriteLine("Inserisci il Nickname");
                    nome = Console.ReadLine();
                } while (String.IsNullOrEmpty(nome));

                utente.Nickname = nome;

                string psw = String.Empty;
                do
                {
                    Console.WriteLine("Inserisci la Password");
                    psw = Console.ReadLine();
                } while (String.IsNullOrEmpty(psw));

                utente.Password = psw;
                userAutenticato = UserServices.AccessUser(utente);
            } while (userAutenticato is null);
            
            
            if (userAutenticato.IsAdmin)
            {
                MenuAdmin(userAutenticato);
            }
            else
            {
                MenuNotAdmin(userAutenticato);
            }

        }

        internal static void MenuAdmin(Utente user)
        {
            Console.Clear();

        }

        internal static void MenuNotAdmin(Utente user)
        {
            Console.Clear();
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per Giocare");
                Console.WriteLine("Premi 2 per Creare un nuovo eroe");
                Console.WriteLine("Premi 3 per Eliminare un eroe");
                Console.WriteLine("Premi 4 per Effettuare il logout");


                int.TryParse(Console.ReadLine(), out int scelta);

                switch (scelta)
                {
                    case 1:
                        GameServices.MostraEroi(user);
                        break;
                    case 2:
                        GameServices.CreaEroe(user);
                        break;
                    case 3:
                        GameServices.EliminaEroe(user)
                        break;
                    case 4:
                        break;
                }

            } while (continuare);

        }
        internal static void Insert()
        {
            Console.Clear();
            Utente utente = new Utente();

            string nome = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il Nickname");
                nome = Console.ReadLine();
            } while (String.IsNullOrEmpty(nome) || UserServices.CheckNickname(nome));

            utente.Nickname = nome;

            string psw = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la Password");
                psw = Console.ReadLine();
            } while (String.IsNullOrEmpty(psw));

            utente.Password = psw;

            UserServices.InsertUser(utente);
            MenuNotAdmin(utente);
        }
    }
}
