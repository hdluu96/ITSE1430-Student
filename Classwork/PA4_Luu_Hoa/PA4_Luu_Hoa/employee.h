#ifndef _EMPLOYEE_H_
#define _EMPLOYEE_H_

#include <string>

class Employee
{
private:
	std::string ID;
	std::string firstName;
	std::string lastName;
public:
	// Constructors
	Employee(std::string ID, std::string firstName, std::string lastName);

	// Getters
	std::string getID() const;
	std::string getFirstName() const;
	std::string getLastName() const;

	// Operator overload
	Employee& operator==(const Employee &ID);

	// Pure virtual function
	virtual void calculatePay() = 0;
};
#endif // !_EMPLOYEE_H_
