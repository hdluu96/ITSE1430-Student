#ifndef _SALARYEMPLOYEE_H_
#define _SALARYEMPLOYEE_H_

#include <string>
#include "employee.h"

class SalaryEmployee : public Employee
{
private:
	double weeklySalary;
public:
	// Constructor
	SalaryEmployee(std::string ID, std::string firstName, std::string lastName, double weeklySalary);

	// Override
	void calculatePay() override;
};
#endif // !_SALARYEMPLOYEE_H_

