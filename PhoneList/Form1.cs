using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneList
{
    public partial class Form1 : Form
    {
        string[][] lista;
        readonly int max = 100;
        public Form1()
        {
            InitializeComponent();
            lista = new string[max][];
        }
        int Length(string[][] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    itens++;
                }
            }
            return itens;
        }

        int Length(string[] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    itens++;
                }
            }
            return itens;
        }

        void Update()
        {
            dgvList.Rows.Clear();
            for (int i = 0;i<Length(lista); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvList);
                for (int j = 0; j < Length(lista[i]); j++)
                {
                    row.Cells[j].Value = lista[i][j];
                }
                dgvList.Rows.Add(row);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || !txtPhone.MaskFull)
            {
                MessageBox.Show("Insira nome e telefone!");
                return;
            }
            int id = 1;
            if(Length(lista) > 0)
            {
                id = int.Parse(lista[Length(lista) - 1][0])+1;
            }
            lista[Length(lista)] = new string[] {id.ToString(), txtName.Text,txtPhone.Text};

            Update();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvList.SelectedCells[0];
            int linha = cell.RowIndex;
            string id = dgvList.Rows[linha].Cells[0].Value.ToString();
            int indice = 0;
            for (indice = 0; indice < Length(lista) && lista[indice][0] != id; indice++) ;
            DialogResult result = MessageBox.Show("Deseja realmente remover?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for(int i = indice; i < Length(lista) - 1; i++)
                {
                    lista[i] = lista[i+1];
                }
                lista[Length(lista) - 1] = null;
                Update();

            }
            else
            {
                return;
            }


        }
    }
}
