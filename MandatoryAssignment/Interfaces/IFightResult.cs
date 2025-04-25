namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a fight result object returning information about an attempted fight.
    /// </summary>
    public interface IFightResult
    {
        /// <summary>
        /// If the fight was sucessfully initialized, or not
        /// </summary>
        bool Sucess { get; }
        /// <summary>
        /// Result message giving additional context and/or reason for why it was sucessful or not
        /// </summary>
        string ResultMessage { get; }
        /// <summary>
        /// True if the attack resulted in the entities death
        /// </summary>
        bool IsDead { get; }
    }
}