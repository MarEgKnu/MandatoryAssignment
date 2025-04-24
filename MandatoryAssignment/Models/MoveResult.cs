using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Models
{
    /// <summary>
    /// A implmenetation of a MoveResult, includes a property for sucess, and a extra message
    /// </summary>
    public class MoveResult : IMoveResult
    {
        public MoveResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        /// <summary>
        /// If the move succeeded or not
        /// </summary>
        public bool IsSuccess {  get; }
        /// <summary>
        /// A message giving context or reason as to why it failed/Succeeded
        /// </summary>
        public string Message {  get; }
    }
}
