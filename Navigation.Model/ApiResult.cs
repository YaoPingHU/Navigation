﻿
namespace Navigation.Model
{
    public class ApiResult
    {
        public bool Result { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
