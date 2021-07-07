using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Fabricante
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de Inserir Fabricante
        public void inserirFornecedor(modelFabricante cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_fabricante (nm_fabricante, tel_fabricante, cnpj_fabricante, eml_fabricante, cd_estado, cep_fabricante) values(@nmFabricante, @telFabricante, @cnpjFabricante, @emlFabricante, @cdEstado, @cepFabricante)", con.MyConectarBD());

            cmd.Parameters.Add("@nmFabricante", MySqlDbType.VarChar).Value = cm.nm_fabricante;
            cmd.Parameters.Add("@telFabricante", MySqlDbType.VarChar).Value = cm.tel_fabricante;
            cmd.Parameters.Add("@cnpjFabricante", MySqlDbType.VarChar).Value = cm.cnpj_fabricante;
            cmd.Parameters.Add("@emlFabricante", MySqlDbType.VarChar).Value = cm.eml_fabricante;
            cmd.Parameters.Add("@cdEstado", MySqlDbType.VarChar).Value = cm.cd_estado;
            cmd.Parameters.Add("@cepFabricante", MySqlDbType.VarChar).Value = cm.cep_fabricante;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

        }

        public List<modelFabricante> listarAtualizar()
        {
            List<modelFabricante> FabricanteList = new List<modelFabricante>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_fabricante", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FabricanteList.Add(
                    new modelFabricante
                    {
                        cd_fabricante = Convert.ToString(dr["cd_fabricante"]),
                        nm_fabricante = Convert.ToString(dr["nm_fabricante"]),
                        tel_fabricante = Convert.ToString(dr["tel_fabricante"]),
                        cnpj_fabricante = Convert.ToString(dr["cnpj_fabricante"]),
                        eml_fabricante = Convert.ToString(dr["eml_fabricante"]),
                        cd_estado = Convert.ToString(dr["cd_estado"]),
                        cep_fabricante = Convert.ToString(dr["cep_fabricante"])
                    });
            }
            return FabricanteList;
        }

        public List<modelFabricante> listarFabricante()
        {
            List<modelFabricante> FabricanteList = new List<modelFabricante>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_fabricante.cd_fabricante, " +
                "tbl_fabricante.nm_fabricante, " +
                "tbl_fabricante.tel_fabricante, " +
                "tbl_fabricante.cnpj_fabricante, " +
                "tbl_fabricante.eml_fabricante, " +
                "tbl_estadoUf.uf_estado, " +
                "tbl_fabricante.cep_fabricante " +
                "from tbl_fabricante inner join tbl_estadoUf " +
                "on tbl_fabricante.cd_estado = tbl_estadoUf.cd_estado order by cd_fabricante; ", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FabricanteList.Add(
                    new modelFabricante
                    {
                        cd_fabricante = Convert.ToString(dr["cd_fabricante"]),
                        nm_fabricante = Convert.ToString(dr["nm_fabricante"]),
                        tel_fabricante = Convert.ToString(dr["tel_fabricante"]),
                        cnpj_fabricante = Convert.ToString(dr["cnpj_fabricante"]),
                        eml_fabricante = Convert.ToString(dr["eml_fabricante"]),
                        uf_estado = Convert.ToString(dr["uf_estado"]),
                        cep_fabricante = Convert.ToString(dr["cep_fabricante"])
                    });
            }
            return FabricanteList;
        }

        public bool excluirFabricante(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_fabricante where cd_fabricante = @cdFabricante", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFabricante", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarFabricante(modelFabricante smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_fabricante set nm_fabricante = @nmFabricante, tel_fabricante = @telFabricante, cnpj_fabricante = @cnpjFabricante, eml_fabricante = @emlfabricante, cd_estado = @cdEstado, cep_fabricante = @cepFabricante where cd_fabricante = @cdFabricante", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFabricante", smodel.cd_fabricante);
            cmd.Parameters.AddWithValue("@nmFabricante", smodel.nm_fabricante);
            cmd.Parameters.AddWithValue("@telFabricante", smodel.tel_fabricante);
            cmd.Parameters.AddWithValue("@cnpjFabricante", smodel.cnpj_fabricante);
            cmd.Parameters.AddWithValue("@emlfabricante", smodel.eml_fabricante);
            cmd.Parameters.AddWithValue("@cdEstado", smodel.cd_estado);
            cmd.Parameters.AddWithValue("@cepFabricante", smodel.cep_fabricante);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}