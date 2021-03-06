﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

namespace Cube1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Stage
        {
            public double Num { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
        }

        List<Stage> stages = new List<Stage>();

        public void SimpleDataGridSample()
        {
            InitializeComponent();
                        
            stages.Add(new Stage() { Num = 1, Width = 0.6, Height = 0.1 });
            stages.Add(new Stage() { Num = 2, Width = 0.8, Height = 0.2 });
            stages.Add(new Stage() { Num = 3, Width = 0.6, Height = 0.1 });

            dgDims.ItemsSource = stages;
        }

        // Core dimensions
        double YY = 2;
        double LL = 4;
        double MW = 0.8;
        double H = 0.1;

        Model3DGroup modelGroup = new Model3DGroup();

        MeshGeometry3D MCentreLeg(double offsetZ)
        {
            MeshGeometry3D centreLeg = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            corners.Add(new Point3D(0, YY/2, H + offsetZ));
            corners.Add(new Point3D(MW/2, YY/2 - MW/2, H + offsetZ));
            corners.Add(new Point3D(MW/2, -(YY/2 - MW/2), H + offsetZ));
            corners.Add(new Point3D(0, -YY/2, H + offsetZ));
            corners.Add(new Point3D(-MW/2, -(YY/2 - MW/2), H + offsetZ));
            corners.Add(new Point3D(-MW/2, YY/2 - MW/2, H + offsetZ));

            corners.Add(new Point3D(0, YY/2, -H + offsetZ));
            corners.Add(new Point3D(MW/2, YY/2 - MW/2, -H + offsetZ));
            corners.Add(new Point3D(MW/2, -(YY/2 - MW/2), -H + offsetZ));
            corners.Add(new Point3D(0, -YY/2, -H + offsetZ));
            corners.Add(new Point3D(-MW/2, -(YY/2 - MW/2), -H + offsetZ));
            corners.Add(new Point3D(-MW/2, YY/2 - MW/2, -H + offsetZ));
            centreLeg.Positions = corners;
            Int32[] indices ={
            //top
              0,5,1,
              1,5,2,
              5,4,2,
              2,4,3,
            //bottom
              6,7,11,
              7,8,11,
              11,8,10,
              8,9,10,
            //right 
              1,2,8,
              7,1,8,
            //left
              5,11,4,
              10,4,11,
            //top right
              0,1,6,
              6,1,7,
            //top left
              0,6,5,
              6,11,5,
            //bottom right
              2,3,9,
              9,8,2,
            //bottom left
              4,10,9,
              9,3,4
            };
            
            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            centreLeg.TriangleIndices = Triangles;
            return centreLeg;            
        }

        MeshGeometry3D MLeftLeg(double offsetZ)
        {
            MeshGeometry3D leftLeg = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            corners.Add(new Point3D(-(LL/2 + MW/2),YY/2 + MW/2,H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),YY/2 - MW/2,H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),-(YY/2 - MW/2),H + offsetZ));
            corners.Add(new Point3D(-(LL/2 + MW/2),-(YY/2 + MW/2),H + offsetZ));

            corners.Add(new Point3D(-(LL/2 + MW/2),YY/2 + MW/2,-H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),YY/2 - MW/2,-H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),-(YY/2 - MW/2),-H + offsetZ));
            corners.Add(new Point3D(-(LL/2 + MW/2),-(YY/2 + MW/2),-H + offsetZ));
            leftLeg.Positions = corners;
            Int32[] indices ={
            //top
              0,2,1,
              0,3,2,
            //bottom
              4,5,6,
              4,6,7,
            //right 
              1,2,5,
              2,6,5,
            //left
              0,4,3,
              4,7,3,
            //top
              0,1,4,
              4,1,5,
            //bottom
              2,3,7,
              2,7,6
            };

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            leftLeg.TriangleIndices = Triangles;
            return leftLeg;            
        }

        MeshGeometry3D MRightLeg(double offsetZ)
        {
            MeshGeometry3D rightLeg = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            corners.Add(new Point3D((LL/2 + MW/2),YY/2 + MW/2,H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),YY/2 - MW/2,H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),-(YY/2 - MW/2),H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),-(YY/2 + MW/2),H + offsetZ));

            corners.Add(new Point3D((LL/2 + MW/2),YY/2 + MW/2,-H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),YY/2 - MW/2,-H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),-(YY/2 - MW/2),-H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),-(YY/2 + MW/2),-H + offsetZ));
            rightLeg.Positions = corners;
            Int32[] indices ={
            //top
              0,2,1,
              0,3,2,
            //bottom
              4,5,6,
              4,6,7,
            //right 
              1,2,5,
              2,6,5,
            //left
              0,4,3,
              4,7,3,
            //top
              0,1,4,
              4,1,5,
            //bottom
              2,3,7,
              2,7,6
            };

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            rightLeg.TriangleIndices = Triangles;
            return rightLeg;            
        }

        MeshGeometry3D MUpperYoke(double offsetZ)
        {
            MeshGeometry3D upperYoke = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            corners.Add(new Point3D(-(LL/2 + MW/2),YY/2 + MW/2,H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),YY/2 + MW/2,H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),YY/2 - MW/2,H + offsetZ));
            corners.Add(new Point3D(MW/2, YY/2 - MW/2, H + offsetZ));
            corners.Add(new Point3D(0, YY/2, H + offsetZ));
            corners.Add(new Point3D(-MW/2, YY/2 - MW/2, H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),YY/2 - MW/2,H + offsetZ));
            
            corners.Add(new Point3D(-(LL/2 + MW/2),YY/2 + MW/2,-H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),YY/2 + MW/2,-H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),YY/2 - MW/2,-H + offsetZ));
            corners.Add(new Point3D(MW/2, YY/2 - MW/2, -H + offsetZ));
            corners.Add(new Point3D(0, YY/2, -H + offsetZ));
            corners.Add(new Point3D(-MW/2, YY/2 - MW/2,- H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),YY/2 - MW/2,-H + offsetZ));
            upperYoke.Positions = corners;
            Int32[] indices ={
            //top
              0,4,1,
              0,6,4,
              6,5,4,
              4,3,2,
              4,2,1,
            //bottom
              7,8,11,
              7,11,13,
              13,11,12,
              11,8,9,
              11,9,10,
            //right 
              1,2,9,
              1,9,8,
            //left
              0,13,6,
              0,7,13,
            //top
              0,1,8,
              0,8,7,
            //bottom left
              6,13,12,
              6,12,5,
            //bottom right
              3,10,2,
              10,9,2,
            //V left
              5,12,4,
              12,11,4,
            //V right
              4,11,10,
              4,10,3
            };

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            upperYoke.TriangleIndices = Triangles;
            return upperYoke;            
        }

        MeshGeometry3D MBottomYoke(double offsetZ)
        {
            MeshGeometry3D bottomYoke = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            corners.Add(new Point3D(-(LL/2 + MW/2),-(YY/2 + MW/2),H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),-(YY/2 + MW/2),H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),-(YY/2 - MW/2),H + offsetZ));
            corners.Add(new Point3D(MW/2, -(YY/2 - MW/2), H + offsetZ));
            corners.Add(new Point3D(0, -YY/2, H + offsetZ));
            corners.Add(new Point3D(-MW/2, -(YY/2 - MW/2), H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),-(YY/2 - MW/2),H + offsetZ));
            
            corners.Add(new Point3D(-(LL/2 + MW/2),-(YY/2 + MW/2),-H + offsetZ));
            corners.Add(new Point3D((LL/2 + MW/2),-(YY/2 + MW/2),-H + offsetZ));
            corners.Add(new Point3D((LL/2 - MW/2),-(YY/2 - MW/2),-H + offsetZ));
            corners.Add(new Point3D(MW/2, -(YY/2 - MW/2), -H + offsetZ));
            corners.Add(new Point3D(0, -YY/2, -H + offsetZ));
            corners.Add(new Point3D(-MW/2, -(YY/2 - MW/2), -H + offsetZ));
            corners.Add(new Point3D(-(LL/2 - MW/2),-(YY/2 - MW/2),-H + offsetZ));
            bottomYoke.Positions = corners;
            Int32[] indices ={
            //top
              0,4,1,
              0,6,4,
              6,5,4,
              4,3,2,
              4,2,1,
            //bottom
              7,8,11,
              7,11,13,
              13,11,12,
              11,8,9,
              11,9,10,
            //right 
              1,2,9,
              1,9,8,
            //left
              0,13,6,
              0,7,13,
            //top
              0,1,8,
              0,8,7,
            //bottom left
              6,13,12,
              6,12,5,
            //bottom right
              3,10,2,
              10,9,2,
            //V left
              5,12,4,
              12,11,4,
            //V right
              4,11,10,
              4,10,3
            };

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            bottomYoke.TriangleIndices = Triangles;
            return bottomYoke;            
        }

        MeshGeometry3D MCube()
        {
            MeshGeometry3D cube = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();
            corners.Add(new Point3D(0.5, 0.5, 0.5));
            corners.Add(new Point3D(-0.5, 0.5, 0.5));
            corners.Add(new Point3D(-0.5, -0.5, 0.5));
            corners.Add(new Point3D(0.5, -0.5, 0.5));
            corners.Add(new Point3D(0.5, 0.5, -0.5));
            corners.Add(new Point3D(-0.5, 0.5, -0.5));
            corners.Add(new Point3D(-0.5, -0.5, -0.5));
            corners.Add(new Point3D(0.5, -0.5, -0.5));
            cube.Positions = corners;
            Int32[] indices ={
            //front
              0,1,2,
              0,2,3,
            //back
              4,7,6,
              4,6,5,
            //Right
              4,0,3,
              4,3,7,
           //Left
              1,5,6,
              1,6,2,
           //Top
              1,0,4,
              1,4,5,
           //Bottom
              2,6,7,
              2,7,3
            };

            Int32Collection Triangles = new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            cube.TriangleIndices = Triangles;
            return cube;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SimpleDataGridSample();

            //GeometryModel3D CentreLeg1 = new GeometryModel3D();
            //MeshGeometry3D centreLegMesh = MCentreLeg();
            //CentreLeg1.Geometry = centreLegMesh;
            //CentreLeg1.Material = new DiffuseMaterial(
            //   new SolidColorBrush(Colors.SteelBlue));

            //GeometryModel3D LeftLeg1 = new GeometryModel3D();
            //MeshGeometry3D leftLegMesh = MLeftLeg();
            //LeftLeg1.Geometry = leftLegMesh;
            //LeftLeg1.Material = new DiffuseMaterial(
            //   new SolidColorBrush(Colors.SteelBlue));

            //GeometryModel3D RightLeg1 = new GeometryModel3D();
            //MeshGeometry3D rightLegMesh = MRightLeg();
            //RightLeg1.Geometry = rightLegMesh;
            //RightLeg1.Material = new DiffuseMaterial(
            //   new SolidColorBrush(Colors.SteelBlue));

            //GeometryModel3D UpperYoke1 = new GeometryModel3D();
            //MeshGeometry3D upperYokeMesh = MUpperYoke();
            //UpperYoke1.Geometry = upperYokeMesh;
            //UpperYoke1.Material = new DiffuseMaterial(
            //   new SolidColorBrush(Colors.Red));

            //GeometryModel3D BottomYoke1 = new GeometryModel3D();
            //MeshGeometry3D bottomYokeMesh = MBottomYoke();
            //BottomYoke1.Geometry = bottomYokeMesh;
            //BottomYoke1.Material = new DiffuseMaterial(
            //   new SolidColorBrush(Colors.Red));

            //DirectionalLight DirLight1 = new DirectionalLight();
            //DirLight1.Color = Colors.White;
            //DirLight1.Direction = new Vector3D(-1, -1, -1);

            ////DirectionalLight DirLight2 = new DirectionalLight();
            ////DirLight2.Color = Colors.White;
            ////DirLight2.Direction = new Vector3D(1, 1, 1);

            //PerspectiveCamera Camera1 = new PerspectiveCamera();
            //Camera1.FarPlaneDistance = 20;
            //Camera1.NearPlaneDistance = 1;
            //Camera1.FieldOfView = 45;
            //Camera1.Position = new Point3D(4, 4, 6);
            //Camera1.LookDirection = new Vector3D(-2, -2, -3);
            //Camera1.UpDirection = new Vector3D(0, 1, 0);

            //Model3DGroup modelGroup = new Model3DGroup();
            //modelGroup.Children.Add(CentreLeg1);
            //modelGroup.Children.Add(LeftLeg1);
            //modelGroup.Children.Add(RightLeg1);
            //modelGroup.Children.Add(UpperYoke1);
            //modelGroup.Children.Add(BottomYoke1);
            //modelGroup.Children.Add(DirLight1);
            //ModelVisual3D modelsVisual = new ModelVisual3D();
            //modelsVisual.Content = modelGroup;

            //Viewport3D myViewport = new Viewport3D();
            //myViewport.Camera = Camera1;
            //myViewport.Children.Add(modelsVisual);
            //this.Canvas1.Children.Add(myViewport);
            //myViewport.Height = 800;
            //myViewport.Width = 900;
            //Canvas.SetTop(myViewport, 0);
            //Canvas.SetLeft(myViewport, 0);
            ////this.Width = myViewport.Width;
            ////this.Height = myViewport.Height;

            //AxisAngleRotation3D axis = new AxisAngleRotation3D(
            //      new Vector3D(0, 1, 0), 0);
            //RotateTransform3D Rotate = new RotateTransform3D(axis);
            ////CentreLeg.Transform = Rotate;
            //modelGroup.Transform = Rotate;
            //DoubleAnimation RotAngle = new DoubleAnimation();
            //RotAngle.From = 0;
            //RotAngle.To = 360;
            //RotAngle.Duration = new Duration(
            //                  TimeSpan.FromSeconds(7.0));
            //RotAngle.RepeatBehavior = RepeatBehavior.Forever;

            //NameScope.SetNameScope(Canvas1, new NameScope());
            //Canvas1.RegisterName("cubeaxis", axis);

            //Storyboard.SetTargetName(RotAngle, "cubeaxis");
            //Storyboard.SetTargetProperty(RotAngle,
            // new PropertyPath(AxisAngleRotation3D.AngleProperty));
            //Storyboard RotCube = new Storyboard();
            //RotCube.Children.Add(RotAngle);
            //RotCube.Begin(Canvas1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            YY = double.Parse(txtYokeYoke.Text, CultureInfo.InvariantCulture);
            LL = double.Parse(txtLegLeg.Text, CultureInfo.InvariantCulture);
            MW = double.Parse(txtMatWidth.Text, CultureInfo.InvariantCulture);
            H = double.Parse(txtHeight.Text, CultureInfo.InvariantCulture);

            int numStgs = int.Parse(txtStages.Text);
            GeometryModel3D[] CentreLeg = new GeometryModel3D[numStgs];
            MeshGeometry3D[] centreLegMesh = new MeshGeometry3D[numStgs];            
            GeometryModel3D[] LeftLeg = new GeometryModel3D[numStgs];
            MeshGeometry3D[] leftLegMesh = new MeshGeometry3D[numStgs]; 
            GeometryModel3D[] RightLeg = new GeometryModel3D[numStgs];
            MeshGeometry3D[] rightLegMesh = new MeshGeometry3D[numStgs]; 
            GeometryModel3D[] UpperYoke = new GeometryModel3D[numStgs];
            MeshGeometry3D[] upperYokeMesh = new MeshGeometry3D[numStgs]; 
            GeometryModel3D[] BottomYoke = new GeometryModel3D[numStgs];
            MeshGeometry3D[] bottomYokeMesh = new MeshGeometry3D[numStgs]; 

            double offsetZ = 0;
            
            for (int i = 0; i < numStgs; i++)
            {
                MW = stages[i].Width;
                H = stages[i].Height;
                
                if (i > 0)
                {
                    offsetZ = offsetZ + (stages[i-1].Height + stages[i].Height);
                }
                centreLegMesh[i] = MCentreLeg(offsetZ);
                CentreLeg[i] = new GeometryModel3D();                
                CentreLeg[i].Geometry = centreLegMesh[i];
                CentreLeg[i].Material = new DiffuseMaterial(
                   new SolidColorBrush(Colors.SteelBlue));
            
                leftLegMesh[i] = MLeftLeg(offsetZ);
                LeftLeg[i] = new GeometryModel3D();
                LeftLeg[i].Geometry = leftLegMesh[i];
                LeftLeg[i].Material = new DiffuseMaterial(
                   new SolidColorBrush(Colors.SteelBlue));

                rightLegMesh[i] = MRightLeg(offsetZ);
                RightLeg[i] = new GeometryModel3D();
                RightLeg[i].Geometry = rightLegMesh[i];
                RightLeg[i].Material = new DiffuseMaterial(
                   new SolidColorBrush(Colors.SteelBlue));

                upperYokeMesh[i] = MUpperYoke(offsetZ);
                UpperYoke[i] = new GeometryModel3D();
                UpperYoke[i].Geometry = upperYokeMesh[i];
                UpperYoke[i].Material = new DiffuseMaterial(
                   new SolidColorBrush(Colors.Red));

                bottomYokeMesh[i] = MBottomYoke(offsetZ);
                BottomYoke[i] = new GeometryModel3D();
                BottomYoke[i].Geometry = bottomYokeMesh[i];
                BottomYoke[i].Material = new DiffuseMaterial(
                   new SolidColorBrush(Colors.Red));
            }

            DirectionalLight DirLight1 = new DirectionalLight();
            DirLight1.Color = Colors.White;
            DirLight1.Direction = new Vector3D(-1, -1, -1);

            AmbientLight AmbiLight1 = new AmbientLight();
            AmbiLight1.Color = Colors.White;
            
            DirectionalLight DirLight2 = new DirectionalLight();
            DirLight2.Color = Colors.White;
            DirLight2.Direction = new Vector3D(1, 1, 1);

            PerspectiveCamera Camera1 = new PerspectiveCamera();
            Camera1.FarPlaneDistance = 20;
            Camera1.NearPlaneDistance = 1;
            Camera1.FieldOfView = 45;
            Camera1.Position = new Point3D(4, 4, 6);
            Camera1.LookDirection = new Vector3D(-2, -2, -3);
            Camera1.UpDirection = new Vector3D(0, 1, 0);

            modelGroup.Children.Clear();
            for (int i = 0; i < numStgs; i++)
            {
                if ((bool)chkCL.IsChecked)
                {       modelGroup.Children.Add(CentreLeg[i]);                }
                if ((bool)chkLL.IsChecked) 
                {       modelGroup.Children.Add(LeftLeg[i]);                 }
                if ((bool)chkRL.IsChecked) 
                {       modelGroup.Children.Add(RightLeg[i]);                 }
                if ((bool)chkTY.IsChecked)
                {       modelGroup.Children.Add(UpperYoke[i]);                 }
                if ((bool)chkBY.IsChecked)
                {       modelGroup.Children.Add(BottomYoke[i]);                 }
            }

            modelGroup.Children.Add(DirLight1);
            modelGroup.Children.Add(DirLight2);
            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            Viewport3D myViewport = new Viewport3D();
            myViewport.Camera = Camera1;
            myViewport.Children.Add(modelsVisual);
            this.Canvas1.Children.Add(myViewport);
            myViewport.Height = 800;
            myViewport.Width = 900;
            Canvas.SetTop(myViewport, 0);
            Canvas.SetLeft(myViewport, 0);
            //this.Width = myViewport.Width;
            //this.Height = myViewport.Height;

            AxisAngleRotation3D axis = new AxisAngleRotation3D(
                  new Vector3D(0, 1, 0), 0);
            RotateTransform3D Rotate = new RotateTransform3D(axis);
            //CentreLeg.Transform = Rotate;
            modelGroup.Transform = Rotate;
            DoubleAnimation RotAngle = new DoubleAnimation();
            RotAngle.From = 0;
            RotAngle.To = 360;
            RotAngle.Duration = new Duration(
                              TimeSpan.FromSeconds(7.0));
            RotAngle.RepeatBehavior = RepeatBehavior.Forever;

            NameScope.SetNameScope(Canvas1, new NameScope());
            Canvas1.RegisterName("cubeaxis", axis);

            Storyboard.SetTargetName(RotAngle, "cubeaxis");
            Storyboard.SetTargetProperty(RotAngle,
             new PropertyPath(AxisAngleRotation3D.AngleProperty));
            Storyboard RotCube = new Storyboard();
            RotCube.Children.Add(RotAngle);
            RotCube.Begin(Canvas1);
        }

        private void btnUpdStgs_Click(object sender, RoutedEventArgs e)
        {
            stages.Clear();

            for (int i = 0; i < int.Parse(txtStages.Text); i++)
            {
                stages.Add(new Stage() { Num = i+1, Width = 0.6, Height = 0.1 });
            }
            
            dgDims.Items.Refresh();
        }
    }

}
