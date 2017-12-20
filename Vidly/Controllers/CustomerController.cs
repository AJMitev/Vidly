using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using DbContext = Vidly.Database.DbContext;

namespace Vidly.Controllers
{   
    public class CustomerController : Controller
    {
        private readonly DbContext _context;

        public CustomerController()
        {
            _context = new DbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Custumer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
            {
                using (_context)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                }
            }
            else
            {
                using (var db = _context)
                {
                    var customerInDb = db.Customers.SingleOrDefault(c => c.Id == customer.Id);

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;

                    db.SaveChanges();

                }
            }

            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Details(int id)
        {
            var currentCustumer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (currentCustumer == null)
            {
                return HttpNotFound();
            }

            return View(currentCustumer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}