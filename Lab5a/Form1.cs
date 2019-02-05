/*
  Class:  Form1.cs
  Author: Arpit Patel
  Student ID: 000762465
  Date:   Decembner 7, 2018

*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5a
{
    public partial class Form1 : Form
    {
        int y = 400;
        private Graphics g;                         //Encapsulates a GDI+ drawing surface
        private Pen lineColor,bucketFillColor;                              //Pens are used to draw objects
        private Font f;                             //Defines a particular format for text, including font face, size, and style attributes
        private SolidBrush b;                       //Brushes are used to fill graphics shapes
        private Color c = Color.Blue;              //Represents a color, initially set to black
        SolidBrush bucketColor ;

        
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(frmMain_Paint);  //Registers the Paint event handler

            bucketColor = new SolidBrush(Color.White);
        }

        /// <summary>
        /// set main fram for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;                          //Get the Graphics object from the PaintEventArgs
            lineColor = new Pen(Color.Black);                          //Create a new Pen using the current colour
           
            b = new SolidBrush(c);                   //Create a new brush using the current colour

            g = this.CreateGraphics();               //Create a graphics object

            g.DrawLine(lineColor, 160, 300, 160, 400);        //Draw two intersecting lines using the current Pen
            g.DrawLine(lineColor, 160, 400, 350, 400);
            g.DrawLine(lineColor, 350, 400, 350, 300);

           

        }


        /// <summary>
        /// Choose color using this button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = c;                //Display with the previous colour already chosen
            colorDialog.ShowDialog();             //Display the actual dialog box
            c = colorDialog.Color;                //Save the colour choice the user made
        }

        /// <summary>
        /// Close form usin this button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// tick bar event for increase the speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            
            timer.Interval = 120 - trackBar.Value * 10;
            
            b = new SolidBrush(c);
            bucketFillColor = new Pen(c);

           // trackBar.Minimum = 1;
            //trackBar.Maximum= 10;
            //trackBar.TickFrequency = 10;
            //trackBar.LargeChange = 100;
            //trackBar.SmallChange = 10;

            if (trackBar.Value > 0 )
            {
                g = this.CreateGraphics();
                g.FillRectangle(b, 190, 185, 14, 215);
                timer.Start();
            }
            

            timer.Interval = 120 - trackBar.Value * 11;
            
        }

        /// <summary>
        /// Timer tick listener stop and set background color in inside bucket and rectangle 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {

            y--;
            g.DrawLine(bucketFillColor, 349, y, 161, y);

            if (y == 300)
            {
                y = 400;
                timer.Enabled = false;
                timer.Stop();
                 
                g.FillRectangle(bucketColor, 161,300,189,100);
                g.FillRectangle(bucketColor, 190, 182, 14, 214);
            }

        }


    }
}
