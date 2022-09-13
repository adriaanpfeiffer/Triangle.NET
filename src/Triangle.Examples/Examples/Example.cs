using System;
using TriangleNet.Meshing;

namespace TriangleNet.Examples
{
    public abstract class Example
    {
        public abstract bool Run(bool print = false);
        public abstract string Name { get; }
        public string Description { get; set; }
        public EventHandler InputGenerated { get; set; }
        public void SendInputGeneratedMessage(IMesh mesh)
        {
            if (InputGenerated != null)
                InputGenerated(mesh, EventArgs.Empty);
        }
    }
}
