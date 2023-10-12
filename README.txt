There are 3 types of data:
    -Employer
    -JobListing
    -Applicant

The Employer data type has 2 fields:
    -Id which is an Integer
    -Name which is a String

The JobListing data type has 4 fields:
    -Id which is an Integer
    -Name which is a String
    -Description which is a String
    -EmployerId which is an Integer and links a JobListing to an Employer

The Applicant data type has 11 fields:
    -Id which is an Integer
    -FirstName which is a String
    -LastName which is a String
    -PhoneNumber which is a String
    -Email which is a String
    -AddressLine1 which is a String
    -AddressLine2 which is a String
    -Country which is a String
    -State which is a String
    -City which is a String
    -JobListingId which is an Integer and links an Applicant to a JobListing

Dependencies used:
    -Microsoft.EntityFrameworkCore;
    -System.ComponentModel.DataAnnotations;
    -Microsoft.AspNetCore.Mvc;