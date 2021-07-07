using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Funcionario
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de Inserir Funcionario
        public void inserirFuncionario(modelFuncionario cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_funcionario (nm_funcionario, ida_funcionario, cpf_funcionario, cd_genero, cel_funcionario, eml_funcionario, cep_funcionario) values(@nmFuncionario, @idaFuncionario, @cpfFuncionario, @cdGenero, @celFuncionario, @emlFuncionario, @cepFuncionario)", con.MyConectarBD());

            cmd.Parameters.Add("@nmFuncionario", MySqlDbType.VarChar).Value = cm.nm_funcionario;
            cmd.Parameters.Add("@idaFuncionario", MySqlDbType.VarChar).Value = cm.ida_funcionario;
            cmd.Parameters.Add("@cpfFuncionario", MySqlDbType.VarChar).Value = cm.cpf_funcionario;
            cmd.Parameters.Add("@cdGenero", MySqlDbType.VarChar).Value = cm.cd_genero;
            cmd.Parameters.Add("@celFuncionario", MySqlDbType.VarChar).Value = cm.cel_funcionario;
            cmd.Parameters.Add("@emlFuncionario", MySqlDbType.VarChar).Value = cm.eml_funcionario;
            cmd.Parameters.Add("@cepFuncionario", MySqlDbType.VarChar).Value = cm.cep_funcionario;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

        }

        public List<modelFuncionario> listarAtualizar()
        {
            List<modelFuncionario> FuncionarioList = new List<modelFuncionario>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FuncionarioList.Add(
                    new modelFuncionario
                    {
                        cd_funcionario = Convert.ToString(dr["cd_funcionario"]),
                        nm_funcionario = Convert.ToString(dr["nm_funcionario"]),
                        ida_funcionario = Convert.ToString(dr["ida_funcionario"]),
                        cpf_funcionario = Convert.ToString(dr["cpf_funcionario"]),
                        cd_genero = Convert.ToString(dr["cd_genero"]),
                        cel_funcionario = Convert.ToString(dr["cel_funcionario"]),
                        eml_funcionario = Convert.ToString(dr["eml_funcionario"]),
                        cep_funcionario = Convert.ToString(dr["cep_funcionario"])
                    });
            }
            return FuncionarioList;
        }

        public List<modelFuncionario> listarFuncionario()
        {
            List<modelFuncionario> FuncionarioList = new List<modelFuncionario>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_funcionario.cd_funcionario, " +
                "tbl_funcionario.nm_funcionario, " +
                "tbl_funcionario.ida_funcionario, " +
                "tbl_funcionario.cpf_funcionario, " +
                "tbl_genero.nm_genero, " +
                "tbl_funcionario.cel_funcionario, " +
                "tbl_funcionario.eml_funcionario, " +
                "tbl_funcionario.cep_funcionario " +
                "from tbl_funcionario inner join tbl_genero " +
                "on tbl_funcionario.cd_genero = tbl_genero.cd_genero order by cd_funcionario; ", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FuncionarioList.Add(
                    new modelFuncionario
                    {
                        cd_funcionario = Convert.ToString(dr["cd_funcionario"]),
                        nm_funcionario = Convert.ToString(dr["nm_funcionario"]),
                        ida_funcionario = Convert.ToString(dr["ida_funcionario"]),
                        cpf_funcionario = Convert.ToString(dr["cpf_funcionario"]),
                        nm_genero = Convert.ToString(dr["nm_genero"]),
                        cel_funcionario = Convert.ToString(dr["cel_funcionario"]),
                        eml_funcionario = Convert.ToString(dr["eml_funcionario"]),
                        cep_funcionario = Convert.ToString(dr["cep_funcionario"])
                    });
            }
            return FuncionarioList;
        }

        public bool excluirFuncionario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_funcionario where cd_funcionario = @cdFuncionario", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFuncionario", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarFuncionario(modelFuncionario smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_funcionario set nm_funcionario = @nmFuncionario, ida_funcionario = @idaFuncionario, cpf_funcionario = @cpfFuncionario, cd_genero = @cdGenero, cel_funcionario = @celFuncionario, eml_funcionario = @emlFuncionario, cep_funcionario = @cepFuncionario where cd_funcionario = @cdFuncionario", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFuncionario", smodel.cd_funcionario);
            cmd.Parameters.AddWithValue("@nmFuncionario", smodel.nm_funcionario);
            cmd.Parameters.AddWithValue("@idaFuncionario", smodel.ida_funcionario);
            cmd.Parameters.AddWithValue("@cpfFuncionario", smodel.cpf_funcionario);
            cmd.Parameters.AddWithValue("@cdGenero", smodel.cd_genero);
            cmd.Parameters.AddWithValue("@celFuncionario", smodel.cel_funcionario);
            cmd.Parameters.AddWithValue("@emlFuncionario", smodel.eml_funcionario);
            cmd.Parameters.AddWithValue("@cepFuncionario", smodel.cep_funcionario);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}