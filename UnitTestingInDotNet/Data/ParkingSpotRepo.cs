using UnitTestingInDotNet.Models;

namespace UnitTestingInDotNet.Data
{
    public class ParkingSpotRepo : IRepository<ParkingSpot>
    {

        private readonly UnitTestingInDotNetContext _context;
        public ParkingSpotRepo(UnitTestingInDotNetContext context)
        {
            _context = context;
        }
        public void Create(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParkingSpot> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        ParkingSpot IRepository<ParkingSpot>.Create(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        ParkingSpot IRepository<ParkingSpot>.Update(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }
    }
}
