using System.Web.Mvc;
using Website1.Models;


namespace Website1.Controllers
{
    public class HomeController : Controller
    {

        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(MultiViewModel MVMviewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(MVMviewModel);
            }
            else
            {
                return View("Results", MVMviewModel);
            }
        }
        public ActionResult Results(MultiViewModel MVMviewModel)
        {

            return View(MVMviewModel);
        }

        public ActionResult WebUrl()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult WebUrl(WebUrlModel WUMurlModel)
        {
            if (!ModelState.IsValid)
            {
                return View(WUMurlModel);
            }
            else
            {
                WebResultsUrlViewModel WRUVMmyViewModel = new WebResultsUrlViewModel();
                WebUrlBLL WUBwebBLL = new WebUrlBLL();
                ListUrlReturn LURreturnObject = WUBwebBLL.LURGetImageUrls(WUMurlModel.Url);
                if (!string.IsNullOrWhiteSpace(LURreturnObject.ErrorMessage))
                {
                    ModelState.AddModelError("", LURreturnObject.ErrorMessage);
                    return View(WUMurlModel);
                }
                else
                {
                    WRUVMmyViewModel.UrlList = LURreturnObject.ImgUrl;
                    return View("WebUrlResults", WRUVMmyViewModel);
                }
            }

        }
    }
}