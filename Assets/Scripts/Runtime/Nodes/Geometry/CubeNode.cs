
using System.Collections.Generic;
using UnityEngine;

namespace MiniDini.Nodes
{
    /// <summary>
    /// <see cref="Node"/> that has a list of children.
    /// </summary>
    [System.Serializable]
    public class CubeNode : Node
    {

        #region Overrides of Node

        [SerializeField]
        protected ConstructionPlane editplane = new ConstructionPlane();
        [SerializeField]
        protected float size = 1.0f;

        public override string GetDescription() { return "A single cube"; }

        /// <summary>
        /// Get the geometry for this Node.
        /// </summary>
        /// <returns>A geometry object</returns>
        public override Geometry GetGeometry()
        {
            if (m_geometry == null)
            {
                Debug.Log("CubeNode:Geometry was null in GetGeometry, so creating");
                // create new geometry container
                m_geometry = new Geometry();
            }

            m_geometry.Empty();

            // here is where we construct the geometry for a cube (8 points, 6 prims, 8 indices)

            Point a = new();
            a.position = editplane.up * size;
            Point b = new();
            b.position = editplane.right * size;
            Point c = new();
            c.position = editplane.down * size;
            Point d = new();
            d.position = editplane.left * size;
            Point e = new();
            e.position = (editplane.normal) + (editplane.up * size);
            Point f = new();
            f.position = (editplane.normal)+(editplane.right * size);
            Point g = new();
            g.position = (editplane.normal)+(editplane.down * size);
            Point h = new();
            h.position = (editplane.normal)+(editplane.left * size);

            int index1 = m_geometry.AddPoint(a);
            int index2 = m_geometry.AddPoint(b);
            int index3 = m_geometry.AddPoint(c);
            int index4 = m_geometry.AddPoint(d);
            int index5 = m_geometry.AddPoint(e);
            int index6 = m_geometry.AddPoint(f);
            int index7 = m_geometry.AddPoint(g);
            int index8 = m_geometry.AddPoint(h);
            
            Prim first = new Prim();
            first.points.Add(index1);
            first.points.Add(index2);
            first.points.Add(index3);
            first.points.Add(index4);

            m_geometry.AddPrim(first);

            Prim second = new Prim();
            second.points.Add(index5);
            second.points.Add(index8);
            second.points.Add(index7);
            second.points.Add(index6);
            m_geometry.AddPrim(second);

            Prim third = new Prim();
            third.points.Add(index1);
            third.points.Add(index5);
            third.points.Add(index6);
            third.points.Add(index2);
            m_geometry.AddPrim(third);

            Prim fourth = new Prim();
            fourth.points.Add(index4);
            fourth.points.Add(index3);
            fourth.points.Add(index7);
            fourth.points.Add(index8);
            m_geometry.AddPrim(fourth);

            Prim fifth = new Prim();
            fifth.points.Add(index1);
            fifth.points.Add(index4);
            fifth.points.Add(index8);
            fifth.points.Add(index5);
            m_geometry.AddPrim(fifth);

            Prim sixth = new Prim();
            sixth.points.Add(index2);
            sixth.points.Add(index6);
            sixth.points.Add(index7);
            sixth.points.Add(index3);
            m_geometry.AddPrim(sixth);

            return m_geometry;
        }

        #endregion
    }
}