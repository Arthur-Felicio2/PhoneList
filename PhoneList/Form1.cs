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
        string[,] lista;
        readonly int max = 100;
        int itens = 0;
        public Form1()
        {
            InitializeComponent();
            lista = new string[max, 2];
        }

        void Update()
        {
            dgvList.Rows.Clear();
            for (int i = 0;i<itens; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvList);
                for (int j = 0; j < 2; j++)
                {
                    row.Cells[j].Value = lista[i, j];
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
            lista[itens, 0] = txtName.Text;
            lista[itens, 1] = txtPhone.Text;
            itens++;

            Update();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente remover?", "Remover", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewCell cell = dgvList.SelectedCells[0];
                int indice = cell.RowIndex;
                if (dgvList.SelectedCells.Count > 0)
                {
                    for (int i = indice; i < itens - 1; i++)
                    {
                        lista[i, 0] = lista[i + 1, 0];
                        lista[i, 1] = lista[i + 1, 1];
                    }
                    itens--;
                    Update();
                }
            }
            else
            {
                return;
            }


        }
    }
}
