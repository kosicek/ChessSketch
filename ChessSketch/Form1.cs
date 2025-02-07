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

        private GameState gameState;
        public Form1()
        {
            InitializeComponent();
            FillGrid();

            gameState = new GameState(Team.White,Board.Intial());
            RenderBoard(gameState.Board);
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
            
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
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
                    ButtonGrid[row, column].Location = new Point(column * buttonSize, row * buttonSize);
                    // Debug
                    ButtonGrid[row, column].Text = row + "/" + column;
                    // Gives Tags for event
                    ButtonGrid[row, column].Tag = new Point(row,column);

                    //Sets some basic visuals
                    ButtonGrid[row, column].BackColor = Color.Transparent;
                    ButtonGrid[row, column].FlatStyle = FlatStyle.Flat;
                    ButtonGrid[row, column].FlatAppearance.BorderSize = 0;
                    ButtonGrid[row, column].FlatAppearance.MouseOverBackColor = Color.Transparent;
                    ButtonGrid[row, column].FlatAppearance.MouseDownBackColor = Color.LightGreen;
                    ButtonGrid[row, column].BackgroundImageLayout = ImageLayout.Zoom;
                }
            }

        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // get the button clicked
            Button clicked = (Button)sender;

        }

        private void RenderBoard(Board board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    ChessPiece piece = board[row, column];
                    ButtonGrid[row, column].BackgroundImage = Images.GetImage(piece);
            }
            }   
        }
    }
}
