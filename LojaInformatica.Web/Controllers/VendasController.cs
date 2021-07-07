using LojaInformatica.Web.Dados;
using LojaInformatica.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaInformatica.Web.Controllers
{
    public class VendasController : Controller
    {
        // Instanciando tanto a classe Vendas de Dados quanto a modelVendas da pasta Models
        modelVendas cad = new modelVendas();
        Vendas acVenda = new Vendas();

        public void carregaCliente()
        {
            List<SelectListItem> cliente = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cliente.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.cliente = new SelectList(cliente, "Value", "Text");
        }

        public void carregaFuncionario()
        {
            List<SelectListItem> funcionario = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_funcionario", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    funcionario.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.funcionario = new SelectList(funcionario, "Value", "Text");
        }

        public void carregaProduto()
        {
            List<SelectListItem> produto = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_produto", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    produto.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.produto = new SelectList(produto, "Value", "Text");
        }

        public void carregaPagamento()
        {
            List<SelectListItem> pagamento = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_pagamento", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pagamento.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.pagamento = new SelectList(pagamento, "Value", "Text");
        }

        // Cadastro de venda
        public ActionResult cadVenda()
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
                    carregaCliente();
                    carregaFuncionario();
                    carregaProduto();
                    carregaPagamento();
                    return View();
                }
            }
        }

        // Ações ao clicar no botão de cadastro de venda
        [HttpPost]
        public ActionResult cadVenda(modelVendas vend)
        {
            carregaCliente();
            carregaFuncionario();
            carregaProduto();
            carregaPagamento();
            vend.cd_cliente = Request["cliente"];
            vend.cd_funcionario = Request["funcionario"];
            vend.cd_produto = Request["produto"];
            vend.cd_pagamento = Request["pagamento"];
            acVenda.inserirVenda(vend);

            ViewBag.confCadastro = "Venda realizada com sucesso";
            return View();
        }

        public ActionResult listarVenda()
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
                    Vendas dbhandle = new Vendas();
                    ModelState.Clear();
                    return View(dbhandle.listarVenda());
                }
            }
        }

        public ActionResult excluirVenda(int id)
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
                        Vendas sdb = new Vendas();
                        if (sdb.excluirVenda(id))
                        {
                            ViewBag.AlertMsg = "Venda excluída com sucesso";
                        }
                        return RedirectToAction("listarVenda");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }

        }
    }
}