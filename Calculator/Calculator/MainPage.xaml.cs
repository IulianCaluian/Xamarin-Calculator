using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double curentNumber;
        double displayedNumber;
        double op1,op2;
        int tipOp;
        public MainPage()
        {
            InitializeComponent();
            curentNumber = displayedNumber = op1 = op2 = 0;
            tipOp = 0;
            updateUI();
            btn0.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 0; displayedNumber = curentNumber; updateUI(); };
            btn1.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 1; displayedNumber = curentNumber; updateUI(); };
            btn2.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 2; displayedNumber = curentNumber; updateUI(); };
            btn3.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 3; displayedNumber = curentNumber; updateUI(); };
            btn4.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 4; displayedNumber = curentNumber; updateUI(); };
            btn5.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 5; displayedNumber = curentNumber; updateUI(); };
            btn6.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 6; displayedNumber = curentNumber; updateUI(); };
            btn7.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 7; displayedNumber = curentNumber; updateUI(); };
            btn8.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 8; displayedNumber = curentNumber; updateUI(); };
            btn9.Clicked += (s, e) => { curentNumber = curentNumber * 10 + 9; displayedNumber = curentNumber; updateUI(); };
            btnClr.Clicked += (s, e) => { curentNumber = displayedNumber = op1 = op2 = 0; tipOp = 0; updateUI(); };
            
            btnPlu.Clicked += (s, e) => { if (tipOp > 0) calcRez(); else updateOp1();  tipOp = 1; };
            btnMin.Clicked += (s, e) => { if (tipOp > 0) calcRez(); else updateOp1();  tipOp = 2; };
            btnMul.Clicked += (s, e) => { if (tipOp > 0) calcRez(); else updateOp1();  tipOp = 3; };
            btnDiv.Clicked += (s, e) => { if (tipOp > 0) calcRez(); else updateOp1();  tipOp = 4; };
            btnEqu.Clicked += (s, e) => { calcRez(); };
        }

        private void updateUI()
        {   String text = "";
            textCalc.Text = displayedNumber.ToString("N0");
            if((displayedNumber % 1) == 0)
                text = String.Format("{0:n0}", displayedNumber);
            else 
                text = String.Format("{0:n}", displayedNumber);

            textCalc.Text = text;
        }

        private void calcRez()
        {
            if(tipOp > 0)
                op2 = curentNumber;

            switch (tipOp)
            {
                case 1: case -1: displayedNumber = op1 + op2; break;
                case 2: case -2: displayedNumber = op1 - op2; break;
                case 3: case -3: displayedNumber = op1 * op2; break;
                case 4: case -4: displayedNumber = op1 / op2; break;
            }

            if (tipOp > 0) tipOp = -tipOp; // Chained equal test. Negative meaning = chained 2 + 3 = 5, = 8, ...

            updateUI();
            updateOp1();
           
        }

        private void updateOp1()
        {
            op1 = displayedNumber;
            curentNumber = 0;
        }
    }
}
