#include "salaryemployee.h"

SalaryEmployee::SalaryEmployee(std::string ID, std::string firstName, std::string lastName, double weeklySalary)
	: Employee(ID, firstName, lastName), weeklySalary(weeklySalary)
{
}

void SalaryEmployee::calculatePay()
{
}
