using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Login
    {
        Conexao con = new Conexao();

        public void TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_login where nm_login = @nmLogin and sh_login = @shLogin", con.MyConectarBD());

            cmd.Parameters.Add("@nmLogin", MySqlDbType.VarChar).Value = user.nm_login;
            cmd.Parameters.Add("@shLogin", MySqlDbType.VarChar).Value = user.sh_login;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.nm_login = Convert.ToString(leitor["nm_login"]);
                    user.sh_login = Convert.ToString(leitor["sh_login"]);
                    user.tp_login = Convert.ToString(leitor["tp_login"]);
                }
            }

            else
            {
                user.nm_login = null;
                user.sh_login = null;
                user.tp_login = null;
            }

            con.MyDesconectarBD();
        }

    }
}