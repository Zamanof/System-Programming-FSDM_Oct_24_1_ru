using System.Threading;

namespace SP_02._UI_Thread;

public partial class Form1 : Form
{
    int time = 0;

    public Form1()
    {
        InitializeComponent();

    }

    private void StartButton_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i < 100; i++)
        //{
        //    CountLabel.Text = i.ToString();
        //    Thread.Sleep(100);
        //}

        new Thread(() =>
        {
            StartButton.Enabled = false;

            for (int i = 0; i < 100; i++)
            {
                CountLabel.Text = i.ToString();
                Thread.Sleep(100);
            }
            StartButton.Enabled = true;
        }).Start();



    }


}
