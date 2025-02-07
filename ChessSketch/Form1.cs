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
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();

        private GameState gameState;
        private Position selectedPos = null;
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
                    ButtonGrid[row, column].Tag = new Position(row,column);

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
            Position position = (Position)clicked.Tag;

            if (selectedPos == null)
            {
                OnFromPositionSelected(position);
            }
            else
            {
                OnToPositionSelected(position);
            }
        }

        private void OnFromPositionSelected(Position position)
        {
            IEnumerable<Move> moves = gameState.LegalMovesForPiece(position);

            if (moves.Any())
            {
                selectedPos = position;
                CacheMoves(moves);
                ShowHighlights();
            }
        }

        private void OnToPositionSelected(Position position)
        {
            selectedPos = null;
            HideHighlights();

            if (moveCache.TryGetValue(position, out Move move))
            {
                if (move.Type == MoveType.PawnPromotion)
                {
                   HandlePromotion(move.FromPos, move.ToPos);
                }
                else
                {
                HandleMove(move);
                }
                
            }
        }

        private void HandlePromotion(Position from, Position to)
        {
            panel2.Visible = true;

            PieceSelected += type =>
            {
                panel2.Visible = false;
                Move promMove = new PawnPromotion(from, to,type);
                HandleMove(promMove);
            };

        }

        private void HandleMove(Move move)
        {
            gameState.MakeMove(move);
            RenderBoard(gameState.Board);
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

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();
            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }
        }

        private void ShowHighlights()
        {
            Color color = Color.Green;
            Color color2 = Color.LightGreen;

            foreach (Position to in moveCache.Keys)
            {
                ButtonGrid[to.Row, to.Column].BackColor = color;
                ButtonGrid[to.Row, to.Column].FlatAppearance.MouseOverBackColor = color2;
            }
        }

        private void HideHighlights()
        {
            Color color = Color.Transparent;

            foreach (Position to in moveCache.Keys)
            {

                {
                    ButtonGrid[to.Row, to.Column].BackColor = color;
                    ButtonGrid[to.Row, to.Column].FlatAppearance.MouseOverBackColor = color;
                }
            }
        }

        public event Action<Piecetype> PieceSelected;

        private void button1_Click(object sender, EventArgs e)
        {
            // Queen
            PieceSelected?.Invoke(Piecetype.Queen);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Knight
            PieceSelected?.Invoke(Piecetype.Knight);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Rook
            PieceSelected?.Invoke(Piecetype.Rook);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Bishop
            PieceSelected?.Invoke(Piecetype.Bishop);
        }
    }
}
