namespace oop42
{
    public partial class Form1 : Form
    {
        public Numbers numbers;
        public Form1()
        {
            InitializeComponent();
            numbers = new Numbers();
            numbers.update += new EventHandler(this.UpdateForm);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.A = numbers.getNumber('a');
            Properties.Settings.Default.C = numbers.getNumber('c');
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numbers.setNumber('a', Properties.Settings.Default.A);
            numbers.setNumber('b', Properties.Settings.Default.B);
            numbers.setNumber('c', Properties.Settings.Default.C);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                numbers.setNumber('a', Int32.Parse(textBox1.Text));
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                numbers.setNumber('b', Int32.Parse(textBox2.Text));
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                numbers.setNumber('c', Int32.Parse(textBox3.Text));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numbers.setNumber('a', Decimal.ToInt32(numericUpDown1.Value));
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numbers.setNumber('b', Decimal.ToInt32(numericUpDown2.Value));
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numbers.setNumber('c', Decimal.ToInt32(numericUpDown3.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numbers.setNumber('a', trackBar1.Value);
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numbers.setNumber('b', trackBar2.Value);
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numbers.setNumber('c', trackBar3.Value);
        }


        void UpdateForm(object sender, EventArgs e)
        {
            textBox1.Text = numbers.getNumber('a').ToString();
            textBox2.Text = numbers.getNumber('b').ToString();
            textBox3.Text = numbers.getNumber('c').ToString();
            numericUpDown1.Value = numbers.getNumber('a');
            numericUpDown2.Value = numbers.getNumber('b');
            numericUpDown3.Value = numbers.getNumber('c');
            trackBar1.Value = numbers.getNumber('a');
            trackBar2.Value = numbers.getNumber('b');
            trackBar3.Value = numbers.getNumber('c');
        }
    }

    public class Numbers
    {
        private int A, B, C;
        public EventHandler update;

        public Numbers()
        {
            A = Properties.Settings.Default.A;
            C = Properties.Settings.Default.C;
        }
        public void setNumber(char Name, int value)
        {
            if (Name == 'a')
            {
                if (value < 0)
                    value = 0;
                else if (value > B)
                {
                    if (value >= C)
                    {
                        B = C;
                        value = B;
                    }
                    else if (value < C)
                    {
                        B = value;
                    }
                }
                A = value;
            }
            else if (Name == 'b')
            {
                if(value > C)
                    value = C;
                if(value < A)
                    value = A;
                B = value;
            }
            else if (Name == 'c')
            {
                if (value > 100)
                    value = 100;
                else if (value < B)
                {
                    if(value <= A)
                    {
                        B = A;
                        value = B;
                    }
                    else if(value > A)
                    {
                        B = value;
                    }
                }
                C = value;
            }
            update.Invoke(this, null);
        }
        public int getNumber(char Name)
        {
            if (Name == 'a')
                return A;
            else if (Name == 'b')
                return B;
            else if (Name == 'c')
                return C;
            else
                return 0;
        }
    }
}