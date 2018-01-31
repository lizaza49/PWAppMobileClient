using System;

namespace ParriotWings.Helpers
{
    public abstract class Result<TResult> where TResult : class
    {
        public TResult Instance { get; protected set; }
        public abstract Error Error { get; }

        public bool IsSuccessful
        {
            get
            {
                return Error == null;
            }
        }

        public bool IsError
        {
            get
            {
                return Error != null;
            }
        }

        public static Result<TResult> Create(object resultObject)
        {
            var error = resultObject as Error;
            if (error != null)
            {
                return new ErrorResult<TResult>(error);
            }

            var succes = resultObject as TResult;
            if (succes != null)
            {
                return new SuccessResult<TResult>(succes);
            }

            return new ErrorResult<TResult>(new Error { Code = "", Message = "Wrong rootKey of json document" });
        }
    }
}
