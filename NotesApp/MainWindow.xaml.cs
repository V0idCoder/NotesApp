using NotesCli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bulletin Bulletin = new();
        public MainWindow()
        {
            //var b = new Branche() { Nom = "Mathématiques" };
            //b.Notes.Add(new Note() { Valeur = 6.0 });
            //b.Notes.Add(new Note() { Valeur = 5.5 });
            //b.Notes.Add(new Note() { Valeur = 6.0 });
            //Bulletin.Branches.Add(b);
            //b = new Branche() { Nom = "Anglais" };
            //b.Notes.Add(new Note() { Valeur = 5.3 });
            //b.Notes.Add(new Note() { Valeur = 5.1 });
            //b.Notes.Add(new Note() { Valeur = 4.2 });
            //Bulletin.Branches.Add(b);
            //Bulletin.Save();

            Bulletin.Load();

            InitializeComponent();
            DataContext = Bulletin;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bulletin.Save();
        }
    }
}
