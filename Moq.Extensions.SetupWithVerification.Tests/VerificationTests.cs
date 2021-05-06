using FluentAssertions;
using System;
using Xunit;

namespace Moq.Extensions.SetupWithVerification.Tests
{
    public class VerificationTests
    {
        [Fact]
        public void ActionVerificationShouldVerify() => EnsureVerificationErrorHappens(GetActionStunt());

        [Fact]
        public void FuncVerificationShouldVerify() => EnsureVerificationErrorHappens(GetFuncStunt());

        [Fact]
        public void ActionVerificationShouldHappenWhenDisposing() => EnsureActionThrowsVerificationError(() => GetActionStunt().Dispose());

        [Fact]
        public void FuncVerificationShouldHappenWhenDisposing() => EnsureActionThrowsVerificationError(() => GetFuncStunt().Dispose());

        [Fact]
        public void ActionSetupWithVerificationShouldConfigureMock()
        {
            bool configured = false;

            var mock = new Mock<VerificationStunt>();

            mock.SetupWithVerification(m => m.DoWork(), Times.Once,
                it => it.Callback(() => configured = true));

            mock.Object.DoWork();

            configured.Should().BeTrue();
        }

        [Fact]
        public void FuncSetupWithVerificationShouldConfigureMock()
        {
            var mock = new Mock<VerificationStunt>();

            mock.SetupWithVerification(m => m.GetValue(), Times.Once, it => it.Returns(1));

            var result = mock.Object.GetValue();

            result.Should().Be(1);
        }

        private Verification<VerificationStunt> GetActionStunt() => new Verification<VerificationStunt>(m => m.DoWork(), Times.Once);

        private Verification<VerificationStunt, int> GetFuncStunt() => new Verification<VerificationStunt, int>(m => m.GetValue(), Times.Once);

        private static void EnsureVerificationErrorHappens<T>(VerificationBase<T> verification) where T : class
            => EnsureActionThrowsVerificationError(verification.Verify);

        private static void EnsureActionThrowsVerificationError(Action action) =>
            action.Should().Throw<MockException>()
                .Which
                .IsVerificationError.Should().BeTrue();
    }
}
