using Newtonsoft.Json.Serialization;

namespace Fiken.Net.Api
{
    /// <summary>
    /// Converts property names to lower camel case.
    /// </summary>
    internal class LowerCamelCaseContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Resolves the name of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// Name of the property.
        /// </returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            var propName = propertyName.ToCharArray();
            var firstChar = char.ToLower(propName[0]);

            return firstChar + propertyName.Substring(1);
        }
    }
}
