using System;
using System.Linq.Expressions;

namespace Moq.Extensions.SetupWithVerification
{
    public class MoqSetupWithVerification<TMocked> : MoqSetupWithVerificationBase<TMocked> where TMocked : class
    {
        private readonly Expression<Action<TMocked>> _expression;
        private readonly Func<Times> _times;

        public MoqSetupWithVerification(Expression<Action<TMocked>> expression, Func<Times> times, Mock<TMocked> mock = null) : base(mock)
        {
            _expression = expression;
            _times = times;
        }

        public override void Verify() => Mock.Verify(_expression, _times);
    }

    public class MoqSetupWithVerification<TMocked, TReturn> : MoqSetupWithVerificationBase<TMocked> where TMocked : class
    {
        private readonly Expression<Func<TMocked, TReturn>> _expression;
        private readonly Func<Times> _times;

        public MoqSetupWithVerification(Expression<Func<TMocked, TReturn>> expression, Func<Times> times, Mock<TMocked> mock = null) : base(mock)
        {
            _expression = expression;
            _times = times;
        }

        public override void Verify() => Mock.Verify(_expression, _times);
    }
}