using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    [Serializable]
    class CustomExceptions : ApplicationException
    {
        private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CustomExceptions() { }

        public CustomExceptions(string message) : base(message) { }

        public CustomExceptions(string message, System.Exception inner) : base(message, inner) { }

        public CustomExceptions(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        public override string Message
        {
            get
            {
                Console.WriteLine("You have not entered a proper number for a money amount");
                return string.Format("You have not entered a proper number for a money amount", messageDetails);

            }
        }
        
    }
}
