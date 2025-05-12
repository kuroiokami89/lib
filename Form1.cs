using System;
using System.Windows.Forms;
using Library.Models;

namespace LibraryForm
{
    public partial class Form1 : Form
    {
        private MyLibrary libreria;

        // Campi UI
        private TextBox txtTitolo;
        private TextBox txtAutore;
        private TextBox txtAnno;
        private Button btnAggiungi;
        private ListBox listaLibri;

        public Form1()
        {
            InitializeComponent();
            libreria = new MyLibrary();
            InizializzaUI();
        }

        private void InizializzaUI()
        {
            // Titolo
            txtTitolo = new TextBox { PlaceholderText = "Titolo", Location = new System.Drawing.Point(20, 20), Width = 200 };
            Controls.Add(txtTitolo);

            // Autore
            txtAutore = new TextBox { PlaceholderText = "Autore", Location = new System.Drawing.Point(20, 60), Width = 200 };
            Controls.Add(txtAutore);

            // Anno
            txtAnno = new TextBox { PlaceholderText = "Anno", Location = new System.Drawing.Point(20, 100), Width = 200 };
            Controls.Add(txtAnno);

            // Bottone
            btnAggiungi = new Button { Text = "Aggiungi Libro", Location = new System.Drawing.Point(20, 140), Width = 200 };
            btnAggiungi.Click += BtnAggiungi_Click;
            Controls.Add(btnAggiungi);

            // Lista
            listaLibri = new ListBox { Location = new System.Drawing.Point(250, 20), Width = 300, Height = 200 };
            Controls.Add(listaLibri);
        }

        private void BtnAggiungi_Click(object sender, EventArgs e)
        {
            // Validazione base
            if (string.IsNullOrWhiteSpace(txtTitolo.Text) || string.IsNullOrWhiteSpace(txtAutore.Text) || !int.TryParse(txtAnno.Text, out int anno))
            {
                MessageBox.Show("Compila tutti i campi correttamente.");
                return;
            }

            // Crea nuovo libro
            var libro = new Book(txtTitolo.Text, txtAutore.Text, anno);

            // Aggiungi alla libreria e aggiorna UI
            libreria.AddBook(libro);
            listaLibri.Items.Add(libro);
        }

        // private void BtnRimuovi_Click(object sender, EventArgs e)
        // {
        //     // Validazione base
        //     if (string.IsNullOrWhiteSpace(txtTitolo.Text) || string.IsNullOrWhiteSpace(txtAutore.Text) || !int.TryParse(txtAnno.Text, out int anno))
        //     {
        //         MessageBox.Show("Compila tutti i campi correttamente.");
        //         return;
        //     }

        //     libreria.RemoveBook(txtTitolo);
        // }
    }
}
