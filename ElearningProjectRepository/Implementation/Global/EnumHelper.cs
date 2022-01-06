using System;
using System.Collections.Generic;
using System.Text;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectRepository.Implementation.Global
{
   public class EnumHelper
    {
        private static string _defaultError = "Converting to Enum Error Has Occured.";
        public enum SystemEnums
        {
            Status = 1,
            Login_Status = 2
        }

        public static string GetEnumValue(SystemEnums enumName,int resultValue)
        {
            return enumName switch
            {
                SystemEnums.Status => ((Status)resultValue).ToString(),
                SystemEnums.Login_Status => ((LoginStatus)resultValue).ToString(),
                _ => _defaultError,
            };
        }

    }
}
