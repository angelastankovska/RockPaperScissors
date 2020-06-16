using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;
        
        string[] choiceList = { "rock", "paper", "scissors" };
        int randomNumber = 0;
        Random random = new Random();

        string CPUChoice;
        string playerChoice;

        int playerScore;
        int CPUScore;


        public Form1()
        {
            InitializeComponent();
            countDown.Enabled = true;
            playerChoice = "none";
            txtTime.Text = "5";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissors";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            txtScore.Text = playerScore + " - " + CPUScore;
            playerChoice = "none";
            countDown.Enabled = true;
            picPlayer.Image = Properties.Resources._default;
            picCPU.Image = Properties.Resources._default;
            gameOver = false;

        }

        private void countDown_Tick(object sender, EventArgs e)
        {
            timerPerRound = timerPerRound - 1;
            txtTime.Text = timerPerRound.ToString();
            txtRound.Text = "Rounds left: " + rounds;
            if (timerPerRound < 1)
            {
                countDown.Enabled = false;
                timerPerRound = 6;
                randomNumber = random.Next(0, choiceList.Length);
                CPUChoice = choiceList[randomNumber];

                switch (CPUChoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        picCPU.Image = Properties.Resources.paper;
                        break;

                    case "scissors":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }
                if (rounds > 0)
                {
                    checkWinner();
                }
                else
                {
                    if (playerScore > CPUScore)
                    {
                        MessageBox.Show("You won the game!!!");
                    }
                    else
                    {
                        MessageBox.Show("CPU won the game! Try again!");
                    }
                    gameOver = true;
                   
                }
            }
           
        }
        private void checkWinner()
        {
            if (playerChoice == "paper" && CPUChoice == "rock")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You won this round");
            }
           else if (playerChoice == "paper" && CPUChoice == "scissors")
            {
                CPUScore += 1;
                rounds -= 1;
               MessageBox.Show("CPU won this round");
            }
            else if (playerChoice == "rock" && CPUChoice == "paper")
            {
                CPUScore += 1;
                rounds -= 1;
                MessageBox.Show("CPU won this round");
            }
            else if (playerChoice == "rock" && CPUChoice == "scissors")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You won this round");
            }
            
            else if (playerChoice == "scissors" && CPUChoice == "paper")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("You won this round");
            }
            else if (playerChoice == "scissors" && CPUChoice == "rock")
            {
                CPUScore += 1;
                rounds -= 1;
                MessageBox.Show("CPU won this round");
            }
            else if (playerChoice == "none")
            {
                
                MessageBox.Show("Please make a choice!");
            }
            else 
            {
                MessageBox.Show("It's a draw!");
            }
            startNextRound();
        }
        private void startNextRound()
        {
            if (gameOver == true)
            {
                return;
            }
            txtScore.Text =  playerScore + " - " +  CPUScore;
            playerChoice = "none";
            countDown.Enabled = true;
            picPlayer.Image=Properties.Resources._default;
            picCPU.Image = Properties.Resources._default;

        }
    }
}
