using System;

namespace ParriotWings.Helpers
{
    public class SuccessResult<TResult> : Result<TResult> where TResult : class
    {
        public SuccessResult(TResult instance)
        {
            Instance = instance;
        }

        public override Error Error
        {
            get
            {
                return null;
            }
        }
    }
}
