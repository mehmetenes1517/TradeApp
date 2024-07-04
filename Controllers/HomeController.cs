using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TradeApp.Data.Abstract;
using TradeApp.Data.Main;
using TradeApp.Models;

namespace TradeApp.Controllers;

public class HomeController : Controller
{
    public IUserContext _context{set;get;}
    public HomeController(IUserContext context){
        _context=context;
    }

    public IActionResult Index()
    {
        if(User.Identity.Name==null){
            ViewBag.username="User";
        }else{
            var Name=User.Identity.Name;
            ViewBag.username=Name.ToString();
        }
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(User user){
        if (ModelState.IsValid)
        {
            var isuser_exists=_context.user_list.FirstOrDefault(x=>x.username ==user.username && x.password == user.password);
            if (isuser_exists!=null)
            {
                var userclaims=new List<Claim>{
                    new Claim(ClaimTypes.Name,isuser_exists.name ?? ""),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString() ?? "")
                };
                var claimidentity=new ClaimsIdentity(userclaims,CookieAuthenticationDefaults.AuthenticationScheme);
                var properties=new AuthenticationProperties();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimidentity),properties);
              
                
                return RedirectToAction("Index");
            }else{
                
                return View();
            }
        }
                

        return View();
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(User user){
        _context.CreateUser(user);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        return RedirectToAction("Login");
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }
}
