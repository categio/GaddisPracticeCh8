using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //NumberUpperCase method: accepts a string argument
        // returns the number of upper case letters it cotains
        private int NumberUpperCase(string str)
        {
            // num of uppercase letters
            int upperCase = 0;

            // count of uppercase chars in str
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    upperCase++;
                }
            }
            //return num of uppercase chars
            return upperCase;
        }

        //NumberLowerCase method: accepts string argument 
        // returns the number of lowercase letters it contains
        private int NumberLowerCase(string str)
        {
            // num of lowercase letters
            int lowerCase = 0;

            // count of lowercase chars in str
            foreach (char ch in str)
            {
                if (char.IsLower(ch))
                {
                    lowerCase++;
                }
            }
            //return num of lowercase chars
            return lowerCase;
        }

        //NumberDigits method accepts a string argument 
        // & returns the num of numeric digits contained.
        private int NumberDigits(string str)
        {
            // num of digits
            int digits = 0;

            // count digits in str
            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    digits++;
                }
            }
            //return num of digits in str 
            return digits;
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                //password length limitation val set to 8
                const int MIN_LENGTH = 8;

                //get password entered in textbox by user
                string password = passwordTextBox.Text;

                //validate password
                if (password.Length >= MIN_LENGTH &&
                    NumberUpperCase(password) >= 1 &&
                    NumberLowerCase(password) >= 1 &&
                    NumberDigits(password) >= 1)
                {
                    MessageBox.Show("The password is valid.");
                }
                else
                {
                    MessageBox.Show("The password does not meet requirements. " +
                        "\nThe requirements are: \nMUST CONTAIN AT LEAST " + 
                        "\n1 uppercase letter,\n1 lower case letter," +
                        "\n1 number, & \n8 characters.\n Please try again.");
                    //clear the text box.
                    passwordTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}
