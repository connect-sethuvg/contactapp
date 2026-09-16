using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Extension
{
    public class ActionStatus
    {
        public ActionStatus(bool isSuccess, ResponseVM response)
        {
            IsSuccess = isSuccess;
        }

        public ActionStatus(ResponseVM error)
        {
            IsSuccess = false;
            Response = error;
        }

        public ActionStatus(string locationCode, Exception exception)
        {
            IsSuccess = false;
            Exception = exception;
            Response = new ResponseVM(locationCode);
        }

        public ActionStatus(ActionStatus actionStatus)
        {
            IsSuccess = actionStatus.IsSuccess;
            Exception = actionStatus.Exception;
            Response = actionStatus.Response;
        }

        public static implicit operator bool (ActionStatus actionStatus)
        {
            return actionStatus.IsSuccess;
        }

        public static explicit operator ActionStatus(bool isSuccess)
        {
            return new ActionStatus(isSuccess, new ResponseVM("DEFAULT"));
        }

        public bool IsSuccess { get; set; } = false;
        public Exception? Exception { get; set; }
        public ResponseVM? Response { get; set; }
        public bool HasException => Exception != null;

    }

    public class ActionStatus<T> : ActionStatus
    {
        public ActionStatus(ActionStatus actionStatus) : base(actionStatus)
        {
            Result = default;
        }

        public ActionStatus(ResponseVM error) : base(error)
        {
            Result = default;
        }

        public ActionStatus(bool isSuccess, T result) : base(isSuccess, new ResponseVM("DEFAULT"))
        {
            Result = result;
        }
        public ActionStatus(bool isSuccess, T result, int totalCount) : base(isSuccess, new ResponseVM("DEFAULT"))
        {
            Result = result;
            TotalCount = totalCount;
        }


        public ActionStatus(string locationCode, Exception exception) : base(locationCode, exception)
        {
            Result = default;
        }
        
        public T? Result { get; }
        public int TotalCount { get; set; }
    }

}
