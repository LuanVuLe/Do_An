using System;
using System.Windows;

namespace Do_An
{
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string maSo = txtUsername.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(maSo))
            {
                MessageBox.Show("Vui lòng nhập mã số!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string accountType = null;
            if (rdQuanLy.IsChecked == true) accountType = "Quản lý";
            else if (rdHocSinh.IsChecked == true) accountType = "Học sinh - Phụ huynh";
            else if (rdGiaoVien.IsChecked == true) accountType = "Giáo viên - Nhân viên";

            if (string.IsNullOrEmpty(accountType))
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra tiền tố mã số với vai trò
            if (maSo.StartsWith("QL") && accountType != "Quản lý")
            {
                MessageBox.Show("Mã số này thuộc Quản lý, bạn đã chọn sai vai trò!",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (maSo.StartsWith("HS") && accountType != "Học sinh - Phụ huynh")
            {
                MessageBox.Show("Mã số này thuộc Học sinh/Phụ huynh, bạn đã chọn sai vai trò!",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (maSo.StartsWith("GV") && accountType != "Giáo viên - Nhân viên")
            {
                MessageBox.Show("Mã số này thuộc Giáo viên/Nhân viên, bạn đã chọn sai vai trò!",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!(maSo.StartsWith("QL") || maSo.StartsWith("HS") || maSo.StartsWith("GV")))
            {
                MessageBox.Show("Mã số không hợp lệ! Vui lòng nhập đúng định dạng (QL/HS/GV...).",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Nếu hợp lệ -> mở Step2 và truyền mã số
            ForgotPasswordStep2 step2 = new ForgotPasswordStep2(maSo);
            step2.Owner = this;
            this.Hide();
            step2.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            else
            {
                LoginWindow login = new LoginWindow();
                login.Show();
            }
        }
    }
}
