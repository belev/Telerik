namespace AcademyGeometry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdvancedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D circleCenter = Vector3D.Parse(splitFigString[1]);
                        double circleRadius = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(circleRadius, circleCenter);
                        break;
                    }

                case "cylinder":
                    {
                        Vector3D bottomCylinderCenter = Vector3D.Parse(splitFigString[1]);
                        Vector3D topCylinderCenter = Vector3D.Parse(splitFigString[2]);
                        double cylinderRadius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(cylinderRadius, bottomCylinderCenter, topCylinderCenter);
                        break;
                    }

                default:
                    base.ExecuteFigureCreationCommand(splitFigString);
                    break;
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        var currentFigAsIAreaMeasurable = this.currentFigure as IAreaMeasurable;

                        if (currentFigAsIAreaMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentFigAsIAreaMeasurable.GetArea());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }

                        break;
                    }

                case "volume":
                    {
                        var currentFigAsIVolumeMeasurable = this.currentFigure as IVolumeMeasurable;

                        if (currentFigAsIVolumeMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentFigAsIVolumeMeasurable.GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }

                case "normal":
                    {
                        var currentFigAsIFlat = this.currentFigure as IFlat;

                        if (currentFigAsIFlat != null)
                        {
                            var normalVector = currentFigAsIFlat.GetNormal();

                            Console.WriteLine(normalVector.ToString());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }

                default:
                    base.ExecuteFigureInstanceCommand(splitCommand);
                    break;
            }
        }
    }
}
