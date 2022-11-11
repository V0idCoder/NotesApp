using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace NotesCli
{
    public class Branche
    {
        public string? Nom { get; set; }
        public ObservableCollection<Note> Notes { get; set; } = new();
        public string ListeNotes {
            get 
            {
                StringBuilder sb = new();
                foreach (var note in Notes)
                {
                    if (sb.Length > 0)
                        sb.Append(", ");
                    sb.Append(note.Valeur.ToString("F1"));
                }
                return sb.ToString();
            }
            set
            {
                var values = value.Split(',');
                ObservableCollection<Note> newNotes = new();
                foreach (var v in values)
                    if (double.TryParse(v, out var n))
                        newNotes.Add(new Note() { Valeur = n });
                    else
                        return;
                Notes = newNotes;
            }
        }
        public double Moyenne
        {
            get
            {
                double t = 0;
                double n = 0;
                foreach (var note in Notes)
                {
                    t += note.Valeur * note.Ponderation;
                    n += note.Ponderation;
                }
                return t / n;
            }
        }
        public string Serialize()
        {
            //Créer une boucle qui parcoure toute la liste
            StringBuilder sb = new StringBuilder();
            sb.Append(Nom);
            foreach (var n in Notes)
            {
                sb.Append('\t');
                sb.Append(n.Serialize());
            }
            return sb.ToString();
        }
        public void Deserialize(string s)
        {
            var fields = s.Split('\t'); //Permet de séparer les valeurs d'un string. Ici determiné par le ";".
            Nom = fields[0];
            for (int i = 1; i < fields.Length; i++)
            {
                var n = new Note();
                n.Deserialize(fields[i]);
                Notes.Add(n);
            }
        }
    }
}
