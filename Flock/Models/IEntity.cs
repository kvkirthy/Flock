namespace Flock.Models
{
    /// <summary>
    /// defines minimum implementation for entities
    /// </summary>
    /// <typeparam name="T">The type of the Id</typeparam>
    public interface IEntity<T>
        where T : struct
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        T Id { get; set; }
    }
}
