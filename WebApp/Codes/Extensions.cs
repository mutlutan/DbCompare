using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApp1.Codes
{
    #region Genel Extensions

    public static class MyExtensions
    {
        #region Exception için

        public static Exception MyLastInner(this Exception _ex)
        {
            if (_ex.InnerException == null) return _ex;
            return _ex.InnerException.MyLastInner();
        }

        #endregion

        #region string işlemler

        public static string MyToStr(this object _value)
        {
            string? rV = Convert.ToString(_value);
            return rV ?? "";
        }

        public static string MyToTrim(this object _value)
        {
            return _value.MyToStr().Trim();
        }

        #endregion

        #region int
        public static int MyToInt(this string _str)
        {
            int rValue = 0;
            if (!String.IsNullOrEmpty(_str))
            {
                _ = int.TryParse(_str, out rValue);
            }
            return rValue;
        }

        public static int MyToInt(this object _value)
        {
            int rValue = 0;
            if (_value != null)
            {
                try
                {
                    rValue = Convert.ToInt32(_value);
                }
                catch { }
            }
            return rValue;
        }

        #endregion
    }

    #endregion


}
