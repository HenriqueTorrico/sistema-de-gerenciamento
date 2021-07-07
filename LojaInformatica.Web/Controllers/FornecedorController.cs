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
    public class FornecedorController : Controller
    {
        // Instanciando tanto a classe Fornecedor de Dados quanto a modelFornecedor da pasta Models
        modelFornecedor cad = new modelFornecedor();
        Fornecedor acFornecedor = new Fornecedor();

        // Método de carregar os Estados
        public void carregaEstado()
        {
            List<SelectListItem> estado = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_estadoUf", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    estado.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.estado = new SelectList(estado, "Value", "Text");
        }

        //
        public ActionResult cadFornecedor()
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
                    carregaEstado();
                    return View();
                }
            }
        }

        //
        [HttpPost]
        public ActionResult cadFornecedor(modelFornecedor forn)
        {
            carregaEstado();
            forn.cd_estado = Request["estado"];
            acFornecedor.inserirFornecedor(forn);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        public ActionResult listarFornecedor()
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
                    Fornecedor dbhandle = new Fornecedor();
                    ModelState.Clear();
                    return View(dbhandle.listarFornecedor());
                }
            }
        }

        public ActionResult excluirFornecedor(int id)
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
                        Fornecedor sdb = new Fornecedor();
                        if (sdb.excluirFornecedor(id))
                        {
                            ViewBag.AlertMsg = "Fornecedor excluído com sucesso";
                        }
                        return RedirectToAction("listarFornecedor");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }

        }

        public ActionResult editarFornecedor(string id)
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
                    Fornecedor sdb = new Fornecedor();
                    return View(sdb.listarAtualizar().Find(smodel => smodel.cd_fornecedor == id));
                }
            }
        }

        [HttpPost]
        public ActionResult editarFornecedor(int id, modelFornecedor smodel)
        {
            try
            {
                Fornecedor sdb = new Fornecedor();
                sdb.atualizarFornecedor(smodel);
                return RedirectToAction("listarFornecedor");
            }
            catch
            {
                return View();
            }
        }
    }
}