using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.PageModels.Character
{
    public class EditModel : PageModel
    {
        private readonly LarpBuilderContext _larpBuilderContext;

        public EditModel(LarpBuilderContext larpBuilderContext)
        {
            _larpBuilderContext = larpBuilderContext;
        }

        [BindProperty] public Models.Character Character { get; set; }
        [BindProperty] public IList<Models.CharacterSkill> CharacterSkills { get; set; }
        [BindProperty] public IList<Models.Skill> Skills { get; set; }
        public async Task<IActionResult> OnGetAsync(long id)
        {
            Character = await _larpBuilderContext.Character.FindAsync(id);
            CharacterSkills = _larpBuilderContext.CharacterSkills
                .Where(c => c.CharacterId == id)
                .Include(c => c.Skill)
                .ToList();
            Skills = _larpBuilderContext.Skill.ToList();
            if (Character == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _larpBuilderContext.Attach(Character).State = EntityState.Modified;
            try
            {
                await _larpBuilderContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("A DBUpdateConcurrencyException was thrown.");
                throw new Exception("Character " + Character.Id + " not found!");
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostLearn(int skillId)
        {
            Console.WriteLine("TODO: add a skill on character with ID: " + Character.Id + "and skill ID: " + skillId);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var learnMe = new Models.CharacterSkill()
            {
                CharacterId = Character.Id,
                SkillId = skillId
            };
            _larpBuilderContext.CharacterSkills.Add(learnMe);
            await _larpBuilderContext.SaveChangesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostForget(long skillId)
        {
            var contact = await _larpBuilderContext.CharacterSkills.FindAsync(Character.Id, skillId);

            if (contact != null)
            {
                _larpBuilderContext.CharacterSkills.Remove(contact);
                await _larpBuilderContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}