using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace AlgoritmoBacktrackingInterfazGrafica
{
    public partial class SUDOKU : Form
    {

        Sudoku sudoku = new Sudoku();
        int[,] tablero1 = new int[9, 9];

        public SUDOKU()
        {

            InitializeComponent();
            tableroVacio();
            formatoTextBox();
            validacionTextBox(); //TODO
            esconderMenu(); //TODO
        }


        public void validacionTextBox() //TODO
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.KeyPress += tB00_KeyPress;
                    }
                }
            }
        }


        public void formatoTextBox()
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.Multiline = true;
                        textBox.Size = new System.Drawing.Size(55, 55);

                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tB00_TextChanged(object sender, EventArgs e)
        {

        }


        public void tableroVacio()
        {

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        tablero1[fila, columna] = 0;
                        textBox.Text = "";
                    }
                }
            }
        }



        private void resolver_Click(object sender, EventArgs e)
        {
            bool bandera = true;

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text != "") { bandera = false; }
                        

                    }
                }
            }

            if (bandera)
            {
                MessageBox.Show("El tablero esta vacio");
                return;
            }
            bool solucionable;

            sudoku.Dimension = tablero1.GetLength(0);

            solucionable = sudoku.resolver(tablero1);

            if (solucionable)
            {

                for (int fila = 0; fila < 9; fila++)
                {
                    for (int columna = 0; columna < 9; columna++)
                    {
                        string nombreControl = "tB" + fila.ToString() + columna.ToString();

                        Control[] controles = this.Controls.Find(nombreControl, true);

                        if (controles.Length > 0 && controles[0] is TextBox textBox)
                        {
                            textBox.Text = tablero1[fila, columna].ToString();

                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("El tablero no tiene solucion");
            }
        }

        private void comprobarSolucion_Click(object sender, EventArgs e)
        {

            bool bandera = true;

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text == "")
                        {
                            bandera = true;
                            break;
                        }
                        else { bandera = false; }

                    }
                }
            }

            if (bandera)
            {
                MessageBox.Show("El tablero esta incompleto");
                return;
            }

            int[,] tablero2 = new int[9, 9];

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text == "") { textBox.Text = "0"; }
                        tablero1[fila, columna] = Convert.ToInt32(textBox.Text);
                    }
                }
            }
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text == "") { textBox.Text = "0"; }
                        tablero2[fila, columna] = Convert.ToInt32(textBox.Text);
                    }
                }
            }


            sudoku.Dimension = tablero2.GetLength(0);
            Boolean solucionable = sudoku.resolver(tablero2);

            static bool SonMatricesIguales(int[,] matriz1, int[,] matriz2)
            {
                int filas = matriz1.GetLength(0);
                int columnas = matriz1.GetLength(1);

                if (matriz2.GetLength(0) != filas || matriz2.GetLength(1) != columnas)
                {
                    return false;
                }

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (matriz1[i, j] != matriz2[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            bool sonIguales = SonMatricesIguales(tablero2, tablero1);

            if (sonIguales)
            {
                MessageBox.Show("La solucion es correcta");
            }
            else
            {
                MessageBox.Show("La solucion es incorrecta");
            }
        }

        private void tB00_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                int digit = int.Parse(e.KeyChar.ToString());
                if (digit < 1 || digit > 9)
                {
                    e.Handled = true;
                }
                else if (textBox.Text.Length > 0)
                {
                    e.Handled = true; 
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool bandera;

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text == "") { textBox.Text = "0"; }
                        tablero1[fila, columna] = Convert.ToInt32(textBox.Text);
                    }
                }
            }

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    if (tablero1[fila, columna] != 0)
                    {
                        bandera = sudoku.esPosibleInsertar(tablero1, fila, columna, tablero1[fila, columna]);
                        if (!bandera)
                        {
                            MessageBox.Show("El tablero ingresado no tiene solucion");
                            return;
                        }
                    }
                }
            }

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.Text = tablero1[fila, columna].ToString();
                        if (textBox.Text == "0") { textBox.Text = ""; }
                        if (textBox.Text != "") { textBox.Enabled = false; }
                    }
                }
            }
        }

        bool MatrizLlenaDeCeros(int[,] matriz)
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    if (matriz[fila, columna] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public void esconderMenu() //TODO
        {
            panelOpciones.Visible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int[,] tablero3 = new int[9, 9];

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        if (textBox.Text == "") { textBox.Text = "0"; }
                        tablero3[fila, columna] = Convert.ToInt32(textBox.Text);
                    }
                }
            }


            if (ValidarSudoku(tablero3))
            {
                tablero1 = tablero3;
                for (int fila = 0; fila < 9; fila++)
                {
                    for (int columna = 0; columna < 9; columna++)
                    {
                        string nombreControl = "tB" + fila.ToString() + columna.ToString();

                        Control[] controles = this.Controls.Find(nombreControl, true);

                        if (controles.Length > 0 && controles[0] is TextBox textBox)
                        {
                            textBox.Text = tablero1[fila, columna].ToString();
                            if (textBox.Text == "0") { textBox.Text = ""; }
                            if (textBox.Text != "") { textBox.Enabled = false; }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El tablero ingresado no es valido");
                tableroVacio();
            }

        }

        bool ValidarSudoku(int[,] matriz)
        {
            for (int fila = 0; fila < 9; fila++)
            {
                HashSet<int> filaSet = new HashSet<int>();
                HashSet<int> columnaSet = new HashSet<int>();
                for (int columna = 0; columna < 9; columna++)
                {
                    // Verificación en la fila
                    if (matriz[fila, columna] != 0)
                    {
                        if (!filaSet.Add(matriz[fila, columna]))
                        {
                            return false;
                        }
                    }

                    // Verificación en la columna
                    if (matriz[columna, fila] != 0)
                    {
                        if (!columnaSet.Add(matriz[columna, fila]))
                        {
                            return false;
                        }
                    }
                }
            }

            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    HashSet<int> submatrizSet = new HashSet<int>();
                    for (int fila = i; fila < i + 3; fila++)
                    {
                        for (int columna = j; columna < j + 3; columna++)
                        {
                            if (matriz[fila, columna] != 0)
                            {
                                if (!submatrizSet.Add(matriz[fila, columna]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void buttonoOpciones_Click(object sender, EventArgs e)
        {
            if (panelOpciones.Visible == false)
            {
                panelOpciones.Visible = true;
            }
            else
            {
                panelOpciones.Visible = false;
            }
        }

        private void buttonGenerarJuegoAutomatico_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.Enabled = true;

                    }
                }
            }
            tableroVacio();
            sudoku.Dimension = tablero1.GetLength(0);
            tablero1 = sudoku.GenerarTablero();

            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.Text = tablero1[fila, columna].ToString();
                        if (textBox.Text == "0") { textBox.Text = ""; }
                        if (textBox.Text != "") { textBox.Enabled = false; }
                    }
                }
            }
        }

        private void buttongGenerarTableroBlanco_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < 9; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    string nombreControl = "tB" + fila.ToString() + columna.ToString();

                    Control[] controles = this.Controls.Find(nombreControl, true);

                    if (controles.Length > 0 && controles[0] is TextBox textBox)
                    {
                        textBox.Enabled = true;

                    }
                }
            }

            tableroVacio();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panelMenuLat.Visible == false)
            {
                panelMenuLat.Visible = true;
                for (int fila = 0; fila < 9; fila++)
                {
                    for (int columna = 0; columna < 9; columna++)
                    {
                        string nombreControl = "tB" + fila.ToString() + columna.ToString();

                        Control[] controles = this.Controls.Find(nombreControl, true);

                        if (controles.Length > 0 && controles[0] is TextBox textBox)
                        {
                            textBox.Location = new System.Drawing.Point(textBox.Location.X + 275, textBox.Location.Y);
                        }
                    }
                }
                pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X + 375, pictureBox2.Location.Y);
            }
            else
            {
                panelMenuLat.Visible = false;
                for (int fila = 0; fila < 9; fila++)
                {
                    for (int columna = 0; columna < 9; columna++)
                    {
                        string nombreControl = "tB" + fila.ToString() + columna.ToString();

                        Control[] controles = this.Controls.Find(nombreControl, true);

                        if (controles.Length > 0 && controles[0] is TextBox textBox)
                        {
                            textBox.Location = new System.Drawing.Point(textBox.Location.X - 275, textBox.Location.Y);
                        }
                    }
                }
                pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X - 375, pictureBox2.Location.Y);
            }
        }
    }
}