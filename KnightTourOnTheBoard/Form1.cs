using ChessBoardModel.Classes;
using ChessBoardModel.Resources;
using ChessClassLibrary;
using KnightTourOnTheBoard.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightTourOnTheBoard
{
    public partial class Form1 : Form
    {

        #region Fields
        // there is only one board ever for this app!
        static Board Board;
        private PictureBox[,] Cells;
        private Cell StartCell;

        // represents the moveNumber
        private string cellValue;

        // check for the start button activity 
        private bool isBoardFilled;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Form1()
        {
            // Simplicity is the ultimate sophistication! //

            // initialize board
            isBoardFilled = false;
            LoadBoardValues();
            Cells = new PictureBox[Board._size, Board._size];
            cellValue = "";
            InitializeComponent();
            PopulateGrid();
        }


        #region Initialize Settings and Grid Cells

        /// <summary>
        /// load standard chess board
        /// </summary>
        private void LoadBoardValues()
        {
            Board = new Board(8);
            for (int i = 0; i < Board._size; i++)
                for (int j = 0; j < Board._size; j++)
                    Board._grid[i, j].Value = Setting.ACloseTour[i, j];
        }

        /// <summary>
        /// initialize cell settings
        /// </summary>
        private void PopulateGrid()
        {
            // make sure that the board is a perfect square
            Grid.Width = Grid.Height;

            // indenting the inner squares, makes the board row and column values visible
            int cellSize = (Grid.Width - 40) / Board._size;

            for (int i = 0; i < Board._size; i++)
            {
                for (int j = 0; j < Board._size; j++)
                {
                    Cells[i, j] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(Cells[i, j])).BeginInit();

                    // the cell is also a perfect square
                    Cells[i, j].Height = cellSize;
                    Cells[i, j].Width = cellSize;

                    // some visual settings
                    Cells[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    Cells[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    Cells[i, j].BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray;
                    // half of indentation from up, down, right and left
                    Cells[i, j].Location = new Point(i * cellSize + 20, j * cellSize + 20);

                    // used for overriding toString method, as well as practicability
                    Cells[i, j].Name = Board._grid[i, j].Name;

                    // when we are valuing the cells, which picture box calls the event? check by this tag
                    Cells[i, j].Tag = new Tag() { _location = new Point(i, j), _value = Board._grid[i, j].Value };
                    Cells[i, j].Click += GridCellClick;

                    Grid.Controls.Add(Cells[i, j]);
                    ((System.ComponentModel.ISupportInitialize)(Cells[i, j])).EndInit();
                }
            }
        }
        #endregion


        #region Valuing the Cells

        /// <summary>
        /// assigning the move numbers to the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // we are sure that the sender is a picturebox of a grid cell
            PictureBox currentCell = (PictureBox)sender;

            // we had set the tag is of type tag
            Tag tag = (Tag)currentCell.Tag;
            Point location = tag._location;

            // cell value settings
            Font btnFont = new Font("Arial", 12);

            // since I used a closed tour, incrementing or decrementing each value by the
            // same amount will not affect the order. They are uniquely sorted in mod 64
            // first adding 64 then taking mod, prevents the negative values            
            int value = (tag._value - StartCell.Value + 64) % 64;
            cellValue = value + "";
            var size = g.MeasureString(cellValue, btnFont);            
                        
            // prints the value at the center of the cell.
            g.DrawString(cellValue, btnFont, Brushes.Blue,
                (currentCell.Width - size.Width) / 2, (currentCell.Height - size.Height) / 2);

        }

        /// <summary>
        /// start cell activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCellClick(object sender, EventArgs e)
        {
            PictureBox currentCell = (PictureBox)sender;
            Point location = ((Tag)currentCell.Tag)._location;

            // make sure that other cells are cleaned
            ClearColors();
            Cells[location.X, location.Y].BackColor = Color.Red;
            Cells[location.X, location.Y].Image = ((System.Drawing.Image)(Resources.Knight));
            Board.SetCurrentCell(location.X, location.Y);
        }
        #endregion


        #region Start Reset Print Menu

        /// <summary>
        /// I am adding animation, making the knight visiting cells visually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void start_Click(object sender, EventArgs e)
        {
            // if the board is filled, reset the application
            if (!isBoardFilled)
            {
                StartCell = Board._currentCell;
                Knight knight = new Knight(StartCell);
                int nextValue = StartCell.Value == 64 ? 1 : StartCell.Value + 1;
                await GoToNextMove(knight, nextValue);               
            }
            else
                MessageBox.Show(Resources.ResetApplication);
        }

        private async Task GoToNextMove(Knight knight, int value)
        {
            if (value == StartCell.Value)
                isBoardFilled = true;
            else
            {
                foreach (var cell in knight.NextMove.ToList().Where(m => m != null))
                {
                    if (cell.Value == value)
                    {
                        knight.Move(cell);
                        int nextValue = value == 64 ? 1 : value + 1;
                        Cells[cell.RowNumber, cell.ColumnNumber].BackColor = Color.Red;
                        Cells[cell.RowNumber, cell.ColumnNumber].Paint += new PaintEventHandler(this.pictureBox1_Paint);
                        Thread.Sleep(800);
                        await Task.Run(() => GoToNextMove(knight, nextValue));
                    }
                }
            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            // the board cells can be reinitialized as well
            Application.Restart();
        }
        private void print_Click(object sender, EventArgs e)
        {
            var output = "";
            for (int col = 0; col < Board._size; col++)
            {
                for (int row = 0; row < Board._size; row++)
                    if (row == Board._currentCell.RowNumber && col == Board._currentCell.ColumnNumber)
                        output += "start    ";
                    else
                        output += Board._grid[row, col].Value + (Cells[row, col].Text.Length > 1 ? "\t" : "\t ");
                output += "\n\n\n";
            }

            // used try catch, for some reason file may not be created 
            try
            {
                var path = @"C:\Users\yasin\OneDrive\Masaüstü\AkınSoftChessApp\Outpts\DataFor";
                var fileName = path + StartCell.Name + ".txt";
                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                file.Directory.Create(); // If the directory already exists, this method does nothing.
                File.WriteAllText(fileName, output);
                MessageBox.Show(Resources.FileSuccess);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.FileError);
            }
        }

        #endregion

        /// <summary>
        /// changing the start button should reset the old one
        /// can be used for reset button as well
        /// </summary>
        private void ClearColors()
        {
            int r = Board._currentCell.RowNumber;
            int c = Board._currentCell.ColumnNumber;
            Cells[r, c].Image = null;
            Cells[r, c].BackColor = (r + c) % 2 == 0 ? Color.White : Color.Gray;
        }

    }
}
