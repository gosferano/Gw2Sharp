using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters training endpoint.
    /// </summary>
    public class CharactersTraining
    {
        /// <summary>
        /// The list of character trainings.
        /// </summary>
        public IReadOnlyList<CharacterTraining> Training { get; set; }
    }
}
