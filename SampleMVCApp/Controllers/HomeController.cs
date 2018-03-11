using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using SampleMVCApp.Infrastructure;
using SampleMVCApp.Models;

namespace SampleMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private IGateWayIntegrator Integrator { get; set; }

        private IntegrateConfig config;

        private RemitaHashGenerator _hasher;

        public HomeController()
        {
            config = new SampleConfig("2547916", "4430731", "1946");
            _hasher = new RemitaHashGenerator(config);
            //Better way would be to use DI to inject everything rather than newing up thing in the controller
            Integrator = new RemitaGateWayIntegrator(_hasher);
        }
        public ActionResult Index()
        {
            //TODO:
            /**
             * Handle the display of the status of transaction status.
             * test the creation of demo payments to test.
             */
            return View();
        }


        public ActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePayment(Payment model)
        {
            var post = new SampleRemitaPost
            {
                Amount = model.PaymentAmount.ToString(CultureInfo.InvariantCulture),
                PayerEmail = model.PayerEmail,
                PayerName = model.PayerName,
                PayerPhone = model.PayerPhoneNumber,
                PayerId = Guid.NewGuid().ToString(),
                OrderId = DateTimeOffset.UtcNow.UtcTicks.ToString(),
                MerchantId = config.MerchantId,
                ServiceTypeId = config.ServiceTypeId,
                RemitaPaymentType = model.PaymentType.ToString(),
                ResponseUrl = "http://localhost:3819/Home/Index"
            };

            post.Hash = _hasher.HashRemitaRequest(post);

            return View("ProcessPayment",post);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}