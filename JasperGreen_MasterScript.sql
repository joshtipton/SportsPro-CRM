-- Create the Schema/Database for Jasper Green
CREATE SCHEMA JasperGreen;

-- Specify the database for creating tables
USE JasperGreen;

-- Allow for arbitrary order creation of tables
SET 
    FOREIGN_KEY_CHECKS = 0;
	-- Allow for Updates, Deletes, Alters, Etc
SET 
    SQL_SAFE_UPDATES = 0;
-- Allow Invalid Date Formats for Date-related Queries
SET 
	SQL_MODE = 'ALLOW_INVALID_DATES';

-- Create the Contracted_Service Table
CREATE TABLE IF NOT EXISTS CONTRACTED_SERVICE (
    CONTRACT_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    PROPERTY_ID INT NOT NULL,
    SERVICE_ID INT NOT NULL,
    CONTRACT_DATE DATE NOT NULL,
    CONTRACT_AMOUNT VARCHAR(255) NOT NULL,
    FREQUENCY VARCHAR(255) NOT NULL,
    NEXT_SERVICE_DATE DATE NOT NULL,
    CONSTRAINT FK_CONTRACT_PROPERTY_ID FOREIGN KEY (PROPERTY_ID)
        REFERENCES Property (PROPERTY_ID),
    CONSTRAINT FK_CONTRACT_SERVICE_ID FOREIGN KEY (SERVICE_ID)
        REFERENCES Service (SERVICE_ID)
);

-- Create the Customer Table
CREATE TABLE IF NOT EXISTS CUSTOMER (
    CUST_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    CUST_FIRST_NAME VARCHAR(255) NOT NULL,
    CUST_LAST_NAME VARCHAR(255) NOT NULL,
    CUST_STREET VARCHAR(255) NOT NULL,
    CUST_CITY VARCHAR(255) NOT NULL,
    CUST_STATE VARCHAR(255) NOT NULL,
    CUST_ZIP VARCHAR(255) NOT NULL,
    CUST_PHONE VARCHAR(255) NOT NULL,
    CUST_EMAIL VARCHAR(255) NOT NULL,
    CUST_BALANCE VARCHAR(255) NOT NULL,
    CUST_REFERRED_BY VARCHAR(255) NOT NULL
);

-- Create the Employee Table
CREATE TABLE EMPLOYEE (
    EMP_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    EMP_FIRST_NAME VARCHAR(255) NOT NULL,
    EMP_LAST_NAME VARCHAR(255) NOT NULL,
    EMP_STREET VARCHAR(255) NOT NULL,
    EMP_CITY VARCHAR(255) NOT NULL,
    EMP_STATE VARCHAR(255) NOT NULL,
    EMP_ZIP VARCHAR(255) NOT NULL,
    EMP_PHONE VARCHAR(255) NOT NULL,
    CREW_CHIEF INT NOT NULL,
    CONSTRAINT FK_EMPLOYEE_CREW_CHIEF FOREIGN KEY (CREW_CHIEF)
        REFERENCES Employee (EMP_ID)
);

-- Create the Payment Table
CREATE TABLE IF NOT EXISTS PAYMENT (
    PAYMENT_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    CUST_ID INT NOT NULL,
    CREW_CHIEF INT NOT NULL,
    PAYMENT_DATE DATE NOT NULL,
    PAYMENT_AMOUNT VARCHAR(255) NOT NULL,
    CONSTRAINT FK_PAYMENT_CUSTOMER FOREIGN KEY (CUST_ID)
        REFERENCES Customer (CUST_ID),
    CONSTRAINT FK_PAYMENT_CREW_CHIEF FOREIGN KEY (CREW_CHIEF)
        REFERENCES Employee (EMP_ID)
);

-- Create the Property Table
CREATE TABLE IF NOT EXISTS PROPERTY (
    PROPERTY_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    CUST_ID INT NOT NULL,
    PROPERTY_STREET VARCHAR(255) NOT NULL,
    PROPERTY_CITY VARCHAR(255) NOT NULL,
    PROPERTY_STATE VARCHAR(255) NOT NULL,
    PROPERTY_ZIP VARCHAR(255) NOT NULL,
    PROPERTY_SIZE VARCHAR(255) NOT NULL,
    PROPERTY_DETAILS VARCHAR(255) NOT NULL,
    CONSTRAINT FK_CUST_ID_PROPERTY FOREIGN KEY (CUST_ID)
        REFERENCES Customer (CUST_ID)
);



                -- Create the Provided_Service Table
CREATE TABLE IF NOT EXISTS PROVIDED_SERVICE (
    PROVISION_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    CONTRACT_ID INT NOT NULL,
    PROVISION_DATE DATE NOT NULL,
    CREW_CHIEF INT NOT NULL,
    CUST_ID INT NOT NULL,
    CONSTRAINT FK_CUST_ID_SERVICE FOREIGN KEY (CUST_ID)
        REFERENCES Customer (CUST_ID),
    CONSTRAINT FK_CREW_CHIEF_SERVICE FOREIGN KEY (CREW_CHIEF)
        REFERENCES Employee (EMP_ID),
    CONSTRAINT FK_CONTRACT_ID_SERVICE FOREIGN KEY (CONTRACT_ID)
        REFERENCES Contracted_Service (CONTRACT_ID)
);

-- Create the Service 
CREATE TABLE IF NOT EXISTS SERVICE (
    SERVICE_ID INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    SERVICE_DESCRIPTION VARCHAR(255) NOT NULL
);

-- Load the Contracted_Servics CSV into the Contracted_Service Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Contracted_Service.csv' INTO TABLE CONTRACTED_SERVICE FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Customer CSV into the Customer Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Customer.csv' INTO TABLE CUSTOMER FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Employee CSV into the Employee Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Employee.csv' INTO TABLE EMPLOYEE FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Payment CSV into the Payment Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Payment.csv' INTO TABLE PAYMENT FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Property CSV into the Property Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Property.csv' INTO TABLE PROPERTY FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Provided_Service CSV into the Provided_Service Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Provided_Service.csv' INTO TABLE PROVIDED_SERVICE FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

-- Load the Service CSV into the Service Table.
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Service.csv' INTO TABLE SERVICE FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"' LINES terminated by '\r\n';

