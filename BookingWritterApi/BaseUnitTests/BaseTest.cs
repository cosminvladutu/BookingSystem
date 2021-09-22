using Moq;

namespace BaseUnitTests
{
    public abstract class BaseTest<T>
    {
        protected MockRepository MockRepository;
        protected T SystemUnderTest { get; set; }

        protected BaseTest()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            Initialize();
        }

        protected void Initialize()
        {
            SetupData();
            CreateSystemUnderTest();
            SetupMocking();
        }

        protected virtual void SetupData()
        {
        }

        protected virtual void CreateSystemUnderTest()
        {
        }

        protected virtual void SetupMocking()
        {
        }
    }
}
