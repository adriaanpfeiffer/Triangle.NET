
namespace TriangleNet.Examples
{
    using System.Collections.Generic;
    using System.Threading;
    using TriangleNet;
    using TriangleNet.Geometry;
    using TriangleNet.Meshing;
    using TriangleNet.Meshing.Iterators;
    using TriangleNet.Rendering.Text;

    /// <summary>
    /// Two ways finding boundary triangles.
    /// </summary>
    public class Example6 : Example
    {
        public override string Name => "Two ways finding boundary triangles.";
        public override bool Run(bool print = false)
        {
            var mesh = Example4.CreateMesh();

            FindBoundary1(mesh);
            SendInputGeneratedMessage(mesh);

            if (print) SvgImage.Save(mesh, "example-6-1.svg", 500, true, false);

            FindBoundary2(mesh);

            if (print) SvgImage.Save(mesh, "example-6-2.svg", 500, true, false);
            Thread.Sleep(600);
            SendInputGeneratedMessage(mesh);
            return mesh.Triangles.Count > 0;
        }

        /// <summary>
        /// Find boundary triangles using segments.
        /// </summary>
        private static void FindBoundary1(IMesh mesh)
        {
            foreach (var s in mesh.Segments)
            {
                int label = s.Label;

                // Get both adjacent triangles.
                var a = s.GetTriangle(0);
                var b = s.GetTriangle(1);

                if (a != null) a.Label = label;
                if (b != null) b.Label = label;
            }
        }


        /// <summary>
        /// Find boundary triangles using vertices.
        /// </summary>
        private static void FindBoundary2(IMesh mesh)
        {
            var circulator = new VertexCirculator((Mesh)mesh);

            foreach (var vertex in mesh.Vertices)
            {
                int label = vertex.Label;

                if (label > 0)
                {
                    var star = circulator.EnumerateTriangles(vertex);

                    foreach (var triangle in star)
                    {
                        triangle.Label = label;
                    }
                }
            }
        }
    }
}
