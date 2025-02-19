using System.ComponentModel.DataAnnotations;

namespace Orien.FinanceBuddy.Data.Entity
{
    public class User
    {
        /// <summary>
        /// Get or Sets Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Get or Sets UId.
        /// </summary>
        [Required]
        public string Uid { get; set; }

        /// <summary>
        /// Gets or Sets Google Id.
        /// </summary>
        public string Google_id { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets Picture.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or Sets Salary.
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Gets or Sets Last Login.
        /// </summary>
        public DateTime Last_Login { get; set; }

        /// <summary>
        /// Gets or Sets Registered On.
        /// </summary>
        public DateTime Registered_on { get; set; }
    }
}
