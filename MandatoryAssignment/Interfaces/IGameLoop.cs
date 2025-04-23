namespace MandatoryAssignment.Interfaces
{
    /// <summary>
    /// Interface for a custom game loop.
    /// </summary>
    public interface IGameLoop
    {
        /// <summary>
        /// Should start the gameloop, and should only return when the game exists, or halts due to an unrecoverable error.
        /// </summary>
        void Start();
    }
}