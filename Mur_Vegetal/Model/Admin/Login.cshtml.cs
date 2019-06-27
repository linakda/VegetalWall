using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Mur_Vegetal.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet(){
            if( Request.Cookies["communication"] != null ){
                Redirect("/Admin");
            }
            if( Request.Cookies["administration"] != null ){
                Redirect("/AdminWall");
            }
        }

        public void OnPost(){
            var login = Request.Form["login"];
            var password = Request.Form["password"];
            var submit = Request.Form["submit"];
            if (submit == "connexion"){
                Console.WriteLine("LOGIN");
                if (login == "communication"){
                    if (password == "AdminComm2019"){
                        var cookieOptions = new CookieOptions{
                            Expires = DateTime.Now.AddHours(2)
                        };
                        //Response.Cookies.Append("communication", "ok", cookieOptions)
                        Console.WriteLine("COMMM");
                    }
                }
                if (login == "administration"){
                    if (password == "AdminAdmin2019"){
                        var cookieOptions = new CookieOptions{
                            Expires = DateTime.Now.AddHours(2)
                        };
                        Response.Cookies.Append("administration", "ok", cookieOptions);
                        Console.WriteLine("ADMIN");
                    }
                }
            }
            OnGet();
        }

    }
}
