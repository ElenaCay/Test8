using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using System.Data.SqlClient;

namespace DBProject
{
    public class AdoGame
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MostriVSEroi;Trusted_Connection=True;";

        public static bool EstraiEroi(Utente user)
        {
            Console.Clear();
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                SqlCommand leggi = new SqlCommand("" +
                    "SELECT Eroe.Id as EroeId, Eroe.Nome as EroeN, Categoria.Nome as CategoriaN, Arma.Nome as ArmaN " +
                    "FROM Eroe " +
                    "INNER JOIN Arma " +
                    "ON Eroe.IdArma = Arma.Id " +
                    "INNER JOIN Categoria " +
                    "ON Categoria.Id = Eroe.IdCategoria " +
                    "INNER JOIN Utente " +
                    "ON Eroe.IdUtente = Utente.Id " +
                    "WHERE Utente.Id =" + user.Id + "", conn);

                SqlDataReader reader = leggi.ExecuteReader();

                if (!reader.HasRows)
                {

                    Console.WriteLine("Non hai ancora nessun eroe, creane uno!");
                    return false; 
                }

                   Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "Id Eroe", "Nome", "Categoria", "Arma in uso");
                   Console.WriteLine(new String('-', 60));

                while (reader.Read())
                {
                     Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}",
                         reader["EroeId"],
                         reader["EroeN"],
                         reader["CategoriaN"],
                         reader["ArmaN"]
                     );;
                }
                 Console.WriteLine(new String('-', 60));
                conn.Close();
                return true;
            }
        }

        public static void VisualizzaArmi(int id)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                SqlCommand leggi = new SqlCommand("" +
                    "SELECT * FROM Arma " +
                    "WHERE IdCategoria=" + id + "", conn);

                SqlDataReader reader = leggi.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("Errore, categoria non assegnata!");
                }

                Console.WriteLine("{0,-15}{1,-10}{2,-10}", "Id dell'arma","Nome", "Punti Danno");
                Console.WriteLine(new String('-', 50));
                /*
                  List<int> Armi = new List<int>();
                int indice = 0;
                while (reader.Read())
                {
                    Armi[indice] = (int)reader["Id"];
                    Console.WriteLine("{0,-15}{1,-10}{2,-10}",
                        Armi[indice],
                        reader["Nome"],
                        reader["PuntiDanno"]
                    );
                }
               
                 */
                while (reader.Read())
                {
                    Console.WriteLine("{0,-15}{1,-10}{2,-10}",
                        reader["Id"],
                        reader["Nome"],
                        reader["PuntiDanno"]
                    );
                }
                Console.WriteLine(new String('-', 50));
               
                conn.Close();
               // return Armi;
            }
        }

        public static bool CheckArm(int id)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                SqlCommand leggi = new SqlCommand("" +
                    "SELECT * FROM Arma " +
                    "WHERE Id='" + id + "'", conn);

                SqlDataReader reader = leggi.ExecuteReader();

                if (reader.Read())
                {
                    conn.Close();

                    return true;

                }
                else
                {
                    conn.Close();

                    return false;
                }

            }

        }

        public static void InserisciEroe(Eroe eroe, Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");
                //      GESTIONE DELLA CATEGORIA DA RIVEDERE!!
                int IdCategoria = 0;
                if (eroe.Categoria == Eroe.categoria.Guerriero)
                {
                    IdCategoria = 1;
                }
                else { IdCategoria = 2; }
                string inserisci = @"INSERT INTO Eroe(Nome, IdCategoria, IdUtente, IdArma) VALUES " +
                                            $"('{eroe.Nome}', {IdCategoria}, {utente.Id}, {eroe.IdArma});";

                SqlCommand command = new SqlCommand(inserisci, conn);
                command.ExecuteScalar();
                conn.Close();
            }
            Console.WriteLine("Eroe inserito!");

        }

        public static void EliminaEroe(int id)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                //DA TESTARE
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");
              
                string elimina = "DELETE FROM Eroe WHERE Id="+id;

                SqlCommand command = new SqlCommand(elimina, conn);
                command.ExecuteScalar();
                conn.Close();
            }

    }
}
