using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using University_Lander.Models;
using University_Lander.Services;

namespace University_Lander.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseService2 _dbService;

    public HomeController(ILogger<HomeController> logger, DatabaseService2 dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    public IActionResult Index()
    {
        return View(_dbService.GetAsync().Result);
    }

    public IActionResult Privacy()
    {
        // ContactUsModel obje = new ContactUsModel();
        // obje.Email = new List<string>{"12"};
        // obje.PhoneNumber = new List<string>{"12345432", "242354"};
        // _dbService.CreateAsync(obje).Wait();
        return View();
    }

    public IActionResult Upload(UploadForm form){

        FileModel a = new FileModel();
        a.FileData = form.caption;
        
        using ( var file = form.image1.OpenReadStream()){
            using (BinaryReader reader = new BinaryReader(file))
    {      
            _logger.LogWarning("test", reader.ReadString()); 
    }
        }

        return Redirect("/");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
