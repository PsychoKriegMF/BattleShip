using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace BattleShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            //model.PlayerShips[0, 0] = CoordStatus.Ship;
            //model.PlayerShips[5, 2] = CoordStatus.Ship;
            //model.PlayerShips[5, 3] = CoordStatus.Ship;
            //model.PlayerShips[5, 4] = CoordStatus.Ship;
            //model.PlayerShips[5, 5] = CoordStatus.Ship;
            //model.PlayerShips[7, 1] = CoordStatus.Ship;
            //model.PlayerShips[8, 1] = CoordStatus.Ship;
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.ClearSelection();
        }
        Model model;

        string[] row = { "", "", "", "", "", "", "", "", "", "" };
        int x4 = 1;
        int x3 = 2;
        int x2 = 3;
        int x1 = 4;


        private void button1_Click(object sender, EventArgs e)
        {
            model.LastShot = model.Shot(textBox1.Text);
            int x = int.Parse(textBox1.Text.Substring(0, 1));
            int y = int.Parse(textBox1.Text.Substring(1));
            switch (model.LastShot)
            {
                case ShotStatus.Miss:
                    model.EnemyShips[x, y] = CoordStatus.Shot; break;
                case ShotStatus.Wounded:
                    model.EnemyShips[x, y] = CoordStatus.Got; break;
                case ShotStatus.Kill:
                    model.EnemyShips[x, y] = CoordStatus.Got; break;
            }
            //Model.LastShotCoord = textBox1.Text;
            if (model.LastShot == ShotStatus.Wounded)
            {
                model.LastShotCoord = textBox1.Text;
                model.WoundedStatus = true;

            }
            MessageBox.Show(model.LastShot.ToString());
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // �������� ������������ �����
        //        if (textBox1.Text.Length != 2 ||
        //            !int.TryParse(textBox1.Text.Substring(0, 1), out int x) ||
        //            !int.TryParse(textBox1.Text.Substring(1), out int y) ||
        //            x < 0 || x >= 10 || y < 0 || y >= 10)
        //        {
        //            MessageBox.Show("Invalid input. Please enter coordinates in the format 'xy', where x and y are between 0 and 9.");
        //            return;
        //        }

        //        model.LastShot = model.Shot(textBox1.Text);

        //        switch (model.LastShot)
        //        {
        //            case ShotStatus.Miss:
        //                model.EnemyShips[x, y] = CoordStatus.Shot;
        //                break;
        //            case ShotStatus.Wounded:
        //                model.EnemyShips[x, y] = CoordStatus.Got;
        //                model.LastShotCoord = textBox1.Text;
        //                model.WoundedStatus = true;
        //                break;
        //            case ShotStatus.Kill:
        //                model.EnemyShips[x, y] = CoordStatus.Got;
        //                break;
        //        }

        //        MessageBox.Show(model.LastShot.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        // ����������� ��� ����� ��������� �� ������
        //        MessageBox.Show("Error in button1_Click: " + ex.Message);
        //    }
        //}


        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            int x, y;
            do
            {
                s = model.ShotGen();
                x = int.Parse(s.Substring(0, 1));
                y = int.Parse(s.Substring(1));
            }
            while (model.EnemyShips[x, y] != CoordStatus.None);
            textBox1.Text = s;
        }

        private void button204_Click(object sender, EventArgs e) // ������������
        {            
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    switch (model.PlayerShips[x, y])
                    {
                        case CoordStatus.Ship:
                            dataGridView1[x, y].Value = "X"; break;
                        case CoordStatus.None:
                            dataGridView1[x, y].Value = ""; break;
                    }
                }
            }
        }

        private void button203_Click(object sender, EventArgs e)  // ���������
        {
            int cnt = dataGridView1.SelectedCells.Count;
            if (cnt > 0)
            {
                if (checkBox2.Checked)
                {
                    int a, b;
                    a = dataGridView1.SelectedCells[0].RowIndex;
                    b = dataGridView1.SelectedCells[0].ColumnIndex;
                    if (dataGridView1.Rows[a].Cells[b].Value.ToString() == "") return;
                }
                if (cnt == 1)
                    if (!checkBox2.Checked)
                    {
                        if (x1 == 0) return;
                        x1--;
                    }
                    else x1++;
                if (cnt == 2)
                    if (!checkBox2.Checked)
                    {
                        if (x2 == 0) return;
                        x2--;
                    }
                    else x2++;
                if (cnt == 3)
                    if (!checkBox2.Checked)
                    {
                        if (x3 == 0) return;
                        x3--;
                    }
                    else x3++;
                if (cnt == 4)
                    if (!checkBox2.Checked)
                    {
                        if (x4 == 0) return;
                        x4--;
                    }
                    else x4++;

                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    int x = dataGridView1.SelectedCells[i].ColumnIndex;
                    int y = dataGridView1.SelectedCells[i].RowIndex;
                    CoordStatus coordStatus;
                    if (!checkBox2.Checked) coordStatus = CoordStatus.Ship;
                    else coordStatus = CoordStatus.None;
                    model.PlayerShips[x, y] = coordStatus;
                }
                dataGridView1.ClearSelection();


                //if (dataGridView1.SelectedCells.Count > 1)
                //{
                //    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                //    {
                //        int x = dataGridView1.SelectedCells[i].ColumnIndex;
                //        int y = dataGridView1.SelectedCells[i].RowIndex;
                //        CoordStatus coordStatus;
                //        if (!checkBox2.Checked) coordStatus = CoordStatus.Ship;                    
                //        else coordStatus = CoordStatus.None;
                //        model.PlayerShips[x, y] = coordStatus;
                //    }
                //        dataGridView1.ClearSelection();
                //}
                //else
                //{

                //}
                //Direction direction;
                //ShipType shipType = ShipType.x1;
                //if (checkBox1.Checked) direction = Direction.Vertical; else direction = Direction.Horizontal;
                //if (checkBox2.Checked)
                //{
                //    model.AddDellShip(textBox1.Text, shipType, direction, true);
                //    button204_Click(sender, e);
                //    return;
                //}
                //if (radioButton1.Checked) shipType = ShipType.x1;
                //if (radioButton2.Checked) shipType = ShipType.x2;
                //if (radioButton3.Checked) shipType = ShipType.x3;
                //if (radioButton4.Checked) shipType = ShipType.x4;

                //model.AddDellShip(textBox1.Text, shipType, direction, checkBox2.Checked);
            }
                button204_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = dataGridView1.SelectedCells[0].RowIndex;
            int x = dataGridView1.SelectedCells[0].ColumnIndex;
            textBox1.Text = x.ToString() + y.ToString();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { button203.Text = "�������"; }
            else { button203.Text = "���������"; }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int cnt = dataGridView1.SelectedCells.Count;
            textBox1.Text = cnt.ToString();
            if (cnt > 4)
            {
                MessageBox.Show("��������� ���������� ������!");
                int x = dataGridView1.SelectedCells[cnt - 1].ColumnIndex;
                int y = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows[y].Cells[x].Selected = false;
                dataGridView1.ClearSelection();
            }
            
            
        }
    }
}
