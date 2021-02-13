using System;
using System.Linq;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.Skill
{
    public class EditModelSkill : PageModel
    {
        private readonly LarpBuilderContext _larpBuilderContext;
        private readonly ISkillRepository _skillRepository;

        public EditModelSkill(LarpBuilderContext larpBuilderContext,
            ISkillRepository skillRepository)
        {
            _larpBuilderContext = larpBuilderContext;
            _skillRepository = skillRepository;
        }


        [BindProperty] public Models.Skill Skill { get; set; }

        [TempData] public string Message { get; set; }
        [TempData] public string MessageAlert { get; set; } // danger / primary / warning / info / see bootstrap for HTML alert types.
        
        public async Task<IActionResult> OnGetAsync(long id)
        {
            Skill = _skillRepository.Get(id).FirstOrDefault();
            if (Skill == null)
            {
                return RedirectToPage("./Skills");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _larpBuilderContext.Attach(Skill).State = EntityState.Modified;
            try
            {
                await _larpBuilderContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("A DBUpdateConcurrencyException was thrown.");
                throw new Exception("Skill " + id + " not found!");
            }

            Message = "Skill saved";
            MessageAlert = "success";
            return RedirectToPage();
        }
    }
}