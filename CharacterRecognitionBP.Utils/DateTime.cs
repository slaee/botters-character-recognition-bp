namespace CharacterRecognitionBP.Utils
{
    /// <summary>
    /// TimeStamp helper class.
    /// </summary>
    public class TimeStamp
    {
        /// <summary>
        /// Returns the current UTC time in seconds.
        /// </summary>
        public static String GetUTCNow()
        {
            return Convert.ToString((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }
    }
}
