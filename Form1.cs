using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad3_04._06._23
{
    public partial class frmSector : Form
    {
        int m;
        double Sum;
        public frmSector()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            if (txtColvoEl.Text == "")
            { MessageBox.Show("Количество категорий расходов не введено!", "Ошибка"); }
            else
            {
                m = Int32.Parse(txtColvoEl.Text);
                if (m > 10)
                { MessageBox.Show("Количество категорий расходов превышает число 10!", "Ошибка"); }
                else
                {
                    dgvMass.ColumnCount = m;

                    for (int j = 0; j < m; j++)
                    {
                        dgvMass.Columns[j].Width = 110;
                        dgvMass.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvMass.Columns[j].HeaderText = "Расход категории " + (j + 1).ToString();
                    }
                }
            }

        }

        private void btCreateDiag_Click(object sender, EventArgs e)
        {
            Sum = 0;
            double[] A = new double[m];
            string[] B = new string[m];

            for (int j = 0; j < m; j++)
            {
                A[j] = Convert.ToDouble(dgvMass.Rows[0].Cells[j].Value);
                B[j] = "Расходы категории " + (j + 1).ToString();
                Sum += A[j];
                if (A[j] <= 0)
                { MessageBox.Show("Среди введённых элементов есть отрицательные или нулевые!", "Ошибка"); }
            }

            if (Sum != 100)
            { MessageBox.Show("Сумма процентного содержания расходов должна равняться 100%! Перепроверьте данные!", "Ошибка"); }
            else
            {
                chartSector.Series[0].Points.DataBindXY(B, A);
                chartSector.ChartAreas[0].Area3DStyle.Enable3D = true;
            }

        }
    }
}
