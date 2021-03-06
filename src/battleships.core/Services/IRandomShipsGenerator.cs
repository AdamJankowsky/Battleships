using battleships.core.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("battleships.core.tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace battleships.core.Services
{
    internal interface IRandomShipsGenerator
    {
        List<Ship> RandomizeShips();
        string ConvertToSymbolic((int, int) positionInt);
        (int, int) ConvertToCoordinates(string symbolic);
    }
}