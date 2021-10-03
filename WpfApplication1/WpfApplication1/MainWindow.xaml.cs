using System;
using System.Diagnostics;
using System.IO.Packaging;
using System.Windows;

namespace WpfApplication1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Help_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            MessageBox.Show("Cette application a été créer dans le cadre d'un TP en C#, le but de cette application est de pouvoir coder et décoder un message quelconque en Caesar, en Vigenère et en Hexadécimal.", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        private void Exit_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the "??" operator checks for nullability and value all at once.
            // because ConvertCheckBox.IsChecked is of type __bool ?__ which
            // is a nullable boolean, so it can either be true, false or null
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var inputKey = InputKeyTextBox.Text;
            var encryptionmethod = EncryptionComboBox.Text;
            
            /*OutputTextBox.Text = toDecrypt
                ? $"{inputText} is gibberish and should be decrypted using {encryptionmethod}"
                : $"{inputText} was written as an input to be encrypted using {encryptionmethod}";*/

            switch (encryptionmethod)
            {
                case "Caesar":
                    try
                    {
                        OutputTextBox.Text = Caesar.Code(inputText, toDecrypt, inputKey);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        MessageBox.Show("Key : NaN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Hexadecimal":
                    OutputTextBox.Text = Hex.Code(inputText, toDecrypt);
                    break;
                case "Vigenere":
                    OutputTextBox.Text = Vigenere.Code(inputText, toDecrypt, inputKey);
                    break;
            }
        }
    }
}