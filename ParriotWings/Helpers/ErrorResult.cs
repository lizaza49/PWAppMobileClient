using System;
namespace ParriotWings.Helpers
{
    public class ErrorResult<TResult> : Result<TResult> where TResult : class
    {
        private readonly Error error;

        public ErrorResult(Error error)
        {
            this.error = error;
        }

        public override Error Error => error;
    }
}
