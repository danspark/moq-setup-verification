# Moq.Extensions.SetupWithVerification

This library provides two extension methods (and two classes) for creating setups with a matching verification, this makes you write less code and avoid errors such as mismatching expressions between setup and verification.

## Usage

```csharp
var mock = new Mock<MyClass>();

// configure MyClass.DoStuff() to be verifiable and return the value 1
var verification = mock.SetupWithVerification(m => m.DoStuff(), Times.Once, it => it.Returns(1));

int result = mock.Object.DoStuff();

// asserts that DoStuff() was called exactly once
verification.Verify();
```
