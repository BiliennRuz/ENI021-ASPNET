using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP01.module05.LesChats.Models;

namespace TP01.module05.LesChats.Controllers
{
    public class ChatController : Controller

{
        private static List<ChatViewModel> listChats = ChatViewModel.GetMeuteDeChats();

        // GET: ChatController
        public ActionResult Index()
    {
            return View(listChats);
    }

    // GET: ChatController/Details/5
    public ActionResult Details(int id)
{
        var chat = listChats.FirstOrDefault(c => c.Id == id);
        return View(chat);
    }

    // GET: ChatController/Delete/5
    public ActionResult Delete(int id)
    {
        var chat = listChats.FirstOrDefault(c => c.Id == id);
        return View(chat);
    }

    // POST: ChatController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
                var chat = listChats.FirstOrDefault(c => c.Id == id);
                listChats.Remove(chat);
                return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
}
