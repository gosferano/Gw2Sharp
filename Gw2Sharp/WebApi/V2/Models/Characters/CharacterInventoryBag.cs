using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character inventory bag.
    /// </summary>
    public class CharacterInventoryBag
    {
        /// <summary>
        /// The bag item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The bag size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The bag inventory with a list of items.
        /// A slot that is empty, is <c>null</c>.
        /// </summary>
        public IReadOnlyList<AccountItem> Inventory { get; set; }
    }
}
