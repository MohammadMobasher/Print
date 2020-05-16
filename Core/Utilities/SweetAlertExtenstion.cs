using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SweetAlertExtenstion
    {
        public string Message { get; set; }
        public bool Succeed { get; set; }

        public static SweetAlertExtenstion Ok(string message = null)
        {
            return new SweetAlertExtenstion()
            {
                Message = string.IsNullOrEmpty(message) ? "Mission accomplished" : message ,
                Succeed = true
            };
        }
        public static SweetAlertExtenstion Error(string message = null)
        {
            return new SweetAlertExtenstion()
            {
                Message = string.IsNullOrEmpty(message) ? "The operation encountered an error" : message,
                Succeed = false
            };
        }

        /// <summary>
        /// این متد برای این است که از کلاس جاری بتوان خروجی 
        /// bool 
        /// گرفت
        /// </summary>
        /// <param name="result"></param>

        public static implicit operator bool(SweetAlertExtenstion result) => result.Succeed;
    }
}
