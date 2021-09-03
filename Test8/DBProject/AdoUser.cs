using System;
using BusinessLayer.Entities;
using System.Data.SqlClient;

namespace DBProject
{

    public class AdoUser
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MostriVSEroi;Trusted_Connection=True;";

        public static Utente AccessUser(Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                SqlCommand leggi = new SqlCommand("" +
                    "SELECT * FROM Utente " +
                    "WHERE Nickname='" + utente.Nickname + "' " +
                    "AND Pass='" + utente.Password + "'", conn);

                SqlDataReader reader = leggi.ExecuteReader();

               
                if (reader.Read())
                {
                    utente.Id = (int)reader[0];
                    utente.Nickname = (string)reader[1];
                    utente.Password = (string)reader[2];
                    utente.Livello = (int)reader[3];
                    utente.PuntiVita = (int)reader[4];
                    utente.IsAuthenticated = (bool)reader[5];
                    utente.IsAdmin = (bool)reader[6];
                    conn.Close();
                    return utente;
                }
                else
                {
                    Console.WriteLine("Errore nei dati, riprova a fare il login");
                    conn.Close();
                    return null;
                }
            }
        }

        public static bool CheckNickname(String nickname)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");
          
                SqlCommand leggi = new SqlCommand("" +
                    "SELECT * FROM Utente " +
                    "WHERE Nickname='" + nickname + "'", conn);

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

        public static void InsertUser(Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                string inserisci = @"INSERT INTO Utente(Nickname, Pass, IsAdmin, Livello, PuntiVita, Autenticazione) VALUES " +
                                            $"('{utente.Nickname}','{utente.Password}',0, 1, 20, 1);";

                SqlCommand command = new SqlCommand(inserisci, conn);
                command.ExecuteScalar();
                conn.Close();
            }
            Console.WriteLine("Inserimento effettuato!");
        }

        public static bool CheckNickname()
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessione stabilita con successo");
                else
                    Console.WriteLine("Connessione fallita");

                SqlCommand leggi = new SqlCommand("" +
                    "SELECT * FROM Utente ", conn);

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


    }
}
