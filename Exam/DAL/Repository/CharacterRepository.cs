using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class CharacterRepository
{
    private readonly ApplicationContext _context;

    public CharacterRepository(ApplicationContext context) =>
        _context = context;

    public async Task<IEnumerable<Character?>> GetAllCharacters() =>
        await _context.Characters.ToListAsync();

    public async Task<Character?> GetCharacterAsync(int id) =>
        await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Character?> GetCharacterAsync(string name) =>
        await _context.Characters.FirstOrDefaultAsync(c => c.Name == name);

    public async Task AddCharacterAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveCharacterAsync(Character character)
    {
        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCharacterAsync(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }
}