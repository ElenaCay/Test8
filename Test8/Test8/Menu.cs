using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;


namespace Presentation
{
    public static class Menu
    {
        public static void Start()
        {
            bool continuare = true;
            int scelta;

            do
            {
                Console.WriteLine("Premi 1 per accedere");
                Console.WriteLine("Premi 2 per registrarti");
                Console.WriteLine("Premi 3 per uscire");

                
                int.TryParse(Console.ReadLine(), out scelta);

                switch (scelta)
                {
                    case 1:
                        if (UserServices.CheckNickname()) {
                            UtenteMenu.Access();
                        }
                        else
                        {
                            Console.WriteLine("Nessun utente inserito, registrati!");
                            UtenteMenu.Insert();
                        }
                        break;
                    case 2:
                        UtenteMenu.Insert();
                        break;
                    case 3:
                        Console.WriteLine("Alla prossima partita");
                        continuare = false;
                        break;
                }

            } while (continuare);
        }
    }
}
