/******************************
   Name
   Date
   File Name template.cpp
   Description
********************************/

// Headers
#include <iostream>
#include <cstdlib>
#include <string>
#include <vector>
#include <fstream>
#include <cstring>
#include <algorithm>
#include <iomanip>
using namespace std;

#include "Employee.h"
#include "HourlyEmployee.h"
#include "SalaryEmployee.h"

// Global variables
const int EMPID_LENGTH = 7;			// length of id is 6
const int FIRSTNAME_LENGTH = 12;	// length of first name is less than 21
const int LASTNAME_LENGTH = 12;		// length of last name is less than 21
const string EMPDATA_FILENAME = "employees.dat";
const string TIMEDATA_FILENAME = "emp_time.dat";
const string PAYROLL_REPORT_FILENAME = "payroll.txt";

struct EmployeeRecord
{
	char employeeType;					// H for hourly employee, S for salary employee
	char id[EMPID_LENGTH];				// Id of employee
	char firstName[FIRSTNAME_LENGTH];	// Employee's first name
	char lastName[LASTNAME_LENGTH];		// Employee's last name
	double salary;						// Employee's weekly or hourly salary depending on type of employee
};

struct EmployeeTime
{
	char id[EMPID_LENGTH];				// ID of employee
	double hours;						// Hours worked for week
};

// Function declarations
void loadEmployees(vector<Employee*>& employees, string fileName);
void loadEmployeeTime(vector<EmployeeTime>& empTime, string fileName);
void createPayrollReport(const vector<Employee*>& employees, const vector<EmployeeTime>& empTime, string fileName);
vector<Employee*>::const_iterator findEmployee(const vector<Employee*>& employees, string id);

int main()
{
	
	vector<Employee*> employees;		// vector of pointers to Employee
	vector<EmployeeTime> timeCards;		// vector of EmployeeTime structs

	loadEmployees(employees, EMPDATA_FILENAME);
	loadEmployeeTime(timeCards, TIMEDATA_FILENAME);
	createPayrollReport(employees, timeCards, PAYROLL_REPORT_FILENAME);
    
	//	Make sure we place the end message on a new line
    cout << endl;

	//	The following is system dependent.  It will only work on Windows
    system("PAUSE");

	/* 
	// A non-system dependent method is below
	cout << "Press any key to continue";
	cin.get();
	*/
    return 0;
}

/***************************************************************
Loads the employees from the file
employees is a vector of pointers to Employee class
fileName is the name of the file to read the data from
****************************************************************/
void loadEmployees(vector<Employee*>& employees, string fileName)
{
	// Open the file fileName for input and binary
	
	// Declare an EmployeeRecord
	// Loop through the file reading each file record into EmployeeRecord
	// If the employee is type H (for hourly) create an hourly employee and push on the vector
	// Else if the employee is type S (for salary) create a salary employee and push on the vector 
	
}

/***************************************************************
Loads the employee time data from the file
empTime is a vector of EmployeeTime struct
fileName is the name of the file to read the data from
****************************************************************/
void loadEmployeeTime(vector<EmployeeTime>& empTime, string fileName)
{
	// Open the file fileName for input and binary
	
	// Declare an EmployeeTime
	// Loop through the file reading each file record into EmployeeTime
	// Push the EmployeeTime record onto the vector
	
}

/***************************************************************
Creates a payroll report and writes it out to a file
employees is a vector of pointers to Employee class
empTime is a vector of EmployeeTime struct
fileName is the name of the file to write the data to
****************************************************************/
void createPayrollReport(const vector<Employee*>& employees, const vector<EmployeeTime>& empTime, string fileName)
{
	// Open the file fileName for output and text
	
	// Output a title for the report
	
	// Output a header for the report (make sure it is formatted nicely)
	
	
	// The following is pseudocode that you can use to write the primary logic for this function
	/*
	for each EmployeeTime et in empTime
		get an iterator from a call to findEmployee passing employees and et.id as a string
		from the iterator, call calculatePay(et.hours) and assign to pay
		using the iterator, concatenate the last name with the first name separated by a comma and assign to name
		using above variables write to the file: id, name, hours, and pay
	*/
	
	// close the file
	
}

/***************************************************************
findEmployee searchs for id in vector employees
if id is found it returns an iterator to the employee in the vector
if id is not found it returns an iterator pointing to end
****************************************************************/
vector<Employee*>::const_iterator findEmployee(const vector<Employee*>& employees, string id)
{
	vector<Employee*>::const_iterator it;
	for (it = employees.begin(); it != employees.end(); it++)
		if ((*it)->getID() == id) return it;
	return it;
}
