using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //IsValidFormat bool method: accepets str arg
        //  determines if properly formatted as a US
        //  telephone number. ie: (XXX)XXX-XXXX
        //  If properly formatted, bool is true
        //  else, false
        private bool IsValidFormat(string str)
        {
            //length char count const variable
            const int VALID_LENGTH = 13;

            //bool to flag validity
            bool valid;

            //is str properly formatted?
            if (str.Length == VALID_LENGTH && str[0] == '(' &&
                     str[4] == ')' && str[8] == '-')
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            //return val of bool 
            return valid;
        }

        //Unformat method: accepts str ref'd arg
        //  assumed to have validly formatted phone #.
        //  (see above example). Method removes the 
        //  formatting symbols. ie. (,), & -. 
        private void Unformat(ref string str)
        {
            //delete the paren at index 0
            str = str.Remove(0, 1);

            //delete the paren at index 3 
            //  not at index 4 anymore since we 
            //  deleted the first paren at index 0
            str = str.Remove(3, 1);

            //delete the - at index 6
            //  not at index 8 anymore since we 
            //  deleted the first paren at index 0
            //  and the second paren at index 3
            str = str.Remove(6, 1);
        }

        private void Clear()
        {
            MessageBox.Show("Clearing entered data?" +
                "\nOK will proceed with this action.");
            numberTextBox.Text = "";
        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            //trim and aquire user input
            string input = numberTextBox.Text.Trim();

            //if formatted propperly, unformat and display it.
            if (IsValidFormat(input))
            {
                Unformat(ref input);

                MessageBox.Show(input);
            }
            else
            {
                //show error message
                MessageBox.Show("Invalid input." +
                    "\nNot formatted properly, cannot proceed."+
                    "\nPlease Try Again.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Clear();
            this.Close();
        }
    }
}
