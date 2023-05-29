using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        //inject Dbcontext file,we use context file to send or get data from DB
        //each controller must have DbContext file
        private readonly AppDbContext _context; //first we have to declare AppDbContext

        //In order to use DbContext we have to create constructor and inject DbContext
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
       

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException(); 
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }


        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }

       
    }
}
