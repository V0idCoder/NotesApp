using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesCli
{
    public class Bulletin
    {
        public ObservableCollection<Branche> Branches { get; set; } = new();
        public double Moyenne
        {
            get
            {
                double t = 0;
                foreach (var b in Branches)
                {
                    t += b.Moyenne;
                }
                return t / Branches.Count;
            }
        }

        public void Save()
        {
            //Créer un ficheir de type text
            using (var sw = new StreamWriter("notes.txt"))
            {
                foreach (var b in Branches)
                {
                    sw.WriteLine(b.Serialize());
                }
                
            }

        }
        public void Load()
        {
            using (var sr = new StreamReader("notes.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    var b = new Branche();
                    b.Deserialize(s);
                    Branches.Add(b);
                    
                }
            }
        
        }
    }

}
