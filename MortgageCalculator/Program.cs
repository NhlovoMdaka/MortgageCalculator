using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



     class Program
    {
        static void Main(String[]args)
        {
            // Welcome message
            Console.WriteLine("Welcome to UXI Mortgage Loan By Nhlovo Mdaka");

            // Get user input
            Console.Write("Enter the loan amount: ");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.Write("Enter the annual interest rate (in percentage): ");
            double annualInterestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the loan term in years: ");
            int loanTermYears = int.Parse(Console.ReadLine());

            // Create MortgageCalculator object
            MortgageCalculator calculator = new MortgageCalculator();

            // Calculate and display results
            double monthlyRepayment = calculator.CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
            double totalInterestPaid = calculator.CalculateTotalInterestPaid(loanAmount, annualInterestRate, loanTermYears);
            double totalAmountPaid = calculator.CalculateTotalAmountPaid(loanAmount, annualInterestRate, loanTermYears);

            // Print mortgage calculation results
            Console.WriteLine("\nMortgage Calculation Results:");
            // Print monthly repayment amount
            Console.WriteLine("Monthly Repayment: R" + monthlyRepayment.ToString("F2"));
            // Print total interest paid
            Console.WriteLine("Total Interest Paid: R" + totalInterestPaid.ToString("F2"));
            // Print total amount paid
            Console.WriteLine("Total Amount Paid: R" + totalAmountPaid.ToString("F2"));


        // Generate and display amortization schedule
        Console.WriteLine("\nAmortization Schedule:");
            Console.WriteLine("Payment No.\tPayment Amount\tInterest Paid\tPrincipal Paid\tRemaining Balance");
            var amortizationSchedule = calculator.GenerateAmortizationSchedule(loanAmount, annualInterestRate, loanTermYears);
            foreach (var entry in amortizationSchedule)
            {
               
                Console.WriteLine(entry.PaymentNumber + "\t\t" + entry.PaymentAmount.ToString("F2") + "\t\t" + entry.InterestPaid.ToString("F2") + "\t\t" + entry.PrincipalPaid.ToString("F2") + "\t\t" + entry.RemainingBalance.ToString("F2"));

        }
    }
    }

