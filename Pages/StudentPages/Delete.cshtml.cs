using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnnotationsDemo.Data;
using AnnotationsDemo.Models;

namespace AnnotationsDemo.Pages_StudentPages
{
    public class DeleteModel : PageModel
    {
        private readonly AnnotationsDemo.Data.ApplicationDbContext _context;

        public DeleteModel(AnnotationsDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, string? school)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.FirstOrDefaultAsync(m => m.StudentNumber == id && m.School == school);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string? school)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var student =  await _context.Students.FirstOrDefaultAsync(m => m.StudentNumber == id && m.School == school);

            if (student != null)
            {
                Student = student;
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
