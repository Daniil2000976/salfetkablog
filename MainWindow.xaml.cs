using Avalonia.Controls;
using Avalonia.Interactivity;
using SalfetkaBlog.Models;
using System;
using System.Collections.ObjectModel;

namespace SalfetkaBlog.Views
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Post> Posts { get; set; }
        private int nextId = 1;

        public MainWindow()
        {
            InitializeComponent();
            Posts = new ObservableCollection<Post>();
            PostListBox.Items = Posts;
        }

        private async void AddPost_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post
            {
                Id = nextId++,
                Title = "New Post",
                Content = "Post content",
                Date = DateTime.Now
            };
            var detailWindow = new PostDetailWindow(newPost);
            var result = await detailWindow.ShowDialog<Post>(this);
            if (result != null)
            {
                Posts.Add(result);
            }
        }

        private async void EditPost_Click(object sender, RoutedEventArgs e)
        {
            if (PostListBox.SelectedItem is Post selectedPost)
            {
                var detailWindow = new PostDetailWindow(new Post
                {
                    Id = selectedPost.Id,
                    Title = selectedPost.Title,
                    Content = selectedPost.Content,
                    Date = selectedPost.Date
                });
                var result = await detailWindow.ShowDialog<Post>(this);
                if (result != null)
                {
                    selectedPost.Title = result.Title;
                    selectedPost.Content = result.Content;
                    PostListBox.Items = null;
                    PostListBox.Items = Posts;
                }
            }
        }

        private void DeletePost_Click(object sender, RoutedEventArgs e)
        {
            if (PostListBox.SelectedItem is Post selectedPost)
            {
                Posts.Remove(selectedPost);
            }
        }
    }
}
