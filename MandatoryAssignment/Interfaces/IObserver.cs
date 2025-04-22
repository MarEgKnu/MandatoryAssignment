using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a generic observer
    /// </summary>
    /// <typeparam name="T">The type of subject it should observe, eg. IWorldEntity to observe world entities</typeparam>
    public interface IObserver<T>
    {
        /// <summary>
        /// Called when the observer is notified by an event it is subcribed to. 
        /// </summary>
        /// <param name="subject">The subject where the event was fired from</param>
        /// <param name="args">Extra event arguments in the form of classes direved from EventArgs</param>
        void Update(T subject, EventArgs args);
    }
}
