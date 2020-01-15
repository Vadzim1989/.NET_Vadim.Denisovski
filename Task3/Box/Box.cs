using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Figures;
using IOXml;


namespace Task3
{
    [Serializable]
    /// <summary>
    /// Box of Figures
    /// </summary>
    public class Box
    {
        /// <summary>
        /// List of figures.
        /// </summary>
        private List<IFigure> boxoffigure;
        /// <summary>
        /// Default constructor for box of 20 figures
        /// </summary>
        public Box()
        {
            boxoffigure = new List<IFigure>(20);
        }
        /// <summary>
        /// Constructor for individual capacity of figures
        /// </summary>
        /// <param name="c">Capacity of box</param>
        public Box(int c)
        {
            boxoffigure = new List<IFigure>(c);
        }
        /// <summary>
        /// Add new figure into box
        /// </summary>
        /// <param name="f1">Input figure</param>
        public void AddFigure(IFigure f1)
        {
            if (boxoffigure.Count == boxoffigure.Capacity)
            {
                throw new Exception("Box is full");
            }
            else
            {
                boxoffigure.Add(f1);
            }
        }
        /// <summary>
        /// Add new figure into box
        /// </summary>
        /// <param name="f1">Input figure</param>
        /// <param name="i">Index of Figure in box</param>
        public void AddFigure(IFigure f1, int i)
        {
            if (boxoffigure.Count == boxoffigure.Capacity)
            {
                throw new Exception("Box is full");
            }
            else if (boxoffigure.Count < i)
            {
                throw new Exception("Wrong index");
            }
            else
            {
                boxoffigure.Insert(i, f1);
            }
        }
        /// <summary>
        /// View figure by index without remove
        /// </summary>
        /// <param name="i">Index of figure in box</param>
        public IFigure ViewFigure(int i)
        {
            if ((boxoffigure.Count != 0) && (i < boxoffigure.Count))
            {
                return boxoffigure[i];
            }
            else throw new Exception("Box don't have this figure");
        }
        /// <summary>
        /// Remove Figure by index
        /// </summary>
        /// <param name="i">Index of figure in box</param>
        public void RemoveFigure(int i)
        {
            if ((boxoffigure.Count != 0) && (i < boxoffigure.Count))
            {
                boxoffigure.RemoveAt(i);
            }
            else
            {
                throw new Exception("Box don't have this figure");
            }
        }
        /// <summary>
        /// Replace Figure on another by index
        /// </summary>
        /// <param name="f1">New Figure</param>
        /// <param name="i">Index of figure in box</param>
        public void ReplaceFigure(IFigure f1, int i)
        {
            if ((boxoffigure.Count != 0) && (i < boxoffigure.Count))
            {
                RemoveFigure(i);
                AddFigure(f1, i);
            }
            else
            {
                throw new Exception("Box dont have this index of figure");
            }
        }
        /// <summary>
        /// Find figure in box
        /// </summary>
        /// <param name="f1">Figure for search</param>
        /// <returns>Index of figure in box</returns>
        public string FindFigure(IFigure f1)
        {
            string k = null;
            for (int i = 0; i < boxoffigure.Count; i++)
            {
                if (boxoffigure[i].Equals(f1))
                {
                    return k += i;
                }
            }
            return k;
        }
        /// <summary>
        /// Count of figures in box
        /// </summary>
        /// <returns>Int value</returns>
        public int CountFigures()
        {
            return boxoffigure.Count;
        }
        /// <summary>
        /// Total area of all figures into box
        /// </summary>
        /// <returns>Float value of area</returns>
        public float TotalArea()
        {
            float totalarea = 0;
            foreach (var i in boxoffigure)
            {
                totalarea += i.Area;
            }
            return totalarea;
        }
        /// <summary>
        /// Total perimeter of all figures into box
        /// </summary>
        /// <returns>Float value of perimeter</returns>
        public float TotalPerimeter()
        {
            float totalperimeter = 0;
            foreach (var i in boxoffigure)
            {
                totalperimeter += i.Perimeter;
            }
            return totalperimeter;
        }
        /// <summary>
        /// Delete all circles into box
        /// </summary>
        public void RemoveCircles()
        {
            foreach (var i in boxoffigure)
            {
                if (i is Circle)
                {
                    boxoffigure.Remove(i);
                }
            }
        }
        /// <summary>
        /// Delete all film figures
        /// </summary>
        public void RemoveFilm()
        {
            foreach (var i in boxoffigure)
            {
                if (i is IFilm)
                {
                    boxoffigure.Remove(i);
                }
            }
        }
        /// <summary>
        /// Save xml (streamwriter)
        /// </summary>
        public void SaveXMLAll(string output)
        {
            Xml1 t1 = new Xml1();
            t1.Write(output, boxoffigure);
        }
        /// <summary>
        /// Save xml (only film)
        /// </summary>
        public void SaveXMLFilm(string output)
        {
            Xml1 t1 = new Xml1();
            List<IFigure> _tempbox = new List<IFigure>(boxoffigure.Count);
            foreach (var i in boxoffigure)
            {
                if (i is IFilm)
                {
                    _tempbox.Add(i);
                }
            }
            t1.Write(output, _tempbox);
        }
        /// <summary>
        /// Save xml (only paper)
        /// </summary>
        public void SaveXMLPaper(string output)
        {
            Xml1 t1 = new Xml1();
            List<IFigure> _tempbox = new List<IFigure>(boxoffigure.Count);
            foreach (var i in boxoffigure)
            {
                if (i is IPaper)
                {
                    _tempbox.Add(i);
                }
            }
            t1.Write(output, _tempbox);
        }
        /// <summary>
        /// load xml (streamreader)
        /// </summary>
        public void LoadXML(string input)
        {
            Xml1 t1 = new Xml1();
            boxoffigure = t1.Read(input);
        }
        /// <summary>
        /// Save xml (xmlwriter)
        /// </summary>
        public void SaveXML2All(string output)
        {
            Xml2 wx = new Xml2();
            wx.Write(output, boxoffigure);
        }
        /// <summary>
        /// Save xml only film (xmlwriter)
        /// </summary>
        public void SaveXML2Film(string output)
        {
            Xml2 wx = new Xml2();
            List<IFigure> _tempbox = new List<IFigure>(boxoffigure.Count);
            foreach (var i in boxoffigure)
            {
                if (i is IFilm)
                {
                    _tempbox.Add(i);
                }
            }
            wx.Write(output, _tempbox);
        }
        /// <summary>
        /// Save xml only paper (xmlwriter)
        /// </summary>
        public void SaveXML2Paper(string output)
        {
            Xml2 wx = new Xml2();
            List<IFigure> _tempbox = new List<IFigure>(boxoffigure.Count);
            foreach (var i in boxoffigure)
            {
                if (i is IPaper)
                {
                    _tempbox.Add(i);
                }
            }
            wx.Write(output, _tempbox);
        }
        /// <summary>
        /// load xml (xmlreader)
        /// </summary>
        public void LoadXML2(string input)
        {
            Xml2 t1 = new Xml2();
            boxoffigure = t1.Read(input);
        }
    }
}
