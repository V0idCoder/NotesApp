using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesCli
{
    public class Note
    {
        public double Valeur { get; set; } //Le nom de la branche
        public double Ponderation { get; set; } = 1.0;

        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now); //


        //Return all separated by semi columns
        public string Serialize()
        {
            return $"{Date};{Ponderation};{Valeur}";
        }
        public void Deserialize(string s)
        {
            var fields =s.Split(';'); //Permet de séparer les valeurs d'un string. Ici determiné par le ";".
            Date = DateOnly.Parse(fields[0]); //Convert un string en date
            Ponderation = Convert.ToDouble(fields[1]); //Convert de string en double
            Valeur = Convert.ToDouble(fields[2]); //Convert de string en double
        }
    }
}
