using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickNV.Onvif.TestUI.Utils
{
    public class ExceptionUtils
    {
        //忽略的属性名称数组
        private static string[] ignorePropertiyNames = new string[]
        {
            "Message","InnerException","StackTrace","Data"
        };

        public static string GetExceptionString(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception tmpEx = ex;
            while (tmpEx != null)
            {
                sb.AppendLine("------------------------------------------------------");
                _GetExceptionString(tmpEx, sb, string.Empty);
                tmpEx = tmpEx.InnerException;
            }
            return sb.ToString();
        }

        private static void _GetExceptionString(Exception ex, StringBuilder sb, string prefix)
        {
            Type exType = ex.GetType();
            sb.AppendLine(prefix + "异常类型：" + exType.FullName);
            sb.AppendLine(prefix + "异常消息：" + ex.Message);
            PropertyInfo[] propertys = exType.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance).Where(t =>
            {
                return !ignorePropertiyNames.Contains(t.Name);
            }).OrderBy(t => { return t.Name; }).ToArray();

            if (propertys.Length > 0)
            {
                sb.AppendLine(prefix + "异常公共属性：");
                foreach (PropertyInfo pi in propertys)
                {
                    try
                    {
                        object propertyValue = pi.GetValue(ex, null);
                        if (propertyValue == null) continue;
                        if (propertyValue is Exception[])
                        {
                            Exception[] subExs = (Exception[])propertyValue;
                            foreach (Exception subEx in subExs)
                            {
                                _GetExceptionString(subEx, sb, prefix + "    ");
                            }
                        }
                        else
                        {
                            sb.AppendLine(string.Format(prefix + "    {0} : {1}", pi.Name, propertyValue.ToString()));
                        }
                    }
                    catch { }
                }
            }
            sb.AppendLine(prefix + "异常堆栈：" + ex.StackTrace);
        }

        public static string GetExceptionMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception tmpEx = ex;
            while (tmpEx != null)
            {
                sb.Append(">");
                sb.AppendLine(tmpEx.Message);
                tmpEx = tmpEx.InnerException;
            }
            return sb.ToString();
        }
    }
}
