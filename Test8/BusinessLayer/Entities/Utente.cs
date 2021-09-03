using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }

        public Utente()
        {

        }

        public Utente(int id, string username, string password, int livello, int punti)
        {
            Livello = livello;
            PuntiVita = punti;
            Id = id;
            Nickname = username;
            Password = password;
            IsAuthenticated = false;
            IsAdmin = false;
        }
        public Utente(string username, string password)
        {
            Nickname = username;
            Password = password;
        }
    }
}
