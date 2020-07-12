using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LarpCharacterBuilder3.PageModels.CharacterSkill
{
    public class CreateModel : PageModel
    {
        private readonly LarpBuilderContext _context;

        public CreateModel(LarpBuilderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Models.Character CharacterSkill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Character.Add(CharacterSkill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}