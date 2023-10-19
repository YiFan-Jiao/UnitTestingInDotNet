using UnitTestingInDotNet.Models;

namespace UnitTestingInDotNet.Data
{
    public class PassRepo : IRepository<Pass>
    {
        private readonly UnitTestingInDotNetContext _context;
        public PassRepo(UnitTestingInDotNetContext context)
        {
            _context = context;
        }

        public Pass Create(Pass entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pass entity)
        {
            throw new NotImplementedException();
        }

        public Pass Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pass> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pass Update(Pass entity)
        {
            throw new NotImplementedException();
        }
    }
