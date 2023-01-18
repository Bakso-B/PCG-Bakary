
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
            float stepX = width/(columns - 1);
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
            }


            return m_geometry;
        }


        #endregion
    }
}