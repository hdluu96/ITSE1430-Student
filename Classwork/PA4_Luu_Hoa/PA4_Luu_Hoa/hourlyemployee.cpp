#include "hourlyemployee.h"

HourlyEmployee::HourlyEmployee(std::string ID, std::string firstName, std::string lastName, double hourlyWage)
	: Employee(ID, firstName, lastName), hourlyWage(hourlyWage)
{
}

void HourlyEmployee::calculatePay()
{ 
}
