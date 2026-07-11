using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string logFilePath = "ErrorLog.txt";

            File.AppendAllText(
                logFilePath,
                $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult(new
            {
                Message = "An unexpected error occurred.",
                Error = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}