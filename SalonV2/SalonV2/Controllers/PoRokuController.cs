using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonV2.Data;
using SalonV2.Models;

namespace SalonV2.Controllers
{
    [Authorize]
    public class PoRokuController : Controller
    {  
        private readonly SalonV2Context _context;
        public PoRokuController(SalonV2Context context)
        {
            _context = context;
        }
        
        // GET: Kliencis
        public async Task<IActionResult> Index()
        {
            var salonV2Context = _context.Uslugi.Include(u => u.Klienci);
            return View(await salonV2Context.ToListAsync());
        }
    }
}
