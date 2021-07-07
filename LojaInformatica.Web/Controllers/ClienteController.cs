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
    public class ClienteController : Controller
    {

        // Instanciando tanto a classe Cliente de Dados quanto a modelCliente da pasta Models
        modelCliente cad = new modelCliente();
        Cliente acCliente = new Cliente();

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

        // Método de carregar as Cidades
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

        // Ação (Cadastrar Cliente)
        public ActionResult cadCliente()
        {
            // Condição do login
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
                    // carrega os metodos (genero e estado)
                    carregaGenero();
                    carregaEstado();                  
                    return View();
                }
            }
        }

        // Açoes ao clicar no botao cadastrar
        [HttpPost]
        public ActionResult cadCliente(modelCliente cli)
        {
            carregaGenero();
            carregaEstado();
            cli.cd_estado = Request["estado"];
            cli.cd_genero = Request["genero"];
            acCliente.inserirCliente(cli);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        // Ação de listar o cliente
        public ActionResult listarCliente()
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
                    Cliente dbhandle = new Cliente();
                    ModelState.Clear();
                    return View(dbhandle.listarCliente());
                }
            }
        }

        // Ação de excluir o cliente
        public ActionResult excluirCliente(int id)
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
                    try
                    {
                        Cliente sdb = new Cliente();
                        if (sdb.excluirCliente(id))
                        {
                            ViewBag.AlertMsg = "Cliente excluído com sucesso";
                        }
                        return RedirectToAction("listarCliente");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            
        }

        // Ação de editar o cliente
        public ActionResult editarCliente(string id)
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
                    Cliente sdb = new Cliente();
                    return View(sdb.listarAtualizar().Find(smodel => smodel.cd_cliente == id));
                }
            }            
        }

        // Ação ao clicar no botão de editar Cliente
        [HttpPost]
        public ActionResult editarCliente(int id, modelCliente smodel)
        {
            try
            {
                Cliente sdb = new Cliente();
                sdb.atualizarCliente(smodel);
                return RedirectToAction("listarCliente");
            }
            catch
            {
                return View();
            }
        }
    }
}