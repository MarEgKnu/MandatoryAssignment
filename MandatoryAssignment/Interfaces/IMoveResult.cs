using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a move result after an attempted move
    /// </summary>
    public interface IMoveResult
    {
        /// <summary>
        /// If the move was sucessful
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// A message with further details on what happend, and why it might have failed or suceeded. 
        /// </summary>
        string Message { get; }
    }
}
