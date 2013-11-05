using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mainWindow : Form
    {
        private string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";

        public mainWindow()
        {
            InitializeComponent();
            string logLoc = getLoc.getLocation() + @"\" + @"\Logs\" + logStrings.date + ".txt";
        }

        //d6 Roll Button
        private void button2_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d6NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d6NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d6NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d6PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                        modifier = int.Parse(d6Mod.Text);
                        j = 1;
                        Random d6Roll = new Random();
                        int roll = randomRoll.Next(1, 7);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        try
                        {
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                                modifier = int.Parse(d6Mod.Text);
                                Random d6Roll = new Random();
                                int roll = randomRoll.Next(1, 7);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                try
                                {
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                        catch (Exception d6ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d6 Plus Mod Error - " + d6ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d6PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d6 Error - " + d6PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d6MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d6Mod.Text);
                        j = 1;
                        Random d6Roll = new Random();
                        int roll = randomRoll.Next(1, 7);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            try
                            {
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        //Otherwise run this code
                        else
                        {
                            string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            try
                            {
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d6Mod.Text);
                                Random d6Roll = new Random();
                                int roll = randomRoll.Next(1, 7);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    try
                                    {
                                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }
                                else
                                {
                                    string rollLog = getLoc.getLocation() + @"\" + @"\Logs\Rolls\" + logStrings.date + "rolls.txt";
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    try
                                    {
                                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                        catch (Exception d6minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d6 Minus Mod Loop Exception - " + d6minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d6ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d6 Modifier Exception - " + d6ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d6PlusMod.Checked == false && d6MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d6Roll = new Random();
                            int roll = randomRoll.Next(1, 7);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            try
                            {
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d6Roll = new Random();
                                int roll = randomRoll.Next(1, 7);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                try
                                {
                                    File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d6 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
                catch (Exception d6NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d6 No Mod Multi Dice Exception - " + d6NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //d4 Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d4NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d4NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d4NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d4PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d4Mod.Text);
                        j = 1;
                        Random d4Roll = new Random();
                        int roll = randomRoll.Next(1, 5);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d4Mod.Text);
                                Random d4Roll = new Random();
                                int roll = randomRoll.Next(1, 5);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d4ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d4 Plus Mod Error - " + d4ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d4PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d4 Error - " + d4PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d4MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d4Mod.Text);
                        j = 1;
                        Random d4Roll = new Random();
                        int roll = randomRoll.Next(1, 5);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d4Mod.Text);
                                Random d4Roll = new Random();
                                int roll = randomRoll.Next(1, 5);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d4minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d4 Minus Mod Loop Exception - " + d4minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d4ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d4 Modifier Exception - " + d4ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d4PlusMod.Checked == false && d4MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d4Roll = new Random();
                            int roll = randomRoll.Next(1, 5);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d4Roll = new Random();
                                int roll = randomRoll.Next(1, 5);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d4 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d4NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d4 No Mod Multi Dice Exception - " + d4NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //Clear Button
        private void button8_Click(object sender, EventArgs e)
        {
            resultArea.Clear();
        }

        //d8 Button
        private void button3_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d8NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d8NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d8NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d8PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d8Mod.Text);
                        j = 1;
                        Random d8Roll = new Random();
                        int roll = randomRoll.Next(1, 9);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d8Mod.Text);
                                Random d8Roll = new Random();
                                int roll = randomRoll.Next(1, 9);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d8ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d8 Plus Mod Error - " + d8ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d8PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d8 Error - " + d8PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d8MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d8Mod.Text);
                        j = 1;
                        Random d8Roll = new Random();
                        int roll = randomRoll.Next(1, 9);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d8Mod.Text);
                                Random d8Roll = new Random();
                                int roll = randomRoll.Next(1, 9);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d8minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d8 Minus Mod Loop Exception - " + d8minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d8ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d8 Modifier Exception - " + d8ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d8PlusMod.Checked == false && d8MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d8Roll = new Random();
                            int roll = randomRoll.Next(1, 9);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d8Roll = new Random();
                                int roll = randomRoll.Next(1, 9);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d8 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d8NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d8 No Mod Multi Dice Exception - " + d8NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //d10 Button
        private void button4_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d10NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d10NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d10NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d10PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d10Mod.Text);
                        j = 1;
                        Random d10Roll = new Random();
                        int roll = randomRoll.Next(1, 11);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d10Mod.Text);
                                Random d10Roll = new Random();
                                int roll = randomRoll.Next(1, 11);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d10ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d10 Plus Mod Error - " + d10ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d10PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d10 Error - " + d10PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d10MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d10Mod.Text);
                        j = 1;
                        Random d10Roll = new Random();
                        int roll = randomRoll.Next(1, 11);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d10Mod.Text);
                                Random d10Roll = new Random();
                                int roll = randomRoll.Next(1, 11);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d10minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d10 Minus Mod Loop Exception - " + d10minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d10ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d10 Modifier Exception - " + d10ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d10PlusMod.Checked == false && d10MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d10Roll = new Random();
                            int roll = randomRoll.Next(1, 11);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d10Roll = new Random();
                                int roll = randomRoll.Next(1, 11);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d10 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d10NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d10 No Mod Multi Dice Exception - " + d10NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //d12 Button
        private void button5_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d12NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d12NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d12NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d12PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d12Mod.Text);
                        j = 1;
                        Random d12Roll = new Random();
                        int roll = randomRoll.Next(1, 13);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d12Mod.Text);
                                Random d12Roll = new Random();
                                int roll = randomRoll.Next(1, 13);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d12ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d12 Plus Mod Error - " + d12ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d12PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d12 Error - " + d12PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d12MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d12Mod.Text);
                        j = 1;
                        Random d12Roll = new Random();
                        int roll = randomRoll.Next(1, 13);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d12Mod.Text);
                                Random d12Roll = new Random();
                                int roll = randomRoll.Next(1, 13);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d12minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d12 Minus Mod Loop Exception - " + d12minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d12ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d12 Modifier Exception - " + d12ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d12PlusMod.Checked == false && d12MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d12Roll = new Random();
                            int roll = randomRoll.Next(1, 13);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d12Roll = new Random();
                                int roll = randomRoll.Next(1, 13);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d12 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d12NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d12 No Mod Multi Dice Exception - " + d12NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //d20 Button
        private void button6_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d20NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d20NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d20NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d20PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d20Mod.Text);
                        j = 1;
                        Random d20Roll = new Random();
                        int roll = randomRoll.Next(1, 21);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d20Mod.Text);
                                Random d20Roll = new Random();
                                int roll = randomRoll.Next(1, 21);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d20ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d20 Plus Mod Error - " + d20ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d20PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d20 Error - " + d20PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d20MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d20Mod.Text);
                        j = 1;
                        Random d20Roll = new Random();
                        int roll = randomRoll.Next(1, 21);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d20Mod.Text);
                                Random d20Roll = new Random();
                                int roll = randomRoll.Next(1, 21);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d20minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d20 Minus Mod Loop Exception - " + d20minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d20ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d20 Modifier Exception - " + d20ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d20PlusMod.Checked == false && d20MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d20Roll = new Random();
                            int roll = randomRoll.Next(1, 21);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d20Roll = new Random();
                                int roll = randomRoll.Next(1, 21);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d20 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d20NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d20 No Mod Multi Dice Exception - " + d20NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //d100 Button
        private void button7_Click(object sender, EventArgs e)
        {
            //Check of Number of Dice field is empty.  If it is, set numberDice to 1
            //Set initial variables
            int i;
            int j;
            Random randomRoll = new Random();
            int numberDice;
            int modifier;
            if (d100NumberDice.Text == String.Empty)
            {
                numberDice = 1;
                d100NumberDice.Text = "1";
            }
            //If not, use number in textbox
            else
            {
                numberDice = int.Parse(d100NumberDice.Text);
            }
            //If Plus modifier is used, execute this code
            if (d100PlusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one dice
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d100Mod.Text);
                        j = 1;
                        Random d100Roll = new Random();
                        int roll = randomRoll.Next(1, 101);
                        int total1 = roll + modifier;
                        resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                        File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d100Mod.Text);
                                Random d100Roll = new Random();
                                int roll = randomRoll.Next(1, 101);
                                int total1 = roll + modifier;
                                resultArea.Text += roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                            }
                        }
                        catch (Exception d100ModPlusExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d100 Plus Mod Error - " + d100ModPlusExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d100PlusExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d100 Error - " + d100PlusExcept + Environment.NewLine);
                }
                //End Plus Modifier
            }
            //If Minus Modifier is used execute this code
            else if (d100MinusMod.Checked)
            {
                try
                {
                    //If number of dice is 1 or less, only roll one die
                    if (numberDice <= 1)
                    {
                        modifier = int.Parse(d100Mod.Text);
                        j = 1;
                        Random d100Roll = new Random();
                        int roll = randomRoll.Next(1, 101);
                        int total1 = roll - modifier;
                        //if the total is 0 or less after modifier is subtracted run below code
                        if (total1 <= 0)
                        {
                            int total2 = 0;
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                        //Otherwise run this code
                        else
                        {
                            resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                        }
                    }
                    else
                    {
                        j = numberDice;
                        try
                        {
                            for (i = 0; i < j; i++)
                            {
                                modifier = int.Parse(d100Mod.Text);
                                Random d100Roll = new Random();
                                int roll = randomRoll.Next(1, 101);
                                int total1 = roll - modifier;
                                if (total1 <= 0)
                                {
                                    int total2 = 0;
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total2.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    resultArea.Text += roll.ToString() + ("-") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled a: ") + total1.ToString() + Environment.NewLine;
                                    File.AppendAllText(rollLog, roll.ToString() + ("+") + modifier.ToString() + ("=") + total1.ToString() + ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + total1.ToString() + Environment.NewLine);
                                }
                            }
                        }
                        catch (Exception d100minusModLoopExcept)
                        {
                            File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d100 Minus Mod Loop Exception - " + d100minusModLoopExcept + Environment.NewLine);
                        }
                    }
                }
                catch (Exception d100ModExcept)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d100 Modifier Exception - " + d100ModExcept + Environment.NewLine);
                }
            }
            else
            {
                try
                {
                    if (d100PlusMod.Checked == false && d100MinusMod.Checked == false)
                    {
                        if (numberDice <= 1)
                        {
                            Random d100Roll = new Random();
                            int roll = randomRoll.Next(1, 101);
                            resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                            File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                        }
                        else
                        {
                            j = numberDice;
                            for (i = 0; i < j; i++)
                            {
                                Random d100Roll = new Random();
                                int roll = randomRoll.Next(1, 101);
                                resultArea.Text += ("You rolled a: ") + roll.ToString() + Environment.NewLine;
                                File.AppendAllText(rollLog, ("\n You rolled ") + numberDice + ("d100 dice for a roll of: ") + roll.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
                catch (Exception d100NoModMultiDice)
                {
                    File.AppendAllText(logStrings.logLoc, logStrings.time + ":" + "d100 No Mod Multi Dice Exception - " + d100NoModMultiDice + Environment.NewLine);
                }
            }
        }

        //Clear Modifiers Button
        private void button9_Click(object sender, EventArgs e)
        {
            //Clear d4 Modifiers
            d4PlusMod.Checked = false;
            d4MinusMod.Checked = false;
            d4Mod.Clear();
            //Clear d6 Modifiers
            d6PlusMod.Checked = false;
            d6MinusMod.Checked = false;
            d6Mod.Clear();
            //Clear d8 Modifiers
            d8PlusMod.Checked = false;
            d8MinusMod.Checked = false;
            d8Mod.Clear();
            //Clear d10 Modifiers
            d10PlusMod.Checked = false;
            d10MinusMod.Checked = false;
            d10Mod.Clear();
            //Clear d12 Modifiers
            d12PlusMod.Checked = false;
            d12MinusMod.Checked = false;
            d12Mod.Clear();
            //Clear d20 Modifiers
            d20PlusMod.Checked = false;
            d20MinusMod.Checked = false;
            d20Mod.Clear();
            //Clear d100 Modifiers
            d100PlusMod.Checked = false;
            d100MinusMod.Checked = false;
            d100Mod.Clear();
        }

        //Delete Roll Log Button
        private void button10_Click(object sender, EventArgs e)
        {
            File.Delete(rollLog);
            MessageBox.Show("Rolls Log Deleted");
        }
    }
}