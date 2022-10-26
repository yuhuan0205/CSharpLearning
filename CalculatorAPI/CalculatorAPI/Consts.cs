namespace CalculatorAPI
{
    /// <summary>
    /// a static class store some common const.
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// First index.
        /// </summary>
        public const int FIRST = 0;

        /// <summary>
        /// zero
        /// </summary>
        public const int ZERO = 0;

        /// <summary>
        /// one
        /// </summary>
        public const int ONE = 1;

        /// <summary>
        /// string zero
        /// </summary>
        public const string ZERO_STRING = "0";

        /// <summary>
        /// empty string
        /// </summary>
        public const string EMYPT_STRING = "";

        /// <summary>
        /// point string
        /// </summary>
        public const string POINT = ".";

        /// <summary>
        /// plaus sign
        /// </summary>
        public const string ADD_SIGN = "+";

        /// <summary>
        /// minus sign
        /// </summary>
        public const string MINUS_SIGN = "-";

        /// <summary>
        /// multipy sign
        /// </summary>
        public const string MULTIPY_SIGN = "*";

        /// <summary>
        /// divide sign
        /// </summary>
        public const string DIVIDE_SIGN = "/";

        /// <summary>
        /// left parengthese
        /// </summary>
        public const string LEFT_PARENTHESE = "(";

        /// <summary>
        /// right parenhese
        /// </summary>
        public const string RIGHT_PARENTHESE = ")";

        /// <summary>
        /// a error message.
        /// </summary>
        public const string DIVIDE_BY_ZERO_ERROR = "無法除以零";

        /// <summary>
        /// a error message.
        /// </summary>
        public const string SQUARE_ROOT_WITH_NAGATIVE = "無法對負數開根號";

        /// <summary>
        /// priority of the elements which are not a operator.
        /// </summary>
        public const int PRIORITY_NONE = 0;

        /// <summary>
        /// priority divider and multipyer.
        /// </summary>
        public const int PRIORITY_OPERTOR_HIGH = 2;

        /// <summary>
        /// priority adder and minuser.
        /// </summary>
        public const int PRIORITY_OPERTOR_LOW = 1;
    }
}