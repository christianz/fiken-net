using System;

namespace Fiken.Net
{
    public class FikenPayment
    {
        /// <summary>
        /// [REQUIRED] Date of payment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// [REQUIRED] The accounting account that received the payment. For example "1920:10002"
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// [REQUIRED] Payment amount in øre
        /// </summary>
        public int Amount { get; set; }
    }
}
