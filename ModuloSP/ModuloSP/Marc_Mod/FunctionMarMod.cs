﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloSP.Marc_Mod
{
    internal class FunctionMarMod
    {
        //Apresentar tabela Marca_Modelo 
        public static void LoadMarMod(DataGridView _DataGridName)
        {
            using (SqlConnection con =
                new SqlConnection(Models.Utils.conString))
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                string query = "select Marca_Modelo.ID, Marca.Nome, Modelo.Nome as Modelo " +
                                "from Marca_Modelo " +
                                "join Marca on Marca.ID = Marca_Modelo.fk_Marca_ID " +
                                "join Modelo on Modelo.ID = Marca_Modelo.fk_Modelo_ID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                bs.DataSource = dt;
                _DataGridName.DataSource = bs;
                con.Close();
                Models.IDManagment.IDMarca_Modelo = "";
            }
        }

        //Apresentar tabela Marca_Modelo segundo nome da Marca dado pela variavel 
        public static void MarcaSelect(DataGridView _DataGridName, string _order)
        {
            using (SqlConnection con =
               new SqlConnection(Models.Utils.conString))
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                string query = "select Marca_Modelo.ID, Marca.Nome, Modelo.Nome as Modelo " +
                                "from Marca_Modelo " +
                                "join Marca on Marca.ID = Marca_Modelo.fk_Marca_ID " +
                                "join Modelo on Modelo.ID = Marca_Modelo.fk_Modelo_ID " +
                                "where Marca.Nome = '" + _order + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                bs.DataSource = dt;
                _DataGridName.DataSource = bs;
                con.Close();
                Models.IDManagment.IdMaquina = "";
            }
        }

        //Apresentar tabela Marca_Modelo segundo nome da Marca e Modelo dado pelas variaveis 
        public static void MarcaMoDSelect(DataGridView _DataGridName, string _order, string order2)
        {
            using (SqlConnection con =
               new SqlConnection(Models.Utils.conString))
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                string query = "select Marca_Modelo.ID, Marca.Nome, Modelo.Nome as Modelo " +
                                "from Marca_Modelo " +
                                "join Marca on Marca.ID = Marca_Modelo.fk_Marca_ID " +
                                "join Modelo on Modelo.ID = Marca_Modelo.fk_Modelo_ID " +
                                "where Marca.Nome = '" + _order + "' AND  Modelo.Nome = '" + order2 + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                bs.DataSource = dt;
                _DataGridName.DataSource = bs;
                con.Close();
                Models.IDManagment.IdMaquina = "";
            }
        }

        //Inserir campo nome da tabela Modelo na ToolStripComboBox se esse modelo estiver associando a nome da Marca dada na variavel
        public static void CmbInsertMM(ToolStripComboBox _cmb, string _cmb2)
        {
            _cmb.Items.Clear();
            SqlConnection con = new SqlConnection(Models.Utils.conString);
            con.Open();
            string query = "SELECT Modelo.Nome as Modelo FROM Marca_Modelo " +
                            "INNER JOIN Modelo on Marca_Modelo.fk_Modelo_ID = Modelo.ID " +
                            "INNER JOIN Marca on Marca_Modelo.fk_Marca_ID = Marca.ID " +
                            "where Marca.Nome = '" + _cmb2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _cmb.Items.Add(dr["Modelo"].ToString());
            }
        }

        //Apresentar Tabela Maquinas quando o ID da Marca_Modelo for igual à variavel
        public static void INFOMaquinaMarca(DataGridView _Datagridview, string _ID)
        {
            using (SqlConnection con =
                new SqlConnection(Models.Utils.conString))
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                string query = "select maq.ID, maq.Dimensoes, maq.Cor, modl.Nome as [Modelo], mar.Nome as [Marca], Preco " +
                                "from Maquinas as maq " +
                                "join Marca_Modelo as marModl on marModl.ID = maq.fk_Marca_Modelo_ID " +
                                "join Marca as mar on mar.ID = marModl.fk_Marca_ID " +
                                "join Modelo as modl on modl.ID = marModl.fk_Modelo_ID " +
                               "where marModl.ID = '" + _ID + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                bs.DataSource = dt;
                _Datagridview.DataSource = bs;
                con.Close();
                Models.IDManagment.IdAddOn = "";
            }
            Models.IDManagment.IdMaquina = "";

            Models.FunctionsGeneral.EditDataGrid(_Datagridview);
        }



    }

}

