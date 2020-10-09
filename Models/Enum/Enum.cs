using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Enum
{
    public class Enum
    {
       public enum LoginStatus
        {
            Failed ,
            // The Login has failed due to a filed being null
            Successful ,
            // Login in has been successful
            Unsuccessful
            // Login in was unsuccessfull due to user not being found or incorrect data being entered by the user.
        }

        public enum Status
        {
            Empty,
            //The Update/Add has failed due to an empty field
            NotFound,
            //The object has not been found
            Duplicate,
            //The requested row already exist in the Database
            Success,
           // The add/Update has been successfully
           Failed
           // The add/Update has failed.
        }

    }
}
