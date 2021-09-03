using System;
using BusinessLayer.Entities;
using DBProject;

namespace Services
{
    public static class UserServices
    {
        public static Utente AccessUser(Utente utente)
        {
            Utente user = AdoUser.AccessUser(utente);
            return user;
        }

        public static bool CheckNickname(String nickname)
        {
            bool trovato = AdoUser.CheckNickname(nickname);
            if (trovato)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckNickname()
        {
            bool trovato = AdoUser.CheckNickname();
            if (trovato)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void InsertUser(Utente utente)
        {
            AdoUser.InsertUser(utente);
        }
    }
}
