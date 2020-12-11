using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Services
{
    public static class ControllerService
    {
        public class ReponseStatus
        {
            public int StatusCode { get; set; }
            public object Response { get; set; }
        }

        private static ReponseStatus _reponseStatus = new ReponseStatus();
        private static string _emptyValues = "Required values may haved been empty.";
        public static ReponseStatus GetIActionResult(Status requestStatus)
        {
            switch (requestStatus)
            {
                case Status.Empty:
                    SetResponseStatus(400, new { Message = _emptyValues, Code = 400 });
                    return _reponseStatus;
                case Status.NotFound:
                    SetResponseStatus(404, new { Message = "Item can not be found", Code = 404 });
                    return _reponseStatus;
                case Status.Duplicate:
                    SetResponseStatus(400, new { Message = "This name has already been used.", Code = 400 });
                    return _reponseStatus;
                case Status.Success:
                    SetResponseStatus(200, new { Message = "Successful", Code = 200 });
                    return _reponseStatus;
                case Status.Failed:
                    SetResponseStatus(400, new { Message = "The request has failed", Code = 400 });
                    return _reponseStatus;
                default:
                    SetResponseStatus(500, new { Message = "The request has failed", Code = 500 });
                    return _reponseStatus;
            }
        }

        private static void SetResponseStatus(int statusCode, object requestResponse)
        {
            _reponseStatus.StatusCode = statusCode;
            _reponseStatus.Response = requestResponse;
        }
    }
}
