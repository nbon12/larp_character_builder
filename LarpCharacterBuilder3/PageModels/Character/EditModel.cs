using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Logic;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace LarpCharacterBuilder3.PageModels.Character
{
    public class EditModel : PageModel
    {
        private readonly LarpBuilderContext _larpBuilderContext;
        private readonly ICharacterRepository _characterRepository;

        public EditModel(LarpBuilderContext larpBuilderContext, ICharacterRepository characterRepository)
        {
            _larpBuilderContext = larpBuilderContext;
            _characterRepository = characterRepository;
        }

        [BindProperty] public Models.Character Character { get; set; }
        [BindProperty] public IList<Models.CharacterSkill> CharacterSkills { get; set; }
        [BindProperty] public IList<Models.Skill> Skills { get; set; }
        [BindProperty] public int CpRemaining { get; set; }
        
        [TempData] public string Message { get; set; }
        [TempData] public string MessageAlert { get; set; } // danger / primary / warning / info / see bootstrap for HTML alert types.
        
        public async Task<IActionResult> OnGetAsync(long id)
        {
            Character = await _larpBuilderContext.Character.FindAsync(id);
            CharacterSkills = _larpBuilderContext.CharacterSkills
                .Where(c => c.CharacterId == id)
                .Include(c => c.Skill)
                .ToList();
            Skills = _larpBuilderContext.Skill.ToList();
            CpRemaining = _characterRepository.GetCpRemaining(Character.Id);
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

        public async Task<IActionResult> OnPostLearn(int skillId, string skillName)
        {
            Console.WriteLine("Character ID: " + Character.Id + " attempting to learn Skill ID: " + skillId);
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

            try
            {
                await _larpBuilderContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("CharacterId " + Character.Id + " already knows the skillId" + skillId);
                Message = "Character already knows " + skillName;
                MessageAlert = "danger";
                return RedirectToPage();
            }

            Message = "Learned " + skillName;
            Console.WriteLine("INFO: SKILL LEARNED: " + Character.Id + " learned " + skillName);
            MessageAlert = "primary";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostForget(long skillId, string skillName)
        {
            var contact = await _larpBuilderContext.CharacterSkills.FindAsync(Character.Id, skillId);

            if (contact != null)
            {
                _larpBuilderContext.CharacterSkills.Remove(contact);
                await _larpBuilderContext.SaveChangesAsync();
            }
            Message = "Forgot " + skillName;
            Console.WriteLine("INFO: SKILL LEARNED: " + Character.Id + " learned " + skillName);
            MessageAlert = "secondary";
            return RedirectToPage();
        }
    }
}