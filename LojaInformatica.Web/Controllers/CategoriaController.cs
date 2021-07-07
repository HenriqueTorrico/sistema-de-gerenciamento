using LojaInformatica.Web.Dados;
using LojaInformatica.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInformatica.Web.Controllers
{
    public class CategoriaController : Controller
    {
        // Instanciando tanto a classe Categoria de Dados quanto a modelCategoria da pasta Models
        modelCategoria cad = new modelCategoria();
        Categoria acCategoria = new Categoria();

        // Cadastro de categoria
        public ActionResult cadCategoria()
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
                    return View();
                }
            }
        }

        // Ações ao clicar no botão de cadastro de categoria
        [HttpPost]
        public ActionResult cadCategoria(modelCategoria cate)
        {
            acCategoria.inserirCategoria(cate);

            ViewBag.confCadastro = "Cadastro realizado com sucesso";
            return View();
        }

        public ActionResult listarCategoria()
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
                    Categoria dbhandle = new Categoria();
                    ModelState.Clear();
                    return View(dbhandle.listarCategoria());
                }
            }
        }

        public ActionResult excluirCategoria(int id)
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
                        Categoria sdb = new Categoria();
                        if (sdb.excluirCategoria(id))
                        {
                            ViewBag.AlertMsg = "Categoria excluída com sucesso";
                        }
                        return RedirectToAction("listarCategoria");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        public ActionResult editarCategoria(string id)
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
                    Categoria sdb = new Categoria();
                    return View(sdb.listarCategoria().Find(smodel => smodel.cd_categoria == id));
                }
            }
        }

        [HttpPost]
        public ActionResult editarCategoria(int id, modelCategoria smodel)
        {
            try
            {
                Categoria sdb = new Categoria();
                sdb.atualizarCategoria(smodel);
                return RedirectToAction("listarCategoria");
            }
            catch
            {
                return View();
            }
        }
    }
}