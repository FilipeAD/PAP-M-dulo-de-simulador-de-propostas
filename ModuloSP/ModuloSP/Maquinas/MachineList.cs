﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloSP.Maquinas
{
    public partial class MachineList : Form
    {
        public MachineList()
        {
            InitializeComponent();
        }

      
        private void MachineList_Load(object sender, EventArgs e)
        {
            FunctionsMaq.LoadInfo(dataGridView1);
            Models.FunctionsGeneral.EditDataGrid(dataGridView1);


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

                //dataGridView1.Rows[i].Collumns["Cor"].CellStyle.BackColor = ColorTranslator.FromHtml(dataGridView1.Rows[i].Cells["Cor"].Value.ToString());

            }


        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Models.IDManagment.IdMaquina = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

    
        private void adicionarbt_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Maquinas.MachineAdd))
                {
                    frm.Activate();
                    return;
                }
            }

            var userList = new Maquinas.MachineAdd();

            Models.Utils._form.mudaform(userList);
            FunctionsMaq.LoadInfo(dataGridView1);
            Models.FunctionsGeneral.EditDataGrid(dataGridView1);
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Models.IDManagment.IdMaquina == "")
            {
                MessageBox.Show("Selecione um registo primeiro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(Maquinas.MachineEdit))
                    {
                        frm.Activate();
                        return;
                    }
                }

                var userList = new Maquinas.MachineEdit();

                Models.Utils._form.mudaform(userList);
                FunctionsMaq.LoadInfo(dataGridView1);
                Models.FunctionsGeneral.EditDataGrid(dataGridView1);
            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Models.IDManagment.IdMaquina))
            {
                MessageBox.Show("Selecione um registo primeiro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Prosseguir e eliminar registo " + Models.IDManagment.IdMaquina + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                        return;
                }
                else
                {
                    Models.FunctionsGeneral.DeleteRow("Maquinas", Models.IDManagment.IdMaquina);
                }
                FunctionsMaq.LoadInfo(dataGridView1);
                Models.FunctionsGeneral.EditDataGrid(dataGridView1);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Maquinas.MachineEdit))
                {
                    frm.Activate();
                    return;
                }
            }

            var userList = new Maquinas.MachineEdit();

            Models.Utils._form.mudaform(userList);
            FunctionsMaq.LoadInfo(dataGridView1);
            Models.FunctionsGeneral.EditDataGrid(dataGridView1);

        }

        private void MachineList_Activated(object sender, EventArgs e)
        {
            FunctionsMaq.LoadInfo(dataGridView1);
            Models.FunctionsGeneral.EditDataGrid(dataGridView1);
        }

        
    }
}
