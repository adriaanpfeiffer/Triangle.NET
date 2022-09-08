﻿
namespace TriangleNet.Examples
{
    using System;
    using TriangleNet.Geometry;
    using TriangleNet.Meshing.Algorithm;
    using TriangleNet.Rendering.Text;

    /// <summary>
    /// Simple point set triangulation.
    /// </summary>
    public class Example1 : IExample
    {
        public string Name { get; }

        public string Description { get; }

        public EventHandler InputGenerated { get; set; }
        public Example1()
        {
            Name = "Simple point set triangulation";
            Description = "This example shows how to do a point set triangulation";
        }
        public bool Run(bool print = false)
        {
            // Generate points.
            var points = Generate.RandomPoints(50, new Rectangle(0, 0, 100, 100));

            // Choose triangulator: Incremental, SweepLine or Dwyer.
            var triangulator = new Dwyer();

            // Generate mesh.
            var mesh = triangulator.Triangulate(points, new Configuration());

            InputGenerated(mesh, EventArgs.Empty);

            if (print) SvgImage.Save(mesh, "example-1.svg", 500);

            return mesh.Triangles.Count > 0;
        }
    }
}
