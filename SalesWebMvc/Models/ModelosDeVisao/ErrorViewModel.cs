using System;

namespace SalesWebMvc.Models.ModelosDeVisao
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        //Para se ter uma msenagem customizada
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
