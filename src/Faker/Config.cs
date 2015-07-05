using System;

namespace Faker
{
    /// <summary>
    ///     The Settings used in this Project.
    /// </summary>
    public static class Config
    {
        /// <summary>
        ///     The separator character used in the internal Resource files.
        /// </summary>
        public const char SEPARATOR = ';';

        /// <summary>
        ///     Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        /// <include file='Docs/CustomRemarks.xml' path='Comments/ConfigSeparator/remarks' />
        [Obsolete]
        public static char Separator { get; set; } = SEPARATOR;
    }
}
