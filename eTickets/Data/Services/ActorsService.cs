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
       
        
        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException(); 
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
