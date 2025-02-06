using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessSketch
{
    public partial class Form1 : Form
    {
        // Array containing buttons representing the squares on a chess board
        public Button[,] ButtonGrid = new Button[8, 8];
        public Form1()
        {
            InitializeComponent();
            FillGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillGrid()
        {
            // Gets the size needed for height and Width for the invidual squares
            int buttonSize = panel1.Width / 8;

            // Ensures the Panel is a perfect square
            panel1.Height = panel1.Width;
            
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // Creates new button
                    ButtonGrid[row, column] = new Button();
                    // sets the width and height to the previously calculated size
                    ButtonGrid[row, column].Height = buttonSize;
                    ButtonGrid[row, column].Width = buttonSize;

                    // Adds a click event to each button
                    ButtonGrid[row, column].Click += Grid_Button_Click;

                    // Adds the button to the Panel
                    panel1.Controls.Add(ButtonGrid[row, column]);

                    //Sets the location of the buttons to appropiate locations again using the perfect size previously calculated
                    ButtonGrid[row, column].Location = new Point(row * buttonSize, column * buttonSize);

                    ButtonGrid[row, column].Text = row + "/" + column;
                }
            }

        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
