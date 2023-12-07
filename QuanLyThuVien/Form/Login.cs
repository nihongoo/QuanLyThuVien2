using BUS.Service;
using DAL.Models;
using Microsoft.VisualBasic.Logging;

namespace QuanLyThuVien
{
    public partial class Login : Form
    {
        UserSev UserSev;
        public Login()
        {
            InitializeComponent();
            UserSev = new UserSev();
        }
        public static string role;

        private void bt_Login_Click(object sender, EventArgs e)
        {
            string UserName = txt_UserName.Text;
            string Pass = txt_Pass.Text;

            if (UserSev.Check(UserName, Pass))
            {
                //kiểm tra tài khoản có đúng ko
                role = UserSev.GetRole(UserName);
                //kiểm tra quyền
                switch (role)
                {
                    case "admin":
                        MainAdmin mainAdmin = new MainAdmin();
                        mainAdmin.Show();
                        break;
                    case "user":
                        MainTT mainTT = new MainTT();
                        mainTT.Show();
                        break;
                    case "bdh":
                        Main main = new Main();
                        main.Show();
                        break;
                    default:
                        MessageBox.Show("Sai tên người dùng hoặc mật khẩu");
                        break;
                        //hiện main
                }
                this.Hide();//ẩn form login nhưng nó vẫn chạy ngầm
                //nếu đang chạy ngầm form login mà đóng form main thì chương trình sẽ ko đóng hẳn
            }
            else
            {
                MessageBox.Show("Sai tên người dùng hoặc mật khẩu");
            }


        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            txt_UserName.Text = txt_UserName.Text.Trim();
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {
            txt_Pass.Text = txt_Pass.Text.Trim();
        }
    }
}