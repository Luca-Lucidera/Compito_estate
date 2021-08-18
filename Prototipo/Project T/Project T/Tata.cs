using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_T
{
    public class Tata
    {
        public int id { set; get; }
        public string nome { set; get; }
        public string cognome { set; get; }
        public string email { set; get; }

        public string psw { set; get; }

        public string zona_operativa { set; get; }
        public bool occupata { set; get; }
        public string image_path { set; get; }
        public Tata()
        {
            id = -1;
            nome = "";
            cognome = "";
            email = "";
            psw = "";
            zona_operativa = "";
            occupata = false;
            image_path = "";
        }

        public Tata(List<string> tata)
        {
            id = Convert.ToInt32(tata.ElementAt(0));
            nome = tata.ElementAt(1);
            cognome = tata.ElementAt(2);
            email = tata.ElementAt(3);
            psw = tata.ElementAt(4);
            zona_operativa = tata.ElementAt(5);
            occupata = Convert.ToBoolean(tata.ElementAt(6));
            image_path = tata.ElementAt(7);
        }

        public override string ToString()
        {
            return nome + " " + cognome + " " + email + " " + zona_operativa;
        }
    }
}
