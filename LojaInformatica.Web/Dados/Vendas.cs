using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Vendas
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de inserir uma venda
        public void inserirVenda(modelVendas cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_vendas (cd_cliente, cd_produto, qt_produto, vl_total, cd_pagamento, cd_funcionario) values(@cdCliente, @cdProduto, @qtProduto, @vlTotal, @cdPagamento, @cdFuncionario)", con.MyConectarBD());

            cmd.Parameters.Add("@cdCliente", MySqlDbType.VarChar).Value = cm.cd_cliente;
            cmd.Parameters.Add("@cdProduto", MySqlDbType.VarChar).Value = cm.cd_produto;
            cmd.Parameters.Add("@qtProduto", MySqlDbType.VarChar).Value = cm.qt_produto;
            cmd.Parameters.Add("@vlTotal", MySqlDbType.VarChar).Value = cm.vl_total;
            cmd.Parameters.Add("@cdPagamento", MySqlDbType.VarChar).Value = cm.cd_pagamento;
            cmd.Parameters.Add("@cdFuncionario", MySqlDbType.VarChar).Value = cm.cd_funcionario;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelVendas> listarVenda()
        {
            List<modelVendas> VendaList = new List<modelVendas>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_vendas.cd_venda, " +
                "tbl_cliente.nm_cliente, " +
                "tbl_cliente.cpf_cliente, " +
                "tbl_produto.nm_produto, " +
                "tbl_vendas.qt_produto, " +
                "tbl_vendas.vl_total, " +
                "tbl_pagamento.fr_pagamento, " +
                "tbl_funcionario.nm_funcionario " +
                "from tbl_vendas inner join tbl_cliente on tbl_vendas.cd_cliente = tbl_cliente.cd_cliente " +
                "inner join tbl_produto " +
                "on tbl_vendas.cd_produto = tbl_produto.cd_produto " +
                "inner join tbl_funcionario " +
                "on tbl_vendas.cd_funcionario = tbl_funcionario.cd_funcionario " +
                "inner join tbl_pagamento " +
                "on tbl_vendas.cd_pagamento = tbl_pagamento.cd_pagamento order by cd_venda;", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                VendaList.Add(
                    new modelVendas
                    {
                        cd_venda = Convert.ToString(dr["cd_venda"]),
                        nm_cliente = Convert.ToString(dr["nm_cliente"]),
                        cpf_cliente = Convert.ToString(dr["cpf_cliente"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_total = Convert.ToString(dr["vl_total"]),
                        fr_pagamento = Convert.ToString(dr["fr_pagamento"]),
                        nm_funcionario = Convert.ToString(dr["nm_funcionario"])
                    });
            }
            return VendaList;
        }

        public bool excluirVenda(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_vendas where cd_venda = @cdVenda", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdVenda", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}