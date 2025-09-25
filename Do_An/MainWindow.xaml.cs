using System.Windows;

namespace Do_An
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text?.Trim() ?? "";
            string password = txtPassword.Password?.Trim() ?? "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: xử lý đăng nhập thật sự (kiểm tra DB...)
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ForgotPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ForgotPasswordWindow forgot = new ForgotPasswordWindow();
            forgot.Owner = this; // chỉ định cha
            this.Hide();         // ẩn login đi
            forgot.ShowDialog(); // mở form quên mật khẩu

            this.Show(); // khi đóng forgot thì hiện lại login
        }
    }
}
