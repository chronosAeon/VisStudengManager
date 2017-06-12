using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VisStudengManager.Utils
{
    static class StrOperator
    {/// <summary>  
     /// 判断是否为数字或字母  
     /// </summary>  
     /// <param name="strMessage">要判断的字符串</param>  
     /// <param name="iMinLong">最小长度</param>  
     /// <param name="iMaxLong">最大长度</param>  
     /// <returns>结果</returns>  
        public static bool fnIsDigitOrLetter(string strMessage, int iMinLong, int iMaxLong)
        {
            bool bResult = false;

            //开头匹配一个字母或数字+匹配两个十进制数字+匹配一个字母或数字+匹配两个相同格式的的（-加数字）+已字母或数字结尾  
            //如：1111-111-1119  
            //string pattern = @"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$";  

            //string pattern = @"^[a-zA-Z0-9]\d{2}$"; //开头以字母或数字，然后后面加两个数字字符  

            string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间  

            //string pattern = @"^[a-z0-9]*$"; //匹配所有字符都在小写字母和数字之间  

            //string pattern = @"^[A-Z][0-9]*$"; //以大写字母开头，后面的都是数字  

            //string pattern = @"^\d{3}-\d{2}$";//匹配 333-22 格式,三个数字加-加两个数字  

            if (strMessage.Length >= iMinLong && strMessage.Length <= iMaxLong)//判断字符串长度  
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(strMessage, pattern))
                {
                    bResult = true;
                }
                else
                {
                    bResult = false;
                }
            }

            return bResult;
        }
    }
}
