﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloSP
{
    public partial class GeneralView : Form
    {
        

        public GeneralView()
        {
            InitializeComponent();
        }

        private void Permissionview()
        {
            var list = Permissoes.AcountPermission.LoginPermission();

            if (Permissoes.AcountPermission.LoginView(list, "Visualizar todos os utilizadores"))
            {
                listUtilizadores.Visible = true;
            }
            if (Permissoes.AcountPermission.LoginView(list, "CRUD Maquinas"))
            {
                ListImpressoras.Visible = true;
            }
            if (Permissoes.AcountPermission.LoginView(list, "CRUD AddOns"))
            {
                ListAddOns.Visible = true;
            }
            if (Permissoes.AcountPermission.LoginView(list, "Visualizar e editar Permissões"))
            {
                ListPermicoes.Visible = true;
            }
            if (Permissoes.AcountPermission.LoginView(list, "Visualizar produtos para compra"))
            {
                InterfaceClient.Visible = true;
                //InterfaceClient.Size = 206, 22;
            }
            if (Permissoes.AcountPermission.LoginView(list, "Visualizar Atividade dos Utilizadores"))
            {
                Activity.Visible = true;
            }

        }

        private void mudaform(Form _form)
        {
            _form.WindowState = FormWindowState.Maximized;
            _form.MdiParent = this;
            _form.Size = this.Size;
            _form.Show();
        }





        private void AdminView_Load(object sender, EventArgs e)
        {
            lblEmail.Text = Models.CurrentUser.email;
            lblUsername.Text = Models.CurrentUser.username;
            Permissionview();







        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Têm a certeza que pretende sair?", "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (userpanel.Visible == false)
            {
                userpanel.Visible = true;
            }
            else
            {
                userpanel.Visible = false;
            }
        }


        private void btMenu_Click(object sender, EventArgs e)
        {
            if(Menu.Visible == false)
            {
                Menu.Visible = true;
            }
            else
            {
                Menu.Visible = false;   
            }

        }

        private void listUtilizadores_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(UserList))
                {
                    frm.Activate();
                    return;
                }
            }

            var userList = new UserList();
            mudaform(userList);
        }

        private void ListImpressoras_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Maquinas.MachineList))
                {
                    frm.Activate();
                    return;
                }
            }
            
            Maquinas.MachineList load = new Maquinas.MachineList();
            mudaform(load);
        }

        private void ListAddOns_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(AddOn.AddOnList))
                {
                    frm.Activate();
                    return;
                }
            }

            AddOn.AddOnList load = new AddOn.AddOnList();
            mudaform(load);
        }

        private void ListMarca_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Marca.MarcaList))
                {
                    frm.Activate();
                    return;
                }
            }

            Marca.MarcaList load = new Marca.MarcaList();
            mudaform(load);
        }

        private void ListMarcaModelo_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Marc_Mod.MarcaModeloList))
                {
                    frm.Activate();
                    return;
                }
            }

            Marc_Mod.MarcaModeloList load = new Marc_Mod.MarcaModeloList();
            mudaform(load);
        }

        private void Menu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text == "")
            {
                e.Item.Visible = false;
            }
        }

        private void ListPermicoes_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Permissoes.GPermissionsList))
                {
                    frm.Activate();
                    return;
                }
            }

            Permissoes.GPermissionsList load = new Permissoes.GPermissionsList();
            mudaform(load);
        }

        private void InterfaceClient_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(ViewClient.Produtos))
                {
                    frm.Activate();
                    return;
                }
            }

            ViewClient.Produtos load = new ViewClient.Produtos();
            mudaform(load);
        }













    }
}
