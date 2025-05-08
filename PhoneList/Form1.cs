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
        string identificador = "";
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
            for (int i = 0; i < Length(lista); i++)
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

            if (identificador != "")
            {
                for (int i = 0; i < Length(lista); i++)
                {
                    if (lista[i][0] == identificador)
                    {
                        lista[i][1] = txtName.Text;
                        lista[i][2] = txtPhone.Text;
                        break;
                    }
                }
                identificador = ""; 
            }
            else
            {
                int novoId = Length(lista) + 1;
                lista[Length(lista)] = new string[] { novoId.ToString(), txtName.Text, txtPhone.Text };
            }

            txtName.Clear();
            txtPhone.Clear();
            Update();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvList.SelectedCells[0];
            int linha = cell.RowIndex;
            string idRemover = dgvList.Rows[linha].Cells[0].Value.ToString(); 

            int indice = 0;
            for (indice = 0; indice < Length(lista) && lista[indice][0] != idRemover; indice++) ;

            DialogResult result = MessageBox.Show("Deseja realmente remover?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int i = indice; i < Length(lista) - 1; i++)
                {
                    lista[i] = lista[i + 1];
                }
                lista[Length(lista) - 1] = null;

                // Após excluir, você pode reatribuir os IDs sequencialmente se quiser
                for (int i = 0; i < Length(lista); i++)
                {
                    lista[i][0] = (i + 1).ToString(); // Atualiza os IDs
                }

                Update();
            }


        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvList.Rows.Count)
            {
                DataGridViewRow row = dgvList.Rows[e.RowIndex];
                identificador = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
            }

        }
    }
}