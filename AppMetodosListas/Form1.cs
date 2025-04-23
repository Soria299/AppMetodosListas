using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMetodosListas
{
    public partial class Form1 : Form
    {
        // Lista para almacenar elementos 

        private List<string> elementos = new List<string>();
        public Form1()
        {
            InitializeComponent();
            txtElemento.KeyPress += new KeyPressEventHandler(txtElemento_KeyPress);
        }

        // Método para agregar elementos 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoElemento = txtElemento.Text;
            if (!string.IsNullOrWhiteSpace(nuevoElemento) && SoloContienLetras(nuevoElemento))
            {
                elementos.Add(nuevoElemento);
                ActualizarLista();
                txtElemento.Clear();
            }
            else
            {
                MessageBox.Show("Por favor ingresa solo letras.");
            }
        }
        private bool SoloContienLetras(string texto)
        {
            // Verifica que cada carácter sea una letra o un espacio
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        // Método para eliminar elementos seleccionados 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstElementos.SelectedItem != null)
            {
                elementos.Remove(lstElementos.SelectedItem.ToString());
                ActualizarLista();
            }
            else
            {
                MessageBox.Show("Selecciona un elemento para eliminar.");
            }
        }

        // Método para actualizar ListBox 
        private void ActualizarLista()
        {
            lstElementos.DataSource = null;
            lstElementos.DataSource = elementos;
        }
        private void txtElemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras (mayúsculas y minúsculas), la tecla de retroceso y espacios
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }
    }
}