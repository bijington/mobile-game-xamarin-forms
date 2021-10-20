using System.Collections.Generic;
using System.Threading.Tasks;
using Pairs.Models;

namespace Pairs.Repositories
{
    public interface IShapeRepository
    {
        /// <summary>
        /// Asynchronously lists all <see cref="Shape"/>s in the system.
        /// </summary>
        /// <returns>Asynchronously returns all <see cref="Shape"/>s in the system.</returns>
        Task<IList<Shape>> ListAsync();
    }
}
