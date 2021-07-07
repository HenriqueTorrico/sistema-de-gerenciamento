using LojaInformatica.Web.Dados;
using LojaInformatica.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaInformatica.Web.Controllers
{
    public class LoginController : Controller
    {

        Login Lg = new Login();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(modelLogin verLogin)
        {
            Lg.TestarUsuario(verLogin);

            if (verLogin.nm_login != null && verLogin.sh_login != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.nm_login, false);
                Session["usuarioLogado"] = verLogin.nm_login.ToString();
                Session["senhaLogado"] = verLogin.sh_login.ToString();

                if (verLogin.tp_login == "Comum")
                {
                    Session["tipoComum"] = verLogin.tp_login.ToString(); // tipo 1
                    return RedirectToAction("Index", "Home");
                }
                else if(verLogin.tp_login == "Funcionario")
                {
                    Session["tipoFuncionario"] = verLogin.tp_login.ToString(); // tipo 2
                    return RedirectToAction("IndexPainel", "Home");
                }
                else
                {
                    Session["tipoGerente"] = verLogin.tp_login.ToString(); // tipo 3
                    return RedirectToAction("IndexPainel", "Home");
                }
            }

            else
            {
                Response.Write("<script>alert('Usuário não encontrado. Verifique o nome do usuário e a senha')</script>");
                return View();
            }
        }

        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Você não tem acesso a está operação')</script>");
            return View();
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoFuncionario"] = null;
            Session["tipoGerente"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}