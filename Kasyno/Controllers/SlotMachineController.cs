using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasyno.Classes;


namespace Kasyno.Controllers
{

public class SlotMachineController : Controller
    {
        static SlotMachine SlotMachine = new SlotMachine();

        public IActionResult Index()
        {
            SlotMachine.Losuj();
            return View("SlotMachine", SlotMachine);
        }

    }
}
