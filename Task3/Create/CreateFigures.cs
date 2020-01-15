using Task3.Figures.Materials.Film;
using Task3.Figures.Materials.Paper;
using Task3.Figures;
using System;

namespace Task3.Create
{
    public class CreateFigures
    {
        /// <summary>
        /// Create new figure 
        /// </summary>
        /// <param name="material">Material of new figure</param>
        /// <param name="form">Form of new figure</param>
        /// <param name="ps">Array of other params</param>
        /// <returns>Figure</returns>
        public IFigure CreateFigure(Material material, Form form, params float[] ps)
        {
            IFigure figure;
            switch (material)
            {
                case Material.Film:
                    {
                        switch (form)
                        {
                            case Form.Circle:
                                {
                                    if (ps.Length == 1)
                                    {
                                        figure = new CircleMadeByFilm(ps[0]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Rectangle:
                                {
                                    if (ps.Length == 2)
                                    {
                                        figure = new RectangleMadeByFilm(ps[0], ps[1]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Square:
                                {
                                    if (ps.Length == 1)
                                    {
                                        figure = new SquareMadeByFilm(ps[0]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Triangle:
                                {
                                    if (ps.Length == 3)
                                    {
                                        figure = new TriangleMadeByFilm(ps[0], ps[1], ps[2]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            default: throw new Exception("Wrong input Form");
                        }
                        break;
                    }
                case Material.Paper:
                    {
                        switch (form)
                        {
                            case Form.Circle:
                                {
                                    if (ps.Length == 1)
                                    {
                                        figure = new CircleMadeByPaper(ps[0]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Rectangle:
                                {
                                    if (ps.Length == 2)
                                    {
                                        figure = new RectangleMadeByPaper(ps[0], ps[1]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Square:
                                {
                                    if (ps.Length == 1)
                                    {
                                        figure = new SquareMadeByPaper(ps[0]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            case Form.Triangle:
                                {
                                    if (ps.Length == 3)
                                    {
                                        figure = new TriangleMadeByPaper(ps[0], ps[1], ps[2]);
                                        break;
                                    }
                                    else throw new Exception("Wrong input parameters");
                                }
                            default: throw new Exception("Wrong input Form");
                        }
                        break;
                    }
                default: throw new Exception("Wrong input Material");
            }
            return figure;
        }
    }
}
