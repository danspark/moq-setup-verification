using System;

namespace Moq.Extensions.SetupWithVerification
{
    public abstract class MoqSetupWithVerificationBase<TMocked> : IDisposable where TMocked : class
    {
        public Mock<TMocked> Mock { get; set; }

        protected MoqSetupWithVerificationBase(Mock<TMocked> mock = null)
        {
            Mock = mock ?? new Mock<TMocked>();
        }

        public abstract void Verify();

        public void Dispose() => Verify();
    }
}