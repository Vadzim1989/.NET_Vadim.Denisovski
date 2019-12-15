using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Shapes;
using Task3.FigureBoxException;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Task3.FigureBox
{
    public class FigureBox
    {
        /// <summary>
        /// Using LIST
        /// </summary>
        public List<Figure> Box = new List<Figure>(30);
        /// <summary>
        /// Constructor
        /// </summary>
        public FigureBox() { }
        /// <summary>
        /// Method to add some figure to BOX
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="material"></param>
        public void AddFigureToBox(Figure figure, Material material)
        {
            if (Box.Count == 20)
                throw new FullBoxEx();
            foreach (Figure SomeFigure in Box)
            {
                if (figure.Equals(SomeFigure))
                    throw new ExistFigureEx();
            }
            Box.Add(figure);
        }
        /// <summary>
        /// Check exception by number
        /// </summary>
        /// <param name="number"></param>
        private void CheckException(int number = 2)
        {
            if (Box.Count == 0)
            {
                throw new EmptyBoxEx();
            }
            if (number > Box.Count)
            {
                throw new InvalidNumEx(Box.Count);
            }
            if (number <= 0)
            {
                throw new NegativeNumEx();
            }
        }
        /// <summary>
        /// Method to find figure by number
        /// </summary>
        /// <param name="num"></param>
        public void FindByNum(int num)
        {
            CheckException(num);

            for (int i = 0; i < Box.Count; i++)
            {
                if (i == num - 1)
                    Box[i].ToString();
            }
        }
        /// <summary>
        /// Remove figure by number
        /// </summary>
        /// <param name="num"></param>
        public void RemoveByNum(int num)
        {
            CheckException(num);
            Box.RemoveAt(num - 1);
        }
        /// <summary>
        /// Change figure by number
        /// </summary>
        /// <param name="num"></param>
        /// <param name="figure"></param>
        public void ChangeByNum(int num, Figure figure)
        {
            CheckException(num);
            Box.Insert(num - 1, figure);
        }
        /// <summary>
        /// Find figure in BOX
        /// </summary>
        /// <param name="figure"></param>
        public void FindFigureInBox(Figure figure)
        {
            bool flag = false;
            foreach (Figure SomeFigure in Box)
            {
                if(figure.Equals(SomeFigure))
                {
                    flag = true;
                    figure.ToString();
                }
            }
            if (flag = true)
                throw new Exception("There is no such figure");
        }
        /// <summary>
        /// Method to show exist figure
        /// </summary>
        public void ShowExistFigure()
        {
            foreach (Figure SomeFigure in Box)
            {
                SomeFigure.ToString();
            }
        }
        /// <summary>
        /// Get perimeters of figures
        /// </summary>
        /// <returns></returns>
        public double GetPerimeterFigures()
        {
            CheckException();
            double result = 0;
            foreach (Figure SomeFigure in Box)
            {
                result += SomeFigure.GetPerimeter();
            }
            return result;
        }
        /// <summary>
        /// Get squares of figures
        /// </summary>
        /// <returns></returns>
        public double GetSquareFigures()
        {
            CheckException();
            double result = 0;
            foreach (Figure SomeFigure in Box)
            {
                result += SomeFigure.GetSquare();
            }
            return result;
        }
        /// <summary>
        /// Remove all triange
        /// </summary>
        public void RemoveAllTriangle()
        {
            foreach (Figure SomeFigure in Box.ToArray())
            {
                if (SomeFigure is Triangle)
                    Box.Remove(SomeFigure);
            }
        }
        /// <summary>
        /// Remove all circle
        /// </summary>
        public void RemoveAllCircle()
        {
            foreach (Figure SomeFigure in Box.ToArray())
            {
                if (SomeFigure is Circle)
                    Box.Remove(SomeFigure);
            }
        }
        /// <summary>
        /// Remove all quadrate
        /// </summary>
        public void RemoveAllQuadrate()
        {
            foreach (Figure SomeFigure in Box.ToArray())
            {
                if (SomeFigure is Quadrate)
                    Box.Remove(SomeFigure);
            }
        }
        /// <summary>
        /// Remove all films figures
        /// </summary>
        public void RemoveAllFilmFigure()
        {
            foreach (Figure SomeFigure in Box.ToArray())
            {
                if (SomeFigure.Material==Material.FIlm)
                    Box.Remove(SomeFigure);
            }
        }
        /// <summary>
        /// Remove all papers figures
        /// </summary>
        public void RemoveAllFilmPaper()
        {
            foreach (Figure SomeFigure in Box.ToArray())
            {
                if (SomeFigure.Material == Material.Paper)
                    Box.Remove(SomeFigure);
            }
        }
        /// <summary>
        /// using XML
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="filePath"></param>
        public void SaveFigures(List<Figure> figures, string filePath)
        {
            XmlWriter writer = XmlWriter.Create(filePath);

            writer.WriteStartDocument();
            writer.WriteStartElement("figures");

            foreach (Figure item in figures)
            {
                writer.WriteStartElement("figure");
                writer.WriteStartElement(Figure.GetFType(item));
                writer.WriteAttributeString("material", Figure.GetFMaterial(item));
                if (item.Material == Material.Paper && item.IsPainted == true)
                {
                    writer.WriteAttributeString("color", item.Colors.ToString());
                }
                writer.WriteEndElement();

            }
            writer.WriteEndDocument();
            writer.Close();
        }
        /// <summary>
        /// Get films figures
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetFilmFigure()
        {
            List<Figure> filmFigure = new List<Figure>();
            foreach (Figure SomeFigure in Box)
            {
                if (SomeFigure.Material == Material.FIlm)
                    filmFigure.Add(SomeFigure);
            }
            return filmFigure;
        }
        /// <summary>
        /// Get papers figures
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetPaperFigure()
        {
            List<Figure> paperFigure = new List<Figure>();
            foreach (Figure SomeFigure in Box)
            {
                if (SomeFigure.Material == Material.FIlm)
                    paperFigure.Add(SomeFigure);
            }
            return paperFigure;
        }

        public List<Figure> GetFiguresFromFile(string filePath)
        {
            List<Figure> figures = new List<Figure>();
            Figure figure = null;

            XmlReader reader = XmlReader.Create(filePath);
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && ((reader.Name == "Circle") || (reader.Name == "Triangle") || (reader.Name == "Rectangle") || (reader.Name == "Square")))
                {
                    if (reader.HasAttributes)
                    {
                        figure.Material = (Material)Enum.Parse(typeof(Material), reader.GetAttribute("material"));
                        reader.MoveToNextAttribute();
                        if (reader.Name == "color")
                        {
                            figure.Colors = (Colors)Enum.Parse(typeof(Colors), reader.GetAttribute("color"));
                        }
                    }
                }

                figures.Add(figure);
            }

            return figures;
        }
        /// <summary>
        /// using StreamReader
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// Document
        /// </returns>
        private XmlDocument LoadDocument(string filePath)
        {
            XmlDocument document = new XmlDocument();
            using (StreamReader stream = new StreamReader(filePath))
            {
                document.Load(stream);
            }
            return (document);
        }
        /// <summary>
        /// using StreamWriter
        /// </summary>
        /// <param name="document"></param>
        /// <param name="filePath"></param>
        /// <returns>
        /// Document
        /// </returns>
        private XmlDocument SaveDocument(XmlDocument document, string filePath)
        {
            using (StreamWriter stream = new StreamWriter(filePath))
            {
                document.Save(stream);
            }
            return (document);
        }
    }
}
