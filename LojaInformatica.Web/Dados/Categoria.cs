using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Categoria
    {
        Conexao con = new Conexao();

        public void inserirCategoria(modelCategoria cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_categoria (nm_categoria, desc_categoria) values(@nmCategoria, @descCategoria)", con.MyConectarBD());

            cmd.Parameters.Add("@nmCategoria", MySqlDbType.VarChar).Value = cm.nm_categoria;
            cmd.Parameters.Add("@descCategoria", MySqlDbType.VarChar).Value = cm.desc_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelCategoria> listarCategoria()
        {
            List<modelCategoria> CategoriaAt = new List<modelCategoria>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_categoria order by cd_categoria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CategoriaAt.Add(
                    new modelCategoria
                    {
                        cd_categoria = Convert.ToString(dr["cd_categoria"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        desc_categoria = Convert.ToString(dr["desc_categoria"])
                    });
            }
            return CategoriaAt;
        }

        public bool excluirCategoria(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_categoria where cd_categoria = @cdCategoria", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCategoria", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarCategoria(modelCategoria smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_categoria set nm_categoria = @nmCategoria, desc_categoria = @descCategoria where cd_categoria = @cdCategoria", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCategoria", smodel.cd_categoria);
            cmd.Parameters.AddWithValue("@nmCategoria", smodel.nm_categoria);
            cmd.Parameters.AddWithValue("@descCategoria", smodel.desc_categoria);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}