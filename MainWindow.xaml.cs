using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDZ
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string name = "Иванов";
		TextBox message;
		StackPanel chat;
		ScrollViewer viewer;
		StackPanel contact_panel;
		Dictionary<string, StackPanel> mess;
		public MainWindow()
		{
			InitializeComponent();
			var main_doc = new DockPanel();
			main_doc.Background = Brushes.Silver;
			Content = main_doc;

			var message_doc = new DockPanel();
			message_doc.Background = Brushes.Bisque;
			message_doc.Margin = new Thickness(3);
			DockPanel.SetDock(message_doc, Dock.Bottom);
			main_doc.Children.Add(message_doc);

			var send = new Button();
			DockPanel.SetDock(send, Dock.Right);
			message_doc.Children.Add(send);
			send.Padding = new Thickness(7);
			send.Margin = new Thickness(3);
			send.Content = "ОТПРАВИТЬ";
			send.IsDefault = true;
			send.Click += Send_Click;

			message = new TextBox();
			message.TextWrapping = TextWrapping.Wrap;
			message.Margin = new Thickness(3, 3, 0, 3);
			message_doc.Children.Add(message);

			contact_panel = new StackPanel();
			DockPanel.SetDock(contact_panel, Dock.Right);
			main_doc.Children.Add(contact_panel);
			contact_panel.Background = Brushes.Green;
			contact_panel.Margin = new Thickness(3, 3, 3, 0);
			Button b1 = new Button() { Content = "Иванов", Margin = new Thickness(3) };
			Button b2 = new Button() { Content = "Петров", Margin = new Thickness(3) };
			Button b3 = new Button() { Content = "Сидоров", Margin = new Thickness(3) };
			Button b4 = new Button() { Content = "Табуреткин", Margin = new Thickness(3) };
			Button b5 = new Button() { Content = "Креветкин", Margin = new Thickness(3) };
			Button b6 = new Button() { Content = "Собакин", Margin = new Thickness(3) };
			Button b7 = new Button() { Content = "Кошкин", Margin = new Thickness(3) };
			Button b8 = new Button() { Content = "Галкин", Margin = new Thickness(3) };
			Button b9 = new Button() { Content = "Палкин", Margin = new Thickness(3) };
			contact_panel.Children.Add(b1); b1.Click += B_Click;
			contact_panel.Children.Add(b2); b2.Click += B_Click;
			contact_panel.Children.Add(b3); b3.Click += B_Click;
			contact_panel.Children.Add(b4); b4.Click += B_Click;
			contact_panel.Children.Add(b5); b5.Click += B_Click;
			contact_panel.Children.Add(b6); b6.Click += B_Click;
			contact_panel.Children.Add(b7); b7.Click += B_Click;
			contact_panel.Children.Add(b8); b8.Click += B_Click;
			contact_panel.Children.Add(b9); b9.Click += B_Click;

			viewer = new ScrollViewer();
			chat = new StackPanel();
			viewer.Content = chat;
			chat.Orientation = Orientation.Vertical;
			main_doc.Children.Add(viewer);
			chat.Margin = new Thickness(3, 3, 0, 0);
			chat.Background = Brushes.White;
			mess = new Dictionary<string, StackPanel>();
			mess.Add(name, chat);
		}

		private void B_Click(object sender, RoutedEventArgs e)
		{
			bool second = false;
			if (((Button)sender).Content.ToString() == name) return;
			foreach (Button but in contact_panel.Children)
			{
				if (second) break;
				if (name == but.Content.ToString())
				{
					mess[name] = chat;
					name = (sender as Button).Content.ToString();
					chat.Children.Clear();
					if (mess.TryGetValue(name, out StackPanel tmp))
						chat = tmp;
					second = true;
				}
			}
		}

		private void Send_Click(object sender, RoutedEventArgs e)
		{
			if (message.Text == "") return;
			Label label = new Label() { Content = message.Text };
			label.Background = Brushes.Beige;
			label.Margin = new Thickness(1, 2, 1, 0);
			chat.Children.Add(label);
			message.Clear();
		}
	}
}