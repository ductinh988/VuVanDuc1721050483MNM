using BaiThucHanh1402.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanh1402.Controllers {
    public class GiaiPhuongTrinhController : Controller {
        giaiptbac1 gpt = new giaiptbac1();
        giaiptbac2 gpt2 = new giaiptbac2();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(double soA, double soB)
        {
            ViewBag.result = gpt.giaiphuongtrinh(soA,soB);
            return View();
        }

        public IActionResult Ptbac2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ptbac2(double soA, double soB,double soC)
        {
            ViewBag.result = gpt2.giaiphuongtrinh2(soA,soB,soC);
            return View();
        }
    }
}