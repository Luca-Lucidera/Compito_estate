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
        public string zona_operativa { set; get; }
        public bool occupata { set; get; }
        public string image_path { set; get; }
        public override string ToString()
        {
            string tmp="";
            if (occupata)
                tmp = "occupata";
            else
                tmp = "libera";
            return "id: " + id + " nome " + nome + " cognome " + cognome + " zona operativa: " + zona_operativa + " occupazione: " + tmp;
        }
    }
}
