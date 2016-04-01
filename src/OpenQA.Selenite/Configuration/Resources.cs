using System.Globalization;

namespace Microsoft.Extensions.Configuration
{
    public static class Resources
    {
        public const string Error_NoSources = "A configuration provider is not registered. Please register one before setting a value.";

        public const string Error_InvalidFilePath = "File path must be a non-empty string.";

        public const string Error_FileNotFound = "The configuration file '{0}' was not found and is not optional.";

        public const string Error_JSONParseError = "Could not parse the JSON file. Error on line number '{0}': '{1}'.";

        public const string Error_KeyIsDuplicated = "A duplicate key '{0}' was found.";

        public const string Error_UnsupportedJSONToken = "Unsupported JSON token '{0}' was found. Path '{1}', line {2} position {3}.";

        /// <summary>
        /// Cannot create instance of type '{0}' because it is either abstract or an interface.
        /// </summary>
        internal static string Error_CannotActivateAbstractOrInterface
        {
            get { return ("Cannot create instance of type '{0}' because it is either abstract or an interface."); }
        }
        
        /// <summary>
        /// Failed to convert '{0}' to type '{1}'.
        /// </summary>
        internal static string Error_FailedBinding
        {
            get { return ("Failed to convert '{0}' to type '{1}'."); }
        }

        
        /// <summary>
        /// Failed to create instance of type '{0}'.
        /// </summary>
        internal static string Error_FailedToActivate
        {
            get { return ("Failed to create instance of type '{0}'."); }
        }

        /// <summary>
        /// Cannot create instance of type '{0}' because it is missing a public parameterless constructor.
        /// </summary>
        internal static string Error_MissingParameterlessConstructor
        {
            get { return ("Cannot create instance of type '{0}' because it is missing a public parameterless constructor."); }
        }

        /// <summary>
        /// Cannot create instance of type '{0}' because multidimensional arrays are not supported.
        /// </summary>
        internal static string Error_UnsupportedMultidimensionalArray
        {
            get { return ("Cannot create instance of type '{0}' because multidimensional arrays are not supported."); }
        }

        /// <summary>
        /// Failed to create instance of type '{0}'.
        /// </summary>
        internal static string FormatError_FailedToActivate(object p0)
        {
            return string.Format(Error_FailedToActivate, p0);
        }

        /// <summary>
        /// Cannot create instance of type '{0}' because it is missing a public parameterless constructor.
        /// </summary>
        internal static string FormatError_MissingParameterlessConstructor(object p0)
        {
            return string.Format(Error_MissingParameterlessConstructor, p0);
        }

        /// <summary>
        /// Cannot create instance of type '{0}' because multidimensional arrays are not supported.
        /// </summary>
        internal static string FormatError_UnsupportedMultidimensionalArray(object p0)
        {
            return string.Format(Error_UnsupportedMultidimensionalArray, p0);
        }

        
        /// <summary>
        /// The configuration file '{0}' was not found and is not optional.
        /// </summary>
        public static string FormatError_FileNotFound(object p0)
        {
            return string.Format(Error_FileNotFound, p0);
        }

        /// <summary>
        /// A duplicate key '{0}' was found.
        /// </summary>
        internal static string FormatError_KeyIsDuplicated(object p0)
        {
            return string.Format(Error_KeyIsDuplicated, p0);
        }
        
        /// <summary>
        /// Unsupported JSON token '{0}' was found. Path '{1}', line {2} position {3}.
        /// </summary>
        internal static string FormatError_UnsupportedJSONToken(object p0, object p1, object p2, object p3)
        {
            return string.Format(Error_UnsupportedJSONToken, p0, p1, p2, p3);
        }

        /// <summary>
        /// Could not parse the JSON file. Error on line number '{0}': '{1}'.
        /// </summary>
        internal static string FormatError_JSONParseError(object p0, object p1)
        {
            return string.Format(Error_JSONParseError, p0, p1);
        }

        /// <summary>
        /// Cannot create instance of type '{0}' because it is either abstract or an interface.
        /// </summary>
        internal static string FormatError_CannotActivateAbstractOrInterface(object p0)
        {
            return string.Format(Error_CannotActivateAbstractOrInterface, p0);
        }

        /// <summary>
        /// Failed to convert '{0}' to type '{1}'.
        /// </summary>
        internal static string FormatError_FailedBinding(object p0, object p1)
        {
            return string.Format(Error_FailedBinding, p0, p1);
        }
    }
}
