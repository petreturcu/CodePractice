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
                e.StackTrace.Should().NotContain(":line 92");
                e.StackTrace.Should().Contain(":line 99");
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
                e.StackTrace.Should().Contain(":line 110");
                e.StackTrace.Should().Contain(":line 116");
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
                // hundreds of lines here

                // this line is NOT shown in the stack trace
                throw new NullReferenceException();

                // hundreds of lines here
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
                // hundreds of lines here

                // with ExceptionDispatchInfo this line is now shown in the stack trace
                throw new NullReferenceException();

                // hundreds of lines here
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