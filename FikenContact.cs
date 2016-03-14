using System;

namespace Fiken.Net
{
    public class FikenContact
    {
        public Uri Url { get; set; }

        /// <summary>
        /// [REQUIRED] The (company) name of the customer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organization identifier - in Norway this is an org. nr.
        /// </summary>
        public string OrganizationIdentifier { get; set; }

        public string Email { get; set; }
        public FikenAddress Address { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// [READ-ONLY]
        /// </summary>
        public string CustomerNumber { get; private set; }

        /// <summary>
        /// [WRITE-ONLY] If true, a customer number will be generated if not already present
        /// </summary>
        public bool Customer { get; set; }

        /// <summary>
        /// [READ-ONLY]
        /// </summary>
        public string SupplierNumber { get; private set; }

        /// <summary>
        /// [WRITE-ONLY] If true, a supplier number will be generated if not already present
        /// </summary>
        public bool Supplier { get; set; }

        public void Save()
        {
            
        }
    }
}
