using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    public interface IMoveResult
    {
        bool IsSuccess { get; }

        string Message { get; }
    }
}
