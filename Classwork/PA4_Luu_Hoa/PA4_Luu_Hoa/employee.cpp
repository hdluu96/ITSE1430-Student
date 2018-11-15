#include "employee.h"

Employee::Employee(std::string ID, std::string firstName, std::string lastName) : ID(ID), firstName(firstName), lastName(lastName)
{
}

std::string Employee::getID() const
{
	return ID;
}

std::string Employee::getFirstName() const
{
	return firstName;
}

std::string Employee::getLastName() const
{
	return lastName;
}

Employee & Employee::operator==(const Employee & ID)
{
	// TODO: insert return statement here
}
