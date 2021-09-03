using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using DBProject;

namespace Services
{
    public class GameServices
    {
        public static void MostraEroi(Utente user)
        {
            bool Estrazione = AdoGame.EstraiEroi(user);
            if (!Estrazione) {
                Console.WriteLine("Non hai ancora nessun eroe, creane uno");
                CreaEroe(user);
            }

        }

        public static void CreaEroe(Utente user)
        {
            Console.Clear();
            Eroe eroe = new Eroe();
            //                              NOME
            Console.WriteLine("Inserisci il nome dell'eroe");
            eroe.Nome = Console.ReadLine();
            //                              Categoria
            Console.WriteLine("Premi 1 per scegliere la categoria Guerriero");
            Console.WriteLine("Oppure 2 per scegliere la categoria Mago");
            int.TryParse(Console.ReadLine(), out int scelta);
            bool continuare = true;
            int id = 0;
            do
            {
                if (scelta == 1)
                {
                    eroe.Categoria = Eroe.categoria.Guerriero;
                    continuare = false;
                    id = 1;
                }
                else
                {
                    if (scelta == 2)
                    {
                        eroe.Categoria = Eroe.categoria.Mago;
                        id = 2;
                        continuare = false;
                    }
                    else
                    {
                        Console.WriteLine("Errore, premi 1 per Guerriero, 2 per Mago");
                    }
                }
            } while (continuare);
            //                      ARMA
            bool trovato = false;
            do
            {
                AdoGame.VisualizzaArmi(id);
                int.TryParse(Console.ReadLine(), out int sceltaArma);
                trovato = AdoGame.CheckArm(sceltaArma);
                if (!trovato)
                {
                    Console.WriteLine("Errore nell'inserimento dell'ID dell'arma, riprova");
                }
                else
                {
                    Console.WriteLine("Scelta dell'arma effettuata");
                    eroe.IdArma = sceltaArma;
                    AdoGame.InserisciEroe(eroe, user);
                }
            } while (!trovato);
            


        }

        public static void EliminaEroe(Utente user)
        {
            Console.Clear();
            MostraEroi(user);
            int.TryParse(Console.ReadLine(), out int EroeDaEliminare);
            AdoGame.EliminaEroe(EroeDaEliminare);

        }
    }
}
