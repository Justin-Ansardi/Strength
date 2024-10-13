using StrengthEFcore;

namespace Strength_UnitTests
{
    public class UnitTest1
    {
        private readonly EntityContext _entityContext;

        public UnitTest1(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }


         // instead of real context, we may need a stub because I/O is not pure
        [Fact]
        public void GetAllBouts()
        {
          
        }
    }
}