using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Cliente
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de Inserir Clientes
        public void inserirCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_cliente (nm_cliente, sob_cliente, ida_cliente, cpf_cliente, cd_genero, cel_cliente, eml_cliente, cd_estado, cep_cliente) values(@nmCliente, @sobCliente, @idaCliente, @cpfCliente, @cdGenero, @celCliente, @emlCliente, @cdEstado, @cepCliente)", con.MyConectarBD());

            cmd.Parameters.Add("@nmCliente", MySqlDbType.VarChar).Value = cm.nm_cliente;
            cmd.Parameters.Add("@sobCliente", MySqlDbType.VarChar).Value = cm.sob_cliente;
            cmd.Parameters.Add("@idaCliente", MySqlDbType.VarChar).Value = cm.ida_cliente;
            cmd.Parameters.Add("@cpfCliente", MySqlDbType.VarChar).Value = cm.cpf_cliente;
            cmd.Parameters.Add("@cdGenero", MySqlDbType.VarChar).Value = cm.cd_genero;
            cmd.Parameters.Add("@celCliente", MySqlDbType.VarChar).Value = cm.cel_cliente;
            cmd.Parameters.Add("@emlCliente", MySqlDbType.VarChar).Value = cm.eml_cliente;
            cmd.Parameters.Add("@cdEstado", MySqlDbType.VarChar).Value = cm.cd_estado;
            cmd.Parameters.Add("@cepCliente", MySqlDbType.VarChar).Value = cm.cep_cliente;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelCliente> listarAtualizar()
        {
            List<modelCliente> ClientAt = new List<modelCliente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ClientAt.Add(
                    new modelCliente
                    {
                        cd_cliente = Convert.ToString(dr["cd_cliente"]),
                        nm_cliente = Convert.ToString(dr["nm_cliente"]),
                        sob_cliente = Convert.ToString(dr["sob_cliente"]),
                        ida_cliente = Convert.ToString(dr["ida_cliente"]),
                        cpf_cliente = Convert.ToString(dr["cpf_cliente"]),
                        cd_genero = Convert.ToString(dr["cd_genero"]),
                        cel_cliente = Convert.ToString(dr["cel_cliente"]),
                        eml_cliente = Convert.ToString(dr["eml_cliente"]),
                        cd_estado = Convert.ToString(dr["cd_estado"]),
                        cep_cliente = Convert.ToString(dr["cep_cliente"])
                    });
            }
            return ClientAt;
        }

        public List<modelCliente> listarCliente()
        {
            List<modelCliente> ClienteList = new List<modelCliente>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_cliente.cd_cliente, " +
                "tbl_cliente.nm_cliente, " +
                "tbl_cliente.sob_cliente, " +
                "tbl_cliente.ida_cliente, " +
                "tbl_cliente.cpf_cliente, " +
                "tbl_genero.nm_genero, " +
                "tbl_cliente.cel_cliente, " +
                "tbl_cliente.eml_cliente, " +
                "tbl_estadoUf.uf_estado, " +
                "tbl_cliente.cep_cliente " +
                "from tbl_cliente inner join tbl_estadoUf on tbl_cliente.cd_estado = tbl_estadoUf.cd_estado inner join tbl_genero " +
                "on tbl_genero.cd_genero = tbl_cliente.cd_genero order by cd_cliente;", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ClienteList.Add(
                    new modelCliente
                    {
                        cd_cliente = Convert.ToString(dr["cd_cliente"]),
                        nm_cliente = Convert.ToString(dr["nm_cliente"]),
                        sob_cliente = Convert.ToString(dr["sob_cliente"]),
                        ida_cliente = Convert.ToString(dr["ida_cliente"]),
                        cpf_cliente = Convert.ToString(dr["cpf_cliente"]),
                        nm_genero = Convert.ToString(dr["nm_genero"]),
                        cel_cliente = Convert.ToString(dr["cel_cliente"]),
                        eml_cliente = Convert.ToString(dr["eml_cliente"]),
                        uf_estado = Convert.ToString(dr["uf_estado"]),
                        cep_cliente = Convert.ToString(dr["cep_cliente"])
                    });
            }
            return ClienteList;
        }

        public bool excluirCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_cliente where cd_cliente = @cdCliente", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCliente", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarCliente(modelCliente smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_cliente set nm_cliente = @nmCliente, sob_cliente = @sobCliente, ida_cliente = @idaCliente, cpf_cliente = @cpfCliente, cd_genero = @cdGenero, cel_cliente = @celCliente, eml_cliente = @emlCliente, cd_estado = @cdEstado, cep_cliente = @cepCliente where cd_cliente = @cdCliente", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCliente", smodel.cd_cliente);
            cmd.Parameters.AddWithValue("@nmCliente", smodel.nm_cliente);
            cmd.Parameters.AddWithValue("@sobCliente", smodel.sob_cliente);
            cmd.Parameters.AddWithValue("@idaCliente", smodel.ida_cliente);
            cmd.Parameters.AddWithValue("@cpfCliente", smodel.cpf_cliente);
            cmd.Parameters.AddWithValue("@cdGenero", smodel.cd_genero);
            cmd.Parameters.AddWithValue("@celCliente", smodel.cel_cliente);
            cmd.Parameters.AddWithValue("@emlCliente", smodel.eml_cliente);
            cmd.Parameters.AddWithValue("@cdEstado", smodel.cd_estado);
            cmd.Parameters.AddWithValue("@cepCliente", smodel.cep_cliente);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}