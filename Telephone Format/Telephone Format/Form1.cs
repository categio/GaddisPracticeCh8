using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //IsValidNumber method: accepts a string
        //  returns true if it contains 10 digits or 
        //  false if otherwise
        private bool IsValidNumber(string str)
        {
            {
                //declare const for length of str val 10
                const int VALID_LENGTH = 10;

                //set bool to true to flag validity
                bool valid = true;

                //check length of str
                if (str.Length == VALID_LENGTH)
                {
                    //check each char in str
                    foreach (char ch in str)
                    {
                        //if not a digit/numerical then 
                        //string not valid
                        if (!char.IsDigit(ch))
                        {
                            //return status of bool
                            valid = false;
                        }
                    }
                }
                else //incorrect length
                {
                    valid = false;
                }
                //return status of bool
                return valid;
            }
        }

        //TelephonFormat method: accepts string arg
        //  by reference & formats it as a phone number
        private void TelephoneFormat(ref string str)
        {
            //first insert left paren at index 0
            str = str.Insert(0, "(");

            //next right paren at index 4
            str = str.Insert(4, ")");

            //last bit add a hyphen at index 8
            str = str.Insert(8, "-");
        }

        //button click event handler
        private void formatButton_Click(object sender, EventArgs e)
        {
            try
            {
                //get trimmed user input
                string input = numberTextBox.Text.Trim();

                //if input is numerical, format it to phone number
                //  and display it
                if (IsValidNumber(input))
                {
                    TelephoneFormat(ref input);
                    MessageBox.Show(input);
                }
                else
                {
                    //show error message
                    MessageBox.Show("Invalid input. \nMust be numerical" +
                        " \nand 10 characters long.");
                    //clear entered data after clicking OK on messagebox
                    numberTextBox.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clear data entered
            numberTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}
