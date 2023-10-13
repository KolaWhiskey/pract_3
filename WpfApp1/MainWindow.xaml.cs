using System;
using System.Collections.Generic;
using System.IO;
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
using Lib_7;
using Lib_Array;
using Lib_New;
using Microsoft.Win32;

namespace WpfApp1
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

        int[,] matr;

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null)
            {
                tb_rez.Clear();

                int[] result = Calculation.Min(matr);
                for (int i = 0; i < result.Length; i++)
                    tb_rez.Text += $"{i + 1}={result[i]}  ";
            }
            else MessageBox.Show("Создайте таблицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программу разработал студент группы ИСП-31 Корняков Дмитрий ");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cozdanie_click(object sender, RoutedEventArgs e)
        {
            bool f1 = Int32.TryParse(tbRowCount.Text, out int rowCount), // Получаем количество рядов в матрице
                f2 = Int32.TryParse(tbColumnCount.Text, out int columnCount); // Получаем количество колонок в матрице

            if (f1 && f2 && rowCount >= 0 && columnCount >= 0)
            {
                matr = new int[rowCount, columnCount]; // Создаем матрицу
                Matrix.ItemsSource = VisualArray.ToDataTable(matr).DefaultView; // Выводим матрицу на форму
            }
            else MessageBox.Show("Введите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Zapolnenie_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = Int32.TryParse(tbRowCount.Text, out int rowCount), // Получаем количество рядов в матрице
                f2 = Int32.TryParse(tbColumnCount.Text, out int columnCount); // Получаем количество колонок в матрице

            if (f1 && f2 && rowCount >= 0 && columnCount >= 0)
            {
                matr = NewClass.Fill(rowCount, columnCount);
                Matrix.ItemsSource = VisualArray.ToDataTable(matr).DefaultView; // Выводим матрицу на форму
            }
            else MessageBox.Show("Введите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_Save(object sender, RoutedEventArgs e)
        {
            if(matr!=null)
            {
                NewClass.Save(matr);
            }
        }
    

        private void btn_Open(object sender, RoutedEventArgs e)
        {
            NewClass.Load(out matr, out Boolean isLoaded);
        }

    }
}