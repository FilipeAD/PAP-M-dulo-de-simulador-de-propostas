﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSP.Models
{
    public class Utils
    {
        //link da conexao sql
        public static string conString = @"Data Source=serversofttests\sqlexpress;Initial Catalog=estagio_2022_12_ano_Filipe;User ID=estagio;Password=Pass.123";

        public static GeneralView _form { get; set; }


        public static string _GroupSearch = "";
            public static string GroupSearch
            {
                get { return _GroupSearch; }
                set { _GroupSearch = value; }
            }

        public static string _Marca_Modelo = "";
        public static string Marca_Modelo
        {
            get { return _Marca_Modelo; }
            set { _Marca_Modelo = value; }
        }

        public static string _IDMarca = "";
        public static string IDMarca
        {
            get { return _IDMarca; }
            set { _IDMarca = value; }
        }

        public static string _IDAddOn = "";
        public static string IDAddOn
        {
            get { return _IDAddOn; }
            set { _IDAddOn = value; }
        }
        public static string _Grupo = "";
        public static string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        public static string _Permissoes = "";
        public static string Permissoes
        {
            get { return _Permissoes; }
            set { _Permissoes = value; }
        }

        public static string _GrupoAddOn = "";
        public static string GrupoAddOn
        {
            get { return _GrupoAddOn; }
            set { _GrupoAddOn = value; }
        }

        public static string _GrupoAddOnNome = "";
        public static string GrupoAddOnNome
        {
            get { return _GrupoAddOnNome; }
            set { _GrupoAddOnNome = value; }
        }

    }


}
