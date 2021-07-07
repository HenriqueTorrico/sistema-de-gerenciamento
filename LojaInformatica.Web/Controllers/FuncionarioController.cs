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
    public class FuncionarioController : Controller
    {
        // Instanciando tanto a classe Funcionario de Dados quanto a modelFuncionario da pasta Models
        modelFuncionario cad = new modelFuncionario();
        Funcionario acFuncionario = new Funcionario();

        // Método de carregar os Generos
        public void carregaGenero()
        {
            List<SelectListItem> genero = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaInformatica; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_genero", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    genero.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.genero = new SelectList(genero, "Value", "Text");
        }

        //
        public ActionResult cadFuncionario()
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
                    carregaGenero();
                    return View();
                }
            }
        }

        //
        [HttpPost]
        public ActionResult cadFuncionario(modelFuncionario func)
        {
            carregaGenero();
            func.cd_genero = Request["genero"];
            acFuncionario.inserirFuncionario(func);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        public ActionResult listarFuncionario()
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
                    Funcionario dbhandle = new Funcionario();
                    ModelState.Clear();
                    return View(dbhandle.listarFuncionario());
                }
            }
        }

        public ActionResult excluirFuncionario(int id)
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
                        Funcionario sdb = new Funcionario();
                        if (sdb.excluirFuncionario(id))
                        {
                            ViewBag.AlertMsg = "Funcionario excluído com sucesso";
                        }
                        return RedirectToAction("listarFuncionario");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }

        }

        public ActionResult editarFuncionario(string id)
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
                    Funcionario sdb = new Funcionario();
                    return View(sdb.listarAtualizar().Find(smodel => smodel.cd_funcionario == id));
                }
            }
        }

        [HttpPost]
        public ActionResult editarFuncionario(int id, modelFuncionario smodel)
        {
            try
            {
                Funcionario sdb = new Funcionario();
                sdb.atualizarFuncionario(smodel);
                return RedirectToAction("listarFuncionario");
            }
            catch
            {
                return View();
            }
        }
    }
}