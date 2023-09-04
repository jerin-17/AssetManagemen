
using System;

namespace AssetManagementAPI.MyExceptions
{
    

    public class DataExistsException : Exception
    {
       
        public DataExistsException()
        {
        }

        public DataExistsException(string message)
            : base(message)
        {
        }

        public DataExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
