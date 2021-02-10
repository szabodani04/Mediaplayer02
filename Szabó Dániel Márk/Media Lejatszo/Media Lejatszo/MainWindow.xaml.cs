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
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;

namespace Media_Lejatszo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer media;
        List<List<string>> elemek = new List<List<string>>();
        int repeater = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            
            InitializeComponent();
            media = new MediaPlayer();
            //DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            onerepeate.Visibility = Visibility.Hidden;
            volume.Value = 0.5;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if ((media.Source != null) && (media.NaturalDuration.HasTimeSpan))
                {
                    slider.Value = media.Position.TotalSeconds;
                    timelabel.Content = String.Format("{0} / {1}", media.Position.ToString(@"mm\:ss"), media.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
                else
                    timelabel.Content = "00:00 / 00:00";
            }
            catch (Exception)
            {

                return;
            }
            try
            {
                cim.Content = elemek[list.SelectedIndex][1];
            }
            catch (Exception)
            {

                return;
            }

        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog(); //Az állomány megnyitási ablak létrehozása
            openfile.Multiselect = true;
            openfile.Title = "Zeneválasztás";
            openfile.Filter = "Media fájlok (*.mp3)|*.mp3|Minden állomány (*.*)|*.*";
            openfile.ShowDialog();
            for (int i = 0; i < openfile.FileNames.Length; i++)
            {
                elemek.Add(new List<string> { openfile.FileNames[i], openfile.SafeFileNames[i] });
            }
            list.ItemsSource = elemek.Select(x => x[1]);
            list.SelectedIndex = 0;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void changed(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                media.Open(new Uri(elemek[list.SelectedIndex][0]));
                
            }
            catch (Exception)
            {
                return;
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                media.Open(new Uri(elemek[list.SelectedIndex +1][0]));
                media.Play();
                list.SelectedIndex += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                try
                {
                    media.Open(new Uri(elemek[0][0]));
                    media.Play();
                    list.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    cim.Content = "Nincsen zene kiválasztva!";
                }
                
            }
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                media.Open(new Uri(elemek[list.SelectedIndex - 1][0]));
                media.Play();
                list.SelectedIndex -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                try
                {
                    media.Open(new Uri(elemek[elemek.Count - 1][0]));
                    media.Play();
                    list.SelectedIndex = elemek.Count - 1;

                }
                catch (Exception)
                {
                cim.Content = "Nincsen zene kiválasztva!";
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                elemek.RemoveAt(list.SelectedIndex); //a kiválasztott elem elemek listában megfelelő indexű elemét kitörli
            }
            catch
            {
                return;
            }
            list.ItemsSource = elemek.Select(x => x[1]);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Lejátszási lista mentése";
            save.Filter = "Configurációs állomány (*.json)|*.json|Minden állomány (*.*)|*.*";
            save.DefaultExt = ".json";
            save.CheckPathExists = true;
            if (save.ShowDialog() == true)
            {
                WriteToBinaryFile<List<List<string>>>(save.FileName, elemek);
            }
        }
        ///@Szabodani
        /// </summary>
        /// <typeparam name="T">The type of object being written to the binary file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the binary file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the binary file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Title = "Lejátszási lista betöltése";
            load.Filter = "Configurációs állomány (*.json)|*.json|Minden állomány (*.*)|*.*";
            load.DefaultExt = ".json";
            load.CheckPathExists = true;
            if (load.ShowDialog() == true)
            {
                elemek = ReadFromBinaryFile<List<List<string>>>(load.FileName);
            }
            list.ItemsSource = elemek.Select(x => x[1]);
            list.SelectedIndex = 0;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                slider.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds; //a zenével módosítja a slider helyét
                cim.Content = ("");
            }
            catch (Exception)
            {
                cim.Content = ("Nincsen zene kiválasztva!");
                return;
            }
            if (slider.Value == slider.Maximum)
            {
                if (repeater == 0)
                {
                    try
                    {
                        media.Open(new Uri(elemek[list.SelectedIndex + 1][0]));
                        media.Play();
                        list.SelectedIndex += 1;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        media.Open(new Uri(elemek[0][0]));
                        media.Play();
                        list.SelectedIndex = 0;
                    }
                }
                else
                {
                        media.Open(new Uri(elemek[list.SelectedIndex][0]));
                        media.Play();
                }
            }
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                media.Volume = (double)volume.Value; //hangerő állítása
            }
            catch (Exception)
            {
                return;
            } 
        }

        private void slieder_lost(object sender, MouseEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, Convert.ToInt32(slider.Value)); //Ahova a slidert mozgatjuk oda ugrik a zene
            media.Play();
            timer.Start();
        }

        private void onerepeate_Click(object sender, RoutedEventArgs e)
        {
            repeater = 0;
            onerepeate.Visibility = Visibility.Hidden;
            repeat.Visibility = Visibility.Visible;
        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            repeater = 1;
            onerepeate.Visibility = Visibility.Visible;
            repeat.Visibility = Visibility.Hidden;
        }

        private void volumeup_Click(object sender, RoutedEventArgs e)
        {
            volume.Value += 0.1;
        }

        private void volumeup_Copy_Click(object sender, RoutedEventArgs e)
        {
            volume.Value -= 0.1;
        }

        private void slider_GotMouseCapture(object sender, MouseEventArgs e)
        {
            media.Pause();
            timer.Stop();
        }
    }
}