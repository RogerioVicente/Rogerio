using MVC_BD.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_BD.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (ClienteModel model = new ClienteModel())
            {
                List<Cliente> clientes = model.ListarClientes();
                return View(clientes);
            }

        }

        // GET: Cliente/Details/
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Cpf = collection["Cpf"];
                cliente.Nome = collection["Nome"];
                using (ClienteModel model = new ClienteModel())
                {
                    model.InserirCliente(cliente);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/
        public ActionResult Edit(int id)
        {
            using (ClienteModel model = new ClienteModel())
            {
                return View(model.SelecionarCliente(id));
            }
        }

        // POST: Cliente/Edit/
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                using (ClienteModel model = new ClienteModel())
                {
                    model.EditarCliente(cliente);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/
        public ActionResult Delete(int id)
        {
            try
            {
                using (ClienteModel model = new ClienteModel())
                {
                    model.DeletarCliente(id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
