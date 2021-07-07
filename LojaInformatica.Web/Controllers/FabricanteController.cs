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
    public class FabricanteController : Controller
    {
        // Instanciando tanto a classe Fornecedor de Dados quanto a modelFornecedor da pasta Models
        modelFabricante cad = new modelFabricante();
        Fabricante acFornecedor = new Fabricante();

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
        public ActionResult cadFabricante()
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
        public ActionResult cadFabricante(modelFabricante fabri)
        {
            carregaEstado();
            fabri.cd_estado = Request["estado"];
            acFornecedor.inserirFornecedor(fabri);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        public ActionResult listarFabricante()
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
                    Fabricante dbhandle = new Fabricante();
                    ModelState.Clear();
                    return View(dbhandle.listarFabricante());
                }
            }
        }

        public ActionResult excluirfabricante(int id)
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
                        Fabricante sdb = new Fabricante();
                        if (sdb.excluirFabricante(id))
                        {
                            ViewBag.AlertMsg = "Fabricante excluído com sucesso";
                        }
                        return RedirectToAction("listarFabricante");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }

        }

        public ActionResult editarFabricante(string id)
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
                    Fabricante sdb = new Fabricante();
                    return View(sdb.listarAtualizar().Find(smodel => smodel.cd_fabricante == id));
                }
            }
        }

        [HttpPost]
        public ActionResult editarFabricante(int id, modelFabricante smodel)
        {
            try
            {
                Fabricante sdb = new Fabricante();
                sdb.atualizarFabricante(smodel);
                return RedirectToAction("listarFabricante");
            }
            catch
            {
                return View();
            }
        }
    }
}