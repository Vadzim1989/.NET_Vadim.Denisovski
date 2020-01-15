using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;
using Task3.Figures;
using Task3.Create;
using IOXml;

namespace Task3.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Xml_Tests()
        {
            CreateFigures factory = new CreateFigures();
            Box figures = new Box();

            float[] vs = new float[] { 3f, 2f };
            float[] vs1 = new float[] { 31f };
            float[] vs2 = new float[] { 3f, 2.1f, 5f };
            float[] vs3 = new float[] { 11f };
            float[] vs4 = new float[] { 17f, 0.9f };
            float[] vs5 = new float[] { 9f, 7f };
            
            figures.AddFigure(factory.CreateFigure(Material.Film, Form.Rectangle, vs));
            figures.AddFigure(factory.CreateFigure(Material.Paper, Form.Circle, vs1));
            figures.AddFigure(factory.CreateFigure(Material.Film, Form.Triangle, vs2));
            figures.AddFigure(factory.CreateFigure(Material.Film, Form.Square, vs3));
            figures.AddFigure(factory.CreateFigure(Material.Paper, Form.Rectangle, vs4));
            figures.AddFigure(factory.CreateFigure(Material.Paper, Form.Rectangle, vs5));
          
            figures.SaveXMLAll("output_1_all.xml");
            figures.SaveXMLFilm("output_1_film.xml");
            figures.SaveXMLPaper("output_1_paper.xml");
            figures.SaveXML2All("output_2_all.xml");
            figures.SaveXML2Film("output_2_film.xml");
            figures.SaveXML2Paper("output_2_paper.xml");
            figures.LoadXML("input1.xml");
            figures.LoadXML2("input2.xml");
            figures.SaveXMLAll("output_i1_all.xml");
            figures.SaveXML2All("output_i2_all.xml");
            Assert.IsNotNull(figures);
        }
    }
}
