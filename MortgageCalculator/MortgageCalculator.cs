using System;
using System.Collections.Generic;

public class MortgageCalculator
{
    public double CalculateMonthlyRepayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = annualInterestRate / 12 / 100;
        int totalPayments = loanTermYears * 12;
        double monthlyRepayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalPayments)) /
                                   (Math.Pow(1 + monthlyInterestRate, totalPayments) - 1);
        return monthlyRepayment;
    }

    public double CalculateTotalInterestPaid(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
        int totalPayments = loanTermYears * 12;
        double totalAmountPaid = monthlyRepayment * totalPayments;
        double totalInterestPaid = totalAmountPaid - loanAmount;
        return totalInterestPaid;
    }

    public double CalculateTotalAmountPaid(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
        int totalPayments = loanTermYears * 12;
        return monthlyRepayment * totalPayments;
    }

    public List<AmortizationScheduleEntry> GenerateAmortizationSchedule(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        List<AmortizationScheduleEntry> schedule = new List<AmortizationScheduleEntry>();
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
        double monthlyInterestRate = annualInterestRate / 12 / 100;
        int totalPayments = loanTermYears * 12;
        double remainingBalance = loanAmount;

        for (int i = 1; i <= totalPayments; i++)
        {
            double interestPaid = remainingBalance * monthlyInterestRate;
            double principalPaid = monthlyRepayment - interestPaid;
            remainingBalance -= principalPaid;
            schedule.Add(new AmortizationScheduleEntry(i, monthlyRepayment, interestPaid, principalPaid, remainingBalance));
        }

        return schedule;
    }
}

public class AmortizationScheduleEntry
{
    public int PaymentNumber { get; set; }
    public double PaymentAmount { get; set; }
    public double InterestPaid { get; set; }
    public double PrincipalPaid { get; set; }
    public double RemainingBalance { get; set; }

    public AmortizationScheduleEntry(int paymentNumber, double paymentAmount, double interestPaid, double principalPaid, double remainingBalance)
    {
        PaymentNumber = paymentNumber;
        PaymentAmount = paymentAmount;
        InterestPaid = interestPaid;
        PrincipalPaid = principalPaid;
        RemainingBalance = remainingBalance;
    }
}
