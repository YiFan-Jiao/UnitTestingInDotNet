using UnitTestingInDotNet.Models;

namespace UnitTestingInDotNet.Data
{
    public class ReservationRepo : IRepository<Reservation>
    {
        private readonly UnitTestingInDotNetContext _context;
        public ReservationRepo(UnitTestingInDotNetContext context)
        {
            _context = context;
        }

        public Reservation Create(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Reservation Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reservation Update(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
