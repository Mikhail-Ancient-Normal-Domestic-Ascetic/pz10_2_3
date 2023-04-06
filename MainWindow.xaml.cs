using System;
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
using Microsoft.Win32;
using System.IO;

namespace pz10_2_3
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            items.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            items1.ItemsSource = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 36, 48, 72 };
            items2.ItemsSource = new List<double>() { 1, 1.5, 2, 2.5, 3, 3.5, 5, 10, 20, 50 };
            afas.Selection.ApplyPropertyValue(Paragraph.MarginProperty, new Thickness((Double)0.5));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("кефтеме");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void afas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void afas_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = afas.Selection.GetPropertyValue(Inline.FontWeightProperty);

            bolt.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = afas.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = afas.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underliune.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = afas.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            items.SelectedItem = temp;
            temp = afas.Selection.GetPropertyValue(Inline.FontSizeProperty);
            items1.Text = temp.ToString();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (items.SelectedItem != null)
                afas.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, items.SelectedItem);

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            afas.Selection.ApplyPropertyValue(Inline.FontSizeProperty, items1.SelectedItem);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(afas.Document.ContentStart, afas.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(afas.Document.ContentStart, afas.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var send = sender as Button;
            afas.Selection.ApplyPropertyValue(Inline.ForegroundProperty, send.Background);
        }
        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {


            afas.Selection.ApplyPropertyValue(Paragraph.MarginProperty, new Thickness((Double)items2.SelectedItem));

        }
    }
}
