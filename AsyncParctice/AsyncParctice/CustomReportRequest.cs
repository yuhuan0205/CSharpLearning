namespace AsyncParctice
{
    /// <summary>
    ///  a json like object contains params in order to post and get Result from ICustomReportService. 
    /// </summary>
    public class CustomReportRequest
    {
        /// <summary>
        /// param Dtno
        /// </summary>
        public int Dtno { get; set; }

        /// <summary>
        /// param Ftno
        /// </summary>
        public int Ftno { get; set; }

        /// <summary>
        /// param Params
        /// </summary>
        public string Params { get; set; }

        /// <summary>
        /// param KeyMap
        /// </summary>
        public string KeyMap { get; set; }

        /// <summary>
        /// param AssignSpid
        /// </summary>
        public string AssignSpid { get; set; }
    }
}