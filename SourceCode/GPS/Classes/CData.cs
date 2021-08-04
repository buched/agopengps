using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{
    
    public class CData
    {
        
        private readonly FormGPS mf;

       
        public int DataValue = 128;
        public bool isDataMap = true;
       





        //used to determine if section was off and now is on or vice versa
       


        //constructor
        public CData(FormGPS _f)
        {
            mf = _f;
            //if (mf != null)
            //{
            //    gl = _gl;
            //}
        }



      



        public vec2 RotatePoint(vec2 p1, vec2 p2, double angle)
        {

            double radians = ConvertToRadians(angle);
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            // Translate point back to origin
            p1.easting -= p2.easting;
            p1.northing -= p2.northing;

            // Rotate point
            double xnew = p1.easting * cos - p1.northing * sin;
            double ynew = p1.easting * sin + p1.northing * cos;

            // Translate point back
            vec2 newPoint = new vec2(xnew + p2.easting, ynew + p2.northing);
            return newPoint;
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }



        public void DrawCircle(double radius)
        {
            //GL.Disable(EnableCap.Texture2D);


            GL.Enable(EnableCap.Blend);
            
            GL.Color4(.2f, .5f, .2f, 0.5f);
           

            double theta = 6.28 / 20;
            double c = Math.Cos(theta);//precalculate the sine and cosine
            double s = Math.Sin(theta);
            double x = 0;
            double y =0;
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.TriangleFan);
            x += radius;
            GL.Vertex3(x, y, 0.0);

            for (int ii = 0; ii < 21; ii++)
            {
                //output vertex
                //GL.Vertex3(x, y, 0.0);

                //apply the rotation matrix
                double t = x;
                x = ((c * x) - (s * y));
                y = (s * t) + (c * y);
                GL.Vertex3(x, y, 0.0);
            }
            GL.End();

            GL.Color4(.2f, .9f, .2f, .2f);
            
            x =0;
            y =0;
            GL.LineWidth(2);
            GL.Begin(PrimitiveType.LineLoop);
            x += radius;
            GL.Vertex3(x, y, 0.0);

            for (int ii = 0; ii < 21; ii++)
            {
                //output vertex
                //GL.Vertex3(x, y, 0.0);

                //apply the rotation matrix
                double t = x;
                x = ((c * x) - (s * y));
                y = (s * t) + (c * y);
                GL.Vertex3(x, y, 0.0);
            }
            GL.End();




            

        }
        public void DrawCircle2(double radius)
        {
            //GL.Disable(EnableCap.Texture2D);


            GL.Enable(EnableCap.Blend);
           
            GL.Color4(.5f, .2f, .2f, 0.2f);
            double theta = 6.28 / 20;
            double c = Math.Cos(theta);//precalculate the sine and cosine
            double s = Math.Sin(theta);
            double x = 0;
            double y = 0;
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.TriangleFan);
            x += radius;
            GL.Vertex3(x, y, 0.0);

            for (int ii = 0; ii < 21; ii++)
            {
                //output vertex
                //GL.Vertex3(x, y, 0.0);

                //apply the rotation matrix
                double t = x;
                x = ((c * x) - (s * y));
                y = (s * t) + (c * y);
                GL.Vertex3(x, y, 0.0);
            }
            GL.End();

            GL.Color4(.1f, .1f, .1f, .8f);

            x = 0;
            y = 0;
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.LineLoop);
            x += radius;
            GL.Vertex3(x, y, 0.0);

            for (int ii = 0; ii < 21; ii++)
            {
                //output vertex
                //GL.Vertex3(x, y, 0.0);

                //apply the rotation matrix
                double t = x;
                x = ((c * x) - (s * y));
                y = (s * t) + (c * y);
                GL.Vertex3(x, y, 0.0);
            }
            GL.End();






        }

        public void DrawData()
        {

          

            }
        
    }//class
}//namespace