using UnitTestingInDotNet.Models;

namespace UnitTestingInDotNet.Data
{
    public class VehicleRepo : IRepository<Vehicle>
    {
        private UnitTestingInDotNetContext _context;
        public VehicleRepo(UnitTestingInDotNetContext context)
        {
            _context = context;
        }

        public Vehicle Get(int id)
        {
            return _context.Vehicle.Find(id);
        }

        public ICollection<Vehicle> GetAll()
        {
            return _context.Vehicle.ToList();
        }

        public Vehicle Create(Vehicle entity)
        {
            _context.Vehicle.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Vehicle Update(Vehicle entity)
        {
            _context.Vehicle.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Vehicle entity)
        {
            _context.Vehicle.Remove(entity);
            _context.SaveChanges();
        }


    }
}
