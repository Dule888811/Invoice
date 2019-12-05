<p>
        Need to create a web software solution that will
        make it easier for users to work on invoice processing.
        This process consists of the following:
        creating an invoice,
        adding Items,
        deleting items,
        modify an existing invoice,
        deleting an invoice,
        view existing invoices.

      In order to successfully complete the billing process, the following requirements must be met:

      1. The invoice overview consists of displaying all existing invoices with the following columns:
        a. Invoice date (displayed in format day.month, e.g. 01.01.2019)

        b. Invoice number

        c, Total (displayed with two decimal places, eg 123.00)

      2. The invoice document consists of the following fields:
        a. Document Date (required date field, initially set to current day,
        ie. the day the invoice is made).

        b. Document number (required text field, maximum 10 characters).

        c. Total (numeric field, representing the sum of all  totals from items)
      3. The document number is unique and cannot be repeated.

      4. The user can enter the invoice number.

      5. The invoice item consists of the following fields:
        a. Ordinal number (required numeric field).

        b.The ordinal number is unique at the document level (ie, ordinal numbers cannot be 
        repeated for a specific document).


        c. Quantity (required numeric field greater than zero).

        d. Price (required numeric field greater than zero).

        e. Total (required numeric field greater than zero).

        f. Total value is calculated as Price * Quantity.
      6. The user can see all the invoices in the system.

      7.User can start the process of creating a new invoice by displaying a page for
      insert of new invoice.

      8. The user can delete any invoice from the invoice list.

      9.The user can select any invoice and start the change process. In this scenario
      user is shown an invoice edit page (the same one he used to create).

      10.On the page for creating a new invoice, the user can create a new item.

      11.On the page for creating a new invoice, a user can modify an existing item.	

      12.On the page for creating a new invoice, the user can delete the item.

              Technical requirement
      For database you can use  MS Sql Server or MySql or Postgresql.
      Use one of the .NET technologies (.NET Framework or .net to implement the web solution)
      core). 
      
      <p>I used repository pattern and code first approach. </p>
</p>
