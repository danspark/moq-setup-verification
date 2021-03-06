using System;
using System.Linq.Expressions;
using Moq.Language.Flow;

namespace Moq.Extensions.SetupWithVerification
{
    public static class MoqExtensions
    {
        public static Verification<TMocked> SetupWithVerification<TMocked>(this Mock<TMocked> mock, Expression<Action<TMocked>> expression,
            Func<Times> times, Action<ISetup<TMocked>> configureSetup = null) where TMocked : class
        {
            var setup = mock.Setup(expression);

            configureSetup?.Invoke(setup);

            setup.Verifiable();

            return new Verification<TMocked>(expression, times, mock);
        }

        public static Verification<TMocked, TResult> SetupWithVerification<TMocked, TResult>(this Mock<TMocked> mock,
            Expression<Func<TMocked, TResult>> expression, Func<Times> times, Action<ISetup<TMocked, TResult>> configureSetup = null) where TMocked : class
        {
            var setup = mock.Setup(expression);

            configureSetup?.Invoke(setup);

            setup.Verifiable();

            return new Verification<TMocked, TResult>(expression, times, mock);
        }
    }
}