using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DijkstraAlgorithm
{
    public class Remote
    {

        public static void LoadToDataGridView(DataGridView dg, string TenFile)
        {
            StreamReader sr = new StreamReader(TenFile);
            string Line = sr.ReadLine();
            while ((Line != null) && (Line != " "))
            {
                string[] mang = Line.Split('|');
                dg.Rows.Add(mang);
                Line = sr.ReadLine();
            }
            sr.Close();
        }

        public static void WriteFromDGVToFile(DataGridView dgv, string pathFile)
        {
            StreamWriter sw = new StreamWriter(pathFile);
            string Line = "";

            for (int i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                if (i == dgv.NewRowIndex)
                {
                    break;
                }
                Line = "";
                for (int j = 0; j < dgv.Columns.Count; ++j)
                {
                    Line += dgv[j, i].Value + "|";
                }
                sw.WriteLine(Line);
            }
            sw.Close();
        }

        public static void LoadDataToTextBox(TextBox txt, string pathFile)
        {
            StreamReader sr = new StreamReader(pathFile);
            txt.Text=sr.ReadLine();
            sr.Close();
        }

        public static void WriteFromTextBoxToFile(TextBox txt, string pathFile)
        {
            StreamWriter sw = new StreamWriter(pathFile);
            sw.Write(txt.Text);
            sw.Close();
        }

        public static int TestCanh(string canh)
        {
            int value = 0;
            int flag = 0, flag1 = 0;
            char temp=' ';
            char[] wl = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] wu = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (canh.Length == 2)
            {
                for (int i = 0; i < wl.Length; ++i)
                {
                    if (wl[i] == canh.ToCharArray()[0])
                    {
                        flag = 1;
                        temp = wl[i];
                        break;
                    }
                }

                for(int i = 0; i < wu.Length; ++i)
                {
                    if (wu[i] == canh.ToCharArray()[0])
                    {
                        flag = 2;
                        temp = wu[i];
                        break;
                    }
                }

                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (numbers[i] == canh.ToCharArray()[0])
                    {
                        flag = 3;
                        temp = numbers[i];
                        break;
                    }
                }

                if (flag == 1)
                {
                    for (int i = 0; i < wl.Length; ++i)
                    {
                        if (wl[i] == canh.ToCharArray()[1] && temp != canh.ToCharArray()[1])
                        {
                            flag1 = 1;
                            break;
                        }
                    }
                }

                if (flag == 2)
                {
                    for (int i = 0; i < wu.Length; ++i)
                    {
                        if (wu[i] == canh.ToCharArray()[1] && temp != canh.ToCharArray()[1])
                        {
                            flag1 = 2;
                            break;
                        }
                    }
                }

                if (flag == 3)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == canh.ToCharArray()[1] && temp != canh.ToCharArray()[1])
                        {
                            flag1 = 3;
                            break;
                        }
                    }

                }

                if (flag == 0 || (flag == 1 && flag1 != 1) || (flag == 2 && flag1 != 2) || (flag == 3 && flag1 != 3))
                {
                    value = 1;
                }
            }
            else
            {
                value = 2;
            }
            return value;
        }

        public static int testDinhdau(string dinhdau, string canh)
        {
            int value = 0;
            int flag = 0, flag1 = 0;
            char[] wl = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] wu = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (dinhdau.Length == 1)
            {
                for (int i = 0; i < wl.Length; ++i)
                {
                    if (wl[i] == canh.ToCharArray()[0] || wu[i] == canh.ToCharArray()[0])
                    {
                        flag = 1;
                        break;
                    }
                }

                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (numbers[i] == canh.ToCharArray()[0])
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 1)
                {
                    if (dinhdau.ToCharArray()[0] == canh.ToCharArray()[0])
                    {
                        flag1 = 1;
                    }
                }

                if (flag == 0 || flag1 == 0)
                {
                    value = 1;
                }
            }
            else
            {
                value = 2;
            }
            return value;
        }

        public static int testDinhcuoi(string dinhcuoi, string canh)
        {
            int value = 0;
            int flag = 0, flag1 = 0;
            char[] wl = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] wu = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (dinhcuoi.Length == 1)
            {
                for (int i = 0; i < wl.Length; ++i)
                {
                    if (wl[i] == canh.ToCharArray()[1] || wu[i] == canh.ToCharArray()[1])
                    {
                        flag = 1;
                        break;
                    }
                }

                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (numbers[i] == canh.ToCharArray()[1])
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 1)
                {
                    if (dinhcuoi.ToCharArray()[0] == canh.ToCharArray()[1])
                    {
                        flag1 = 1;
                    }
                }

                if (flag == 0 || flag1 == 0)
                {
                    value = 1;
                }
            }
            else
            {
                value = 2;
            }
            return value;
        }

        public static int testTrongSo(string trongso)
        {
            int value = 0;
            int flag = 0, flag1 = 0, flag2 = 0, flag3 = 0;
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (trongso.Length <= 4 && trongso.Length >= 1)
            {
                if (trongso.Length == 1)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == trongso.ToCharArray()[0])
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(trongso) == 0)
                            {
                                value = 3;
                            }
                        }
                }
                else if (trongso.Length == 2)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == trongso.ToCharArray()[0])
                        {
                            flag = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[1])
                        {
                            flag1 = 1;
                        }
                    }
                    if (flag == 0 || flag1 == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(trongso) == 0)
                            {
                                value = 3;
                            }
                        }
                }
                else if (trongso.Length == 3)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == trongso.ToCharArray()[0])
                        {
                            flag = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[1])
                        {
                            flag1 = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[2])
                        {
                            flag2 = 1;
                        }
                    }
                    if (flag == 0 || flag1 == 0 || flag2 == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(trongso) == 0)
                            {
                                value = 3;
                            }
                        }
                }
                else
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == trongso.ToCharArray()[0])
                        {
                            flag = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[1])
                        {
                            flag1 = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[2])
                        {
                            flag2 = 1;
                        }

                        if (numbers[i] == trongso.ToCharArray()[3])
                        {
                            flag3 = 1;
                        }
                    }

                    if (flag == 0 || flag1 == 0 || flag2 == 0 || flag3 == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(trongso) == 0)
                            {
                                value = 3;
                            }
                        }
                }

            }
            else
            {
                value = 2;
            }
            return value;
        }

        public static int testSoCanh(string socanh)
        {
            int value = 0;
            int flag = 0, flag1 = 0;
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (socanh.Length <= 2 && socanh.Length >= 1)
            {
                if (socanh.Length == 1)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == socanh.ToCharArray()[0])
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(socanh) < 3)
                            {
                                value = 3;
                            }
                        }
                }
                else if (socanh.Length == 2)
                {
                    for (int i = 0; i < numbers.Length; ++i)
                    {
                        if (numbers[i] == socanh.ToCharArray()[0])
                        {
                            flag = 1;
                        }

                        if (numbers[i] == socanh.ToCharArray()[1])
                        {
                            flag1 = 1;
                        }
                    }
                    if (flag == 0 || flag1 == 0)
                    {
                        value = 1;
                    }
                    else
                        if (value == 0)
                        {
                            if (int.Parse(socanh) < 3)
                            {
                                value = 3;
                            }
                        }
                }
            }
            else
            {
                value = 2;
            }
            return value;
        }

        public static int testAlpha(DataGridView dgv, string canh)
        {
            int value = 0;
            int flag = 0, flag1 = 0;
            char[] wl = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] wu = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < wl.Length; ++i)
            {
                if (wl[i] == dgv[0,0].Value.ToString().ToCharArray()[0])
                {
                    flag = 1;
                    break;
                }
            }

            for (int i = 0; i < wu.Length; ++i)
            {
                if (wu[i] == dgv[0, 0].Value.ToString().ToCharArray()[0])
                {
                    flag = 2;
                    break;
                }
            }

            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] == dgv[0, 0].Value.ToString().ToCharArray()[0])
                {
                    flag = 3;
                    break;
                }
            }

            if (flag == 1)
            {
                for (int i = 0; i < wl.Length; ++i)
                {
                    if (wl[i] == canh.ToCharArray()[0])
                    {
                        flag1 = 1;
                        break;
                    }
                }
            }

            if (flag == 2)
            {
                for (int i = 0; i < wu.Length; ++i)
                {
                    if (wu[i] == canh.ToCharArray()[0])
                    {
                        flag1 = 2;
                        break;
                    }
                }
            }

            if (flag == 3)
            {
                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (numbers[i] == canh.ToCharArray()[0])
                    {
                        flag1 = 3;
                        break;
                    }
                }

            }

            if((flag==1 && flag1!=1)||(flag == 2 && flag1 != 2) || (flag == 3 && flag1 != 3))
            {
                value = 1;
            }

            return value;
        }

        public static int testCanhTrung(DataGridView dgv, RadioButton rdbVoHuong, RadioButton rdbCoHuong, string canh)
        {
            int value = 0;
            int flag = 0;
            if (rdbVoHuong.Checked == true)
            {
                for (int i = 0; i < dgv.RowCount - 1; ++i)
                {
                    if (canh == dgv[0, i].Value.ToString() || (canh.ToCharArray()[0] == dgv[0, i].Value.ToString().ToCharArray()[1] && canh.ToCharArray()[1] == dgv[0, i].Value.ToString().ToCharArray()[0]))
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 1)
                {
                    value = 1;
                }
            }
            else 
                if (rdbCoHuong.Checked == true)
                {
                    for (int i = 0; i < dgv.RowCount - 1; ++i)
                    {
                        if (canh == dgv[0, i].Value.ToString())
                        {
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 1)
                    {
                        value = 1;
                    }
                }
            return value;
        }

        public static void LocDuLieuTrung(List<char> list)
        {
            int flag;
            for (int j = 0; j < list.Count; ++j)
            {
                for (int i = j + 1; i < list.Count; ++i)
                {
                    flag = 0;
                    if (list.ElementAt(i).ToString() == list.ElementAt(j).ToString())
                    {
                        flag = 1;
                    }
                    if (flag == 1)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
        }

        public static bool KiemtraTrung(List<char> list)
        {
            bool flag = false;
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = i + 1; j < list.Count; ++j)
                {
                    if (list[i] == list[j])
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        public static void AdddatainList(List<char> list, string TenFile)
        {

            if (list.Count > 0)
            {
                list.Clear();
            }
            StreamReader sr = new StreamReader(TenFile);
            string Line = sr.ReadLine();
            while (Line != null && Line != " ")
            {
                char c = Line.ToCharArray()[0];
                list.Add(c);
                Line = sr.ReadLine();
            }

            while(KiemtraTrung(list) == true)
            {
                LocDuLieuTrung(list);
            }
            sr.Close();
        }

        public static void WriteNodeDataToFile(DataGridView dgv, string pathFile)
        {
            StreamWriter sw = new StreamWriter(pathFile);
            string Line = "";

            for (int i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                if (i == dgv.NewRowIndex)
                {
                    break;
                }
                Line = "";
                Line += dgv[1, i].Value + Environment.NewLine + dgv[2, i].Value;
                sw.WriteLine(Line);
            }
            sw.Close();
        }

        public static Boolean KiemtraLienthong(DataGridView dgv, RadioButton rdbCohuong, RadioButton rdbVohuong)
        {
            Boolean test = false;
            if (rdbVohuong.Checked == true)
            {
                List<char> lbDaxet = new List<char>();
                List<char> lbChuaxet = new List<char>();
                lbDaxet.Add(dgv[1, 0].Value.ToString().ToCharArray()[0]);
                lbDaxet.Add(dgv[2, 0].Value.ToString().ToCharArray()[0]);
                int j = 1;
                while (j < dgv.RowCount - 1)
                {
                    int flag = 0;
                    if (dgv[1, j].Value.ToString().ToCharArray()[0] == lbDaxet[0] || dgv[1, j].Value.ToString().ToCharArray()[0] == lbDaxet[1] || dgv[2, j].Value.ToString().ToCharArray()[0] == lbDaxet[0] || dgv[2, j].Value.ToString().ToCharArray()[0] == lbDaxet[1])
                    {
                        flag = 1;
                    }
                    if (flag == 1)
                    {
                        lbDaxet.Add(dgv[1, j].Value.ToString().ToCharArray()[0]);
                        lbDaxet.Add(dgv[2, j].Value.ToString().ToCharArray()[0]);
                    }
                    else
                    {
                        lbChuaxet.Add(dgv[1, j].Value.ToString().ToCharArray()[0]);
                        lbChuaxet.Add(dgv[2, j].Value.ToString().ToCharArray()[0]);
                    }
                    j++;
                }
                //Cách 1
                if (lbChuaxet.Count != 0)
                {
                    int k = 0;
                    while (k < dgv.RowCount - 1)
                    {
                        int i = 0;
                        while (i < lbChuaxet.Count)
                        {
                            int flag = 0, tempi = 0;
                            for (int a = 0; a < lbDaxet.Count; ++a)
                            {
                                tempi = i + 1;
                                if (lbChuaxet[i] == lbDaxet[a] || lbChuaxet[tempi] == lbDaxet[a])
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 1)
                            {
                                lbDaxet.Add(lbChuaxet[i]);
                                lbDaxet.Add(lbChuaxet[tempi]);
                                lbChuaxet.RemoveRange(i,2);
                            }
                            i = i + 2;
                        }
                        k++;
                    }
                    if (lbChuaxet.Count != 0)
                    {
                        test = true;
                    }
                }
                //Cách 2
                //while (KiemtraTrung(lbDaxet) == true)
                //{
                //    LocDuLieuTrung(lbDaxet);
                //}
                //if (lbChuaxet.Count != 0)
                //{
                //    int k = 0;
                //    while (k < dgv.RowCount - 1)
                //    {
                //        int i = 0;
                //        while (i < lbChuaxet.Count)
                //        {
                //            int flag = 0, tempi = 0;
                //            for (int a = 0; a < lbDaxet.Count; ++a)
                //            {
                //                tempi = i + 1;
                //                if (lbChuaxet[i] == lbDaxet[a] || lbChuaxet[tempi] == lbDaxet[a])
                //                {
                //                    flag = 1;
                //                    break;
                //                }
                //            }
                //            if (flag == 1)
                //            {
                //                lbDaxet.Add(lbChuaxet[i]);
                //                lbDaxet.Add(lbChuaxet[tempi]);
                //                while (KiemtraTrung(lbDaxet) == true)
                //                {
                //                    LocDuLieuTrung(lbDaxet);
                //                }
                //                lbChuaxet.RemoveRange(i, 2);
                //            }
                //            i = i + 2;
                //        }
                //        k++;
                //    }
                //    if (lbChuaxet.Count != 0)
                //    {
                //        test = true;
                //    }
                //}
            }
            else if (rdbCohuong.Checked == true)
            {
                List<char> lbDaxet = new List<char>();
                List<char> lbChuaxet = new List<char>();
                for(int i=0; i < dgv.RowCount - 1; ++i)
                {
                    lbChuaxet.Add(dgv[1, i].Value.ToString().ToCharArray()[0]);
                    lbChuaxet.Add(dgv[2, i].Value.ToString().ToCharArray()[0]);
                }

                while (KiemtraTrung(lbChuaxet) == true)
                {
                    LocDuLieuTrung(lbChuaxet);
                }

                int j = 0;
                while (j < lbChuaxet.Count)
                {
                    int flag = 0, flag1 = 0;
                    for(int i = 0; i < dgv.RowCount - 1; ++i)
                    {
                        if (lbChuaxet[j] == dgv[1, i].Value.ToString().ToCharArray()[0])
                        {
                            flag = 1;
                        }
                        if(lbChuaxet[j] == dgv[2, i].Value.ToString().ToCharArray()[0])
                        {
                            flag1 = 1;
                        }
                    }
                    if (flag == 1 && flag1 == 1)
                    {
                        lbDaxet.Add(lbChuaxet[j]);
                        lbChuaxet.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
                if (lbChuaxet.Count != 0)
                {
                    test = true;
                }
            }
            return test;
        }

        public static void AddDataToCombo(ComboBox cb, List<char> list)
        {
            list.Sort();
            for(int i = 0; i < list.Count; ++i)
            {
                cb.Items.Add(list[i]);
            }
        }

        public static void DijkstraAlgorithm(DataGridView dgvThongTinDT, DataGridView dgvDuongDi, DataGridView dgvMinhHoaDuyet, List<int> listTrongSo, List<char> listKe, List<int> listTro, List<char> listDinh, RadioButton rdbCoHuong, RadioButton rdbVoHuong, ComboBox cbDinhxuatphat)
        {
            if (rdbVoHuong.Checked == true)
            {
                int tro = 0;
                listTro.Add(tro);
                for(int i = 0; i < listDinh.Count; ++i)
                {
                    int count = 0;
                    for(int j = 0; j < dgvThongTinDT.RowCount - 1; ++j)
                    {
                        bool flag = false, flag1 = false;
                        if (listDinh[i] == dgvThongTinDT[1, j].Value.ToString().ToCharArray()[0])
                        {
                            flag = true;
                        }
                        if(listDinh[i] == dgvThongTinDT[2, j].Value.ToString().ToCharArray()[0])
                        {
                            flag1 = true;
                        }
                        if (flag == true)
                        {
                            listKe.Add(dgvThongTinDT[2, j].Value.ToString().ToCharArray()[0]);
                            listTrongSo.Add((int.Parse(dgvThongTinDT[3, j].Value.ToString())));
                            count++;
                        }
                        if (flag1 == true)
                        {
                            listKe.Add(dgvThongTinDT[1, j].Value.ToString().ToCharArray()[0]);
                            listTrongSo.Add((int.Parse(dgvThongTinDT[3, j].Value.ToString())));
                            count++;
                        }
                    }

                    tro += count;
                    listTro.Add(tro);

                    //hoặc
                    //if (i < listDinh.Count - 1)
                    //{
                    //    tro += count;
                    //    listTro.Add(tro);
                    //}

                }

                for (int i = 0; i < listDinh.Count; ++i)
                {
                    int temp = 0;
                    dgvMinhHoaDuyet.Rows.Add();
                    for (int j = 0; j < dgvMinhHoaDuyet.ColumnCount; ++j)
                    {
                        Boolean flag3 = false;
                        if (i == 0 && j == 0)
                        {
                            dgvMinhHoaDuyet[j, i].Value = "Khởi tạo";
                        }
                        else if (i == 0 && j != 0)
                        {
                            if (dgvMinhHoaDuyet.Columns[j].HeaderText == "Đỉnh " + cbDinhxuatphat.Text)
                            {
                                flag3 = true;
                            }
                            if (flag3 == true) //là đỉnh đang xét.
                            {
                                dgvMinhHoaDuyet[j, i].Value = "(0, " + cbDinhxuatphat.Text + ")*";
                            }
                            else // không phải đỉnh đang xét.
                            {
                                bool flag = false, flag1 = false;
                                int temp1 = 0;
                                for (int k = 0; k < listDinh.Count; ++k)
                                {
                                    if (dgvMinhHoaDuyet.Columns[j].Name == listDinh[k].ToString())
                                    {
                                        flag = true;
                                    }
                                    if (flag == true)
                                    {
                                        temp1 = k;//xác định vị trí của đỉnh đang xét
                                        break;
                                    }
                                }
                                for (int r = listTro[temp1]; r < listTro[temp1 + 1]; ++r)
                                {
                                    if (cbDinhxuatphat.Text == listKe[r].ToString())
                                    {
                                        flag1 = true;//đỉnh xuất phát kề với đỉnh đang xét.
                                    }
                                    if (flag1 == true)
                                    {
                                        temp1 = r;
                                        break;
                                    }
                                }
                                if (flag1 == true)
                                {
                                    temp1 = listTrongSo[temp1];//lấy giá trị trọng số của cạnh (đầu là đỉnh đang xét, cuối là đỉnh xuất phát)
                                    dgvMinhHoaDuyet[j, i].Value = "(" + temp1 + ", " + cbDinhxuatphat.Text + ")";
                                }
                                else
                                {
                                    dgvMinhHoaDuyet[j, i].Value = "($, " + cbDinhxuatphat.Text + ")";
                                }

                            }
                        }
                        else//i!=0
                        {
                            dgvMinhHoaDuyet[0, i].Value = i;
                            if (j != 0)
                            {
                                temp = i - 1;
                                flag3 = false;
                                if (dgvMinhHoaDuyet[j, temp].Value.ToString().Length > 6)
                                {
                                    if(dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray().Last() == '*')
                                    {
                                        flag3 = true;
                                    }
                                }
                                else
                                {
                                    if(dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[0] == '-')
                                    {
                                        flag3 = true;
                                    }
                                }
                                if (flag3 == true)
                                {
                                    dgvMinhHoaDuyet[j, i].Value = '-';

                                }
                                else //xét những ô chưa đánh dấu '*' hoặc chưa đánh dấu '-'
                                {
                                    int min = 0, index1 = 0, tempm = 0, tempn = 0, tmp = 0, index = 0;
                                    List<int> listTStemp = new List<int>();
                                    List<int> listIndex = new List<int>();
                                    for (int k = 1; k < dgvMinhHoaDuyet.ColumnCount; ++k)
                                    {
                                        if(dgvMinhHoaDuyet[k, temp].Value.ToString().Length > 6)
                                        {
                                            if(dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray().Last() != '*')
                                            {
                                                char[] ctemp = new char[dgvMinhHoaDuyet[k, temp].Value.ToString().Length];
                                                char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                int itmp = 0;
                                                for (int l = 0; l < dgvMinhHoaDuyet[k, temp].Value.ToString().Length; ++l)
                                                {
                                                    if (dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l] == ',')
                                                    {
                                                        break;
                                                    }
                                                    for (int t = 0; t < numbers.Length; ++t)
                                                    {
                                                        if (dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                        {
                                                            ctemp[itmp] = dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l];
                                                            itmp++;
                                                        }
                                                    }
                                                }
                                                string m = "";
                                                for (int l = 0; l < ctemp.Length; ++l)
                                                {
                                                    m += ctemp[l].ToString();
                                                }
                                                listTStemp.Add(int.Parse(m));
                                                listIndex.Add(k);
                                            }
                                        }
                                        else 
                                        {
                                            if (dgvMinhHoaDuyet[k, temp].Value.ToString().Length == 6)
                                            {
                                                if(dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[1] != '$')
                                                {
                                                    listTStemp.Add(int.Parse(dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[1].ToString()));
                                                    listIndex.Add(k);
                                                }
                                            }
                                        }
                                    }
                                    if (listTStemp.Count >= 1)
                                    {
                                        if (listTStemp.Count == 1)
                                        {
                                            min = listTStemp[0];
                                            index = 0;
                                        }
                                        else
                                        {
                                            min = listTStemp[0];
                                            int l = 0;
                                            while (l < listTStemp.Count)
                                            {
                                                if (listTStemp[l] < min)
                                                {
                                                    min = listTStemp[l];
                                                    index = l;
                                                }
                                                l++;
                                            }
                                        }
                                        for (int k = 0; k < listIndex.Count; ++k)
                                        {
                                            if (k == index)
                                            {
                                                index = listIndex[k];//index chứa vị trí columns cùa ô(i-1) có trọng số nhỏ nhất
                                                break;
                                            }
                                        }
                                        if (j == index && dgvMinhHoaDuyet[index, i].Value == null)
                                        {
                                            dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[index, temp].Value + "*";
                                        }
                                        else
                                        {
                                            for (int k = 0; k < listDinh.Count; ++k)
                                            {
                                                if (dgvMinhHoaDuyet.Columns[index].Name.ToCharArray()[0] == listDinh[k])
                                                {
                                                    index1 = k;
                                                    break;
                                                }
                                            }
                                            flag3 = false;
                                            for (int k = listTro[index1]; k < listTro[index1 + 1]; ++k)
                                            {
                                                if (dgvMinhHoaDuyet.Columns[j].Name.ToCharArray()[0] == listKe[k])//đỉnh đang xét (thuộc ô hiện tại) kề với đỉnh '*'
                                                {
                                                    if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[1] != '$')//ô hiện tại không chứa vô cùng
                                                    {
                                                        char[] ctemp = new char[dgvMinhHoaDuyet[j, temp].Value.ToString().Length];
                                                        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                        int itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[j, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp[itmp] = dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                }
                                                            }
                                                        }
                                                        string m = "";
                                                        for (int l = 0; l < ctemp.Length; ++l)
                                                        {
                                                            m += ctemp[l].ToString();
                                                        }
                                                        tempm = int.Parse(m);
                                                        char[] ctemp1 = new char[dgvMinhHoaDuyet[index, temp].Value.ToString().Length];
                                                        itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[index, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp1[itmp] = dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                }
                                                            }
                                                        }
                                                        m = "";
                                                        for (int l = 0; l < ctemp1.Length; ++l)
                                                        {
                                                            m += ctemp1[l].ToString();
                                                        }
                                                        tmp = int.Parse(m) + listTrongSo[k];
                                                        if (tmp < tempm)
                                                        {
                                                            dgvMinhHoaDuyet[j, i].Value = "(" + tmp + ", " + dgvMinhHoaDuyet.Columns[index].Name + ")";
                                                        }
                                                        else//giá trị trọng số của cạnh đang xét >= cạnh trước đó
                                                        {
                                                            dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[j, temp].Value;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        char[] ctemp = new char[dgvMinhHoaDuyet[index, temp].Value.ToString().Length];
                                                        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                        int itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[index, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp[itmp] = dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                }
                                                            }
                                                        }
                                                        string m = "";
                                                        for (int l = 0; l < ctemp.Length; ++l)
                                                        {
                                                            m += ctemp[l].ToString();
                                                        }
                                                        tempn = int.Parse(m) + listTrongSo[k];
                                                        dgvMinhHoaDuyet[j, i].Value = "(" + tempn + ", " + dgvMinhHoaDuyet.Columns[index].Name + ")";
                                                    }
                                                    flag3 = true;
                                                    break;
                                                }
                                            }
                                            if (flag3 == false)
                                            {
                                                dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[j, temp].Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int tmp1 = 0;
                for (int i = 1; i < dgvMinhHoaDuyet.ColumnCount; ++i)
                {
                    List<char> listDinhDD = new List<char>();
                    if (dgvMinhHoaDuyet.Columns[i].Name != cbDinhxuatphat.Text)
                    {
                        for (int j = 1; j < dgvMinhHoaDuyet.RowCount - 1; ++j)
                        {
                            if (dgvMinhHoaDuyet[i, j].Value.ToString().Length > 6)
                            {
                                if(dgvMinhHoaDuyet[i, j].Value.ToString().Length == 7 && dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Last() == '*')
                                {
                                    if (dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[4].ToString() == cbDinhxuatphat.Text)
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[1].ToString();
                                        dgvDuongDi[i, 1].Value = cbDinhxuatphat.Text + "->" + dgvMinhHoaDuyet.Columns[i].Name + ".";
                                        goto Label2;
                                    }
                                    else
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[1].ToString();
                                        listDinhDD.Add(dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[4]);
                                        int temp = i, temp2 = j;
                                        Label:
                                        for (int a = 1; a < dgvMinhHoaDuyet.ColumnCount; ++a)
                                        {
                                            if(dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 6)
                                            {
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length == 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[4].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if(dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if(dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString()!= cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                if(dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Count() - 3].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                if (dgvMinhHoaDuyet[i, j].Value.ToString().Length > 7 && dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Last() == '*')
                                {
                                    if (dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 3].ToString() == cbDinhxuatphat.Text)
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().Substring(1, dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 6);
                                        dgvDuongDi[i, 1].Value = cbDinhxuatphat.Text + "->" + dgvMinhHoaDuyet.Columns[i].Name + ".";
                                        goto Label2;
                                    }
                                    else
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().Substring(1, dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 6);
                                        listDinhDD.Add(dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 3]);
                                        int temp = i, temp2 = j;
                                        Label:
                                        for (int a = 1; a < dgvMinhHoaDuyet.ColumnCount; ++a)
                                        {
                                            if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 6)
                                            {
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length == 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[4].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Count() - 3].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Label1:
                        string temp1 = cbDinhxuatphat.Text + "->";
                        for (int k = listDinhDD.Count - 1; k >= 0; --k)
                        {
                            temp1 += listDinhDD[k].ToString() + "->";
                        }
                        temp1 = temp1 + dgvMinhHoaDuyet.Columns[i].Name + ".";
                        dgvDuongDi[i, 1].Value = temp1;
                    }
                    else
                    {
                        tmp1 = i;
                    }
                    Label2:
                    { }
                }
                dgvDuongDi.Columns.RemoveAt(tmp1);//xoá cột chứa đỉnh xuất phát.
            }
            else if (rdbCoHuong.Checked == true)//đồ thị có hướng
            {
                int tro = 0;
                listTro.Add(tro);
                for (int i = 0; i < listDinh.Count; ++i)
                {
                    int count = 0;
                    for (int j = 0; j < dgvThongTinDT.RowCount - 1; ++j)
                    {
                        bool flag = false;
                        if (listDinh[i] == dgvThongTinDT[1, j].Value.ToString().ToCharArray()[0])
                        {
                            flag = true;
                        }
                        if (flag == true)
                        {
                            listKe.Add(dgvThongTinDT[2, j].Value.ToString().ToCharArray()[0]);
                            listTrongSo.Add((int.Parse(dgvThongTinDT[3, j].Value.ToString())));
                            count++;
                        }
                    }

                    tro += count;
                    listTro.Add(tro);

                    //hoặc
                    //if (i < listDinh.Count - 1)
                    //{
                    //    tro += count;
                    //    listTro.Add(tro);
                    //}

                }
                for (int i = 0; i < listDinh.Count; ++i)
                {
                    int temp = 0;
                    dgvMinhHoaDuyet.Rows.Add();
                    for (int j = 0; j < dgvMinhHoaDuyet.ColumnCount; ++j)
                    {
                        Boolean flag3 = false;
                        if (i == 0 && j == 0)
                        {
                            dgvMinhHoaDuyet[j, i].Value = "Khởi tạo";
                        }
                        else if (i == 0 && j != 0)
                        {
                            if (dgvMinhHoaDuyet.Columns[j].HeaderText == "Đỉnh " + cbDinhxuatphat.Text)
                            {
                                flag3 = true;
                            }
                            if (flag3 == true) //là đỉnh xuất phát.
                            {
                                dgvMinhHoaDuyet[j, i].Value = "(0, " + cbDinhxuatphat.Text + ")*";
                            }
                            else // không phải đỉnh xuất phát.
                            {
                                bool flag = false, flag1 = false;
                                int temp1 = 0;
                                for (int k = 0; k < listDinh.Count; ++k)
                                {
                                    if (cbDinhxuatphat.Text == listDinh[k].ToString())
                                    {
                                        flag = true;
                                    }
                                    if (flag == true)
                                    {
                                        temp1 = k;//xác định vị trí của đỉnh xuất phát trong danh sách đỉnh
                                        break;
                                    }
                                }
                                for (int r = listTro[temp1]; r < listTro[temp1 + 1]; ++r)
                                {
                                    if (dgvMinhHoaDuyet.Columns[j].Name == listKe[r].ToString())
                                    {
                                        flag1 = true;//đỉnh đang xét kề với đỉnh xuất phát.
                                    }
                                    if (flag1 == true)
                                    {
                                        temp1 = r;
                                        break;
                                    }
                                }
                                if (flag1 == true)
                                {
                                    temp1 = listTrongSo[temp1];//lấy giá trị trọng số của cạnh (đầu là đỉnh xuất phát, cuối là đỉnh đang xét)
                                    dgvMinhHoaDuyet[j, i].Value = "(" + temp1 + ", " + cbDinhxuatphat.Text + ")";
                                }
                                else
                                {
                                    dgvMinhHoaDuyet[j, i].Value = "($, " + cbDinhxuatphat.Text + ")";
                                }

                            }
                        }
                        else//i!=0
                        {
                            dgvMinhHoaDuyet[0, i].Value = i;
                            if (j != 0)
                            {
                                temp = i - 1;
                                flag3 = false;
                                if (dgvMinhHoaDuyet[j, temp].Value.ToString().Length > 6)
                                {
                                    if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray().Last() == '*')
                                    {
                                        flag3 = true;
                                    }
                                }
                                else
                                {
                                    if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[0] == '-')
                                    {
                                        flag3 = true;
                                    }
                                }
                                if (flag3 == true)
                                {
                                    dgvMinhHoaDuyet[j, i].Value = '-';

                                }
                                else //xét những ô chưa đánh dấu '*' hoặc chưa đánh dấu '-'
                                {
                                    int min = 0, index1 = 0, tempm = 0, tempn = 0, tmp = 0, index = 0;
                                    List<int> listTStemp = new List<int>();
                                    List<int> listIndex = new List<int>();
                                    for (int k = 1; k < dgvMinhHoaDuyet.ColumnCount; ++k)
                                    {
                                        if (dgvMinhHoaDuyet[k, temp].Value.ToString().Length > 6)
                                        {
                                            if (dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray().Last() != '*')
                                            {
                                                char[] ctemp = new char[dgvMinhHoaDuyet[k, temp].Value.ToString().Length];
                                                char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                int itmp = 0;
                                                for (int l = 0; l < dgvMinhHoaDuyet[k, temp].Value.ToString().Length; ++l)
                                                {
                                                    if(dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l] == ',')
                                                    {
                                                        break;
                                                    }
                                                    for (int t = 0; t < numbers.Length; ++t)
                                                    {
                                                        if (dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                        {
                                                            ctemp[itmp] = dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[l];
                                                            itmp++;
                                                            break;
                                                        }
                                                    }
                                                }
                                                string m = "";
                                                for (int l = 0; l < ctemp.Length; ++l)
                                                {
                                                    m += ctemp[l].ToString();
                                                }
                                                listTStemp.Add(int.Parse(m));
                                                listIndex.Add(k);
                                            }
                                        }
                                        else
                                        {
                                            if (dgvMinhHoaDuyet[k, temp].Value.ToString().Length == 6)
                                            {
                                                if (dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[1] != '$')
                                                {
                                                    listTStemp.Add(int.Parse(dgvMinhHoaDuyet[k, temp].Value.ToString().ToCharArray()[1].ToString()));
                                                    listIndex.Add(k);
                                                }
                                            }
                                        }
                                    }
                                    if (listTStemp.Count >= 1)
                                    {
                                        if (listTStemp.Count == 1)
                                        {
                                            min = listTStemp[0];
                                            index = 0;
                                        }
                                        else
                                        {
                                            min = listTStemp[0];
                                            int l = 0;
                                            while (l < listTStemp.Count)
                                            {
                                                if (listTStemp[l] < min)
                                                {
                                                    min = listTStemp[l];
                                                    index = l;
                                                }
                                                l++;
                                            }
                                        }
                                        for (int k = 0; k < listIndex.Count; ++k)
                                        {
                                            if (k == index)
                                            {
                                                index = listIndex[k];//index chứa vị trí columns cùa ô(i-1) có trọng số nhỏ nhất
                                                break;
                                            }
                                        }
                                        if (j == index && dgvMinhHoaDuyet[index, i].Value == null)
                                        {
                                            dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[index, temp].Value + "*";
                                        }
                                        else
                                        {
                                            for (int k = 0; k < listDinh.Count; ++k)
                                            {
                                                if (dgvMinhHoaDuyet.Columns[index].Name.ToCharArray()[0] == listDinh[k])
                                                {
                                                    index1 = k;
                                                    break;
                                                }
                                            }
                                            flag3 = false;
                                            for (int k = listTro[index1]; k < listTro[index1 + 1]; ++k)
                                            {
                                                if (dgvMinhHoaDuyet.Columns[j].Name.ToCharArray()[0] == listKe[k])//đỉnh đang xét (thuộc ô hiện tại) kề với đỉnh '*'
                                                {
                                                    if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[1] != '$')//ô hiện tại không chứa vô cùng
                                                    {
                                                        char[] ctemp = new char[dgvMinhHoaDuyet[j, temp].Value.ToString().Length];
                                                        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                        int itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[j, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp[itmp] = dgvMinhHoaDuyet[j, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        string m = "";
                                                        for (int l = 0; l < ctemp.Length; ++l)
                                                        {
                                                            m += ctemp[l].ToString();
                                                        }
                                                        tempm = int.Parse(m);
                                                        char[] ctemp1 = new char[dgvMinhHoaDuyet[index, temp].Value.ToString().Length];
                                                        itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[index, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp1[itmp] = dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        m = "";
                                                        for (int l = 0; l < ctemp1.Length; ++l)
                                                        {
                                                            m += ctemp1[l].ToString();
                                                        }
                                                        tmp = int.Parse(m) + listTrongSo[k];
                                                        if (tmp < tempm)
                                                        {
                                                            dgvMinhHoaDuyet[j, i].Value = "(" + tmp + ", " + dgvMinhHoaDuyet.Columns[index].Name + ")";
                                                        }
                                                        else//giá trị trọng số của cạnh đang xét >= cạnh trước đó
                                                        {
                                                            dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[j, temp].Value;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        char[] ctemp = new char[dgvMinhHoaDuyet[index, temp].Value.ToString().Length];
                                                        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                                        int itmp = 0;
                                                        for (int l = 0; l < dgvMinhHoaDuyet[index, temp].Value.ToString().Length; ++l)
                                                        {
                                                            if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == ',')
                                                            {
                                                                break;
                                                            }
                                                            for (int t = 0; t < numbers.Length; ++t)
                                                            {
                                                                if (dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l] == numbers[t])
                                                                {
                                                                    ctemp[itmp] = dgvMinhHoaDuyet[index, temp].Value.ToString().ToCharArray()[l];
                                                                    itmp++;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        string m = "";
                                                        for (int l = 0; l < ctemp.Length; ++l)
                                                        {
                                                            m += ctemp[l].ToString();
                                                        }
                                                        tempn = int.Parse(m) + listTrongSo[k];
                                                        dgvMinhHoaDuyet[j, i].Value = "(" + tempn + ", " + dgvMinhHoaDuyet.Columns[index].Name + ")";
                                                    }
                                                    flag3 = true;
                                                    break;
                                                }
                                            }
                                            if (flag3 == false)
                                            {
                                                dgvMinhHoaDuyet[j, i].Value = dgvMinhHoaDuyet[j, temp].Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int tmp1 = 0;
                for (int i = 1; i < dgvMinhHoaDuyet.ColumnCount; ++i)
                {
                    List<char> listDinhDD = new List<char>();
                    if (dgvMinhHoaDuyet.Columns[i].Name != cbDinhxuatphat.Text)
                    {
                        for (int j = 1; j < dgvMinhHoaDuyet.RowCount - 1; ++j)
                        {
                            if (dgvMinhHoaDuyet[i, j].Value.ToString().Length > 6)
                            {
                                if (dgvMinhHoaDuyet[i, j].Value.ToString().Length == 7 && dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Last() == '*')
                                {
                                    if (dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[4].ToString() == cbDinhxuatphat.Text)
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[1].ToString();
                                        dgvDuongDi[i, 1].Value = cbDinhxuatphat.Text + "->" + dgvMinhHoaDuyet.Columns[i].Name + ".";
                                        goto Label2;
                                    }
                                    else
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[1].ToString();
                                        listDinhDD.Add(dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[4]);
                                        int temp = i, temp2 = j;
                                        Label:
                                        for (int a = 1; a < dgvMinhHoaDuyet.ColumnCount; ++a)
                                        {
                                            if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 6)
                                            {
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length == 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[4].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Count() - 3].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                if (dgvMinhHoaDuyet[i, j].Value.ToString().Length > 7 && dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Last() == '*')
                                {
                                    if (dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 3].ToString() == cbDinhxuatphat.Text)
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().Substring(1, dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 6);
                                        dgvDuongDi[i, 1].Value = cbDinhxuatphat.Text + "->" + dgvMinhHoaDuyet.Columns[i].Name + ".";
                                        goto Label2;
                                    }
                                    else
                                    {
                                        dgvDuongDi[i, 0].Value = dgvMinhHoaDuyet[i, j].Value.ToString().Substring(1, dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 6);
                                        listDinhDD.Add(dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[i, j].Value.ToString().ToCharArray().Count() - 3]);
                                        int temp = i, temp2 = j;
                                        Label:
                                        for (int a = 1; a < dgvMinhHoaDuyet.ColumnCount; ++a)
                                        {
                                            if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 6)
                                            {
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length == 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[4].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().Length > 7 && dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Last() == '*')
                                                {
                                                    if (dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[temp, temp2].Value.ToString().ToCharArray().Count() - 3].ToString() == dgvMinhHoaDuyet.Columns[a].Name)
                                                    {
                                                        for (int r = 1; r < dgvMinhHoaDuyet.RowCount - 1; ++r)
                                                        {
                                                            if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 6)
                                                            {
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length == 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[4]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                                if (dgvMinhHoaDuyet[a, r].Value.ToString().Length > 7 && dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Last() == '*')
                                                                {
                                                                    if (dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3].ToString() != cbDinhxuatphat.Text)
                                                                    {
                                                                        listDinhDD.Add(dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray()[dgvMinhHoaDuyet[a, r].Value.ToString().ToCharArray().Count() - 3]);
                                                                        temp = a;
                                                                        temp2 = r;
                                                                        goto Label;
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Label1:
                        string temp1 = cbDinhxuatphat.Text + "->";
                        for (int k = listDinhDD.Count - 1; k >= 0; --k)
                        {
                            temp1 += listDinhDD[k].ToString() + "->";
                        }
                        temp1 = temp1 + dgvMinhHoaDuyet.Columns[i].Name + ".";
                        dgvDuongDi[i, 1].Value = temp1;
                    }
                    else
                    {
                        tmp1 = i;
                    }
                    Label2:
                    { }
                }
                dgvDuongDi.Columns.RemoveAt(tmp1);//xoá cột chứa đỉnh xuất phát.
            }
        }

        //public static void DrawGraphs(DataGridView dgvThongTinDT, PictureBox piAnhDT, List<char> listDinh, PointF k, List<PointF> listpoint, List<char> listke, List<int> listTro)
        //{
        //    int tro = 0;
        //    listTro.Add(tro);
        //    for (int i = 0; i < listDinh.Count; ++i)
        //    {
        //        int count = 0;
        //        for (int j = 0; j < dgvThongTinDT.RowCount - 1; ++j)
        //        {
        //            bool flag = false, flag1 = false;
        //            if (listDinh[i] == dgvThongTinDT[1, j].Value.ToString().ToCharArray()[0])
        //            {
        //                flag = true;
        //            }
        //            if (listDinh[i] == dgvThongTinDT[2, j].Value.ToString().ToCharArray()[0])
        //            {
        //                flag1 = true;
        //            }
        //            if (flag == true)
        //            {
        //                listke.Add(dgvThongTinDT[2, j].Value.ToString().ToCharArray()[0]);
        //                //listTrongSo.Add((int.Parse(dgvThongTinDT[3, j].Value.ToString())));
        //                count++;
        //            }
        //            if (flag1 == true)
        //            {
        //                listke.Add(dgvThongTinDT[1, j].Value.ToString().ToCharArray()[0]);
        //                //listTrongSo.Add((int.Parse(dgvThongTinDT[3, j].Value.ToString())));
        //                count++;
        //            }
        //        }

        //        tro += count;
        //        listTro.Add(tro);
        //    }
        //    Graphics line = Graphics.FromImage(piAnhDT.Image);
        //    Pen pen = new Pen(Brushes.Aqua, 3.0F);
        //    for (int i = 0; i < listDinh.Count; ++i)
        //    {
        //        listpoint.Add(k);
        //    }
        //    float x = 100, y = 50;
        //    for (int i = 0; i < listpoint.Count; ++i)
        //    {
        //        listpoint[i] = new PointF(x + 50 * i, y + 50 * i);
        //    }
        //    for (int i = 0; i < listDinh.Count; ++i)
        //    {
        //        for (int j = listTro[i]; j < listTro[i + 1]; ++j)
        //        {
        //            for (int t = 0; t < listDinh.Count; ++t)
        //            {
        //                if (listke[j] == listDinh[t])
        //                {
        //                    line.DrawLine(pen, listpoint[i], listpoint[t]);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
