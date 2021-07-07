using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Fornecedor
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de Inserir Fornecedor
        public void inserirFornecedor(modelFornecedor cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_fornecedor (nm_fornecedor, tel_fornecedor, cnpj_fornecedor, cd_estado, cep_fornecedor) values(@nmFornecedor, @telFornecedor, @cnpjFornecedor, @cdEstado, @cepFornecedor)", con.MyConectarBD());

            cmd.Parameters.Add("@nmFornecedor", MySqlDbType.VarChar).Value = cm.nm_fornecedor;
            cmd.Parameters.Add("@telFornecedor", MySqlDbType.VarChar).Value = cm.tel_fornecedor;
            cmd.Parameters.Add("@cnpjFornecedor", MySqlDbType.VarChar).Value = cm.cnpj_fornecedor;
            cmd.Parameters.Add("@cdEstado", MySqlDbType.VarChar).Value = cm.cd_estado;
            cmd.Parameters.Add("@cepFornecedor", MySqlDbType.VarChar).Value = cm.cep_fornecedor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

        }

        public List<modelFornecedor> listarAtualizar()
        {
            List<modelFornecedor> FornecedorList = new List<modelFornecedor>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_fornecedor", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FornecedorList.Add(
                    new modelFornecedor
                    {
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        tel_fornecedor = Convert.ToString(dr["tel_fornecedor"]),
                        cnpj_fornecedor = Convert.ToString(dr["cnpj_fornecedor"]),
                        cd_estado = Convert.ToString(dr["cd_estado"]),
                        cep_fornecedor = Convert.ToString(dr["cep_fornecedor"])
                    });
            }
            return FornecedorList;
        }

        public List<modelFornecedor> listarFornecedor()
        {
            List<modelFornecedor> FornecedorList = new List<modelFornecedor>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_fornecedor.cd_fornecedor, " +
                "tbl_fornecedor.nm_fornecedor, " +
                "tbl_fornecedor.tel_fornecedor, " +
                "tbl_fornecedor.cnpj_fornecedor, " +
                "tbl_estadoUf.uf_estado, " +
                "tbl_fornecedor.cep_fornecedor " +
                "from tbl_fornecedor inner join tbl_estadoUf " +
                "on tbl_fornecedor.cd_estado = tbl_estadoUf.cd_estado order by cd_fornecedor; ", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FornecedorList.Add(
                    new modelFornecedor
                    {
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        tel_fornecedor = Convert.ToString(dr["tel_fornecedor"]),
                        cnpj_fornecedor = Convert.ToString(dr["cnpj_fornecedor"]),
                        uf_estado = Convert.ToString(dr["uf_estado"]),
                        cep_fornecedor = Convert.ToString(dr["cep_fornecedor"])
                    });
            }
            return FornecedorList;
        }

        public bool excluirFornecedor(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_fornecedor where cd_fornecedor = @cdFornecedor", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFornecedor", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarFornecedor(modelFornecedor smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_fornecedor set nm_fornecedor = @nmFornecedor, tel_fornecedor = @telFornecedor, cnpj_fornecedor = @cnpjFornecedor, cd_estado = @cdEstado, cep_fornecedor = @cepFornecedor where cd_fornecedor = @cdFornecedor", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFornecedor", smodel.cd_fornecedor);
            cmd.Parameters.AddWithValue("@nmFornecedor", smodel.nm_fornecedor);
            cmd.Parameters.AddWithValue("@telFornecedor", smodel.tel_fornecedor);
            cmd.Parameters.AddWithValue("@cnpjFornecedor", smodel.cnpj_fornecedor);
            cmd.Parameters.AddWithValue("@cdEstado", smodel.cd_estado);
            cmd.Parameters.AddWithValue("@cepFornecedor", smodel.cep_fornecedor);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}