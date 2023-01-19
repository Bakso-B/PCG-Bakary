
using System.Collections.Generic;
using UnityEngine;

namespace MiniDini.Nodes
{
    /// <summary>
    /// <see cref="Node"/> that has a list of children.
    /// </summary>
    [System.Serializable]
    public class GridNode : Node
    {
        [SerializeField]
        public ConstructionPlane editplane = new ConstructionPlane();
        [SerializeField]
        public float width = 2.0f;
        [SerializeField]
        public float height = 2.0f;
        [SerializeField]
        public uint rows = 3;
        [SerializeField]
        public uint columns = 3;

        #region Overrides of Node

        public override string GetDescription() { return "A grid made of NxM quads"; }

        /// <summary>
        /// Get the geometry for this Node.
        /// </summary>
        /// <returns>A geometry object</returns>
        public override Geometry GetGeometry()
        {
            if (m_geometry == null)
            {
                Debug.Log("GridNode:Geometry was null in GetGeometry, so creating");
                // create new geometry container
                m_geometry = new Geometry();
            }

            m_geometry.Empty();

            // here is where we construct the geometry for a grid
            //stepX and stepY calculate the position of the points
            /*float stepX = width/(columns - 1);
            float stepY = height/(rows - 1);
            int pointIndex = 0;
            Point point = new Point();
            Prim p = new Prim();

            //loop that goes through each point in the grid
            for (int i = 0; i < rows * columns; i++){
                //getting the position of each point based on their index
                point.position = editplane.up * (i/columns * stepY) + editplane.right * (i%columns *stepX);
                pointIndex = m_geometry.AddPoint(point);

                //making a quad for each 4 points
                if (i%columns < columns - 1 && i/columns < rows - 1){
                    p.points.Add(pointIndex);
                    if (p.points.Count < 9){
                        m_geometry.AddPrim(p);

                        //clearing the points after they are added
                        //p.points.Clear();
                    }
                }
            }*/
            Point a = new();
            a.position = editplane.up * height;
            Point b = new();
            b.position = editplane.right * width;
            Point c = new Point();
            c.position = editplane.down * height;
            Point d = new Point();
            d.position = editplane.left * width;

            Point e = new();
            e.position = editplane.left * width + (editplane.up * height * 2);
            Point f = new();
            f.position = editplane.normal + (editplane.up * height *2);
            Point g = new();
            g.position = editplane.up * height * 2 + (editplane.right * width);
            Point h = new();
            h.position = editplane.up * height * 2 + (editplane.right * width*2);
            Point i = new();
            i.position = editplane.up * height + editplane.right * width * 2;
            Point j = new();
            j.position = editplane.right * width * 2;
            Point k = new();
            k.position = editplane.right * width * 2 +(editplane.down * height);
            Point l = new();
            l.position = editplane.down * height + (editplane.right * width);
            Point m = new();
            m.position = editplane.down * height;
            Point n = new();
            n.position = editplane.down * height + (editplane.left * width);
            Point o = new();
            o.position = editplane.left * width;
            Point p = new();
            p.position = editplane.left * width + (editplane.up * height);

            int index1 = m_geometry.AddPoint(a);
            int index2 = m_geometry.AddPoint(b);
            int index3 = m_geometry.AddPoint(c);
            int index4 = m_geometry.AddPoint(d);
            int index5 = m_geometry.AddPoint(e);
            int index6 = m_geometry.AddPoint(f);
            int index7 = m_geometry.AddPoint(g);
            int index8 = m_geometry.AddPoint(h);
            int index9 = m_geometry.AddPoint(i);
            int index10 = m_geometry.AddPoint(j);
            int index11 = m_geometry.AddPoint(k);
            int index12 = m_geometry.AddPoint(l);
            int index13 = m_geometry.AddPoint(m);
            int index14 = m_geometry.AddPoint(n);
            int index15 = m_geometry.AddPoint(o);
            int index16 = m_geometry.AddPoint(p);


            Prim first = new Prim();
            first.points.Add(index1);
            first.points.Add(index2);
            first.points.Add(index3);
            first.points.Add(index4);
            m_geometry.AddPrim(first);

            Prim second = new Prim();
            second.points.Add(index16);
            second.points.Add(index5);
            second.points.Add(index6);
            second.points.Add(index1);
            m_geometry.AddPrim(second);

            Prim third = new Prim();
            third.points.Add(index1);
            third.points.Add(index2);
            third.points.Add(index7);
            third.points.Add(index6);
            m_geometry.AddPrim(third);

            Prim forth = new Prim();
            forth.points.Add(index2);
            forth.points.Add(index7);
            forth.points.Add(index8);
            forth.points.Add(index9);
            m_geometry.AddPrim(forth);

            Prim fifth = new Prim();
            fifth.points.Add(index2);
            fifth.points.Add(index9);
            fifth.points.Add(index10);
            fifth.points.Add(index3);
            m_geometry.AddPrim(fifth);

            Prim sixth = new Prim();
            sixth.points.Add(index3);
            sixth.points.Add(index10);
            sixth.points.Add(index11);
            sixth.points.Add(index12);
            m_geometry.AddPrim(sixth);

            Prim seventh = new Prim();
            seventh.points.Add(index4);
            seventh.points.Add(index3);
            seventh.points.Add(index12);
            seventh.points.Add(index13);
            m_geometry.AddPrim(seventh);

            Prim eighth = new Prim();
            eighth.points.Add(index4);
            eighth.points.Add(index13);
            eighth.points.Add(index14);
            eighth.points.Add(index15);
            m_geometry.AddPrim(eighth);

            Prim ninth = new Prim();
            ninth.points.Add(index1);
            ninth.points.Add(index4);
            ninth.points.Add(index15);
            ninth.points.Add(index16);
            m_geometry.AddPrim(ninth);

            return m_geometry;
        }


        #endregion
    }
}