using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Matrice
{
    public partial class Form1 : Form

    {
        private bool matrix1Filled = false;
        private bool matrix2Filled = false;
        public Form1()
        {
            InitializeComponent();

            this.textBox1.KeyPress += new KeyPressEventHandler(OnlyNumbers);
            this.textBox2.KeyPress += new KeyPressEventHandler(OnlyNumbers);
            this.textBox5.KeyPress += new KeyPressEventHandler(OnlyNumbers);
            this.textBox6.KeyPress += new KeyPressEventHandler(OnlyNumbers);
            //this.textBox3.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            //this.textBox4.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = "-0123456789.";
            if (!str.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-')
            {
                System.Windows.Forms.TextBox txtBox = sender as System.Windows.Forms.TextBox;
                if (txtBox.Text.Length > 0 && txtBox.Text[0] == '-')
                {
                    e.Handled = true;
                }
            }
        }
        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n, m;
                int.TryParse(textBox1.Text, out n);
                int.TryParse(textBox2.Text, out m);
                if (n > 100 || m > 100)
                {
                    MessageBox.Show("Введите размер до 100");
                    return;
                }
                dataGridView1.RowCount = n;
                dataGridView1.ColumnCount = m;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView1.Columns[j].Width = 60;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView1[j, i].Value = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Цифры надо");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int n, m;
                int.TryParse(textBox1.Text, out n);
                int.TryParse(textBox2.Text, out m);
                dataGridView3.RowCount = m;
                dataGridView3.ColumnCount = n;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView3[i, j].Value = dataGridView1[j, i].Value;
                        if (j == n - 1)
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите матрицу");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int n, m;
                int.TryParse(textBox5.Text, out n);
                int.TryParse(textBox6.Text, out m);
                if (n > 100 || m > 100)
                {
                    MessageBox.Show("Введите размер до 100");
                    return;
                }
                dataGridView2.RowCount = n;
                dataGridView2.ColumnCount = m;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView2.Columns[j].Width = 60;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView2[j, i].Value = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Цифры надо");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                int n, m;
                int.TryParse(textBox1.Text, out n);
                int.TryParse(textBox2.Text, out m);
                dataGridView3.RowCount = m;
                dataGridView3.ColumnCount = n;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView3[i, j].Value = dataGridView2[j, i].Value;
                        if (j == n - 1)
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите матрицу");
            }
        }
        // Умножение на число
        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int n = dataGridView1.RowCount;
            //    int m = dataGridView1.ColumnCount;
            //    int x = int.Parse(textBox3.Text);
            //    dataGridView3.RowCount = n;
            //    dataGridView3.ColumnCount = m;
            //    int[,] a = new int[n, m];
            //    int[,] c = new int[n, m];
            //    for (int i = 0; i < n; i++)
            //        for (int j = 0; j < m; j++)
            //            a[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
            //    for (int i = 0; i < n; i++)
            //        for (int j = 0; j < m; j++)
            //        {
            //            c[i, j] = a[i, j] * x;
            //            dataGridView3[i, j].Value = c[i, j];
            //        }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Введите число");
            //}
            try
            {
                int n = dataGridView1.RowCount;
                int m = dataGridView1.ColumnCount;
                double x = double.Parse(textBox3.Text);
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = m;
                double[,] a = new double[n, m];
                double[,] c = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = a[i, j] * x;
                        dataGridView3[j, i].Value = c[i, j];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите число");
            }



        }
        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int n = dataGridView2.RowCount;
            //    int m = dataGridView2.ColumnCount;
            //    int x = int.Parse(textBox4.Text);
            //    dataGridView3.RowCount = n;
            //    dataGridView3.ColumnCount = m;
            //    int[,] a = new int[n, m];
            //    int[,] c = new int[n, m];
            //    for (int i = 0; i < n; i++)
            //        for (int j = 0; j < m; j++)
            //            a[i, j] = Convert.ToInt32(dataGridView2[i, j].Value);
            //    for (int i = 0; i < n; i++)
            //        for (int j = 0; j < m; j++)
            //        {
            //            c[i, j] = a[i, j] * x;
            //            dataGridView3[i, j].Value = c[i, j];
            //        }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Введите число");
            //}
            try
            {
                int n = dataGridView2.RowCount;
                int m = dataGridView2.ColumnCount;
                double x = double.Parse(textBox4.Text);
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = m;
                double[,] a = new double[n, m];
                double[,] c = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = a[i, j] * x;
                        dataGridView3[j, i].Value = c[i, j];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите число");
            }
        }
        // Сложение
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == textBox2.Text)
                {
                    int n;
                    int.TryParse(textBox2.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    double[,] a = new double[n, n];
                    double[,] b = new double[n, n];
                    double[,] c = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = Convert.ToDouble(dataGridView1[i, j].Value);
                            b[i, j] = Convert.ToDouble(dataGridView2[i, j].Value);
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            c[i, j] = a[i, j] + b[i, j];
                            dataGridView3[i, j].Value = c[i, j];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Складывать можно только матрицы одинакового размера");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите матрицы");
            }
        }
        // Вычитание
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == textBox2.Text)
                {
                    int n;
                    int.TryParse(textBox2.Text, out n);
                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    double[,] a = new double[n, n];
                    double[,] b = new double[n, n];
                    double[,] c = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = Convert.ToDouble(dataGridView1[i, j].Value);
                            b[i, j] = Convert.ToDouble(dataGridView2[i, j].Value);
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            c[i, j] = a[i, j] - b[i, j];
                            dataGridView3[i, j].Value = c[i, j];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Вычитать можно только матрицы одинакового размера");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите матрицы");
            }
        }
        //Умножение
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dataGridView1.RowCount;
                int m = dataGridView2.ColumnCount;
                int p = dataGridView1.ColumnCount;
                if (p != dataGridView2.RowCount)
                {
                    MessageBox.Show("Нельзя умножить матрицы с данными размерами");
                    return;
                }
                dataGridView3.RowCount = n;
                dataGridView3.ColumnCount = m;
                double[,] a = new double[n, p];
                double[,] b = new double[p, m];
                double[,] c = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < p; j++)
                    {
                        a[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                }
                for (int i = 0; i < p; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        b[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < p; k++)
                        {
                            c[i, j] += a[i, k] * b[k, j];
                        }
                        dataGridView3[j, i].Value = c[i, j];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите матрицы");
            }
            //try
            //{


            //    if (textBox1.Text == textBox2.Text)
            //    {
            //        int n, v;
            //        int.TryParse(textBox2.Text, out n);
            //        dataGridView3.RowCount = n;
            //        dataGridView3.ColumnCount = n;
            //        int[,] a = new int[n, n];
            //        int[,] b = new int[n, n];
            //        for (int i = 0; i < n; i++)
            //            for (int j = 0; j < n; j++)
            //                a[j, i] = Convert.ToInt32(dataGridView1[i, j].Value);
            //        for (int i = 0; i < n; i++)
            //            for (int j = 0; j < n; j++)
            //                b[j, i] = Convert.ToInt32(dataGridView2[i, j].Value);

            //        for (int i = 0; i < n; i++)
            //        {
            //            for (int j = 0; j < n; j++)
            //            {
            //                v = 0;
            //                for (int r = 0; r < n; r++)
            //                    v += a[i, r] * b[r, j];
            //                dataGridView3[i, j].Value = v;

            //            }
            //        }
            //    }

            //    else
            //        MessageBox.Show("Умножать матрицы можно только когда количество столбцов первой матрицы равно количеству строк второй матрицы");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Введите матрицы");
            //}
        }


        private double Determinant(double[,] matrix, int n)
        {
            double det = 0;
            if (n == 1)
            {
                det = matrix[0, 0];
            }
            else if (n == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else // Рекурсия
            {
                for (int i = 0; i < n; i++)
                {
                    double[,] subMatrix = new double[n - 1, n - 1];
                    for (int j = 1; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (k < i) // Если индекс столбца меньше i, то элемент записывается в подматрицу без изменений
                                subMatrix[j - 1, k] = matrix[j, k];
                            else if (k > i) // Если индекс столбца больше i, то элемент записывается в подматрицу со сдвигом на одну позицию влево
                                subMatrix[j - 1, k - 1] = matrix[j, k];
                        }
                    }
                    // Вычисление определителя с добавлением или вычитанием определителя подматрицы, умноженного на соответствующий элемент
                    det += Math.Pow(-1, i) * matrix[0, i] * Determinant(subMatrix, n - 1);
                }
            }
            return det;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                int.TryParse(textBox1.Text, out n);
                double[,] matrix = new double[n, n];

                if (AreAllValuesSet(dataGridView1, n, n))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                        }
                    }

                    double determinant = Determinant(matrix, n);

                    dataGridView3.RowCount = 1;
                    dataGridView3.ColumnCount = 1;
                    dataGridView3[0, 0].Value = determinant;
                }
                else
                {
                    MessageBox.Show("Заполните все значения матрицы.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте определителя: {ex.Message}", "Error!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                int.TryParse(textBox5.Text, out n);
                double[,] matrix = new double[n, n];

                if (AreAllValuesSet(dataGridView2, n, n))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                        }
                    }

                    double determinant = Determinant(matrix, n);

                    dataGridView3.RowCount = 1;
                    dataGridView3.ColumnCount = 1;
                    dataGridView3[0, 0].Value = determinant;
                }
                else
                {
                    MessageBox.Show("Заполните все значения матрицы.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте определителя: {ex.Message}", "Error!");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                int.TryParse(textBox1.Text, out n);
                double[,] matrix = new double[n, n];

                if (AreAllValuesSet(dataGridView1, n, n))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                        }
                    }

                    double[,] inverseMatrix = CalculateInverseMatrix(matrix, n);

                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            dataGridView3[j, i].Value = inverseMatrix[i, j];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все значения матрицы.");
                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте обратной матрицы: {ex.Message}", "Error!");
            }
        }

        //обратная матрицы
        private double[,] CalculateInverseMatrix(double[,] matrix, int n)
        {
            double det = Determinant(matrix, n);

            // Проверка делимости на ноль
            if (det == 0)
            {
                throw new DivideByZeroException("Детерминант матрицы равен 0. Невозможно вычислить обратную матрицу.");
            }

            double[,] adjointMatrix = CalculateAdjointMatrix(matrix, n);
            double[,] inverseMatrix = new double[n, n];

            // Получение обратной матрицы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverseMatrix[i, j] = adjointMatrix[i, j] / det;
                }
            }

            return inverseMatrix;
        }

        //Алгеб доп
        private double[,] CalculateAdjointMatrix(double[,] matrix, int n)
        {
            double[,] adjointMatrix = new double[n, n];

            if (n == 1)
            {
                adjointMatrix[0, 0] = 1;
                return adjointMatrix;
            }

            double sign = 1;
            double[,] subMatrix = new double[n, n];

            // Вычисление алгебраического дополнения для каждого элемента матрицы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GetSubMatrix(matrix, subMatrix, i, j, n);
                    sign = ((i + j) % 2 == 0) ? 1 : -1;
                    adjointMatrix[j, i] = sign * Determinant(subMatrix, n - 1);
                }
            }

            return adjointMatrix;
        }

        // Функция для получения подматрицы, исключая указанную строку и столбец
        private void GetSubMatrix(double[,] matrix, double[,] subMatrix, int p, int q, int n)
        {
            int i = 0, j = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)
                    {
                        subMatrix[i, j++] = matrix[row, col];

                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                int.TryParse(textBox5.Text, out n);
                double[,] matrix = new double[n, n];

                if (AreAllValuesSet(dataGridView2, n, n))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                        }
                    }

                    double[,] inverseMatrix = CalculateInverseMatrix(matrix, n);

                    dataGridView3.RowCount = n;
                    dataGridView3.ColumnCount = n;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            dataGridView3[j, i].Value = inverseMatrix[i, j];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все значения матрицы.");
                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте обратной матрицы: {ex.Message}", "Error!");
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
        }


        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewTextBoxEditingControl textBox = (DataGridViewTextBoxEditingControl)sender;

            if (e.KeyChar == '-')
            {
                if (textBox.Text.Contains("-"))
                {
                    e.Handled = true;
                }
                else
                {
                    textBox.Text = "-" + textBox.Text;
                    textBox.SelectionStart = 1;
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ',')
            {
                if (textBox.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
            else if (char.IsDigit(e.KeyChar) && textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            e.Control.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button14_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '-')
            {
                if (textBox.Text.Contains("-"))
                {
                    e.Handled = true;
                }
                else
                {
                    textBox.Text = "-" + textBox.Text;
                    textBox.SelectionStart = 1;
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ',')
            {
                if (textBox.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
            else if (char.IsDigit(e.KeyChar) && textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '-')
            {
                if (textBox.Text.Contains("-"))
                {
                    e.Handled = true;
                }
                else
                {
                    textBox.Text = "-" + textBox.Text;
                    textBox.SelectionStart = 1;
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ',')
            {
                if (textBox.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
            else if (char.IsDigit(e.KeyChar) && textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                int n = (int)dataGridView3.RowCount;
                int m = (int)dataGridView3.ColumnCount;
                dataGridView1.RowCount = n;
                dataGridView1.ColumnCount = m;

                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        dataGridView1[i, j].Value = dataGridView3[i, j].Value;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Результат может копироваться только для первой матрицы");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    dataGridView2[j, i].Value = dataGridView3[j, i].Value;
                }
            }
        }
        private bool AreAllValuesSet(DataGridView dgv, int rows, int columns)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

      

        private void button15_Click(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        dataGridView1[j, i].Value = dataGridView3[j, i].Value;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Результат может копироваться только для первой матрицы");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
    }
}