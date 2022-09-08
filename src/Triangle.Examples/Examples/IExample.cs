using System;

namespace TriangleNet.Examples
{
    public interface IExample
    {
        bool Run(bool print = false);
        string Name { get; }
        string Description { get; }
        EventHandler InputGenerated { get; set; }
    }
}
