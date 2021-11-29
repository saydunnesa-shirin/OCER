# Online construction equipment rental (OCER)
It is an online construction equipment rental application. Customers can choose different pieces of equipment and see an invoice.

## Tools and technologies
Visual Studio 2019, .NET 5 MVC, AG-Grid.

## Project Structure
![Project Structure Image](images/project_structure.png)

## Data Store
I use a mock repository to store some static data.

## How to run
Open the solution using visual studio 19 and run.

## The workFlow
Renting any equipment or processing an invoice will involve the following steps:

1. The home page will appear with all available equipment. I use 'InStock' flag to show or hide equipment in the home page.

2. To rent each piece of equipment, users have to enter the number of days in the day column and click the rent button. By clicking the rent button application will redirect to the rent page.

3. All rented equipment will be shown on the rent page. Customers are able to delete a piece of equipment, by selecting the checkbox of each row and pressing the delete key from the keyboard. Clicking the update button will confirm the delete process. 

4. Deleted equipment will appear on the home page again. Customers are able to add a new item or re-select the same item again to rent.

5. On the rent page, Customers are able to see the calculated price of each piece of equipment based on the type of equipment and number of days.

6. The invoice page will appear with all the rented equipment and a total price and customer loyalty points based on the type of equipment.

## Class Diagram

![Class Diagram Image](images/class_diagram.png)