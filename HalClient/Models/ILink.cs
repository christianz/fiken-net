using Newtonsoft.Json;

namespace Fiken.Net.HalClient.Models
{
    /// <summary>
    /// Represents a HAL link relation.
    /// </summary>
    public interface ILink : INode
    {
        /// <summary>
        /// Specifies whether or not the link has templated parameters.
        /// </summary>
        [JsonProperty("templated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        bool Templated { get; set; }
    }
}