using System;
using System.Runtime.Serialization;

namespace WholeKitAndCaboodle
{
    [Serializable]
    public class MaxVehicleRangeException : Exception
    {
        public MaxVehicleRangeException(string message) : base(message)
        {

        }

        public MaxVehicleRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxVehicleRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}