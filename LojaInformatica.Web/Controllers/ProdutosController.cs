using LojaInformatica.Web.Dados;
using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Web.Controllers
{
    public class ProdutosController : Controller
    {
        // Instanciando tanto a classe Produtos de Dados quanto a modelProdutos da pasta Models
        modelProdutos cad = new modelProdutos();
        Produtos acProdutos = new Produtos();

        public void carregaFabricante()
        {
            List<SelectListItem> fabricante = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_fabricante", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fabricante.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.fabricante = new SelectList(fabricante, "Value", "Text");
        }

        public void carregaFornecedor()
        {
            List<SelectListItem> fornecedor = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_fornecedor", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fornecedor.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.fornecedor = new SelectList(fornecedor, "Value", "Text");
        }

        public void carregaCategoria()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_categoria", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    categoria.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.categoria = new SelectList(categoria, "Value", "Text");
        }

        // Cadastro de produto
        public ActionResult cadProduto()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    carregaFabricante();
                    carregaFornecedor();
                    carregaCategoria();
                    return View();
                }
            }
        }

        // Ações ao clicar no botão de cadastro de produto
        [HttpPost]
        public ActionResult cadProduto(modelProdutos prod)
        {
            carregaFabricante();
            carregaFornecedor();
            carregaCategoria();
            prod.cd_fornecedor = Request["fornecedor"];
            prod.cd_categoria = Request["categoria"];
            prod.cd_fabricante = Request["fabricante"];
            acProdutos.inserirProduto(prod);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        public ActionResult listarProduto()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoFuncionario"] == null && Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    Produtos dbhandle = new Produtos();
                    ModelState.Clear();
                    return View(dbhandle.listarProduto());
                }
            }
        }

        public ActionResult excluirProduto(int id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    try
                    {
                        Produtos sdb = new Produtos();
                        if (sdb.excluirProduto(id))
                        {
                            ViewBag.AlertMsg = "Produto excluído com sucesso";
                        }
                        return RedirectToAction("listarProduto");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }           
        }

        public ActionResult editarProduto(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    Produtos sdb = new Produtos();
                    return View(sdb.listarAtualizar().Find(smodel => smodel.cd_produto == id));
                }
            }
        }

        [HttpPost]
        public ActionResult editarProduto(int id, modelProdutos smodel)
        {
            try
            {
                Produtos sdb = new Produtos();
                sdb.atualizarProduto(smodel);
                return RedirectToAction("listarProduto");
            }
            catch
            {
                return View();
            }
        }
    }
}