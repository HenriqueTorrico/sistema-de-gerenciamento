using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Dados
{
    public class Produtos
    {
        // Instanciando a conexao com o banco de dados
        Conexao con = new Conexao();

        // Criando o método de inserir produtos
        public void inserirProduto(modelProdutos cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_produto (nm_produto, cd_fornecedor, cd_categoria, vl_produto, qt_produto, cd_fabricante, img_produto) values(@nmProduto, @cdFornecedor, @cdCategoria, @vlProduto, @qtProduto, @cdFabricante, @imgProduto)", con.MyConectarBD());

            cmd.Parameters.Add("@nmProduto", MySqlDbType.VarChar).Value = cm.nm_produto;
            cmd.Parameters.Add("@cdFornecedor", MySqlDbType.VarChar).Value = cm.cd_fornecedor;
            cmd.Parameters.Add("@cdCategoria", MySqlDbType.VarChar).Value = cm.cd_categoria;
            cmd.Parameters.Add("@vlProduto", MySqlDbType.VarChar).Value = cm.vl_produto;
            cmd.Parameters.Add("@qtProduto", MySqlDbType.VarChar).Value = cm.qt_produto;
            cmd.Parameters.Add("@cdFabricante", MySqlDbType.VarChar).Value = cm.cd_fabricante;
            cmd.Parameters.Add("@imgProduto", MySqlDbType.VarChar).Value = cm.img_produto;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelProdutos> listarAtualizar()
        {
            List<modelProdutos> ProdutosAt = new List<modelProdutos>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutosAt.Add(
                    new modelProdutos
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        cd_categoria = Convert.ToString(dr["cd_categoria"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        cd_fabricante = Convert.ToString(dr["cd_fabricante"]),
                        img_produto = Convert.ToString(dr["img_produto"])
                    });
            }
            return ProdutosAt;
        }

        public List<modelProdutos> listarProduto()
        {
            List<modelProdutos> ProdutosList = new List<modelProdutos>();

            MySqlCommand cmd = new MySqlCommand("select " +
                "tbl_produto.cd_produto, " +
                "tbl_produto.nm_produto, " +
                "tbl_fornecedor.nm_fornecedor, " +
                "tbl_categoria.nm_categoria, " +
                "tbl_produto.vl_produto, " +
                "tbl_produto.img_produto," +
                "tbl_produto.qt_produto, " +
                "tbl_fabricante.nm_fabricante " +
                "from tbl_produto inner join tbl_fornecedor " +
                "on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor " +
                "inner join tbl_categoria " +
                "on tbl_categoria.cd_categoria = tbl_produto.cd_categoria " +
                "inner join tbl_fabricante " +
                "on tbl_fabricante.cd_fabricante = tbl_produto.cd_fabricante order by cd_produto; ", con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutosList.Add(
                    new modelProdutos
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        nm_fabricante = Convert.ToString(dr["nm_fabricante"]),
                        img_produto = Convert.ToString(dr["img_produto"])
                    });
            }
            return ProdutosList;
        }

        public bool excluirProduto(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_produto where cd_produto = @cdProduto", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdProduto", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarProduto(modelProdutos smodel)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_produto set nm_produto = @nmProduto, cd_fornecedor = @cdFornecedor, cd_categoria = @cdCategoria, vl_produto = @vlProduto, qt_produto = @qtProduto, cd_fabricante = @cdFabricante, img_produto = @imgProduto where cd_produto = @cdProduto", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdProduto", smodel.cd_produto);
            cmd.Parameters.AddWithValue("@nmProduto", smodel.nm_produto);
            cmd.Parameters.AddWithValue("@cdFornecedor", smodel.cd_fornecedor);
            cmd.Parameters.AddWithValue("@cdCategoria", smodel.cd_categoria);
            cmd.Parameters.AddWithValue("@vlProduto", smodel.vl_produto);
            cmd.Parameters.AddWithValue("@qtProduto", smodel.qt_produto);
            cmd.Parameters.AddWithValue("@cdFabricante", smodel.cd_fabricante);
            cmd.Parameters.AddWithValue("@imgProduto", smodel.img_produto);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}