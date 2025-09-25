using System;
using System.Windows;

namespace Do_An
{
    public partial class ForgotPasswordStep2 : Window
    {
        private readonly string maSo;
        private string otpCode;

        public ForgotPasswordStep2(string maSo)
        {
            InitializeComponent();
            this.maSo = maSo;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string emailOrPhone = txtEmailOrUsername.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(emailOrPhone))
            {
                MessageBox.Show("Vui lòng nhập Email hoặc số điện thoại!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sinh OTP ngẫu nhiên 6 số
            otpCode = new Random().Next(100000, 999999).ToString();

            // Giả lập gửi mã
            MessageBox.Show($"Mã xác minh (OTP) đã được gửi đến: {emailOrPhone}\n\nMã OTP: {otpCode}",
                            "Xác minh", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }
    }
}
