namespace Tests
{
    using System;
    using System.Runtime.ExceptionServices;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class ExceptionCatching
    {
        [Test]
        public void SimpleThrow_DoesNotShowTheLineOfTheOriginalException()
        {
            // Arrange


            // Act
            try
            {
                SimpleThrowMethod();
            }
            catch (Exception e)
            {
                // Assert
                e.StackTrace.Should().NotContain(":line 90");
                e.StackTrace.Should().Contain(":line 95");
            }
        }

        [Test]
        public void ExceptionDispatch_ShowsTheLineOfTheOriginalException()
        {
            // Arrange


            // Act
            try
            {
                DispatchThrowMethod();
            }
            catch (Exception e)
            {
                // Assert
                e.StackTrace.Should().Contain(":line 104");
                e.StackTrace.Should().Contain(":line 108");
            }
        }

        public void DispatchThrowMethod()
        {
            try
            {
                FirstMethod();
                SecondMethodWithDispatch();
                ThirdMethod();
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
                throw;
            }
        }

        public void SimpleThrowMethod()
        {
            try
            {
                FirstMethod();
                SecondMethod();
                ThirdMethod();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FirstMethod()
        {
            // some code
        }

        private void SecondMethod()
        {
            try
            {
                // this line is NOT shown in the stack trace
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                // this line is shown in the stack trace
                throw;
            }
        }

        private void SecondMethodWithDispatch()
        {
            try
            {
                // with ExceptionDispatchInfo this line is now shown in the stack trace
                throw new NullReferenceException();
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
                throw;
            }
        }

        private void ThirdMethod()
        {
            // some other code
        }
    }
}