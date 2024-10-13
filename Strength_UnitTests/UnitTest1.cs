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

        [Fact]
        public void GetAllBouts()
        {
            var allBouts = _entityContext.ExerciseBout.Select(x => x).ToArray();

            }
        }
    }
}