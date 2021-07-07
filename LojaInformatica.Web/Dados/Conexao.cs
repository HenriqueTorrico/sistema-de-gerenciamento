using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd = Clashroyale12");
        public static string msg;

        public MySqlConnection MyConectarBD() // Método: MyConectarBD()
        {
            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection MyDesconectarBD()  // Método: MyDesconectarBD()
        {
            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}