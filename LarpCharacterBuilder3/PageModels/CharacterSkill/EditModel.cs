using System;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.CharacterSkill
{
    public class EditModel : PageModel
    {
        private readonly LarpBuilderContext _larpBuilderContext;

        public EditModel(LarpBuilderContext larpBuilderContext)
        {
            _larpBuilderContext = larpBuilderContext;
        }
        
        [BindProperty] public Models.CharacterSkill  CharacterSkill { get; set; }
        
        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _larpBuilderContext.Attach(CharacterSkill).State = EntityState.Modified;
            try
            {
                await _larpBuilderContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("A DBUpdateConcurrencyException was thrown.");
                throw new Exception("The Character with CharacterId: +" + CharacterSkill.CharacterId + " does not have a skill with Skill ID: " + CharacterSkill.SkillId);
            }

            return RedirectToPage("./Index");
        }
    }
}