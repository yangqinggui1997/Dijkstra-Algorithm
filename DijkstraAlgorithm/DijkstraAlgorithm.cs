using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DijkstraAlgorithm
{
    public partial class frmDijkstraAlgorithm : Form
    {
        public frmDijkstraAlgorithm()
        {
            InitializeComponent();
        }
        private bool flag = false, flag1 = false, flag2 = false, flag3 = false, flag4 = false, flag5 = false, flag6 = false;
        private List<char> listDinh = new List<char>();
        private List<char> listKe = new List<char>();
        private List<int> listTrongSo = new List<int>();
        private List<int> listTro = new List<int>();
        List<PointF> listpoint = new List<PointF>();
        PointF k;

        private void frmDijkstraAlgorithm_Load(object sender, EventArgs e)
        {
            UnEnableControl();
        }
        private void UnEnableControl()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnVe.Enabled = false;
            btnDuyet.Enabled = false;
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
            dgvMinhHoaDuyet.Enabled = false;
            dgvThongTinDT.Enabled = false;
            txtCanh.Enabled = false;
            txtDinhDau.Enabled = false;
            txtDinhCuoi.Enabled = false;
            txtTrongSo.Enabled = false;
            lblCanh.Enabled = false;
            lblDinhDau.Enabled = false;
            lblDinhCuoi.Enabled = false;
            lblTrongSo.Enabled = false;
            lblSoCanh.Enabled = false;
            txtSoCanh.Enabled = false;
            btnRefresh.Enabled = false;
            lblDinhxuatphat.Enabled = false;
            cbDinhxuatphat.Enabled = false;
            dgvDuongDiNN.Enabled = false;
            btnChonLoaiDT.Enabled = true;
            rdbCohuong.Enabled = false;
            rdbVohuong.Enabled = false;
            btnKiemTraLienThong.Enabled = false;
            picDoThi.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag4 == true)
            {
                if (txtSoCanh.Text != "" && dgvThongTinDT.RowCount - 1 == int.Parse(txtSoCanh.Text))
                {
                    MessageBox.Show("Số cạnh đã nhập đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                btnThem.Enabled = false;
                btnHuy.Enabled = true;
                btnCapNhat.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnDuyet.Enabled = false;
                btnVe.Enabled = false;
                txtCanh.Enabled = true;
                txtDinhDau.Enabled = true;
                txtDinhCuoi.Enabled = true;
                txtTrongSo.Enabled = true;
                lblCanh.Enabled = true;
                lblDinhDau.Enabled = true;
                lblDinhCuoi.Enabled = true;
                lblTrongSo.Enabled = true;
                txtCanh.Text = "";
                txtDinhCuoi.Text = "";
                txtDinhDau.Text = "";
                txtTrongSo.Text = "";
                if (dgvThongTinDT.RowCount == 1)
                {
                    lblSoCanh.Enabled = true;
                    txtSoCanh.Enabled = true;
                    txtSoCanh.ReadOnly = false;
                    txtSoCanh.Focus();
                }
                else if (dgvThongTinDT.RowCount > 1)
                {
                    dgvThongTinDT.Enabled = true;
                    lblSoCanh.Enabled = true;
                    txtSoCanh.Enabled = true;
                    txtSoCanh.ReadOnly = true;
                    btnRefresh.Enabled = false;
                    txtCanh.Focus();
                    if (dgvThongTinDT.RowCount >= 4)
                    {
                        btnKiemTraLienThong.Enabled = false;
                    }
                }
                flag5 = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (dgvThongTinDT.CurrentRow.Index == dgvThongTinDT.NewRowIndex)
                {
                    MessageBox.Show("Hãy chọn dòng có thông tin!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCanh.Text.ToCharArray()[0] != txtDinhDau.Text.ToCharArray()[0] || txtCanh.Text.ToCharArray()[1] != txtDinhCuoi.Text.ToCharArray()[0])
                {
                    MessageBox.Show("Thông tin đỉnh đầu và đỉnh cuối phải tương ứng với cạnh vừa sửa!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txtCanh.Text.ToCharArray()[0] != txtDinhDau.Text.ToCharArray()[0])
                    {
                        txtDinhDau.Focus();
                    }
                    if (txtCanh.Text.ToCharArray()[1] != txtDinhCuoi.Text.ToCharArray()[0])
                    {
                        txtDinhCuoi.Focus();
                    }
                    return;
                }
                else
                {
                    dgvThongTinDT[0, dgvThongTinDT.CurrentRow.Index].Value = txtCanh.Text;
                    dgvThongTinDT[1, dgvThongTinDT.CurrentRow.Index].Value = txtDinhDau.Text;
                    dgvThongTinDT[2, dgvThongTinDT.CurrentRow.Index].Value = txtDinhCuoi.Text;
                    dgvThongTinDT[3, dgvThongTinDT.CurrentRow.Index].Value = txtTrongSo.Text;

                    Remote.WriteFromDGVToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                    dgvThongTinDT.Rows.Clear();
                    Remote.LoadToDataGridView(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                    Remote.WriteNodeDataToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachdinh.txt");
                    Remote.AdddatainList(listDinh, Application.StartupPath + "/Danhsachdinh.txt");
                }
                if (dgvThongTinDT.RowCount - 1 >= 3)
                {
                    btnKiemTraLienThong.Enabled = true;
                }
                btnVe.Enabled = false;
                flag1 = false;
            }
            else
            {
                txtSoCanh_Leave(sender, e);
                if (int.Parse(txtSoCanh.Text) < dgvThongTinDT.RowCount - 1)
                {
                    if(MessageBox.Show("Số cạnh vừa sửa không nên nhỏ hơn số cạnh trước đó. Nếu bạn vẫn muốn thực hiện thì thông tin đồ thị hiện tại sẽ bị xoá! Bạn có muốn tiếp tục không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        flag2 = true;
                        btnXoa_Click(sender, e);
                        flag = false;
                    }
                    else
                    {
                        Remote.LoadDataToTextBox(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        if (dgvThongTinDT.RowCount - 1 >= 3)
                        {
                            btnKiemTraLienThong.Enabled = true;
                        }
                        btnRefresh.Enabled = true;
                        if (flag1 == true)
                        {
                            btnVe.Enabled = true;
                        }
                        flag2 = false;
                    }
                }
                else
                {
                    Remote.WriteFromTextBoxToFile(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                    btnXoa.Enabled = true;
                    flag1 = false;
                    btnRefresh.Enabled = true;
                    if (dgvThongTinDT.RowCount - 1 >= 3)
                    {
                        btnKiemTraLienThong.Enabled = true;
                    }
                    flag = false;
                }
            }
            if (flag3 == true && flag1 == false)
            {
                btnThem.Enabled = false;
                dgvThongTinDT.Enabled = false;
            }
            else 
            {
                btnThem.Enabled = true;
                dgvThongTinDT.Enabled = true;
            }
            btnSua.Enabled = false;
            btnCapNhat.Enabled = false;
            btnDuyet.Enabled = false;
            btnHuy.Enabled = false;
            txtCanh.Enabled = false;
            txtDinhDau.Enabled = false;
            txtDinhCuoi.Enabled = false;
            txtTrongSo.Enabled = false;
            lblCanh.Enabled = false;
            lblDinhDau.Enabled = false;
            lblDinhCuoi.Enabled = false;
            lblTrongSo.Enabled = false;
            lblSoCanh.Enabled = false;
            txtSoCanh.Enabled = false;
            txtCanh.Text = "";
            txtDinhCuoi.Text = "";
            txtDinhDau.Text = "";
            txtTrongSo.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thao tác sẽ xoá toàn bộ dữ liệu trên form. Bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UnEnableControl();
                txtSoCanh.Text = "";
                txtCanh.Text = "";
                txtDinhCuoi.Text = "";
                txtDinhDau.Text = "";
                txtTrongSo.Text = "";
                cbDinhxuatphat.Text = "";
                picDoThi.Image = null;
                if (rdbCohuong.Checked == true || rdbVohuong.Checked == true)
                {
                    rdbCohuong.Checked = false;
                    rdbVohuong.Checked = false;
                }
                dgvThongTinDT.Rows.Clear();
                Remote.WriteFromDGVToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                Remote.WriteNodeDataToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachdinh.txt");
                listDinh.Clear();
                dgvMinhHoaDuyet.Rows.Clear();
                dgvMinhHoaDuyet.Columns.Clear();
                dgvDuongDiNN.Rows.Clear();
                dgvDuongDiNN.Columns.Clear();
                flag3 = true;
            }
            else
            {
                if (flag2 == true)
                {
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnKiemTraLienThong.Enabled = true;
                    if (flag1 == true)
                    {
                        btnVe.Enabled = true;
                    }
                    Remote.LoadDataToTextBox(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                    flag2 = false;
                    flag3 = false;
                }
                return;
            }
            flag1 = false;
            flag4 = false;
            flag5 = false;
            flag6 = false;
        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            if (rdbCohuong.Checked == true && int.Parse(txtSoCanh.Text) == 15 && listDinh.Count == 7)
            {
                picDoThi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinh.png");
            }
            else if(rdbVohuong.Checked == true && int.Parse(txtSoCanh.Text) == 10 && listDinh.Count == 6)
            {
                picDoThi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinh.png");
            }
            if (cbDinhxuatphat.Items.Count > 0)
            {
                cbDinhxuatphat.Items.Clear();
            }
            Remote.AddDataToCombo(cbDinhxuatphat, listDinh);
            picDoThi.Enabled = true;
            picDuongDi.Enabled = true;
            lblDinhxuatphat.Enabled = true;
            cbDinhxuatphat.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnVe.Enabled = false;
            btnKiemTraLienThong.Enabled = false;
            btnRefresh.Enabled = false;
            dgvDuongDiNN.Enabled = true;
            dgvDuongDiNN.ReadOnly = true;
            dgvMinhHoaDuyet.Enabled = true;
            dgvMinhHoaDuyet.ReadOnly = true;
            txtCanh.Enabled = false;
            txtDinhDau.Enabled = false;
            txtDinhCuoi.Enabled = false;
            txtTrongSo.Enabled = false;
            lblCanh.Enabled = false;
            lblDinhDau.Enabled = false;
            lblDinhCuoi.Enabled = false;
            lblTrongSo.Enabled = false;
            txtCanh.Text = "";
            txtDinhCuoi.Text = "";
            txtDinhDau.Text = "";
            txtTrongSo.Text = "";
            flag6 = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtSoCanh.Text != "" && txtCanh.Text != "" && txtDinhDau.Text != "" && txtDinhCuoi.Text != "" && txtTrongSo.Text != "")
            {
                if (txtDinhDau.Text.ToCharArray()[0] != txtCanh.Text.ToCharArray()[0])
                {
                    MessageBox.Show("Thông tin đỉnh phải phù hợp với thông tin cạnh vừa sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDinhDau.Focus();
                    return;
                }
                
                if (txtDinhCuoi.Text.ToCharArray()[0] != txtCanh.Text.ToCharArray()[1])
                {
                    MessageBox.Show("Thông tin đỉnh phải phù hợp với thông tin cạnh vừa sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDinhCuoi.Focus();
                    return;
                }

                if (txtDinhDau.Text.ToCharArray()[0] != txtCanh.Text.ToCharArray()[0] && txtDinhCuoi.Text.ToCharArray()[0] != txtCanh.Text.ToCharArray()[1])
                {
                    MessageBox.Show("Thông tin đỉnh phải phù hợp với thông tin cạnh vừa sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDinhDau.Focus();
                    return;
                }

                if (dgvThongTinDT.RowCount > 1 && Remote.testAlpha(dgvThongTinDT, txtCanh.Text) == 1)
                {
                    MessageBox.Show("Các ký tự đại diện cho đỉnh phải cùng là chữ hoa hoặc cùng là chữ thường hoặc cùng là số như đã xác định ban đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCanh.Focus();
                    return;
                }

                if(dgvThongTinDT.RowCount > 1 && Remote.testCanhTrung(dgvThongTinDT, rdbVohuong, rdbCohuong, txtCanh.Text) == 1)
                {
                    MessageBox.Show("Cạnh vừa nhập đã tồn tại... Hãy nhập cạnh khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCanh.Focus();
                    return;
                }
                dgvThongTinDT.Rows.Clear();
                Remote.LoadToDataGridView(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                string[] mang = { txtCanh.Text.Trim(), txtDinhDau.Text.Trim(), txtDinhCuoi.Text.Trim(), txtTrongSo.Text.Trim() };
                dgvThongTinDT.Rows.Add(mang);
                Remote.WriteFromDGVToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                Remote.WriteFromTextBoxToFile(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                Remote.WriteNodeDataToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachdinh.txt");
                Remote.AdddatainList(listDinh, Application.StartupPath + "/Danhsachdinh.txt");
                dgvThongTinDT.Enabled = true;
                txtSoCanh.Enabled = false;
                btnRefresh.Enabled = true;

            }
            else
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtSoCanh.Text == ""  && txtCanh.Text == "" && txtDinhDau.Text == "" && txtDinhCuoi.Text == "" && txtTrongSo.Text == "")
                {
                    txtSoCanh.Focus();
                }
                if (txtSoCanh.Text != "" && txtCanh.Text == "")
                {
                    txtCanh.Focus();
                }
                if (txtSoCanh.Text != "" && txtCanh.Text != "" && txtDinhDau.Text == "")
                {
                    txtDinhDau.Focus();
                }
                if(txtSoCanh.Text != "" && txtCanh.Text != "" && txtDinhDau.Text != "" && txtDinhCuoi.Text == "")
                {
                    txtDinhCuoi.Focus();
                }
                if (txtSoCanh.Text != "" && txtCanh.Text != "" && txtDinhDau.Text != "" && txtDinhCuoi.Text != "" && txtTrongSo.Text == "")
                {
                    txtTrongSo.Focus();
                }
                return;
            }

            if (dgvThongTinDT.RowCount >= 4)
            {
                btnKiemTraLienThong.Enabled = true;
            }

            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = true;
            lblCanh.Enabled = false;
            lblDinhDau.Enabled = false;
            lblDinhCuoi.Enabled = false;
            lblTrongSo.Enabled = false;
            lblSoCanh.Enabled = false;
            txtCanh.Enabled = false;
            txtDinhDau.Enabled = false;
            txtDinhCuoi.Enabled = false;
            txtTrongSo.Enabled = false;
            txtCanh.Text = "";
            txtDinhCuoi.Text = "";
            txtDinhDau.Text = "";
            txtTrongSo.Text = "";
            btnThem.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (flag6 == true)
            {
                if(MessageBox.Show("Thao tác sẽ xoá ảnh đồ thị và các thông tin đã duyệt. Bạn có muốn tiếp tục không?","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lblDinhxuatphat.Enabled = false;
                    cbDinhxuatphat.Enabled = false;
                    btnDuyet.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnVe.Enabled = true;
                    btnKiemTraLienThong.Enabled = true;
                    btnRefresh.Enabled = true;
                    dgvThongTinDT.Enabled = true;
                    dgvDuongDiNN.Rows.Clear();
                    dgvDuongDiNN.Columns.Clear();
                    dgvDuongDiNN.Enabled = false;
                    dgvMinhHoaDuyet.Rows.Clear();
                    dgvMinhHoaDuyet.Columns.Clear();
                    dgvMinhHoaDuyet.Enabled = false;
                    picDoThi.Image = null;
                    picDuongDi.Image = null;
                    cbDinhxuatphat.Text = "";
                    flag6 = false; //btnVe
                }
                else
                {
                    return;
                }
            }
            if (flag5 == true || flag4 == false)
            {
                if (dgvThongTinDT.RowCount > 1)
                {
                    btnXoa.Enabled = true;
                    btnRefresh.Enabled = true;
                    if (dgvThongTinDT.RowCount >= 4)
                    {
                        btnKiemTraLienThong.Enabled = true;
                    }
                    if (flag == true)
                    {
                        Remote.LoadDataToTextBox(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                        dgvThongTinDT.Enabled = true;
                    }
                    flag = false; //btnRefresh
                }
                if (flag1 == true && dgvThongTinDT.RowCount - 1 == int.Parse(txtSoCanh.Text))
                {
                    btnVe.Enabled = true;
                }
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
                btnCapNhat.Enabled = false;
                lblSoCanh.Enabled = false;
                txtSoCanh.Enabled = false;
                txtCanh.Enabled = false;
                txtDinhDau.Enabled = false;
                txtDinhCuoi.Enabled = false;
                txtTrongSo.Enabled = false;
                lblCanh.Enabled = false;
                lblDinhDau.Enabled = false;
                lblDinhCuoi.Enabled = false;
                lblTrongSo.Enabled = false;
                if (dgvThongTinDT.RowCount == 1)
                {
                    txtSoCanh.Text = "";
                }
                txtCanh.Text = "";
                txtDinhCuoi.Text = "";
                txtDinhDau.Text = "";
                txtTrongSo.Text = "";
            }
            else
            {
                if (rdbCohuong.Checked == true || rdbVohuong.Checked == true)
                {
                    rdbVohuong.Checked = false;
                    rdbCohuong.Checked = false;
                }
                UnEnableControl();
                flag4 = false;
            }
        }

        private void rdbVohuong_CheckedChanged(object sender, EventArgs e)
        {
            if (btnChonLoaiDT.Enabled == false)
            {
                btnThem.Enabled = true;
                btnHuy.Enabled = true;
                btnThem.Focus();
            }
            rdbCohuong.Enabled = false;
        }

        private void rdbCohuong_CheckedChanged(object sender, EventArgs e)
        {
            if (btnChonLoaiDT.Enabled == false)
            {
                btnThem.Enabled = true;
                btnHuy.Enabled = true;
                btnThem.Focus();
            }
            rdbVohuong.Enabled = false;
        }

        private void dgvThongTinDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag6 == false)
            {
                if (dgvThongTinDT.CurrentRow.Index != dgvThongTinDT.NewRowIndex)
                {
                    lblCanh.Enabled = true;
                    lblDinhDau.Enabled = true;
                    lblDinhCuoi.Enabled = true;
                    lblTrongSo.Enabled = true;
                    txtCanh.Enabled = true;
                    txtDinhDau.Enabled = true;
                    txtDinhCuoi.Enabled = true;
                    txtTrongSo.Enabled = true;
                    btnHuy.Enabled = true;
                    btnVe.Enabled = false;
                    btnSua.Enabled = true;
                    btnKiemTraLienThong.Enabled = false;
                    txtCanh.Text = dgvThongTinDT[0, dgvThongTinDT.CurrentRow.Index].Value.ToString();
                    txtDinhDau.Text = dgvThongTinDT[1, dgvThongTinDT.CurrentRow.Index].Value.ToString();
                    txtDinhCuoi.Text = dgvThongTinDT[2, dgvThongTinDT.CurrentRow.Index].Value.ToString();
                    txtTrongSo.Text = dgvThongTinDT[3, dgvThongTinDT.CurrentRow.Index].Value.ToString();
                }

                else if (dgvThongTinDT.CurrentRow.Index == dgvThongTinDT.NewRowIndex)
                {
                    MessageBox.Show("Hãy chọn dòng có thông tin!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCanh.Text = "";
                    txtDinhCuoi.Text = "";
                    txtDinhDau.Text = "";
                    txtTrongSo.Text = "";
                    lblCanh.Enabled = false;
                    lblDinhDau.Enabled = false;
                    lblDinhCuoi.Enabled = false;
                    lblTrongSo.Enabled = false;
                    txtCanh.Enabled = false;
                    txtDinhDau.Enabled = false;
                    txtDinhCuoi.Enabled = false;
                    txtTrongSo.Enabled = false;
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                    return;
                }
            }
        }

        private void txtCanh_Leave(object sender, EventArgs e)
        {
            if (Remote.TestCanh(txtCanh.Text) == 2)
            {
                MessageBox.Show("Thông tin cạnh chỉ gồm 2 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCanh.Focus();
                return;
            }
            else
                if (Remote.TestCanh(txtCanh.Text) == 1)
                {
                    MessageBox.Show("Thông tin cạnh phải chứa 2 ký tự chữ hoặc 2 ký tự số, không được chứa dấu cách hoặc ký tự đặc biệt. Đối với 2 ký tự chữ và 2 ký tự số thì 2 ký tự đó phải khác nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCanh.Focus();
                    return;
                }
        }

        private void txtDinhDau_Leave(object sender, EventArgs e)
        {
            if (Remote.testDinhdau(txtDinhDau.Text,txtCanh.Text) == 2)
            {
                MessageBox.Show("Thông tin đỉnh đầu chỉ gồm 1 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDinhDau.Focus();
                return;
            }
            else
                if (Remote.testDinhdau(txtDinhDau.Text, txtCanh.Text) == 1)
                {
                    MessageBox.Show("Thông tin đỉnh đầu phải chứa 1 ký tự chữ hoặc 1 ký tự số, không được chứa dấu cách hoặc ký tự đặc biệt và phải trùng với đỉnh đầu của cạnh vừa nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDinhDau.Focus();
                    return;
                }
        }

        private void txtDinhCuoi_Leave(object sender, EventArgs e)
        {
            if (Remote.testDinhcuoi(txtDinhCuoi.Text, txtCanh.Text) == 2)
            {
                MessageBox.Show("Thông tin đỉnh cuối chỉ gồm 1 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDinhCuoi.Focus();
                return;
            }
            else
                if (Remote.testDinhcuoi(txtDinhCuoi.Text, txtCanh.Text) == 1)
                {
                    MessageBox.Show("Thông tin đỉnh cuối phải chứa 1 ký tự chữ hoặc 1 ký tự số, không được chứa dấu cách hoặc ký tự đặc biệt và phải trùng với đỉnh cuối của cạnh vừa nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDinhCuoi.Focus();
                    return;
                }
        }

        private void txtSoCanh_Leave(object sender, EventArgs e)
        {
            if (Remote.testSoCanh(txtSoCanh.Text) == 2)
            {
                MessageBox.Show("Thông tin số cạnh tối đa chỉ gồm 2 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCanh.Focus();
                return;
            }
            else
                if (Remote.testSoCanh(txtSoCanh.Text) == 1)
                {
                    MessageBox.Show("Thông tin số cạnh phải chứa ký tự số, không được chứa ký tự chữ, dấu cách hoặc ký tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoCanh.Focus();
                    return;
                }
                else if (Remote.testSoCanh(txtSoCanh.Text) == 3)
                {
                    MessageBox.Show("Số cạnh phải lớn hơn 2!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoCanh.Focus();
                    return;
                }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flag = true;
            if (MessageBox.Show("Thao tác sẽ đặt lại số cạnh. Bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                btnSua.Enabled = true;
                lblSoCanh.Enabled = true;
                txtSoCanh.Enabled = true;
                txtSoCanh.ReadOnly = false;
                txtSoCanh.Focus();
                btnHuy.Enabled = true;
                dgvThongTinDT.Enabled = false;
                btnRefresh.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnVe.Enabled = false;
                btnKiemTraLienThong.Enabled = false;
                lblCanh.Enabled = false;
                txtCanh.Enabled = false;
                lblDinhDau.Enabled = false;
                txtDinhDau.Enabled = false;
                lblDinhCuoi.Enabled = false;
                txtDinhCuoi.Enabled = false;
                lblTrongSo.Enabled = false;
                txtTrongSo.Enabled = false;
                txtCanh.Text = "";
                txtDinhCuoi.Text = "";
                txtDinhDau.Text = "";
                txtTrongSo.Text = "";
            }
            else                
            {
                flag = false;
                return;
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < listDinh.Count; ++i)
            {
                if (listDinh[i] == cbDinhxuatphat.Text.ToCharArray()[0])
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Đỉnh vừa nhập không tồn tại. Hãy nhập đỉnh khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(dgvMinhHoaDuyet.ColumnCount > 0)
            {
                dgvMinhHoaDuyet.Columns.Clear();
                dgvMinhHoaDuyet.Rows.Clear();
            }
            dgvMinhHoaDuyet.Columns.Add("LanLap", "Lần Lặp");
            for (int i = 0; i < listDinh.Count; ++i)
            {
                string temp = "";
                temp = listDinh[i].ToString();
                dgvMinhHoaDuyet.Columns.Add(temp, "Đỉnh " + temp);
            }

            if (dgvDuongDiNN.ColumnCount > 0)
            {
                dgvDuongDiNN.Columns.Clear();
                dgvDuongDiNN.Rows.Clear();
            }
            dgvDuongDiNN.Columns.Add("", "");
            for (int i = 0; i < listDinh.Count; ++i)
            {
                string temp = "";
                temp = listDinh[i].ToString();
                dgvDuongDiNN.Columns.Add(temp, "Đỉnh " + temp);
            }
            dgvDuongDiNN.Rows.Add(2);
            dgvDuongDiNN[0, 0].Value = "Độ dài đường đi";
            dgvDuongDiNN[0, 1].Value = "Đường đi";
            if (listKe.Count != 0 && listTro.Count != 0 && listTrongSo.Count != 0)
            {
                listTrongSo.Clear();
                listTro.Clear();
                listKe.Clear();
            }
            Remote.DijkstraAlgorithm(dgvThongTinDT, dgvDuongDiNN, dgvMinhHoaDuyet, listTrongSo, listKe, listTro, listDinh, rdbCohuong, rdbVohuong, cbDinhxuatphat);
            if (rdbCohuong.Checked == true && int.Parse(txtSoCanh.Text) == 15 && listDinh.Count == 7)
            {
                if (cbDinhxuatphat.Text == "a")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPa.png");
                }
                if (cbDinhxuatphat.Text == "b")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPb.png");
                }
                if (cbDinhxuatphat.Text == "c")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPc.png");
                }
                if (cbDinhxuatphat.Text == "d")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPd.png");
                }
                if (cbDinhxuatphat.Text == "e")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPe.png");
                }
                if (cbDinhxuatphat.Text == "f")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPf.png");
                }
                if (cbDinhxuatphat.Text == "g")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/15canh7dinhXPg.png");
                }
            }
            else if(rdbVohuong.Checked == true && int.Parse(txtSoCanh.Text) == 10 && listDinh.Count == 6)
            {
                if (cbDinhxuatphat.Text == "a")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPa.png");
                }
                if (cbDinhxuatphat.Text == "b")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPb.png");
                }
                if (cbDinhxuatphat.Text == "c")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPc.png");
                }
                if (cbDinhxuatphat.Text == "d")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPd.png");
                }
                if (cbDinhxuatphat.Text == "e")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPe.png");
                }
                if (cbDinhxuatphat.Text == "f")
                {
                    picDuongDi.Image = Image.FromFile(Application.StartupPath + "/10canh6dinhXPf.png");
                }
            }
        }

        private void btnChonLoaiDT_Click(object sender, EventArgs e)
        {
            rdbVohuong.Enabled = true;
            rdbCohuong.Enabled = true;
            btnChonLoaiDT.Enabled = false;
            flag4 = true;
        }

        private void btnKiemTraLienThong_Click(object sender, EventArgs e)
        {
            if (Remote.KiemtraLienthong(dgvThongTinDT, rdbCohuong, rdbVohuong) == true)
            {
                MessageBox.Show("Đồ thị vừa nhập không liên thông!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag1 = false;
                btnVe.Enabled = false;
                return;
            }
            else
            {
                if (int.Parse(txtSoCanh.Text) > dgvThongTinDT.RowCount - 1)
                {
                    MessageBox.Show("Đồ thị vừa nhập liên thông. Bạn hãy nhập đủ số cạnh để vẽ nó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnVe.Enabled = false;
                    flag1 = false;
                }
                else
                {
                    MessageBox.Show("Đồ thị vừa nhập liên thông. Bạn có thể vẽ nó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnVe.Enabled = true;
                    flag1 = true;
                }
            }
        }

        private void txtSoCanh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void txtCanh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void txtDinhDau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void txtDinhCuoi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void txtTrongSo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
        }

        private void cbDinhxuatphat_TextChanged(object sender, EventArgs e)
        {
            if (cbDinhxuatphat.Text == "")
            {
                btnDuyet.Enabled = false;
            }
            else
            {
                btnDuyet.Enabled = true;
            }
        }

        private void picDoThi_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvThongTinDT_MouseLeave(object sender, EventArgs e)
        {
            lblXoaDong.Text = "";
        }

        private void dgvThongTinDT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag6 == false)
            {
                if (dgvThongTinDT.CurrentRow.Index != dgvThongTinDT.NewRowIndex)
                {
                    dgvThongTinDT.Rows.RemoveAt(dgvThongTinDT.CurrentRow.Index);
                    Remote.WriteFromDGVToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachcanhcung.txt");
                    Remote.WriteFromTextBoxToFile(txtSoCanh, Application.StartupPath + "/SoCanh.txt");
                    Remote.WriteNodeDataToFile(dgvThongTinDT, Application.StartupPath + "/Danhsachdinh.txt");
                    Remote.AdddatainList(listDinh, Application.StartupPath + "/Danhsachdinh.txt");
                    if (dgvThongTinDT.RowCount == 1)
                    {
                        if (rdbCohuong.Checked == true || rdbVohuong.Checked == true)
                        {
                            rdbCohuong.Checked = false;
                            rdbVohuong.Checked = false;
                        }
                        UnEnableControl();
                        txtSoCanh.Text = "";
                        txtCanh.Text = "";
                        txtDinhCuoi.Text = "";
                        txtDinhDau.Text = "";
                        txtTrongSo.Text = "";
                    }
                    else
                    {
                        btnVe.Enabled = false;
                        flag1 = false;
                        txtCanh.Enabled = false;
                        txtDinhDau.Enabled = false;
                        txtDinhCuoi.Enabled = false;
                        txtTrongSo.Enabled = false;
                        lblCanh.Enabled = false;
                        lblDinhDau.Enabled = false;
                        lblDinhCuoi.Enabled = false;
                        lblTrongSo.Enabled = false;
                        txtCanh.Text = "";
                        txtDinhCuoi.Text = "";
                        txtDinhDau.Text = "";
                        txtTrongSo.Text = "";
                    }
                }
            }
        }

        private void dgvThongTinDT_MouseHover(object sender, EventArgs e)
        {
            lblXoaDong.Text = "Click đúp một dòng để xoá!";
        }

        private void txtTrongSo_Leave(object sender, EventArgs e)
        {
            if (Remote.testTrongSo(txtTrongSo.Text) == 2)
            {
                MessageBox.Show("Thông tin trọng số tối đa gồm 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTrongSo.Focus();
                return;
            }
            else
                if (Remote.testTrongSo(txtTrongSo.Text) == 1)
                {
                    MessageBox.Show("Thông tin trọng số phải chứa ký tự số, không được chứa ký tự chữ, dấu cách hoặc ký tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTrongSo.Focus();
                    return;
                }
                else if (Remote.testTrongSo(txtTrongSo.Text) == 3)
                {
                    MessageBox.Show("Trọng số phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTrongSo.Focus();
                    return;
                }
        }

        private void txtDinhDau_Enter(object sender, EventArgs e)
        {
            if (txtCanh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập cạnh trước khi nhập đỉnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCanh.Focus();
                return;
            }
        }

        private void txtDinhCuoi_Enter(object sender, EventArgs e)
        {
            if (txtCanh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập cạnh trước khi nhập đỉnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCanh.Focus();
                return;
            }
        }
    }
}
