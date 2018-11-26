#ifndef _HOURLYEMPLOYEE_H_
#define _HOURLYEMPLOYEE_H_

#include <string>
#include "employee.h"

class HourlyEmployee : public Employee
{
private:
	double hourlyWage;
public:
	// Constructor
	HourlyEmployee(std::string ID, std::string firstName, std::string lastName, double hourlyWage);

	// Override
	void calculatePay() override;
};
#endif // !_HOURLYEMPLOYEE_H_

