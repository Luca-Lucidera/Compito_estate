using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_T
{
    class Utente
    {
        public int id { set; get; }
        public string nome { set; get; }
        public string cognome { set; get; }
        public string email { set; get; }
        public string nascita { set; get; }
        public override string ToString()
        {
            return "id: " + id + " nome: " + nome + " email: " + email + " nascita: "+ nascita;
        }
    }
}
