using Microsoft.AspNetCore.Http;
using MISA.CukCuk.Core.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.CukCukTest.Base.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Xử lý exception.
        /// </summary>
        /// <param name="context">.</param>
        /// <param name="exception">các exception.</param>
        /// <returns>response chứa các thông tin lỗi.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //HttpStatusCode status;
            //string message;
            if (exception is CustomExceptions)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.Response.StatusCode = 500;
            }
            var response = new
            {
                devMsg = exception.Message,
                userMsg = exception.Message,
                errorCode = "Mã lội bộ",
                Data = exception.Data,
                moreInfo = "Hỗ trợ Dev về lỗi",
                traceId = "Tra cứu thông tin log",
            };
            //var stackTrace = String.Empty;
            //message = exception.Message;
            //var exceptionType = exception.GetType();
            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
