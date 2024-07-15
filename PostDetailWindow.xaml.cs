using Avalonia.Controls;
using Avalonia.Interactivity;
using SalfetkaBlog.Models;

namespace SalfetkaBlog.Views
{
    public partial class PostDetailWindow : Window
    {
        private Post Post { get; set; }

        public PostDetailWindow(Post post)
        {
            InitializeComponent();
            Post = post;
            TitleTextBox.Text = post.Title;
            ContentTextBox.Text = post.Content;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Post.Title = TitleTextBox.Text;
            Post.Content = ContentTextBox.Text;
            Close(Post);
        }
    }
}
