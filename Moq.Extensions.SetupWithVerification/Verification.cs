using System;
using System.Linq.Expressions;

namespace Moq.Extensions.SetupWithVerification
{
    public class Verification<TMocked> : VerificationBase<TMocked> where TMocked : class
    {
        private readonly Expression<Action<TMocked>> _expression;
        private readonly Func<Times> _times;

        public Verification(Expression<Action<TMocked>> expression, Func<Times> times, Mock<TMocked> mock = null) : base(mock)
        {
            _expression = expression;
            _times = times;
        }

        public override void Verify() => Mock.Verify(_expression, _times);
    }

    public class Verification<TMocked, TReturn> : VerificationBase<TMocked> where TMocked : class
    {
        private readonly Expression<Func<TMocked, TReturn>> _expression;
        private readonly Func<Times> _times;

        public Verification(Expression<Func<TMocked, TReturn>> expression, Func<Times> times, Mock<TMocked> mock = null) : base(mock)
        {
            _expression = expression;
            _times = times;
        }

        public override void Verify() => Mock.Verify(_expression, _times);
    }
}